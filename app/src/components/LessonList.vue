<script setup lang="ts">
import { onMounted } from 'vue';
import type { Bi } from '../lib/content';
import { loadProgress, progress } from '../lib/progress';
import T from './T.vue';

defineProps<{ lessons: { id: number; href: string; n: string; title: Bi }[] }>();
onMounted(loadProgress);
</script>

<template>
  <ol class="grid gap-2 sm:grid-cols-2">
    <li v-for="l in lessons" :key="l.id">
      <a :href="l.href" class="card flex items-center gap-3 hover:border-brand-500">
        <span
          class="grid size-9 shrink-0 place-items-center rounded-full text-sm font-semibold"
          :class="progress.lessons[l.id]?.done ? 'bg-emerald-600 text-white' : 'bg-slate-100 dark:bg-slate-800'"
          lang="km"
        >{{ progress.lessons[l.id]?.done ? '✓' : l.n }}</span>
        <span class="min-w-0 flex-1"><T :km="l.title.km" :en="l.title.en" stack /></span>
        <span v-if="progress.lessons[l.id]?.quiz" class="text-xs text-slate-500">
          {{ progress.lessons[l.id]!.quiz!.score }}/{{ progress.lessons[l.id]!.quiz!.total }}
        </span>
      </a>
    </li>
  </ol>
</template>
