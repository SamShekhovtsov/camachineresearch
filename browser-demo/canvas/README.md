# CA Machines Browser MVP

This branch contains a dependency-free browser demo that uses TypeScript source and a checked-in JavaScript build.

The implementation keeps simulation and drawing fused in the hot path:

1. state buffers are contiguous typed arrays,
2. each model updates its next-state buffer,
3. the same inner loop writes RGBA pixels into one `ImageData` buffer,
4. Canvas presents that buffer without per-cell DOM work.

## Run

Open `index.html` directly in a browser, or serve the folder with any static server:

```powershell
cd browser-demo\canvas
python -m http.server 5173
```

Then open `http://localhost:5173`.

No package install is required.

## Files

- `src/app.ts` is the TypeScript source.
- `app.js` is the browser-ready JavaScript generated from the TypeScript source.
- `index.html` and `styles.css` provide the UI.
