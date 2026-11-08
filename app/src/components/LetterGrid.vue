<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import type { Consonant } from '../lib/content';
import { play } from '../lib/audio';
import { loadProgress, markHeard, progress } from '../lib/progress';
import T from './T.vue';

const props = defineProps<{ letters: Consonant[]; game?: boolean }>();
onMounted(loadProgress);

const filter = ref<0 | 1 | 2>(0);
const shown = computed(() => props.letters.filter((c) => !filter.value || c.series === filter.value));

async function tap(c: Consonant) {
  if (mode.value === 'find') return guess(c);
  markHeard(`c:${c.id}`);
  if (c.audio) await play(`/${c.audio}`);
}

// ---- "Listen & find": hear a letter, tap it among 4 ----
const mode = ref<'learn' | 'find'>('learn');
const options = ref<Consonant[]>([]);
const target = ref<Consonant | null>(null);
const feedback = ref<'right' | 'wrong' | null>(null);
const score = ref({ right: 0, tries: 0 });

function shuffle<T>(a: T[]) { return a.map((v) => [Math.random(), v] as const).sort((x, y) => x[0] - y[0]).map((x) => x[1]); }

async function nextRound() {
  feedback.value = null;
  const pool = props.letters.filter((c) => c.audio);
  const pick = shuffle(pool).slice(0, Math.min(4, pool.length));
  target.value = pick[0];
  options.value = shuffle(pick);
  await play(`/${target.value.audio}`);
}
function startGame() { mode.value = 'find'; score.value = { right: 0, tries: 0 }; void nextRound(); }
async function guess(c: Consonant) {
  if (!target.value || feedback.value === 'right') return;
  score.value.tries++;
  if (c.id === target.value.id) {
    score.value.right++;
    feedback.value = 'right';
    markHeard(`c:${c.id}`);
    setTimeout(nextRound, 900);
  } else {
    feedback.value = 'wrong';
    await play(`/${target.value.audio}`);
  }
}

const tone = (c: Consonant) => c.series === 1
  ? 'border-teal-300 bg-teal-50 text-teal-900 dark:border-teal-800 dark:bg-teal-950/50 dark:text-teal-100'
  : 'border-amber-300 bg-amber-50 text-amber-900 dark:border-amber-800 dark:bg-amber-950/40 dark:text-amber-100';
</script>

<template>
  <div>
    <div class="mb-4 flex flex-wrap items-center gap-2">
      <template v-if="mode === 'learn'">
        <button v-for="f in ([0, 1, 2] as const)" :key="f" class="chip" :class="filter === f && '!border-brand-600 !bg-brand-50 dark:!bg-brand-900/50'" @click="filter = f">
          <T v-if="f === 0" km="ទាំងអស់" en="All" />
          <T v-else-if="f === 1" km="អក្សរសំឡេងអ" en="a-series" />
          <T v-else km="អក្សរសំឡេងអូ" en="o-series" />
        </button>
        <button v-if="game" class="btn ml-auto" @click="startGame"><T km="ស្តាប់ ហើយរក" en="Listen & find" /></button>
      </template>
      <template v-else>
        <button class="btn" @click="target && play(`/${target.audio}`)"><T km="ស្តាប់ម្តងទៀត" en="Hear again" /></button>
        <span class="text-sm text-slate-500"><T km="ពិន្ទុ" en="Score" /> {{ score.right }}/{{ score.tries }}</span>
        <button class="btn-quiet ml-auto" @click="mode = 'learn'"><T km="ឈប់" en="Stop" /></button>
      </template>
    </div>

    <p v-if="mode === 'find'" class="mb-3 text-lg" aria-live="polite">
      <T v-if="feedback === 'right'" km="ត្រូវហើយ! 🎉" en="Correct!" />
      <T v-else-if="feedback === 'wrong'" km="សាកម្តងទៀត" en="Try again" />
      <T v-else km="តើអក្សរណា?" en="Which letter did you hear?" />
    </p>

    <ul class="grid gap-3" :class="mode === 'find' ? 'grid-cols-2 sm:grid-cols-4' : 'grid-cols-3 sm:grid-cols-5 lg:grid-cols-6'">
      <li v-for="c in mode === 'find' ? options : shown" :key="c.id">
        <button
          type="button"
          class="relative flex aspect-square w-full flex-col items-center justify-center rounded-2xl border-2 transition hover:scale-[1.03] active:scale-95"
          :class="[tone(c), mode === 'find' && feedback === 'right' && c.id === target?.id && 'ring-4 ring-brand-500']"
          :aria-label="mode === 'find' ? `Option ${c.char}` : `${c.char} ${c.roman}`"
          @click="tap(c)"
        >
          <span lang="km" class="font-khmer-serif text-5xl leading-none sm:text-6xl">{{ c.char }}</span>
          <span v-if="mode === 'learn'" class="mt-2 text-sm opacity-75">{{ c.roman }}</span>
          <span v-if="mode === 'learn' && progress.heard[`c:${c.id}`]" class="absolute top-2 right-2 text-xs text-brand-700 dark:text-brand-200" aria-label="heard">✓</span>
        </button>
      </li>
    </ul>
  </div>
</template>
