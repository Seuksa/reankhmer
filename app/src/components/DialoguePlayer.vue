<script setup lang="ts">
import { onMounted, ref } from 'vue';
import type { Item } from '../lib/content';
import { play, playing, stop } from '../lib/audio';
import { loadProgress, markHeard, progress } from '../lib/progress';
import T from './T.vue';

const props = defineProps<{ lessonId: number; lines: Item[] }>();
onMounted(loadProgress);

const showText = ref(true);
const playingAll = ref(false);
const current = ref<number | null>(null);

const SPEAKER_TONE: Record<string, string> = {
  A: 'bg-teal-100 text-teal-900 dark:bg-teal-900/60 dark:text-teal-100',
  B: 'bg-amber-100 text-amber-900 dark:bg-amber-900/50 dark:text-amber-100',
  C: 'bg-sky-100 text-sky-900 dark:bg-sky-900/50 dark:text-sky-100',
  D: 'bg-rose-100 text-rose-900 dark:bg-rose-900/50 dark:text-rose-100',
};

async function playLine(i: number) {
  const line = props.lines[i];
  if (!line.audio) return;
  current.value = i;
  markHeard(`l:${props.lessonId}:${i}`);
  await play(`/${line.audio}`);
  if (!playingAll.value) current.value = null;
}

async function playAll() {
  if (playingAll.value) { playingAll.value = false; stop(); current.value = null; return; }
  playingAll.value = true;
  for (let i = 0; i < props.lines.length && playingAll.value; i++) {
    await playLine(i);
    await new Promise((r) => setTimeout(r, 350));
  }
  playingAll.value = false;
  current.value = null;
}
</script>

<template>
  <div>
    <div class="mb-4 flex flex-wrap gap-2">
      <button class="btn" @click="playAll">
        <T v-if="playingAll" km="ឈប់" en="Stop" />
        <T v-else km="ស្តាប់ទាំងអស់" en="Play whole dialogue" />
      </button>
      <button class="btn-quiet" :aria-pressed="!showText" @click="showText = !showText">
        <T v-if="showText" km="លាក់អក្សរ (ស្តាប់តែប៉ុណ្ណោះ)" en="Hide text (listen only)" />
        <T v-else km="បង្ហាញអក្សរ" en="Show text" />
      </button>
    </div>
    <ol class="space-y-3">
      <li v-for="(line, i) in lines" :key="i">
        <button
          type="button"
          class="card flex w-full items-center gap-3 text-left transition hover:border-brand-500"
          :class="current === i && playing && '!border-brand-600 ring-2 ring-brand-200 dark:ring-brand-800'"
          @click="playLine(i)"
        >
          <img v-if="line.image" :src="`/${line.image}`" alt="" loading="lazy" class="size-16 shrink-0 rounded-xl object-cover" />
          <span v-if="line.speaker" class="grid size-8 shrink-0 place-items-center rounded-full text-sm font-semibold" :class="SPEAKER_TONE[line.speaker]">{{ line.speaker }}</span>
          <span lang="km" class="flex-1 text-lg" :class="!showText && 'blur-sm select-none'">{{ line.text }}</span>
          <span v-if="progress.heard[`l:${lessonId}:${i}`]" class="text-xs text-brand-700 dark:text-brand-200" aria-label="heard">✓</span>
        </button>
      </li>
    </ol>
  </div>
</template>
