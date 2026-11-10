<script setup lang="ts">
import { computed, onMounted, ref } from 'vue';
import { loadProgress, markLessonDone, progress } from '../lib/progress';
import T from './T.vue';

const props = defineProps<{ lessonId: number }>();
const ready = ref(false); // show progress only after mounting (first render matches the built page)
onMounted(async () => { await loadProgress(); ready.value = true; });
const done = computed(() => ready.value && !!progress.lessons[props.lessonId]?.done);
</script>

<template>
  <p v-if="done" class="inline-flex items-center gap-2 rounded-xl bg-emerald-50 px-4 py-2 font-medium text-emerald-800 dark:bg-emerald-950/50 dark:text-emerald-200">
    ✓ <T km="បានរៀនចប់" en="Lesson complete" />
  </p>
  <button v-else class="btn" @click="markLessonDone(lessonId)"><T km="ខ្ញុំរៀនចប់ហើយ" en="I finished this lesson" /></button>
</template>
