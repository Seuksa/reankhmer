<script setup lang="ts">
/** "Listen to the words": each word written in Khmer with its meaning; tap to hear it. */
import { ref } from 'vue';
import { play, playing, stop } from '../lib/audio';
import T from './T.vue';

const props = defineProps<{ words: { key: string; km: string; en?: string; audio: string }[] }>();
const src = (w: { audio: string }) => `/${w.audio}`;
const all = ref(false);

async function tap(w: { audio: string }) {
  all.value = false;
  if (playing.value === src(w)) return stop();
  await play(src(w));
}

async function playAll() {
  if (all.value) { all.value = false; return stop(); }
  all.value = true;
  for (const w of props.words) {
    if (!all.value) break;
    await play(src(w));
    if (!all.value) break;
    await new Promise((r) => setTimeout(r, 400));
  }
  all.value = false;
}
</script>

<template>
  <div>
    <button type="button" class="btn-quiet mb-3 !px-3 !py-1 text-sm" @click="playAll">
      <T v-if="all" km="ឈប់" en="Stop" />
      <T v-else km="ស្តាប់ទាំងអស់" en="Play all" />
    </button>
    <ul class="grid grid-cols-2 gap-2 sm:grid-cols-3 lg:grid-cols-4">
      <li v-for="w in words" :key="w.key">
        <button
          type="button"
          class="flex h-full w-full flex-col items-start rounded-xl border-2 px-3 py-2 text-left transition active:scale-[.98]"
          :class="playing === src(w)
            ? 'border-brand-600 bg-brand-50 dark:bg-brand-900/50'
            : 'border-slate-200 hover:border-brand-500 dark:border-slate-800'"
          :aria-pressed="playing === src(w)"
          @click="tap(w)"
        >
          <span class="flex w-full items-start justify-between gap-2">
            <span lang="km" class="font-khmer-serif text-2xl leading-[1.7] sm:text-3xl">{{ w.km }}</span>
            <svg viewBox="0 0 24 24" class="mt-2 size-5 shrink-0 text-brand-700 dark:text-brand-200" fill="currentColor" aria-hidden="true">
              <path v-if="playing === src(w)" d="M7 6h3v12H7zM14 6h3v12h-3z" />
              <path v-else d="M4 9v6h4l5 4V5L8 9zm12.5 3a4.5 4.5 0 0 0-2.5-4v8a4.5 4.5 0 0 0 2.5-4zM14 3.2v2.1a7 7 0 0 1 0 13.4v2.1a9 9 0 0 0 0-17.6z" />
            </svg>
          </span>
          <span v-if="w.en" lang="en" class="text-sm text-slate-500 dark:text-slate-400">{{ w.en }}</span>
        </button>
      </li>
    </ul>
  </div>
</template>
