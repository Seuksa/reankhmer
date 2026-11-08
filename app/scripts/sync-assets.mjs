// Copies the media the app uses from the shared content package (../assets) into public/assets.
// Photos of people, team pictures and 2006 UI art are left out (rights unclear / unused).
import { cpSync, existsSync, mkdirSync, readdirSync, rmSync } from 'node:fs';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const app = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const src = resolve(app, '../assets');
const dst = join(app, 'public/assets');
const dirs = ['audio', 'images/letters', 'images/vowels', 'images/conversation', 'images/reading'];

if (!existsSync(src)) {
  console.error(`Missing ${src}. Run tools/migrate_legacy.py first.`);
  process.exit(1);
}
rmSync(dst, { recursive: true, force: true });
for (const d of dirs) {
  mkdirSync(join(dst, d), { recursive: true });
  cpSync(join(src, d), join(dst, d), { recursive: true });
}
// 2006 consonant writing animations (kor_1.swf … or_33.swf), played with Ruffle on /writing.
const flashSrc = resolve(app, '../legacy/flash');
mkdirSync(join(dst, 'flash'), { recursive: true });
const swfs = readdirSync(flashSrc).filter((f) => /^[a-z]+_\d+\.swf$/.test(f));
for (const f of swfs) cpSync(join(flashSrc, f), join(dst, 'flash', f));

// Ruffle (Flash emulator, MIT/Apache-2.0), self-hosted so it works offline once cached.
const ruffleSrc = join(app, 'node_modules/@ruffle-rs/ruffle');
const ruffleDst = join(app, 'public/ruffle');
rmSync(ruffleDst, { recursive: true, force: true });
mkdirSync(ruffleDst, { recursive: true });
for (const f of readdirSync(ruffleSrc).filter((f) => /\.(js|wasm)$/.test(f))) cpSync(join(ruffleSrc, f), join(ruffleDst, f));

console.log(`synced ${dirs.length} asset folders, ${swfs.length} SWF, Ruffle -> public/`);
