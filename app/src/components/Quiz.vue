<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import type { Question } from '../lib/content';
import { loadProgress, progress, saveQuiz } from '../lib/progress';
import AudioButton from './AudioButton.vue';
import T from './T.vue';

/** audio[i] (optional) is played for question i — the 2006 listening test for dialogues. */
const props = defineProps<{ lessonId: number; questions: Question[]; audio?: (string | undefined)[] }>();
onMounted(loadProgress);

const answers = ref<Record<number, number>>({});
const submitted = ref(false);
const best = computed(() => progress.lessons[props.lessonId]?.quiz);
const score = computed(() => props.questions.filter((q) => q.choices[answers.value[q.id]]?.correct).length);
const complete = computed(() => props.questions.every((q) => answers.value[q.id] !== undefined));

// "PART 2 :: B" -> part 2, speaker B (dialogue listening test)
const label = (q: Question) => {
  const m = q.question.match(/^PART\s*(\d+)\s*::\s*(\w)/);
  return m ? { km: `ផ្នែកទី ${m[1]} · អ្នកនិយាយ ${m[2]}`, en: `Part ${m[1]} · speaker ${m[2]}` } : null;
};

function submit() {
  submitted.value = true;
  saveQuiz(props.lessonId, score.value, props.questions.length);
}
function retry() { answers.value = {}; submitted.value = false; }

function choiceClass(q: Question, i: number) {
  const picked = answers.value[q.id] === i;
  if (!submitted.value) return picked ? 'border-brand-600 bg-brand-50 dark:bg-brand-900/40' : '';
  if (q.choices[i].correct) return 'border-emerald-500 bg-emerald-50 dark:bg-emerald-950/50';
  return picked ? 'border-rose-500 bg-rose-50 dark:bg-rose-950/40' : 'opacity-60';
}
</script>

<template>
  <div>
    <p v-if="best" class="mb-4 text-sm text-slate-500">
      <T km="ពិន្ទុល្អបំផុត" en="Best score" />: {{ best.score }}/{{ best.total }}
    </p>
    <ol class="space-y-5">
      <li v-for="(q, qi) in questions" :key="q.id" class="card">
        <div class="mb-3 flex flex-wrap items-center gap-3">
          <p v-if="label(q)" class="font-medium"><T v-bind="label(q)!" /></p>
          <p v-else lang="km" class="text-lg font-medium">{{ q.question }}</p>
          <AudioButton v-if="audio?.[qi]" :src="`/${audio[qi]}`" size="sm" label="▶" />
        </div>
        <div class="grid gap-2 sm:grid-cols-3">
          <button
            v-for="(c, i) in q.choices"
            :key="i"
            type="button"
            lang="km"
            class="rounded-xl border-2 border-slate-200 px-3 py-2 text-left text-lg transition dark:border-slate-700"
            :class="choiceClass(q, i)"
            :disabled="submitted"
            :aria-pressed="answers[q.id] === i"
            @click="answers[q.id] = i"
          >{{ c.text }}</button>
        </div>
      </li>
    </ol>
    <div class="mt-5 flex flex-wrap items-center gap-3" aria-live="polite">
      <button v-if="!submitted" class="btn" :disabled="!complete" @click="submit"><T km="ពិនិត្យចម្លើយ" en="Check answers" /></button>
      <template v-else>
        <p class="text-lg font-semibold">{{ score }}/{{ questions.length }}
          <T v-if="score === questions.length" km="ពូកែណាស់!" en="Excellent!" />
          <T v-else km="ល្អ! សាកម្តងទៀត" en="Good — try again" />
        </p>
        <button class="btn-quiet" @click="retry"><T km="ធ្វើម្តងទៀត" en="Try again" /></button>
      </template>
    </div>
  </div>
</template>
