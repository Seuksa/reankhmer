<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import type { Item } from '../lib/content';
import { play, playing, stop } from '../lib/audio';
import { loadProgress, markHeard, progress } from '../lib/progress';
import T from './T.vue';

const props = defineProps<{ lessonId: number; lines: Item[] }>();
onMounted(loadProgress);

const showText = ref(true);
const playingAll = ref(false);
const current = ref<number | null>(null);
// The picture shown big: the line playing now, else the last line tapped (starts on the first line with a picture).
const selected = ref(Math.max(0, props.lines.findIndex((l) => l.image)));
const shown = computed(() => current.value ?? selected.value);
const shownLine = computed(() => props.lines[shown.value]);

const SPEAKER_TONE: Record<string, string> = {
  A: 'bg-teal-100 text-teal-900 dark:bg-teal-900/60 dark:text-teal-100',
  B: 'bg-amber-100 text-amber-900 dark:bg-amber-900/50 dark:text-amber-100',
  C: 'bg-sky-100 text-sky-900 dark:bg-sky-900/50 dark:text-sky-100',
  D: 'bg-rose-100 text-rose-900 dark:bg-rose-900/50 dark:text-rose-100',
};

async function playLine(i: number) {
  const line = props.lines[i];
  selected.value = i;
  if (!line.audio) return;
  current.value = i;
  markHeard(`l:${props.lessonId}:${i}`);
  await play(`/${line.audio}`);
  if (!playingAll.value) current.value = null;
}

function step(d: number) {
  const n = props.lines.length;
  const i = (shown.value + d + n) % n;
  if (playingAll.value) { playingAll.value = false; stop(); current.value = null; }
  void playLine(i);
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
    <div class="lg:grid lg:grid-cols-[minmax(0,1fr)_minmax(0,26rem)] lg:items-start lg:gap-6">
      <ol class="space-y-3">
        <li v-for="(line, i) in lines" :key="i">
          <button
            type="button"
            class="card flex w-full flex-wrap items-center gap-3 text-left transition hover:border-brand-500"
            :class="[current === i && playing && '!border-brand-600 ring-2 ring-brand-200 dark:ring-brand-800', shown === i && '!border-brand-500']"
            :aria-pressed="shown === i"
            @click="playLine(i)"
          >
            <img v-if="line.image" :src="`/${line.image}`" alt="" loading="lazy" class="size-16 shrink-0 rounded-xl object-cover" />
            <span v-if="line.speaker" class="grid size-8 shrink-0 place-items-center rounded-full text-sm font-semibold" :class="SPEAKER_TONE[line.speaker]">{{ line.speaker }}</span>
            <span lang="km" class="flex-1 text-lg" :class="!showText && 'blur-sm select-none'">{{ line.text }}</span>
            <span v-if="progress.heard[`l:${lessonId}:${i}`]" class="text-xs text-brand-700 dark:text-brand-200" aria-label="heard">✓</span>
            <!-- phones: the tapped line opens its picture full width -->
            <img v-if="line.image && shown === i" :src="`/${line.image}`" alt="" class="w-full basis-full rounded-xl lg:hidden" />
          </button>
        </li>
      </ol>
      <!-- wide screens: the picture of the selected line, big, beside the dialogue -->
      <aside v-if="shownLine" class="card sticky top-20 hidden lg:block" aria-live="polite">
        <img v-if="shownLine.image" :key="shownLine.image" :src="`/${shownLine.image}`" alt="" class="aspect-[4/3] w-full rounded-xl object-cover" />
        <div class="mt-3 flex items-start gap-3">
          <span v-if="shownLine.speaker" class="grid size-8 shrink-0 place-items-center rounded-full text-sm font-semibold" :class="SPEAKER_TONE[shownLine.speaker]">{{ shownLine.speaker }}</span>
          <p lang="km" class="flex-1 text-xl leading-relaxed" :class="!showText && 'blur-sm select-none'">{{ shownLine.text }}</p>
        </div>
        <div class="mt-3 flex items-center gap-2">
          <button type="button" class="btn-quiet" @click="step(-1)"><span aria-hidden="true">←</span> <T km="មុន" en="Previous" /></button>
          <span class="flex-1 text-center text-sm text-slate-500">{{ shown + 1 }} / {{ lines.length }}</span>
          <button type="button" class="btn-quiet" @click="step(1)"><T km="បន្ទាប់" en="Next" /> <span aria-hidden="true">→</span></button>
        </div>
      </aside>
    </div>
  </div>
</template>
