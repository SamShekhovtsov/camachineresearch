# CA Machines GPU Browser Demo

This branch contains the performance-oriented browser demo.

The simulation state lives in GPU textures and advances through ping-pong passes:

1. texture A is read as the current CA state,
2. texture B is written as the next CA state,
3. the textures swap,
4. the current texture is rendered directly to the canvas.

The app uses WebGPU when available and falls back to WebGL2.

## Run

WebGPU requires a secure browser context. Use localhost:

```powershell
cd browser-demo\gpu
python -m http.server 5174
```

Then open `http://localhost:5174`.

No package install is required.

## Files

- `src/app.ts` is the TypeScript source.
- `app.js` is the browser-ready JavaScript generated from the TypeScript source.
- `index.html` and `styles.css` provide the UI.
