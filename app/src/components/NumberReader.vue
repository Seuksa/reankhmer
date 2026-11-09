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

const text = ref('1250');
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

watch(text, () => { run++; active.value = null; });
onBeforeUnmount(() => { run++; stop(); });

const key = 'font-khmer-serif grid h-12 place-items-center rounded-xl border-2 border-slate-200 bg-white text-2xl hover:border-brand-500 hover:bg-brand-50 dark:border-slate-700 dark:bg-slate-900 dark:hover:bg-brand-900/40';
const tool = 'grid h-12 place-items-center rounded-xl border-2 border-slate-200 bg-slate-50 text-lg font-semibold hover:border-brand-500 dark:border-slate-700 dark:bg-slate-800';
</script>

<template>
  <div class="card grid gap-6 lg:grid-cols-[minmax(0,20rem)_1fr]">
    <!-- input + keypad -->
    <div>
      <label for="num-in" class="mb-1 block text-sm font-medium"><T km="វាយលេខ" en="Type a number" /></label>
      <input id="num-in" v-model="text" type="text" inputmode="decimal" autocomplete="off" spellcheck="false"
        class="w-full rounded-xl border-2 border-slate-200 bg-white px-3 py-2 text-2xl tabular-nums dark:border-slate-700 dark:bg-slate-900"
        @keydown.enter="readAll" />
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

      <div>
        <button type="button" class="btn" :disabled="!result.ok" @click="readAll"><T km="អានលេខ" en="Read the number" /> ▶</button>
      </div>
    </div>
  </div>
</template>
