const GRID = 512;
const BYTES_PER_PIXEL = 4;
const TEXTURE_BYTES = GRID * GRID * BYTES_PER_PIXEL;

const canvas = document.getElementById("field") as HTMLCanvasElement;
const backendLabel = document.getElementById("backendLabel") as HTMLElement;
const modelSelect = document.getElementById("modelSelect") as HTMLSelectElement;
const toggleRun = document.getElementById("toggleRun") as HTMLButtonElement;
const stepOnce = document.getElementById("stepOnce") as HTMLButtonElement;
const randomizeBtn = document.getElementById("randomize") as HTMLButtonElement;
const resetView = document.getElementById("resetView") as HTMLButtonElement;
const stepsPerFrame = document.getElementById("stepsPerFrame") as HTMLInputElement;
const stepsLabel = document.getElementById("stepsLabel") as HTMLElement;
const generationLabel = document.getElementById("generation") as HTMLElement;
const fpsLabel = document.getElementById("fps") as HTMLElement;
const surviveInput = document.getElementById("surviveInput") as HTMLInputElement;
const birthInput = document.getElementById("birthInput") as HTMLInputElement;
const lifeRules = document.getElementById("lifeRules") as HTMLElement;

interface GpuRunner {
  readonly label: string;
  upload(data: Uint8Array): void;
  frame(steps: number): void;
  setParams(mode: number, birthMask: number, surviveMask: number): void;
}

let runner: GpuRunner | null = null;
let running = true;
let generation = 0;
let frames = 0;
let fpsTime = performance.now();
let mode = 0;
let birthMask = parseRuleMask(birthInput.value);
let surviveMask = parseRuleMask(surviveInput.value);

function parseRuleMask(value: string): number {
  let mask = 0;
  for (const part of value.split(",")) {
    const trimmed = part.trim();
    if (trimmed.includes("-")) {
      const [a, b] = trimmed.split("-").map((n) => Number.parseInt(n.trim(), 10));
      if (Number.isFinite(a) && Number.isFinite(b)) {
        for (let i = Math.max(0, a); i <= Math.min(8, b); i++) {
          mask |= 1 << i;
        }
      }
    } else {
      const n = Number.parseInt(trimmed, 10);
      if (n >= 0 && n <= 8) {
        mask |= 1 << n;
      }
    }
  }
  return mask;
}

function makeInitialState(): Uint8Array {
  const data = new Uint8Array(TEXTURE_BYTES);
  for (let i = 0; i < TEXTURE_BYTES; i += 4) {
    const r = Math.random();
    if (mode === 1) {
      data[i] = r > 0.82 ? Math.floor(120 + Math.random() * 135) : 0;
      data[i + 1] = 0;
    } else if (mode === 2) {
      data[i] = r > 0.72 ? 255 : 0;
      data[i + 1] = Math.random() > 0.72 ? 255 : 0;
    } else {
      data[i] = r > 0.72 ? 255 : 0;
      data[i + 1] = 0;
    }
    data[i + 2] = 0;
    data[i + 3] = 255;
  }
  return data;
}

const webgpuComputeShader = `
struct Params {
  width: u32,
  height: u32,
  mode: u32,
  birthMask: u32,
  surviveMask: u32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}

@group(0) @binding(0) var stateIn: texture_2d<f32>;
@group(0) @binding(1) var stateOut: texture_storage_2d<rgba8unorm, write>;
@group(0) @binding(2) var<uniform> params: Params;

fn wrapCoord(v: i32, size: u32) -> i32 {
  return (v + i32(size)) % i32(size);
}

fn loadState(x: i32, y: i32) -> vec4f {
  return textureLoad(stateIn, vec2i(wrapCoord(x, params.width), wrapCoord(y, params.height)), 0);
}

fn alive(v: f32) -> u32 {
  if (v > 0.5) {
    return 1u;
  }
  return 0u;
}

@compute @workgroup_size(8, 8)
fn main(@builtin(global_invocation_id) id: vec3u) {
  if (id.x >= params.width || id.y >= params.height) {
    return;
  }

  let x = i32(id.x);
  let y = i32(id.y);
  let center = loadState(x, y);
  let n =
    alive(loadState(x - 1, y - 1).r) +
    alive(loadState(x, y - 1).r) +
    alive(loadState(x + 1, y - 1).r) +
    alive(loadState(x - 1, y).r) +
    alive(loadState(x + 1, y).r) +
    alive(loadState(x - 1, y + 1).r) +
    alive(loadState(x, y + 1).r) +
    alive(loadState(x + 1, y + 1).r);

  if (params.mode == 1u) {
    let value = (center.r * 4.0 + loadState(x, y - 1).r + loadState(x, y + 1).r + loadState(x - 1, y).r + loadState(x + 1, y).r) / 8.0;
    textureStore(stateOut, vec2i(x, y), vec4f(value, 0.0, 0.0, 1.0));
    return;
  }

  if (params.mode == 2u) {
    let parity =
      alive(loadState(x, y - 1).r) ^
      alive(loadState(x, y + 1).r) ^
      alive(loadState(x - 1, y).r) ^
      alive(loadState(x + 1, y).r);
    let nextValue = alive(center.g) ^ parity;
    textureStore(stateOut, vec2i(x, y), vec4f(f32(nextValue), center.r, 0.0, 1.0));
    return;
  }

  let bit = 1u << n;
  let isAlive = alive(center.r) == 1u;
  let nextValue = select((params.birthMask & bit) != 0u, (params.surviveMask & bit) != 0u, isAlive);
  textureStore(stateOut, vec2i(x, y), vec4f(select(0.0, 1.0, nextValue), 0.0, 0.0, 1.0));
}
`;

const webgpuRenderShader = `
struct Params {
  width: u32,
  height: u32,
  mode: u32,
  birthMask: u32,
  surviveMask: u32,
  pad0: u32,
  pad1: u32,
  pad2: u32,
}

@group(0) @binding(0) var stateTex: texture_2d<f32>;
@group(0) @binding(1) var<uniform> params: Params;

struct VertexOut {
  @builtin(position) pos: vec4f,
}

@vertex
fn vs(@builtin(vertex_index) index: u32) -> VertexOut {
  var positions = array<vec2f, 3>(
    vec2f(-1.0, -1.0),
    vec2f(3.0, -1.0),
    vec2f(-1.0, 3.0)
  );
  var out: VertexOut;
  out.pos = vec4f(positions[index], 0.0, 1.0);
  return out;
}

@fragment
fn fs(@builtin(position) pos: vec4f) -> @location(0) vec4f {
  let xy = vec2i(i32(pos.x), i32(pos.y));
  let s = textureLoad(stateTex, xy, 0);
  if (params.mode == 1u) {
    let low = vec3f(0.06, 0.16, 0.22);
    let high = vec3f(0.98, 0.76, 0.28);
    return vec4f(mix(low, high, s.r), 1.0);
  }
  if (params.mode == 2u) {
    if (s.r > 0.5 && s.g > 0.5) {
      return vec4f(0.36, 0.78, 1.0, 1.0);
    }
    if (s.r > 0.5) {
      return vec4f(0.37, 0.65, 0.96, 1.0);
    }
    if (s.g > 0.5) {
      return vec4f(0.28, 0.23, 0.36, 1.0);
    }
    return vec4f(0.02, 0.025, 0.024, 1.0);
  }
  if (s.r > 0.5) {
    return vec4f(0.36, 0.84, 0.56, 1.0);
  }
  return vec4f(0.02, 0.025, 0.024, 1.0);
}
`;

class WebGpuRunner implements GpuRunner {
  readonly label = "WebGPU ping-pong textures";
  private device: GPUDevice;
  private context: GPUCanvasContext;
  private format: GPUTextureFormat;
  private textures: GPUTexture[] = [];
  private computeBindGroups: GPUBindGroup[] = [];
  private renderBindGroups: GPUBindGroup[] = [];
  private computePipeline: GPUComputePipeline;
  private renderPipeline: GPURenderPipeline;
  private paramsBuffer: GPUBuffer;
  private currentIndex = 0;
  private params = new Uint32Array(8);

  private constructor(
    device: GPUDevice,
    context: GPUCanvasContext,
    format: GPUTextureFormat,
    computePipeline: GPUComputePipeline,
    renderPipeline: GPURenderPipeline,
    paramsBuffer: GPUBuffer
  ) {
    this.device = device;
    this.context = context;
    this.format = format;
    this.computePipeline = computePipeline;
    this.renderPipeline = renderPipeline;
    this.paramsBuffer = paramsBuffer;
    this.createTexturesAndBindings();
  }

  static async create(canvasEl: HTMLCanvasElement): Promise<WebGpuRunner> {
    if (!("gpu" in navigator)) {
      throw new Error("WebGPU is not available");
    }
    const adapter = await navigator.gpu.requestAdapter({ powerPreference: "high-performance" });
    if (!adapter) {
      throw new Error("No WebGPU adapter");
    }
    const device = await adapter.requestDevice();
    const context = canvasEl.getContext("webgpu") as GPUCanvasContext | null;
    if (!context) {
      throw new Error("No WebGPU canvas context");
    }
    const format = navigator.gpu.getPreferredCanvasFormat();
    context.configure({ device, format, alphaMode: "opaque" });

    const computePipeline = device.createComputePipeline({
      layout: "auto",
      compute: {
        module: device.createShaderModule({ code: webgpuComputeShader }),
        entryPoint: "main"
      }
    });

    const renderPipeline = device.createRenderPipeline({
      layout: "auto",
      vertex: {
        module: device.createShaderModule({ code: webgpuRenderShader }),
        entryPoint: "vs"
      },
      fragment: {
        module: device.createShaderModule({ code: webgpuRenderShader }),
        entryPoint: "fs",
        targets: [{ format }]
      },
      primitive: { topology: "triangle-list" }
    });

    const paramsBuffer = device.createBuffer({
      size: 32,
      usage: GPUBufferUsage.UNIFORM | GPUBufferUsage.COPY_DST
    });

    return new WebGpuRunner(device, context, format, computePipeline, renderPipeline, paramsBuffer);
  }

  setParams(nextMode: number, nextBirthMask: number, nextSurviveMask: number): void {
    this.params[0] = GRID;
    this.params[1] = GRID;
    this.params[2] = nextMode;
    this.params[3] = nextBirthMask;
    this.params[4] = nextSurviveMask;
    this.device.queue.writeBuffer(this.paramsBuffer, 0, this.params);
  }

  upload(data: Uint8Array): void {
    for (const texture of this.textures) {
      this.device.queue.writeTexture(
        { texture },
        data,
        { bytesPerRow: GRID * BYTES_PER_PIXEL, rowsPerImage: GRID },
        { width: GRID, height: GRID }
      );
    }
    this.currentIndex = 0;
  }

  frame(steps: number): void {
    const encoder = this.device.createCommandEncoder();
    for (let i = 0; i < steps; i++) {
      const pass = encoder.beginComputePass();
      pass.setPipeline(this.computePipeline);
      pass.setBindGroup(0, this.computeBindGroups[this.currentIndex]);
      pass.dispatchWorkgroups(GRID / 8, GRID / 8);
      pass.end();
      this.currentIndex = 1 - this.currentIndex;
    }

    const view = this.context.getCurrentTexture().createView();
    const renderPass = encoder.beginRenderPass({
      colorAttachments: [{
        view,
        loadOp: "clear",
        storeOp: "store",
        clearValue: { r: 0.02, g: 0.025, b: 0.024, a: 1 }
      }]
    });
    renderPass.setPipeline(this.renderPipeline);
    renderPass.setBindGroup(0, this.renderBindGroups[this.currentIndex]);
    renderPass.draw(3);
    renderPass.end();
    this.device.queue.submit([encoder.finish()]);
  }

  private createTexturesAndBindings(): void {
    this.textures = [0, 1].map(() => this.device.createTexture({
      size: { width: GRID, height: GRID },
      format: "rgba8unorm",
      usage: GPUTextureUsage.TEXTURE_BINDING | GPUTextureUsage.STORAGE_BINDING | GPUTextureUsage.COPY_DST
    }));

    this.computeBindGroups = [
      this.device.createBindGroup({
        layout: this.computePipeline.getBindGroupLayout(0),
        entries: [
          { binding: 0, resource: this.textures[0].createView() },
          { binding: 1, resource: this.textures[1].createView() },
          { binding: 2, resource: { buffer: this.paramsBuffer } }
        ]
      }),
      this.device.createBindGroup({
        layout: this.computePipeline.getBindGroupLayout(0),
        entries: [
          { binding: 0, resource: this.textures[1].createView() },
          { binding: 1, resource: this.textures[0].createView() },
          { binding: 2, resource: { buffer: this.paramsBuffer } }
        ]
      })
    ];

    this.renderBindGroups = [
      this.device.createBindGroup({
        layout: this.renderPipeline.getBindGroupLayout(0),
        entries: [
          { binding: 0, resource: this.textures[0].createView() },
          { binding: 1, resource: { buffer: this.paramsBuffer } }
        ]
      }),
      this.device.createBindGroup({
        layout: this.renderPipeline.getBindGroupLayout(0),
        entries: [
          { binding: 0, resource: this.textures[1].createView() },
          { binding: 1, resource: { buffer: this.paramsBuffer } }
        ]
      })
    ];
  }
}

const webglVertexShader = `#version 300 es
precision highp float;
const vec2 positions[3] = vec2[3](
  vec2(-1.0, -1.0),
  vec2(3.0, -1.0),
  vec2(-1.0, 3.0)
);
void main() {
  gl_Position = vec4(positions[gl_VertexID], 0.0, 1.0);
}
`;

const webglComputeShader = `#version 300 es
precision highp float;
precision highp int;
uniform sampler2D uState;
uniform int uMode;
uniform int uBirthMask;
uniform int uSurviveMask;
out vec4 outState;

ivec2 wrapCoord(ivec2 p) {
  return ivec2((p.x + ${GRID}) % ${GRID}, (p.y + ${GRID}) % ${GRID});
}

vec4 loadState(ivec2 p) {
  return texelFetch(uState, wrapCoord(p), 0);
}

int alive(float v) {
  return v > 0.5 ? 1 : 0;
}

void main() {
  ivec2 p = ivec2(gl_FragCoord.xy);
  vec4 center = loadState(p);
  int n =
    alive(loadState(p + ivec2(-1, -1)).r) +
    alive(loadState(p + ivec2(0, -1)).r) +
    alive(loadState(p + ivec2(1, -1)).r) +
    alive(loadState(p + ivec2(-1, 0)).r) +
    alive(loadState(p + ivec2(1, 0)).r) +
    alive(loadState(p + ivec2(-1, 1)).r) +
    alive(loadState(p + ivec2(0, 1)).r) +
    alive(loadState(p + ivec2(1, 1)).r);

  if (uMode == 1) {
    float value = (center.r * 4.0 + loadState(p + ivec2(0, -1)).r + loadState(p + ivec2(0, 1)).r + loadState(p + ivec2(-1, 0)).r + loadState(p + ivec2(1, 0)).r) / 8.0;
    outState = vec4(value, 0.0, 0.0, 1.0);
    return;
  }

  if (uMode == 2) {
    int parity =
      alive(loadState(p + ivec2(0, -1)).r) ^
      alive(loadState(p + ivec2(0, 1)).r) ^
      alive(loadState(p + ivec2(-1, 0)).r) ^
      alive(loadState(p + ivec2(1, 0)).r);
    int value = alive(center.g) ^ parity;
    outState = vec4(float(value), center.r, 0.0, 1.0);
    return;
  }

  int bit = 1 << n;
  bool live = alive(center.r) == 1;
  bool nextValue = live ? ((uSurviveMask & bit) != 0) : ((uBirthMask & bit) != 0);
  outState = vec4(nextValue ? 1.0 : 0.0, 0.0, 0.0, 1.0);
}
`;

const webglRenderShader = `#version 300 es
precision highp float;
uniform sampler2D uState;
uniform int uMode;
out vec4 outColor;

void main() {
  vec4 s = texelFetch(uState, ivec2(gl_FragCoord.xy), 0);
  if (uMode == 1) {
    vec3 low = vec3(0.06, 0.16, 0.22);
    vec3 high = vec3(0.98, 0.76, 0.28);
    outColor = vec4(mix(low, high, s.r), 1.0);
    return;
  }
  if (uMode == 2) {
    if (s.r > 0.5 && s.g > 0.5) {
      outColor = vec4(0.36, 0.78, 1.0, 1.0);
    } else if (s.r > 0.5) {
      outColor = vec4(0.37, 0.65, 0.96, 1.0);
    } else if (s.g > 0.5) {
      outColor = vec4(0.28, 0.23, 0.36, 1.0);
    } else {
      outColor = vec4(0.02, 0.025, 0.024, 1.0);
    }
    return;
  }
  outColor = s.r > 0.5 ? vec4(0.36, 0.84, 0.56, 1.0) : vec4(0.02, 0.025, 0.024, 1.0);
}
`;

class WebGlRunner implements GpuRunner {
  readonly label = "WebGL2 ping-pong textures";
  private gl: WebGL2RenderingContext;
  private textures: WebGLTexture[] = [];
  private framebuffer: WebGLFramebuffer;
  private computeProgram: WebGLProgram;
  private renderProgram: WebGLProgram;
  private currentIndex = 0;
  private params = { mode: 0, birthMask: 0, surviveMask: 0 };

  constructor(canvasEl: HTMLCanvasElement) {
    const gl = canvasEl.getContext("webgl2", { alpha: false, antialias: false });
    if (!gl) {
      throw new Error("WebGL2 is not available");
    }
    this.gl = gl;
    this.framebuffer = gl.createFramebuffer() as WebGLFramebuffer;
    this.computeProgram = this.createProgram(webglVertexShader, webglComputeShader);
    this.renderProgram = this.createProgram(webglVertexShader, webglRenderShader);
    this.textures = [this.createTexture(), this.createTexture()];
    gl.viewport(0, 0, GRID, GRID);
  }

  setParams(nextMode: number, nextBirthMask: number, nextSurviveMask: number): void {
    this.params.mode = nextMode;
    this.params.birthMask = nextBirthMask;
    this.params.surviveMask = nextSurviveMask;
  }

  upload(data: Uint8Array): void {
    const gl = this.gl;
    for (const texture of this.textures) {
      gl.bindTexture(gl.TEXTURE_2D, texture);
      gl.texSubImage2D(gl.TEXTURE_2D, 0, 0, 0, GRID, GRID, gl.RGBA, gl.UNSIGNED_BYTE, data);
    }
    this.currentIndex = 0;
  }

  frame(steps: number): void {
    const gl = this.gl;
    for (let i = 0; i < steps; i++) {
      const nextIndex = 1 - this.currentIndex;
      gl.bindFramebuffer(gl.FRAMEBUFFER, this.framebuffer);
      gl.framebufferTexture2D(gl.FRAMEBUFFER, gl.COLOR_ATTACHMENT0, gl.TEXTURE_2D, this.textures[nextIndex], 0);
      gl.viewport(0, 0, GRID, GRID);
      gl.useProgram(this.computeProgram);
      gl.activeTexture(gl.TEXTURE0);
      gl.bindTexture(gl.TEXTURE_2D, this.textures[this.currentIndex]);
      this.setCommonUniforms(this.computeProgram);
      gl.drawArrays(gl.TRIANGLES, 0, 3);
      this.currentIndex = nextIndex;
    }

    gl.bindFramebuffer(gl.FRAMEBUFFER, null);
    gl.viewport(0, 0, GRID, GRID);
    gl.useProgram(this.renderProgram);
    gl.activeTexture(gl.TEXTURE0);
    gl.bindTexture(gl.TEXTURE_2D, this.textures[this.currentIndex]);
    gl.uniform1i(gl.getUniformLocation(this.renderProgram, "uState"), 0);
    gl.uniform1i(gl.getUniformLocation(this.renderProgram, "uMode"), this.params.mode);
    gl.drawArrays(gl.TRIANGLES, 0, 3);
  }

  private setCommonUniforms(program: WebGLProgram): void {
    const gl = this.gl;
    gl.uniform1i(gl.getUniformLocation(program, "uState"), 0);
    gl.uniform1i(gl.getUniformLocation(program, "uMode"), this.params.mode);
    gl.uniform1i(gl.getUniformLocation(program, "uBirthMask"), this.params.birthMask);
    gl.uniform1i(gl.getUniformLocation(program, "uSurviveMask"), this.params.surviveMask);
  }

  private createTexture(): WebGLTexture {
    const gl = this.gl;
    const texture = gl.createTexture() as WebGLTexture;
    gl.bindTexture(gl.TEXTURE_2D, texture);
    gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MIN_FILTER, gl.NEAREST);
    gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_MAG_FILTER, gl.NEAREST);
    gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_WRAP_S, gl.CLAMP_TO_EDGE);
    gl.texParameteri(gl.TEXTURE_2D, gl.TEXTURE_WRAP_T, gl.CLAMP_TO_EDGE);
    gl.texImage2D(gl.TEXTURE_2D, 0, gl.RGBA, GRID, GRID, 0, gl.RGBA, gl.UNSIGNED_BYTE, null);
    return texture;
  }

  private createProgram(vertexSource: string, fragmentSource: string): WebGLProgram {
    const gl = this.gl;
    const vertex = this.createShader(gl.VERTEX_SHADER, vertexSource);
    const fragment = this.createShader(gl.FRAGMENT_SHADER, fragmentSource);
    const program = gl.createProgram() as WebGLProgram;
    gl.attachShader(program, vertex);
    gl.attachShader(program, fragment);
    gl.linkProgram(program);
    if (!gl.getProgramParameter(program, gl.LINK_STATUS)) {
      throw new Error(gl.getProgramInfoLog(program) || "WebGL program link failed");
    }
    return program;
  }

  private createShader(type: number, source: string): WebGLShader {
    const gl = this.gl;
    const shader = gl.createShader(type) as WebGLShader;
    gl.shaderSource(shader, source);
    gl.compileShader(shader);
    if (!gl.getShaderParameter(shader, gl.COMPILE_STATUS)) {
      throw new Error(gl.getShaderInfoLog(shader) || "WebGL shader compile failed");
    }
    return shader;
  }
}

async function createRunner(): Promise<GpuRunner> {
  try {
    return await WebGpuRunner.create(canvas);
  } catch (error) {
    console.warn(error);
    return new WebGlRunner(canvas);
  }
}

function updateParams(): void {
  mode = Number.parseInt(modelSelect.value, 10);
  birthMask = parseRuleMask(birthInput.value);
  surviveMask = parseRuleMask(surviveInput.value);
  lifeRules.style.display = mode === 0 ? "grid" : "none";
  runner?.setParams(mode, birthMask, surviveMask);
}

function resetState(): void {
  generation = 0;
  updateParams();
  runner?.upload(makeInitialState());
  runner?.frame(0);
  updateGeneration();
}

function updateGeneration(): void {
  generationLabel.textContent = generation.toString();
}

function animationLoop(now: number): void {
  if (runner && running) {
    const steps = Number.parseInt(stepsPerFrame.value, 10);
    runner.frame(steps);
    generation += steps;
    updateGeneration();
  }
  frames++;
  if (now - fpsTime >= 500) {
    fpsLabel.textContent = Math.round((frames * 1000) / (now - fpsTime)).toString();
    frames = 0;
    fpsTime = now;
  }
  requestAnimationFrame(animationLoop);
}

modelSelect.addEventListener("change", resetState);
randomizeBtn.addEventListener("click", resetState);
resetView.addEventListener("click", resetState);

toggleRun.addEventListener("click", () => {
  running = !running;
  toggleRun.textContent = running ? "Pause" : "Run";
});

stepOnce.addEventListener("click", () => {
  if (!runner) {
    return;
  }
  runner.frame(1);
  generation++;
  updateGeneration();
});

stepsPerFrame.addEventListener("input", () => {
  stepsLabel.textContent = stepsPerFrame.value;
});

surviveInput.addEventListener("input", updateParams);
birthInput.addEventListener("input", updateParams);

createRunner()
  .then((createdRunner) => {
    runner = createdRunner;
    backendLabel.textContent = createdRunner.label;
    updateParams();
    resetState();
    requestAnimationFrame(animationLoop);
  })
  .catch((error) => {
    backendLabel.textContent = error instanceof Error ? error.message : "GPU initialization failed";
  });
