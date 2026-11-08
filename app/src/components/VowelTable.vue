<script setup lang="ts">
import { onMounted } from 'vue';
import type { Vowel } from '../lib/content';
import { loadProgress, progress } from '../lib/progress';
import AudioButton from './AudioButton.vue';
import T from './T.vue';

defineProps<{ vowels: Vowel[] }>();
onMounted(loadProgress);
// Each vowel sounds different after an a-series consonant (ក) and an o-series consonant (គ).
</script>

<template>
  <div class="overflow-hidden rounded-2xl border border-slate-200 dark:border-slate-800">
    <div class="grid grid-cols-[4.5rem_1fr_1fr] bg-slate-50 px-3 py-2 text-sm font-medium dark:bg-slate-900">
      <span><T km="ស្រៈ" en="Vowel" stack /></span>
      <span class="text-teal-800 dark:text-teal-200"><T km="ជាមួយ ក" en="with a-series" stack /></span>
      <span class="text-amber-800 dark:text-amber-200"><T km="ជាមួយ គ" en="with o-series" stack /></span>
    </div>
    <ul>
      <li v-for="v in vowels" :key="v.id" class="grid grid-cols-[4.5rem_1fr_1fr] items-center gap-2 border-t border-slate-200 px-3 py-2 dark:border-slate-800">
        <span lang="km" class="font-khmer-serif text-4xl text-slate-500">{{ v.sign ? '◌' + v.sign : '◌' }}</span>
        <span class="flex items-center gap-3">
          <span lang="km" class="font-khmer-serif w-14 text-3xl">{{ 'ក' + v.sign }}</span>
          <AudioButton v-if="v.audio_series1" :src="`/${v.audio_series1}`" :heard-key="`v:${v.id}:1`" size="sm" />
          <span v-if="progress.heard[`v:${v.id}:1`]" class="text-xs text-brand-700 dark:text-brand-200">✓</span>
        </span>
        <span class="flex items-center gap-3">
          <span lang="km" class="font-khmer-serif w-14 text-3xl">{{ 'គ' + v.sign }}</span>
          <AudioButton v-if="v.audio_series2" :src="`/${v.audio_series2}`" :heard-key="`v:${v.id}:2`" size="sm" />
          <span v-if="progress.heard[`v:${v.id}:2`]" class="text-xs text-brand-700 dark:text-brand-200">✓</span>
        </span>
      </li>
    </ul>
  </div>
</template>
