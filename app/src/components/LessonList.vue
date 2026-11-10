<script setup lang="ts">
import { onMounted, ref } from 'vue';
import type { Bi } from '../lib/content';
import { loadProgress, progress } from '../lib/progress';
import T from './T.vue';
import LessonStars from './LessonStars.vue';

defineProps<{ lessons: { id: number; href: string; n: string; title: Bi }[] }>();
// progress shows only after mounting, so the first render matches the built page (no hydration mismatch)
const ready = ref(false);
onMounted(async () => { await loadProgress(); ready.value = true; });
const done = (id: number) => ready.value && !!progress.lessons[id]?.done;
const quiz = (id: number) => (ready.value ? progress.lessons[id]?.quiz : undefined);
</script>

<template>
  <ol class="grid gap-2 sm:grid-cols-2">
    <li v-for="l in lessons" :key="l.id">
      <a :href="l.href" class="card flex items-center gap-3 hover:border-brand-500">
        <span
          class="grid size-9 shrink-0 place-items-center rounded-full text-sm font-semibold"
          :class="done(l.id) ? 'bg-emerald-600 text-white' : 'bg-slate-100 dark:bg-slate-800'"
          lang="km"
        >{{ done(l.id) ? '✓' : l.n }}</span>
        <span class="min-w-0 flex-1"><T :km="l.title.km" :en="l.title.en" stack /></span>
        <LessonStars :lesson-id="l.id" />
        <span v-if="quiz(l.id)" class="text-xs text-slate-500">
          {{ quiz(l.id)!.score }}/{{ quiz(l.id)!.total }}
        </span>
      </a>
    </li>
  </ol>
</template>
