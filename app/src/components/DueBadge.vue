<script setup lang="ts">
import { onMounted, ref } from 'vue';
import { sessionIds, type ReviewItem } from '../lib/review';

const props = defineProps<{ items: ReviewItem[] }>();
const n = ref<number | null>(null);
onMounted(async () => {
  const { due, fresh } = await sessionIds(props.items);
  n.value = due.length + fresh.length;
});
</script>

<template>
  <span v-if="n" class="rounded-full bg-rose-600 px-2 py-0.5 text-xs font-semibold text-white" :aria-label="`${n} cards to review`">{{ n }}</span>
  <span v-else-if="n === 0" class="text-xs text-emerald-600">✓</span>
</template>
