<script setup lang="ts">
import { computed } from 'vue';
import { play, playing, stop } from '../lib/audio';
import { markHeard } from '../lib/progress';

const props = defineProps<{ src: string; label?: string; heardKey?: string; size?: 'sm' | 'md' | 'lg' }>();
const active = computed(() => playing.value === props.src);

async function toggle() {
  if (active.value) return stop();
  if (props.heardKey) markHeard(props.heardKey);
  await play(props.src);
}
</script>

<template>
  <button
    type="button"
    class="inline-flex items-center gap-2 rounded-full font-medium transition"
    :class="[
      active ? 'bg-brand-700 text-white' : 'bg-brand-50 text-brand-800 hover:bg-brand-100 dark:bg-brand-900/40 dark:text-brand-100',
      size === 'lg' ? 'px-5 py-3 text-base' : size === 'sm' ? 'px-2.5 py-1 text-sm' : 'px-4 py-2',
    ]"
    :aria-label="label ? undefined : 'Play audio'"
    :aria-pressed="active"
    @click="toggle"
  >
    <svg viewBox="0 0 24 24" class="size-5 shrink-0" fill="currentColor" aria-hidden="true">
      <path v-if="active" d="M7 6h3v12H7zM14 6h3v12h-3z" />
      <path v-else d="M4 9v6h4l5 4V5L8 9zm12.5 3a4.5 4.5 0 0 0-2.5-4v8a4.5 4.5 0 0 0 2.5-4zM14 3.2v2.1a7 7 0 0 1 0 13.4v2.1a9 9 0 0 0 0-17.6z" />
    </svg>
    <span v-if="label || $slots.default"><slot>{{ label }}</slot></span>
  </button>
</template>
