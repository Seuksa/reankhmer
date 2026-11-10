// One-off: render the 1200×630 link-preview image public/og.png (run: node scripts/make-og.mjs).
// Text goes through sharp's Pango renderer, which shapes Khmer properly (coeng, vowel order),
// using the same fonts the site ships (Kantumruy Pro, Noto Serif Khmer) straight from node_modules.
import sharp from 'sharp';
import { readFile } from 'node:fs/promises';

const W = 1200, H = 630;
const fonts = 'node_modules/@fontsource-variable';
const KANTUMRUY_KM = `${fonts}/kantumruy-pro/files/kantumruy-pro-khmer-wght-normal.woff2`;
const KANTUMRUY_LATIN = `${fonts}/kantumruy-pro/files/kantumruy-pro-latin-wght-normal.woff2`;
const SERIF_KM = `${fonts}/noto-serif-khmer/files/noto-serif-khmer-khmer-wght-normal.woff2`;

/** One line (or wrapped block) of text as a transparent PNG. dpi 72 makes Pango points equal pixels. */
const text = (markup, fontfile, font, width) =>
  sharp({ text: { text: markup, fontfile, font, rgba: true, dpi: 72, width, wrap: 'word' } }).png().toBuffer();

// Background: brand teal with a soft diagonal light, a lighter band at the bottom.
const bg = Buffer.from(`<svg xmlns="http://www.w3.org/2000/svg" width="${W}" height="${H}">
  <defs>
    <linearGradient id="g" x1="0" y1="0" x2="1" y2="1">
      <stop offset="0" stop-color="#0f766e"/><stop offset="1" stop-color="#115e59"/>
    </linearGradient>
    <radialGradient id="r" cx="0.85" cy="0.2" r="0.7">
      <stop offset="0" stop-color="#14b8a6" stop-opacity="0.45"/><stop offset="1" stop-color="#14b8a6" stop-opacity="0"/>
    </radialGradient>
  </defs>
  <rect width="100%" height="100%" fill="url(#g)"/>
  <rect width="100%" height="100%" fill="url(#r)"/>
  <rect y="${H - 74}" width="100%" height="74" fill="#134e4a" fill-opacity="0.55"/>
</svg>`);

// The site icon (open book with sound), white-on-teal, from public/favicon.svg.
const icon = await sharp(await readFile('public/favicon.svg')).resize(112, 112).png().toBuffer();

const [letters, title, brand, tagKm, tagEn, url] = await Promise.all([
  // Big faded consonants on the right, as on a classroom wall.
  text('<span foreground="#ccfbf1" fgalpha="16%" font_desc="Noto Serif Khmer 190">ក ខ គ</span>', SERIF_KM, 'Noto Serif Khmer'),
  text('<span foreground="#ffffff" font_desc="Kantumruy Pro Bold 128">រៀនខ្មែរ</span>', KANTUMRUY_KM, 'Kantumruy Pro'),
  text('<span foreground="#ccfbf1" font_desc="Kantumruy Pro SemiBold 60">ReanKhmer</span>', KANTUMRUY_LATIN, 'Kantumruy Pro'),
  text('<span foreground="#ffffff" font_desc="Kantumruy Pro Medium 46">រៀនអាន ស្តាប់ និងនិយាយភាសាខ្មែរ</span>', KANTUMRUY_KM, 'Kantumruy Pro', 1060),
  text('<span foreground="#ccfbf1" font_desc="Kantumruy Pro 36">Learn to read, hear and speak Khmer · free, works offline</span>', KANTUMRUY_LATIN, 'Kantumruy Pro', 1060),
  text('<span foreground="#ffffff" font_desc="Kantumruy Pro SemiBold 32">rean.seuksa.com</span>', KANTUMRUY_LATIN, 'Kantumruy Pro'),
]);

const lm = await sharp(letters).metadata();
console.log('letters', lm.width, lm.height);

await sharp(bg)
  .composite([
    { input: letters, left: W - lm.width - 36, top: 30 },
    { input: icon, left: 72, top: 64 },
    { input: title, left: 66, top: 168 },
    { input: brand, left: 72, top: 356 },
    { input: tagKm, left: 72, top: 430 },
    { input: tagEn, left: 72, top: 497 },
    { input: url, left: 72, top: H - 60 },
  ])
  .png({ compressionLevel: 9 })
  .toFile('public/og.png');
console.log('public/og.png written');
