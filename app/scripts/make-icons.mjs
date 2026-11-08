// One-off: render PWA PNG icons from public/favicon.svg (run: node scripts/make-icons.mjs).
import sharp from 'sharp';
const svg = 'public/favicon.svg';
await sharp(svg).resize(192, 192).png().toFile('public/icons/icon-192.png');
await sharp(svg).resize(512, 512).png().toFile('public/icons/icon-512.png');
await sharp(svg).resize(180, 180).flatten({ background: '#0f766e' }).png().toFile('public/icons/apple-touch-icon.png');
// Maskable: full-bleed background, artwork inside the 80% safe zone.
const inner = await sharp(svg).resize(384, 384).png().toBuffer();
await sharp({ create: { width: 512, height: 512, channels: 4, background: '#0f766e' } })
  .composite([{ input: inner, gravity: 'center' }]).png().toFile('public/icons/maskable-512.png');
console.log('icons written');
