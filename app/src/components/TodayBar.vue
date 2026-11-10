<script setup lang="ts">
/**
 * A slim "today" line under the header on every page (except home and the report, which show
 * the full plan): today's step, the review, and this week's dots. Also remembers the last lesson
 * or practice page for "Continue". Shows nothing until the learner has started a study plan.
 */
import { computed, onMounted, ref } from 'vue';
import { kd, useStudyDay } from '../lib/plan';
import { loadProgress, progress, setLast } from '../lib/progress';
import { activeProfile, type Profile } from '../lib/profiles';
import T from './T.vue';

const props = defineProps<{ title: string; hide?: boolean }>();
const me = ref<Profile | null>(null);
const { step, stepOk, reviewOk, done, weekCount, goal } = useStudyDay();
const show = computed(() => !props.hide && !!me.value && !!progress.plan);
const onStepPage = computed(() => !!step.value && location.pathname + location.search === step.value.href);

// pages worth returning to (not the review: that is part of every day's task anyway)
const RESUME = /^\/(lessons\/\d|spelling|speak|writing|syllables|typing|letters|vowels|numbers)/;
onMounted(async () => {
  me.value = activeProfile();
  await loadProgress();
  const path = location.pathname.replace(/\.html$/, '') + location.search;
  if (me.value && RESUME.test(path)) setLast(path, props.title, props.title);
});
</script>

<template>
  <div v-if="show" class="border-b border-slate-200 bg-brand-50/70 text-sm dark:border-slate-800 dark:bg-brand-950/40">
    <div class="mx-auto flex max-w-5xl flex-wrap items-center gap-x-4 gap-y-1 px-4 py-1.5">
      <a href="/" class="flex items-center gap-1.5 font-medium">
        <span class="inline-block size-2.5 rounded-full" :style="{ background: me!.color }" aria-hidden="true" />{{ me!.name }}
      </a>
      <span v-if="done" class="font-medium text-emerald-700 dark:text-emerald-300">🎉 <T km="កិច្ចការថ្ងៃនេះរួចរាល់" en="Today's task done" /></span>
      <template v-else>
        <a href="/review" :class="reviewOk ? 'text-emerald-700 dark:text-emerald-300' : 'underline underline-offset-2'">
          {{ reviewOk ? '✓' : '○' }} <T km="រំលឹក" en="Review" />
        </a>
        <a v-if="step" :href="step.href" class="min-w-0 truncate" :class="stepOk ? 'text-emerald-700 dark:text-emerald-300' : onStepPage ? 'font-medium' : 'underline underline-offset-2'">
          {{ stepOk ? '✓' : '○' }} <T :km="`${kd(step.ch)}.${kd(step.n)} · ${step.task.km}`" :en="`${step.ch}.${step.n} · ${step.task.en}`" />
        </a>
      </template>
      <span class="ml-auto text-slate-600 dark:text-slate-400" :title="`${weekCount}/${goal}`">
        <T :km="`សប្តាហ៍នេះ ${kd(weekCount)}/${kd(goal)}`" :en="`This week ${weekCount}/${goal}`" />
        <span v-if="weekCount >= goal"> ⭐</span>
      </span>
    </div>
  </div>
</template>
