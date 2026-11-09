<script setup lang="ts">
// "Read any number": the 2006 ReadNum.swf tool rebuilt without Flash (rules in lib/numberReader.ts).
import { computed, onBeforeUnmount, ref, watch } from 'vue';
import { khmerDigits, type NumberWord } from '../lib/content';
import { play, stop } from '../lib/audio';
import { markHeard } from '../lib/progress';
import { normalize, readNumber } from '../lib/numberReader';
import T from './T.vue';

const props = defineProps<{ numbers: NumberWord[] }>();
const byKey = computed(() => new Map(props.numbers.map((n) => [n.key, n])));

const text = ref('១២៥០');
// Digits are shown in Khmer; Latin digits typed on a normal keyboard are converted as you type.
const toKhmer = (s: string) => s.replace(/[0-9]/g, (d) => khmerDigits(d));
watch(text, (v) => { if (/[0-9]/.test(v)) text.value = toKhmer(v); });
/** The same number in Latin digits, shown small beside the box: (1250). */
const latin = computed(() => normalize(text.value) ?? '');
const result = computed(() => readNumber(text.value));
const words = computed(() => (result.value.ok ? result.value.words.map((k) => byKey.value.get(k)).filter((n): n is NumberWord => !!n) : []));
const shown = computed(() => {
  const s = normalize(text.value);
  if (!s) return '';
  const pct = s.endsWith('%');
  const [int, frac] = s.replace('%', '').split('.');
  const grouped = Number(int.replace('-', '')).toLocaleString('en-US');
  return (s.startsWith('-') ? '−' : '') + khmerDigits(grouped) + (frac !== undefined ? '.' + khmerDigits(frac) : '') + (pct ? '%' : '');
});

// The number written out in Khmer words, which are joined without spaces: មួយពាន់ពីររយហាសិប.
const khmerText = computed(() => words.value.map((w) => w.word ?? '').join(''));
const copied = ref(false);
let copiedTimer: ReturnType<typeof setTimeout> | undefined;
const khmerEl = ref<HTMLElement | null>(null);

/** Selects the Khmer line; returns true if the browser also copied it. */
function selectAndCopy(): boolean {
  if (!khmerEl.value) return false;
  const r = document.createRange();
  r.selectNodeContents(khmerEl.value);
  getSelection()?.removeAllRanges();
  getSelection()?.addRange(r);
  let ok = false;
  try { ok = document.execCommand('copy'); } catch { /* unsupported */ }
  if (ok) getSelection()?.removeAllRanges(); // copied; otherwise leave it selected to copy by hand
  return ok;
}

async function copyKhmer() {
  if (!khmerText.value) return;
  // The Clipboard API can be missing (plain http), refuse, or wait on a permission prompt.
  // Give it a second, then fall back to copying the selected text.
  const viaApi = navigator.clipboard
    ? await Promise.race([
        navigator.clipboard.writeText(khmerText.value).then(() => true, () => false),
        new Promise<boolean>((r) => setTimeout(() => r(false), 1000)),
      ])
    : false;
  if (!viaApi && !selectAndCopy()) return;
  copied.value = true;
  clearTimeout(copiedTimer);
  copiedTimer = setTimeout(() => (copied.value = false), 2000);
}

const active = ref<number | null>(null);
let run = 0;

async function readAll() {
  if (!words.value.length) return;
  const mine = ++run;
  markHeard('n:reader');
  for (let i = 0; i < words.value.length; i++) {
    if (mine !== run) return;
    active.value = i;
    await play(`/${words.value[i].audio}`);
  }
  if (mine === run) active.value = null;
}

async function sayOne(i: number) {
  const mine = ++run;
  active.value = i;
  await play(`/${words.value[i].audio}`);
  if (mine === run) active.value = null;
}

// Keypad: like 2006, each digit is spoken as you press it.
const KEYS = [...'០១២៣៤៥៦៧៨៩'];
function press(k: string) {
  run++;
  active.value = null;
  if (text.value === '0') text.value = '';
  // Keep a trailing % at the end: ៥០% then ៥ gives ៥០៥%.
  text.value = text.value.endsWith('%') ? text.value.slice(0, -1) + k + '%' : text.value + k;
  const d = KEYS.indexOf(k);
  if (d >= 0) void play(`/${byKey.value.get(['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'][d])!.audio}`);
}
function back() { text.value = text.value.slice(0, -1); }
function clear() { text.value = ''; }
function togglePercent() { text.value = text.value.endsWith('%') ? text.value.slice(0, -1) : text.value + '%'; }
function toggleMinus() { text.value = text.value.startsWith('-') ? text.value.slice(1) : '-' + text.value; }

watch(text, () => { run++; active.value = null; copied.value = false; });
onBeforeUnmount(() => { run++; stop(); });

const key = 'font-khmer-serif grid h-12 place-items-center rounded-xl border-2 border-slate-200 bg-white text-2xl hover:border-brand-500 hover:bg-brand-50 dark:border-slate-700 dark:bg-slate-900 dark:hover:bg-brand-900/40';
const tool = 'grid h-12 place-items-center rounded-xl border-2 border-slate-200 bg-slate-50 text-lg font-semibold hover:border-brand-500 dark:border-slate-700 dark:bg-slate-800';
</script>

<template>
  <div class="card grid gap-6 lg:grid-cols-[minmax(0,20rem)_1fr]">
    <!-- input + keypad -->
    <div>
      <label for="num-in" class="mb-1 block text-sm font-medium"><T km="វាយលេខ" en="Type a number" /></label>
      <div class="relative">
        <input id="num-in" v-model="text" type="text" inputmode="decimal" autocomplete="off" spellcheck="false" lang="km"
          aria-describedby="num-latin"
          class="font-khmer-serif w-full rounded-xl border-2 border-slate-200 bg-white py-2 pl-3 pr-28 text-2xl tabular-nums dark:border-slate-700 dark:bg-slate-900"
          @keydown.enter="readAll" />
        <span v-if="latin" id="num-latin" class="pointer-events-none absolute right-3 top-1/2 max-w-24 -translate-y-1/2 truncate text-sm tabular-nums text-slate-500">({{ latin }})</span>
      </div>
      <div class="mt-3 grid grid-cols-5 gap-1.5">
        <button v-for="k in KEYS" :key="k" type="button" lang="km" :class="key" :aria-label="`Digit ${KEYS.indexOf(k)}`" @click="press(k)">{{ k }}</button>
        <button type="button" :class="tool" aria-label="Minus" @click="toggleMinus">−</button>
        <button type="button" :class="tool" aria-label="Decimal point" @click="press('.')">.</button>
        <button type="button" :class="tool" aria-label="Percent" @click="togglePercent">%</button>
        <button type="button" :class="tool" aria-label="Delete last" @click="back">⌫</button>
        <button type="button" :class="[tool, 'text-xs']" @click="clear"><T km="លុប" en="Clear" stack /></button>
      </div>
    </div>

    <!-- reading -->
    <div class="flex min-w-0 flex-col gap-4">
      <p lang="km" class="font-khmer-serif min-h-14 break-all text-5xl leading-tight">{{ shown || ' ' }}</p>

      <div v-if="result.ok" class="flex flex-wrap gap-2" aria-live="polite">
        <button v-for="(w, i) in words" :key="i" type="button"
          class="flex flex-col items-center rounded-xl border-2 px-3 py-1.5 transition"
          :class="active === i ? 'border-brand-600 bg-brand-600 text-white' : 'border-slate-200 bg-white hover:border-brand-500 dark:border-slate-700 dark:bg-slate-900'"
          @click="sayOne(i)">
          <span lang="km" class="font-khmer-serif text-xl">{{ w.word ?? '·' }}</span>
          <span class="text-xs opacity-75">{{ w.key.replace(/[_-]/g, ' ') }}</span>
        </button>
      </div>
      <p v-else-if="result.reason === 'invalid'" class="text-sm text-amber-700 dark:text-amber-300">
        <T km="សូមវាយតែលេខ (អាចមាន − . និង %)។" en="Please type only digits (a − sign, one . and a final % are fine)." />
      </p>
      <p v-else-if="result.reason === 'too-long'" class="text-sm text-amber-700 dark:text-amber-300">
        <T km="លេខវែងពេក — រហូតដល់ ១២ ខ្ទង់ និង ៦ ខ្ទង់ក្រោយក្បៀស។" en="That number is too long: up to 12 digits, and 6 after the point." />
      </p>

      <div v-if="result.ok && khmerText" class="flex flex-wrap items-center gap-2 rounded-xl bg-slate-50 px-3 py-2 dark:bg-slate-800/60">
        <span ref="khmerEl" lang="km" class="font-khmer-serif min-w-0 flex-1 break-all text-xl">{{ khmerText }}</span>
        <button type="button" class="chip" :aria-label="`Copy ${khmerText}`" @click="copyKhmer">
          <template v-if="copied">✓ <T km="បានចម្លង" en="Copied" /></template>
          <template v-else>⧉ <T km="ចម្លង" en="Copy" /></template>
        </button>
      </div>

      <div>
        <button type="button" class="btn" :disabled="!result.ok" @click="readAll"><T km="អានលេខ" en="Read the number" /> ▶</button>
      </div>
    </div>
  </div>
</template>
