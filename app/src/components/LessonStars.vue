<script setup lang="ts">
/** The learner's stars for one lesson (★ first part, ★★ all but the last, ★★★ finished). */
import { computed, onMounted, ref } from 'vue';
import { lessonStars, starText } from '../lib/awards';
import { loadSteps, type PlanStep } from '../lib/plan';
import { loadProgress, progress } from '../lib/progress';

const props = defineProps<{ lessonId: number; size?: 'sm' | 'lg' }>();
const steps = ref<PlanStep[]>([]);
onMounted(async () => { [steps.value] = await Promise.all([loadSteps(), loadProgress()]); });
// only once a study plan exists, and only for lessons on the path
const n = computed(() => (progress.plan && steps.value.some((s) => s.lesson === props.lessonId) ? lessonStars(props.lessonId, steps.value) : null));
</script>

<template>
  <span v-if="n !== null" class="tracking-wider text-amber-500" :class="size === 'lg' ? 'text-2xl' : 'text-sm'" :aria-label="`${n} of 3 stars`" :title="`${n}/3`">{{ starText(n) }}</span>
</template>
