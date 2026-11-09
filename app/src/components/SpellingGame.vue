<script setup lang="ts">
/**
 * Spelling games on the recorded word cards (chapters 2–3).
 *  - Hear and pick: hear a word, pick the right spelling among look-alikes.
 *  - Build the word: hear a word, tap its pieces in order.
 * A word missed on the first try becomes a daily-review card (FSRS); a word that is already a card
 * gets graded as usual when answered right.
 */
import { computed, onMounted, ref } from 'vue';
import { play } from '../lib/audio';
import { grade, ratingFor, Rating } from '../lib/review';
import { loadProgress, markHeard, progress } from '../lib/progress';
import { buildTiles, isMarkPiece, pieces, spellingChoices, tileLabel, type SpellSet, type SpellWord } from '../lib/spelling';
import T from './T.vue';

const props = defineProps<{ sets: SpellSet[] }>();
const ROUND = 10;

type Mode = 'pick' | 'build';
const mode = ref<Mode>('pick');
const choice = ref('2'); // "2", "3" (whole chapter) or a set id like "2-2"
const all = computed(() => props.sets.flatMap((s) => s.words));
const selection = computed(() =>
  choice.value.includes('-') ? props.sets.find((s) => s.id === choice.value)?.words ?? []
  : props.sets.filter((s) => String(s.chapter) === choice.value).flatMap((s) => s.words),
);
const chapterLabel = (n: string) => (n === '2' ? { km: 'ជំពូក ២ ទាំងមូល', en: 'All of chapter 2' } : { km: 'ជំពូក ៣ ទាំងមូល', en: 'All of chapter 3' });

onMounted(() => {
  void loadProgress();
  // Deep link from a lesson: /spelling?set=2-2&mode=build
  const q = new URLSearchParams(location.search);
  const s = q.get('set');
  if (s && (s === '2' || s === '3' || props.sets.some((x) => x.id === s))) choice.value = s;
  if (q.get('mode') === 'build') mode.value = 'build';
});

// ---- round state ----
const playingRound = ref(false);
const queue = ref<SpellWord[]>([]);
const index = ref(0);
const word = computed(() => queue.value[index.value] ?? null);
const missed = ref<SpellWord[]>([]);
const firstTry = ref(0);
const finished = ref(false);
const answered = ref(false);   // the current word is solved
const shownAt = ref(0);
let missedThis = false;

const shuffle = <X,>(a: X[]) => a.map((v) => [Math.random(), v] as const).sort((x, y) => x[0] - y[0]).map((x) => x[1]);

function start() {
  queue.value = shuffle(selection.value).slice(0, ROUND);
  index.value = 0; missed.value = []; firstTry.value = 0; finished.value = false; playingRound.value = true;
  void show();
}

async function show() {
  answered.value = false; missedThis = false;
  picked.value = null; wrongPicks.value = []; choices.value = []; built.value = []; tiles.value = []; wrongTile.value = null;
  const w = word.value;
  if (!w) return;
  if (mode.value === 'pick') choices.value = spellingChoices(w, all.value);
  else { tiles.value = buildTiles(w).map((p, i) => ({ id: i, p, used: false })); target.value = pieces(w.km); }
  await play(w.audio);
  shownAt.value = Date.now();
}

function miss() {
  const w = word.value!;
  if (missedThis) return;
  missedThis = true;
  missed.value.push(w);
  grade(w.id, Rating.Again, false); // now a review card; comes back soon, without using today's new-card allowance
}

function solved() {
  const w = word.value!;
  answered.value = true;
  markHeard(w.id);
  if (!missedThis) {
    firstTry.value++;
    // Only words that are already review cards get a normal grade; new ones stay out of the deck.
    if (progress.cards?.[w.id]) grade(w.id, ratingFor(true, false, Date.now() - shownAt.value));
  }
  void play(w.audio);
}

function next() {
  if (index.value + 1 >= queue.value.length) { finished.value = true; return; }
  index.value++;
  void show();
}

// ---- Hear and pick ----
const choices = ref<string[]>([]);
const picked = ref<string | null>(null);
const wrongPicks = ref<string[]>([]);
function choose(c: string) {
  const w = word.value;
  if (!w || answered.value) return;
  picked.value = c;
  if (c === w.km) solved();
  else { if (!wrongPicks.value.includes(c)) wrongPicks.value.push(c); miss(); void play(w.audio); }
}

// ---- Build the word ----
const target = ref<string[]>([]);
const tiles = ref<{ id: number; p: string; used: boolean }[]>([]);
const built = ref<string[]>([]);
const wrongTile = ref<number | null>(null);
function tap(t: { id: number; p: string; used: boolean }) {
  if (answered.value || t.used) return;
  if (t.p === target.value[built.value.length]) {
    t.used = true;
    built.value.push(t.p);
    if (built.value.length === target.value.length) solved();
  } else {
    miss();
    wrongTile.value = t.id;
    setTimeout(() => (wrongTile.value = null), 450);
  }
}
const builtText = computed(() => built.value.join(''));

function quit() { playingRound.value = false; finished.value = false; }
</script>

<template>
  <div>
    <!-- Setup -->
    <div v-if="!playingRound" class="space-y-5">
      <div>
        <p class="mb-2 font-medium"><T km="ល្បែង" en="Game" /></p>
        <div class="grid gap-3 sm:grid-cols-2">
          <button type="button" class="card text-left transition" :class="mode === 'pick' ? '!border-brand-600 ring-2 ring-brand-500/30' : 'hover:border-brand-500'" @click="mode = 'pick'">
            <span class="block font-semibold"><T km="ស្តាប់ ហើយជ្រើស" en="Hear and pick" /></span>
            <span class="mt-1 block text-sm text-slate-500"><T km="ស្តាប់ពាក្យ ហើយជ្រើសអក្ខរាវិរុទ្ធត្រឹមត្រូវ៖ កាច ឬ កាច់?" en="Hear a word and pick the right spelling: កាច or កាច់?" stack /></span>
          </button>
          <button type="button" class="card text-left transition" :class="mode === 'build' ? '!border-brand-600 ring-2 ring-brand-500/30' : 'hover:border-brand-500'" @click="mode = 'build'">
            <span class="block font-semibold"><T km="ផ្គុំពាក្យ" en="Build the word" /></span>
            <span class="mt-1 block text-sm text-slate-500"><T km="ស្តាប់ពាក្យ ហើយចុចអក្សរតាមលំដាប់។" en="Hear a word and tap its letters in order." stack /></span>
          </button>
        </div>
      </div>

      <div>
        <p class="mb-2 font-medium"><T km="ពាក្យពីមេរៀន" en="Words from" /></p>
        <div class="flex flex-wrap gap-2">
          <button v-for="c in ['2', '3']" :key="c" type="button" class="chip" :class="choice === c && '!border-brand-600 !bg-brand-50 dark:!bg-brand-900/50'" @click="choice = c">
            <T v-bind="chapterLabel(c)" />
          </button>
        </div>
        <div class="mt-2 flex flex-wrap gap-2">
          <button v-for="s in sets" :key="s.id" type="button" class="chip" :class="choice === s.id && '!border-brand-600 !bg-brand-50 dark:!bg-brand-900/50'" @click="choice = s.id">
            <span lang="km" class="font-khmer-serif">{{ s.title.km }}</span>
          </button>
        </div>
      </div>

      <button type="button" class="btn" :disabled="!selection.length" @click="start">
        <T km="ចាប់ផ្តើម" en="Start" /> · {{ Math.min(ROUND, selection.length) }} <T km="ពាក្យ" en="words" />
      </button>
    </div>

    <!-- Summary -->
    <div v-else-if="finished" class="card text-center" aria-live="polite">
      <p class="text-4xl font-semibold">{{ firstTry }} / {{ queue.length }}</p>
      <p class="mt-1 text-slate-500"><T km="ត្រូវលើកដំបូង" en="right on the first try" /></p>
      <template v-if="missed.length">
        <p class="mt-5 font-medium"><T km="ពាក្យដែលត្រូវហាត់បន្ថែម" en="Words to practise" /></p>
        <ul class="mx-auto mt-2 flex max-w-xl flex-wrap justify-center gap-2">
          <li v-for="m in missed" :key="m.id">
            <button type="button" class="chip" @click="play(m.audio)">
              <span lang="km" class="font-khmer-serif text-lg">{{ m.km }}</span>
              <span v-if="m.roman" class="text-xs text-slate-500">({{ m.roman }})</span>
            </button>
          </li>
        </ul>
        <p class="mt-2 text-sm text-slate-500"><T km="ពាក្យទាំងនេះនឹងមកវិញក្នុងការរំលឹកប្រចាំថ្ងៃ។" en="These words will come back in your daily review." /></p>
      </template>
      <p v-else class="mt-4 font-medium text-emerald-700 dark:text-emerald-300"><T km="ល្អឥតខ្ចោះ! 🎉" en="Perfect! 🎉" /></p>
      <div class="mt-5 flex flex-wrap justify-center gap-2">
        <button type="button" class="btn" @click="start"><T km="លេងម្តងទៀត" en="Play again" /></button>
        <button type="button" class="btn-quiet" @click="quit"><T km="ជ្រើសពាក្យផ្សេង" en="Choose other words" /></button>
        <a v-if="missed.length" href="/review" class="btn-quiet"><T km="រំលឹកប្រចាំថ្ងៃ" en="Daily review" /></a>
      </div>
    </div>

    <!-- Question -->
    <div v-else-if="word" class="card">
      <div class="mb-4 flex flex-wrap items-center gap-3">
        <p class="font-medium">
          <T v-if="mode === 'pick'" km="សរសេរយ៉ាងដូចម្តេច?" en="Which spelling?" />
          <T v-else km="ផ្គុំពាក្យដែលអ្នកឮ" en="Build the word you hear" />
        </p>
        <span class="text-sm text-slate-500">{{ index + 1 }} / {{ queue.length }}</span>
        <button type="button" class="btn-quiet ml-auto !py-1 text-sm" @click="quit"><T km="ចេញ" en="Exit" /></button>
      </div>

      <button type="button" class="btn mb-5" @click="play(word.audio)">
        <svg viewBox="0 0 24 24" class="size-5" fill="currentColor" aria-hidden="true"><path d="M4 9v6h4l5 4V5L8 9zm12.5 3a4.5 4.5 0 0 0-2.5-4v8a4.5 4.5 0 0 0 2.5-4z" /></svg>
        <T km="ស្តាប់ម្តងទៀត" en="Hear again" />
      </button>

      <!-- Hear and pick -->
      <div v-if="mode === 'pick'" class="grid grid-cols-2 gap-3">
        <button
          v-for="c in choices"
          :key="c"
          type="button"
          lang="km"
          class="font-khmer-serif rounded-2xl border-2 px-2 py-5 text-3xl transition sm:text-4xl"
          :class="answered && c === word.km ? 'border-emerald-500 bg-emerald-50 dark:bg-emerald-950/50'
            : wrongPicks.includes(c) ? 'border-rose-500 bg-rose-50 dark:bg-rose-950/40'
            : 'border-slate-200 hover:border-brand-500 dark:border-slate-700'"
          @click="choose(c)"
        >{{ c }}</button>
      </div>

      <!-- Build the word -->
      <div v-else>
        <div class="mb-4 flex min-h-20 items-center justify-center rounded-2xl border-2 border-dashed px-3 py-2"
          :class="answered ? 'border-emerald-500 bg-emerald-50 dark:bg-emerald-950/40' : 'border-slate-300 dark:border-slate-700'">
          <span lang="km" class="font-khmer-serif text-4xl leading-[1.8] sm:text-5xl">{{ builtText }}<span v-if="!answered" class="animate-pulse text-brand-600">|</span></span>
        </div>
        <div class="flex flex-wrap justify-center gap-2">
          <button
            v-for="t in tiles"
            :key="t.id"
            type="button"
            lang="km"
            class="font-khmer-serif grid min-h-16 min-w-16 place-items-center rounded-xl border-2 px-3 text-3xl transition"
            :class="t.used || answered ? 'invisible'
              : wrongTile === t.id ? 'border-rose-500 bg-rose-50 dark:bg-rose-950/40'
              : isMarkPiece(t.p) ? 'border-amber-300 hover:border-amber-500 dark:border-amber-800' : 'border-teal-300 hover:border-teal-500 dark:border-teal-800'"
            @click="tap(t)"
          >{{ tileLabel(t.p) }}</button>
        </div>
      </div>

      <!-- After answering -->
      <div v-if="answered" class="mt-5 flex flex-wrap items-center gap-x-4 gap-y-2 border-t border-slate-200 pt-4 dark:border-slate-800" aria-live="polite">
        <p class="flex-1">
          <span lang="km" class="font-khmer-serif text-2xl">{{ word.km }}</span>
          <span v-if="word.roman" class="ml-2 text-sm text-slate-500">({{ word.roman }})</span>
          <span v-if="word.en" class="block text-sm text-slate-500">{{ word.en }}</span>
        </p>
        <button type="button" class="btn" @click="next">
          <T v-if="index + 1 < queue.length" km="បន្ទាប់" en="Next" />
          <T v-else km="មើលលទ្ធផល" en="See results" />
        </button>
      </div>
      <p v-else-if="mode === 'pick' && picked" class="mt-4 text-sm text-slate-500" aria-live="polite">
        <T km="មិនទាន់ត្រូវទេ — ស្តាប់ម្តងទៀត ហើយសាកម្តងទៀត។" en="Not quite. Listen again and try another." />
      </p>
    </div>
  </div>
</template>
