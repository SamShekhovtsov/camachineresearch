type ModelId = "life" | "diffusion" | "reversible" | "predator";

interface ModelDescription {
  id: ModelId;
  summary: string;
}

const MODELS: Record<ModelId, ModelDescription> = {
  life: {
    id: "life",
    summary: "Custom Life rules with fused state update and pixel write."
  },
  diffusion: {
    id: "diffusion",
    summary: "Mass-like density spreads through local averaging on a torus."
  },
  reversible: {
    id: "reversible",
    summary: "Second-order parity rule keeps a previous state plane."
  },
  predator: {
    id: "predator",
    summary: "Predators, prey, and empty cells compete in local neighborhoods."
  }
};

const WIDTH = 256;
const HEIGHT = 256;
const SIZE = WIDTH * HEIGHT;

const canvas = document.getElementById("field") as HTMLCanvasElement;
const ctx = canvas.getContext("2d", { alpha: false }) as CanvasRenderingContext2D;
const image = ctx.createImageData(WIDTH, HEIGHT);
const pixels = image.data;

const modelSelect = document.getElementById("modelSelect") as HTMLSelectElement;
const modelSummary = document.getElementById("modelSummary") as HTMLElement;
const toggleRun = document.getElementById("toggleRun") as HTMLButtonElement;
const stepOnce = document.getElementById("stepOnce") as HTMLButtonElement;
const randomizeBtn = document.getElementById("randomize") as HTMLButtonElement;
const clearBtn = document.getElementById("clear") as HTMLButtonElement;
const stepsPerFrame = document.getElementById("stepsPerFrame") as HTMLInputElement;
const brushSize = document.getElementById("brushSize") as HTMLInputElement;
const stepsLabel = document.getElementById("stepsLabel") as HTMLElement;
const brushLabel = document.getElementById("brushLabel") as HTMLElement;
const generationLabel = document.getElementById("generation") as HTMLElement;
const fpsLabel = document.getElementById("fps") as HTMLElement;
const activeCountLabel = document.getElementById("activeCount") as HTMLElement;
const surviveInput = document.getElementById("surviveInput") as HTMLInputElement;
const birthInput = document.getElementById("birthInput") as HTMLInputElement;
const lifeRules = document.getElementById("lifeRules") as HTMLElement;

let current = new Uint8Array(SIZE);
let next = new Uint8Array(SIZE);
let previous = new Uint8Array(SIZE);
let energy = new Uint8Array(SIZE);

let model: ModelId = "life";
let running = true;
let generation = 0;
let activeCount = 0;
let lastTime = performance.now();
let frames = 0;
let fpsTime = lastTime;
let surviveMask = parseRuleMask(surviveInput.value);
let birthMask = parseRuleMask(birthInput.value);
let pointerDown = false;

const palette = {
  background: [8, 10, 9],
  life: [83, 209, 140],
  densityLow: [24, 57, 74],
  densityHigh: [240, 195, 90],
  reversible: [85, 167, 232],
  prey: [82, 210, 130],
  predator: [227, 107, 97],
  trail: [66, 56, 84]
};

function indexOf(x: number, y: number): number {
  return ((y + HEIGHT) & 255) * WIDTH + ((x + WIDTH) & 255);
}

function parseRuleMask(value: string): number {
  let mask = 0;
  const parts = value.split(",");
  for (const part of parts) {
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

function setPixel(offset: number, r: number, g: number, b: number): void {
  const p = offset << 2;
  pixels[p] = r;
  pixels[p + 1] = g;
  pixels[p + 2] = b;
  pixels[p + 3] = 255;
}

function putFrame(): void {
  ctx.putImageData(image, 0, 0);
}

function clearAll(): void {
  current.fill(0);
  next.fill(0);
  previous.fill(0);
  energy.fill(0);
  generation = 0;
  renderOnly();
}

function randomize(): void {
  for (let i = 0; i < SIZE; i++) {
    const r = Math.random();
    if (model === "diffusion") {
      current[i] = r > 0.72 ? Math.floor(120 + Math.random() * 135) : 0;
    } else if (model === "predator") {
      current[i] = r > 0.965 ? 2 : r > 0.74 ? 1 : 0;
      energy[i] = current[i] === 2 ? 14 : 0;
    } else {
      current[i] = r > 0.72 ? 1 : 0;
      previous[i] = Math.random() > 0.72 ? 1 : 0;
    }
  }
  generation = 0;
  renderOnly();
}

function stepLife(): void {
  activeCount = 0;
  for (let y = 0; y < HEIGHT; y++) {
    const y0 = ((y - 1 + HEIGHT) & 255) * WIDTH;
    const y1 = y * WIDTH;
    const y2 = ((y + 1) & 255) * WIDTH;
    for (let x = 0; x < WIDTH; x++) {
      const xm = (x - 1 + WIDTH) & 255;
      const xp = (x + 1) & 255;
      const i = y1 + x;
      const count =
        current[y0 + xm] + current[y0 + x] + current[y0 + xp] +
        current[y1 + xm] + current[y1 + xp] +
        current[y2 + xm] + current[y2 + x] + current[y2 + xp];
      const alive = current[i] === 1;
      const value = alive ? (surviveMask & (1 << count)) !== 0 : (birthMask & (1 << count)) !== 0;
      next[i] = value ? 1 : 0;
      if (value) {
        activeCount++;
        setPixel(i, palette.life[0], palette.life[1], palette.life[2]);
      } else {
        setPixel(i, palette.background[0], palette.background[1], palette.background[2]);
      }
    }
  }
  const temp = current;
  current = next;
  next = temp;
}

function stepDiffusion(): void {
  activeCount = 0;
  for (let y = 0; y < HEIGHT; y++) {
    const y0 = ((y - 1 + HEIGHT) & 255) * WIDTH;
    const y1 = y * WIDTH;
    const y2 = ((y + 1) & 255) * WIDTH;
    for (let x = 0; x < WIDTH; x++) {
      const xm = (x - 1 + WIDTH) & 255;
      const xp = (x + 1) & 255;
      const i = y1 + x;
      const sum = current[i] * 4 + current[y0 + x] + current[y2 + x] + current[y1 + xm] + current[y1 + xp];
      const value = sum >> 3;
      next[i] = value;
      if (value > 2) {
        activeCount++;
      }
      const hot = value / 255;
      const r = Math.floor(palette.densityLow[0] + hot * (palette.densityHigh[0] - palette.densityLow[0]));
      const g = Math.floor(palette.densityLow[1] + hot * (palette.densityHigh[1] - palette.densityLow[1]));
      const b = Math.floor(palette.densityLow[2] + hot * (palette.densityHigh[2] - palette.densityLow[2]));
      setPixel(i, r, g, b);
    }
  }
  const temp = current;
  current = next;
  next = temp;
}

function stepReversible(): void {
  activeCount = 0;
  for (let y = 0; y < HEIGHT; y++) {
    const y0 = ((y - 1 + HEIGHT) & 255) * WIDTH;
    const y1 = y * WIDTH;
    const y2 = ((y + 1) & 255) * WIDTH;
    for (let x = 0; x < WIDTH; x++) {
      const xm = (x - 1 + WIDTH) & 255;
      const xp = (x + 1) & 255;
      const i = y1 + x;
      const parity = current[y0 + x] ^ current[y2 + x] ^ current[y1 + xm] ^ current[y1 + xp];
      const value = previous[i] ^ parity;
      next[i] = value;
      if (value) {
        activeCount++;
        const trail = current[i] ? palette.reversible : palette.trail;
        setPixel(i, trail[0], trail[1], trail[2]);
      } else {
        setPixel(i, palette.background[0], palette.background[1], palette.background[2]);
      }
    }
  }
  const oldPrevious = previous;
  previous = current;
  current = next;
  next = oldPrevious;
}

function stepPredator(): void {
  activeCount = 0;
  for (let y = 0; y < HEIGHT; y++) {
    const y0 = ((y - 1 + HEIGHT) & 255) * WIDTH;
    const y1 = y * WIDTH;
    const y2 = ((y + 1) & 255) * WIDTH;
    for (let x = 0; x < WIDTH; x++) {
      const xm = (x - 1 + WIDTH) & 255;
      const xp = (x + 1) & 255;
      const i = y1 + x;
      let prey = 0;
      let predators = 0;
      const n0 = current[y0 + xm];
      const n1 = current[y0 + x];
      const n2 = current[y0 + xp];
      const n3 = current[y1 + xm];
      const n4 = current[y1 + xp];
      const n5 = current[y2 + xm];
      const n6 = current[y2 + x];
      const n7 = current[y2 + xp];
      prey += n0 === 1 ? 1 : 0; predators += n0 === 2 ? 1 : 0;
      prey += n1 === 1 ? 1 : 0; predators += n1 === 2 ? 1 : 0;
      prey += n2 === 1 ? 1 : 0; predators += n2 === 2 ? 1 : 0;
      prey += n3 === 1 ? 1 : 0; predators += n3 === 2 ? 1 : 0;
      prey += n4 === 1 ? 1 : 0; predators += n4 === 2 ? 1 : 0;
      prey += n5 === 1 ? 1 : 0; predators += n5 === 2 ? 1 : 0;
      prey += n6 === 1 ? 1 : 0; predators += n6 === 2 ? 1 : 0;
      prey += n7 === 1 ? 1 : 0; predators += n7 === 2 ? 1 : 0;
      let value = current[i];
      let nextEnergy = energy[i];
      if (value === 0) {
        value = prey >= 3 && predators <= 2 ? 1 : predators >= 2 && prey >= 1 ? 2 : 0;
        nextEnergy = value === 2 ? 10 : 0;
      } else if (value === 1) {
        value = predators >= 2 ? 0 : prey >= 2 && prey <= 5 ? 1 : 0;
        nextEnergy = 0;
      } else {
        nextEnergy = prey > 0 ? 14 : Math.max(0, nextEnergy - 1);
        value = nextEnergy > 0 ? 2 : 0;
      }
      next[i] = value;
      energy[i] = nextEnergy;
      if (value === 1) {
        activeCount++;
        setPixel(i, palette.prey[0], palette.prey[1], palette.prey[2]);
      } else if (value === 2) {
        activeCount++;
        setPixel(i, palette.predator[0], palette.predator[1], palette.predator[2]);
      } else {
        setPixel(i, palette.background[0], palette.background[1], palette.background[2]);
      }
    }
  }
  const temp = current;
  current = next;
  next = temp;
}

function stepModel(): void {
  if (model === "life") {
    stepLife();
  } else if (model === "diffusion") {
    stepDiffusion();
  } else if (model === "reversible") {
    stepReversible();
  } else {
    stepPredator();
  }
  generation++;
}

function renderOnly(): void {
  activeCount = 0;
  for (let i = 0; i < SIZE; i++) {
    const value = current[i];
    if (model === "diffusion") {
      const hot = value / 255;
      const r = Math.floor(palette.densityLow[0] + hot * (palette.densityHigh[0] - palette.densityLow[0]));
      const g = Math.floor(palette.densityLow[1] + hot * (palette.densityHigh[1] - palette.densityLow[1]));
      const b = Math.floor(palette.densityLow[2] + hot * (palette.densityHigh[2] - palette.densityLow[2]));
      setPixel(i, r, g, b);
      if (value > 2) {
        activeCount++;
      }
    } else if (model === "predator") {
      if (value === 1) {
        activeCount++;
        setPixel(i, palette.prey[0], palette.prey[1], palette.prey[2]);
      } else if (value === 2) {
        activeCount++;
        setPixel(i, palette.predator[0], palette.predator[1], palette.predator[2]);
      } else {
        setPixel(i, palette.background[0], palette.background[1], palette.background[2]);
      }
    } else if (value) {
      activeCount++;
      const color = model === "reversible" ? palette.reversible : palette.life;
      setPixel(i, color[0], color[1], color[2]);
    } else {
      setPixel(i, palette.background[0], palette.background[1], palette.background[2]);
    }
  }
  putFrame();
  updateStats();
}

function updateStats(): void {
  generationLabel.textContent = generation.toString();
  activeCountLabel.textContent = activeCount.toLocaleString();
}

function loop(now: number): void {
  if (running) {
    const steps = Number.parseInt(stepsPerFrame.value, 10);
    for (let i = 0; i < steps; i++) {
      stepModel();
    }
    putFrame();
    updateStats();
  }
  frames++;
  if (now - fpsTime >= 500) {
    const fps = Math.round((frames * 1000) / (now - fpsTime));
    fpsLabel.textContent = fps.toString();
    frames = 0;
    fpsTime = now;
  }
  lastTime = now;
  requestAnimationFrame(loop);
}

function paintAt(clientX: number, clientY: number): void {
  const rect = canvas.getBoundingClientRect();
  const x = Math.floor(((clientX - rect.left) / rect.width) * WIDTH);
  const y = Math.floor(((clientY - rect.top) / rect.height) * HEIGHT);
  const radius = Number.parseInt(brushSize.value, 10);
  for (let dy = -radius; dy <= radius; dy++) {
    for (let dx = -radius; dx <= radius; dx++) {
      if (dx * dx + dy * dy > radius * radius) {
        continue;
      }
      const i = indexOf(x + dx, y + dy);
      if (model === "diffusion") {
        current[i] = 255;
      } else if (model === "predator") {
        current[i] = Math.random() > 0.35 ? 1 : 2;
        energy[i] = current[i] === 2 ? 14 : 0;
      } else {
        current[i] = 1;
      }
    }
  }
  renderOnly();
}

modelSelect.addEventListener("change", () => {
  model = modelSelect.value as ModelId;
  modelSummary.textContent = MODELS[model].summary;
  lifeRules.style.display = model === "life" ? "grid" : "none";
  randomize();
});

toggleRun.addEventListener("click", () => {
  running = !running;
  toggleRun.textContent = running ? "Pause" : "Run";
});

stepOnce.addEventListener("click", () => {
  stepModel();
  putFrame();
  updateStats();
});

randomizeBtn.addEventListener("click", randomize);
clearBtn.addEventListener("click", clearAll);

stepsPerFrame.addEventListener("input", () => {
  stepsLabel.textContent = stepsPerFrame.value;
});

brushSize.addEventListener("input", () => {
  brushLabel.textContent = brushSize.value;
});

surviveInput.addEventListener("input", () => {
  surviveMask = parseRuleMask(surviveInput.value);
});

birthInput.addEventListener("input", () => {
  birthMask = parseRuleMask(birthInput.value);
});

canvas.addEventListener("pointerdown", (event) => {
  pointerDown = true;
  canvas.setPointerCapture(event.pointerId);
  paintAt(event.clientX, event.clientY);
});

canvas.addEventListener("pointermove", (event) => {
  if (pointerDown) {
    paintAt(event.clientX, event.clientY);
  }
});

canvas.addEventListener("pointerup", (event) => {
  pointerDown = false;
  canvas.releasePointerCapture(event.pointerId);
});

modelSummary.textContent = MODELS[model].summary;
randomize();
requestAnimationFrame(loop);
