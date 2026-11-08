<script setup lang="ts">
import { ref } from 'vue';

/** words = Khmer vocabulary; meanings = the subset found in the 2006 dictionary. */
const props = defineProps<{ words: string[]; meanings: Record<string, string> }>();
const open = ref<string | null>(null);
</script>

<template>
  <div>
    <ul class="flex flex-wrap gap-2">
      <li v-for="w in props.words" :key="w">
        <button
          type="button"
          class="chip text-lg"
          :class="open === w && '!border-brand-600 !bg-brand-50 dark:!bg-brand-900/50'"
          :aria-expanded="open === w"
          :disabled="!meanings[w]"
          @click="open = open === w ? null : w"
        >
          <span lang="km">{{ w }}</span>
          <span v-if="meanings[w]" class="text-xs text-brand-700 dark:text-brand-200" aria-hidden="true">ⓘ</span>
        </button>
      </li>
    </ul>
    <p v-if="open && meanings[open]" class="mt-3 rounded-xl bg-slate-50 p-3 text-sm dark:bg-slate-900" aria-live="polite">
      <span lang="km" class="font-semibold">{{ open }}</span> — {{ meanings[open] }}
    </p>
  </div>
</template>
