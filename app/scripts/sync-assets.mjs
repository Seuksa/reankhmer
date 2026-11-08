// Copies the media the app uses from the shared content package (../assets) into public/assets.
// Photos of people, team pictures and 2006 UI art are left out (rights unclear / unused).
import { cpSync, existsSync, mkdirSync, rmSync } from 'node:fs';
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
console.log(`synced ${dirs.length} asset folders -> public/assets`);
