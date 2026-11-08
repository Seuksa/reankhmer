<script setup lang="ts">
import { computed, onBeforeUnmount, onMounted, ref } from 'vue';
import { KEYS, display, strokes, typed, type KeyDef, type Stroke, type TypingLesson } from '../lib/nida';
import { loadProgress, progress, saveTyping } from '../lib/progress';
import KhmerKeyboard from './KhmerKeyboard.vue';
import T from './T.vue';

const props = defineProps<{ lessons: TypingLesson[]; gamePool: string[] }>();

const GAME_SECONDS = 120;
// 2006 ReanKhmer game thresholds, reused as correct keystrokes per minute.
const LEVELS = [
  { min: 100, km: 'ល្អប្រសើរ', en: 'Excellent' },
  { min: 75, km: 'ល្អ', en: 'Good' },
  { min: 55, km: 'ល្អបង្គួរ', en: 'Fair' },
  { min: 30, km: 'មធ្យម', en: 'Normal' },
  { min: 0, km: 'ហាត់បន្តទៀត', en: 'Keep practising' },
];

const active = ref<TypingLesson | null>(null);
const isGame = ref(false);
const queue = ref<string[]>([]);
const text = ref('');
const plan = ref<Stroke[]>([]);
const pos = ref(0);
const pending = ref('');
const output = ref('');
const correct = ref(0);
const errors = ref(0);
const startedAt = ref<number | null>(null);
const now = ref(Date.now());
const shiftOn = ref(false);
const flash = ref<string | null>(null);
const result = ref<{ kpm: number; acc: number } | null>(null);
let timer: ReturnType<typeof setInterval> | undefined;

onMounted(() => { void loadProgress(); window.addEventListener('keydown', onKey); });
onBeforeUnmount(() => { window.removeEventListener('keydown', onKey); clearInterval(timer); });

const next = computed(() => plan.value[pos.value] ?? null);
const nextKey = computed(() => (next.value && next.value.code !== 'Space' ? KEYS.get(next.value.code) : null));
const elapsed = computed(() => (startedAt.value ? (now.value - startedAt.value) / 1000 : 0));
const remaining = computed(() => Math.max(0, Math.ceil(GAME_SECONDS - elapsed.value)));
const level = (kpm: number) => LEVELS.find((l) => kpm >= l.min)!;

const shuffle = <X,>(a: X[]) => a.map((v) => [Math.random(), v] as const).sort((x, y) => x[0] - y[0]).map((x) => x[1]);
const typeable = (s: string) => strokes(s) !== null;

function buildQueue(l: TypingLesson): string[] {
  if (l.kind === 'drill') {
    return Array.from({ length: 3 }, () => Array.from({ length: 10 }, () => l.items[Math.floor(Math.random() * l.items.length)]).join(' '));
  }
  return shuffle(l.items.filter(typeable)).slice(0, 8);
}

function load(t: string) {
  text.value = t;
  plan.value = strokes(t) ?? [];
  pos.value = 0;
  pending.value = '';
  output.value = '';
}

function start(l: TypingLesson | null) {
  isGame.value = !l;
  active.value = l ?? { id: 'game', km: 'ល្បែងវាយអក្សរ ២ នាទី', en: '2-minute typing game', kind: 'text', items: props.gamePool };
  queue.value = l ? buildQueue(l) : shuffle(props.gamePool.filter(typeable));
  correct.value = 0; errors.value = 0; startedAt.value = null; result.value = null; shiftOn.value = false;
  load(queue.value.shift() ?? '');
  clearInterval(timer);
  timer = setInterval(() => {
    now.value = Date.now();
    if (isGame.value && startedAt.value && remaining.value === 0) finish();
  }, 250);
}

function finish() {
  clearInterval(timer);
  const minutes = Math.max(elapsed.value, 1) / 60;
  const kpm = Math.round(correct.value / minutes);
  const acc = correct.value + errors.value ? correct.value / (correct.value + errors.value) : 0;
  result.value = { kpm, acc };
  if (active.value) saveTyping(active.value.id, kpm, acc);
}

function stop() { clearInterval(timer); active.value = null; result.value = null; }

function input(p: string, code?: string) {
  if (!next.value || result.value) return;
  startedAt.value ??= Date.now();
  pending.value += p;
  const want = next.value.out;
  if (pending.value === want) {
    output.value += want;
    correct.value++;
    pos.value++;
    pending.value = '';
    if (pos.value >= plan.value.length) {
      if (queue.value.length) load(queue.value.shift()!);
      else if (isGame.value) { queue.value = shuffle(props.gamePool.filter(typeable)); load(queue.value.shift()!); }
      else finish();
    }
  } else if (!want.startsWith(pending.value)) {
    errors.value++;
    pending.value = '';
    flash.value = code ?? next.value.code;
    setTimeout(() => (flash.value = null), 300);
  }
}

function onKey(e: KeyboardEvent) {
  if (!active.value || result.value) return;
  if (e.key === 'Escape') return stop();
  const p = typed(e);
  if (p === null) return;
  e.preventDefault();
  input(p, e.code);
}

function press(k: KeyDef | 'Space') {
  if (k === 'Space') return input(' ');
  const p = shiftOn.value ? k.shift : k.normal;
  shiftOn.value = false;
  input(p, k.code);
}

const best = (id: string) => progress.typing?.[id];
</script>

<template>
  <div>
    <!-- Lesson picker -->
    <div v-if="!active">
      <ol class="grid gap-2 sm:grid-cols-2">
        <li v-for="(l, i) in lessons" :key="l.id">
          <button type="button" class="card flex w-full items-center gap-3 text-left hover:border-brand-500" @click="start(l)">
            <span class="grid size-9 shrink-0 place-items-center rounded-full text-sm font-semibold"
              :class="best(l.id) ? 'bg-emerald-600 text-white' : 'bg-slate-100 dark:bg-slate-800'">{{ best(l.id) ? '✓' : i + 1 }}</span>
            <span class="min-w-0 flex-1"><T :km="l.km" :en="l.en" stack /></span>
            <span v-if="best(l.id)" class="text-xs text-slate-500">{{ best(l.id)!.kpm }}/min</span>
          </button>
        </li>
      </ol>
      <button type="button" class="btn mt-4 w-full sm:w-auto" @click="start(null)">
        <T km="ល្បែងវាយអក្សរ ២ នាទី" en="2-minute typing game" />
        <span v-if="best('game')" class="text-xs opacity-80">· {{ best('game')!.kpm }}/min</span>
      </button>
    </div>

    <!-- Practice -->
    <div v-else>
      <div class="mb-3 flex flex-wrap items-center gap-3">
        <p class="font-semibold"><T :km="active.km" :en="active.en" /></p>
        <span v-if="isGame" class="rounded-full bg-amber-100 px-3 py-0.5 text-sm font-semibold text-amber-900 dark:bg-amber-900/50 dark:text-amber-100">⏱ {{ remaining }}s</span>
        <span class="text-sm text-slate-500">✓ {{ correct }} · ✗ {{ errors }}</span>
        <button type="button" class="btn-quiet ml-auto !py-1 text-sm" @click="stop"><T km="ចេញ" en="Exit" /></button>
      </div>

      <div v-if="result" class="card mb-4 text-center" aria-live="polite">
        <p class="text-4xl font-semibold">{{ result.kpm }} <span class="text-lg font-normal text-slate-500"><T km="ចុច/នាទី" en="keys/min" /></span></p>
        <p class="mt-1 text-slate-500"><T km="ភាពត្រឹមត្រូវ" en="Accuracy" /> {{ Math.round(result.acc * 100) }}%</p>
        <p class="mt-2 text-xl font-semibold text-brand-700 dark:text-brand-200"><T v-bind="level(result.kpm)" /></p>
        <div class="mt-4 flex justify-center gap-2">
          <button type="button" class="btn" @click="start(isGame ? null : active)"><T km="ម្តងទៀត" en="Again" /></button>
          <button type="button" class="btn-quiet" @click="stop"><T km="មេរៀនផ្សេង" en="Other lessons" /></button>
        </div>
      </div>

      <template v-else>
        <div class="card mb-3">
          <p lang="km" class="font-khmer-serif text-3xl leading-[1.8] break-words sm:text-4xl">{{ text }}</p>
          <p lang="km" class="mt-2 min-h-[2.5rem] border-t border-dashed border-slate-300 pt-2 text-2xl text-brand-700 dark:border-slate-700 dark:text-brand-200">{{ output }}<span class="animate-pulse">|</span></p>
          <div class="mt-2 h-1.5 rounded-full bg-slate-100 dark:bg-slate-800">
            <div class="h-1.5 rounded-full bg-brand-600 transition-all" :style="{ width: `${(pos / Math.max(plan.length, 1)) * 100}%` }" />
          </div>
        </div>
        <p v-if="next" class="mb-3 text-center" aria-live="polite">
          <T km="ចុចបន្ទាប់" en="Next key" />:
          <span lang="km" class="mx-1 text-2xl font-semibold">{{ next.code === 'Space' ? '␣' : display(next.out) }}</span>
          <kbd class="rounded border border-slate-300 px-1.5 py-0.5 font-mono text-sm dark:border-slate-700">{{ next.shift ? 'Shift + ' : '' }}{{ next.code === 'Space' ? 'Space' : nextKey?.latin }}</kbd>
        </p>
        <KhmerKeyboard :next="next" :shift-on="shiftOn" :flash="flash" @press="press" @shift="shiftOn = !shiftOn" />
        <p class="mt-2 text-center text-xs text-slate-500">
          <T km="ប្រើក្តារចុចកុំព្យូទ័រ ឬចុចលើក្តារចុចខាងលើ។ មិនចាំបាច់ដំឡើងក្តារចុចខ្មែរទេ។" en="Type on your computer keyboard or tap the keys above. No Khmer keyboard install needed." />
        </p>
      </template>
    </div>
  </div>
</template>
