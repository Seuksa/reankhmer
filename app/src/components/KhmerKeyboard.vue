<script setup lang="ts">
import { ROWS, display, type KeyDef } from '../lib/nida';

const props = defineProps<{ next?: { code: string; shift: boolean } | null; shiftOn: boolean; flash?: string | null }>();
const emit = defineEmits<{ press: [key: KeyDef | 'Space']; shift: [] }>();

const indent = ['', 'ml-[3%]', 'ml-[5%]', 'ml-[8%]'];
const isNext = (d: KeyDef) => props.next?.code === d.code;
</script>

<template>
  <div class="select-none rounded-2xl bg-slate-100 p-1.5 sm:p-2 dark:bg-slate-900" aria-label="NiDA Khmer keyboard">
    <div v-for="(row, r) in ROWS" :key="r" class="mb-1 flex gap-1" :class="indent[r]">
      <button
        v-if="r === 3"
        type="button"
        class="flex w-[9%] items-center justify-center rounded-lg border text-[0.6rem] font-medium sm:text-xs"
        :class="shiftOn || next?.shift ? 'border-brand-600 bg-brand-600 text-white' : 'border-slate-300 bg-white dark:border-slate-700 dark:bg-slate-800'"
        :aria-pressed="shiftOn"
        @click="emit('shift')"
      >⇧ Shift</button>
      <button
        v-for="d in row"
        :key="d.code"
        type="button"
        class="relative flex aspect-[4/5] min-w-0 flex-1 flex-col items-center justify-center rounded-lg border leading-none transition sm:aspect-square"
        :class="[
          isNext(d) ? 'border-brand-600 bg-brand-100 ring-2 ring-brand-500 dark:bg-brand-900' : 'border-slate-300 bg-white dark:border-slate-700 dark:bg-slate-800',
          flash === d.code && 'animate-pulse !border-rose-500 !bg-rose-100 dark:!bg-rose-950',
          (d.code === 'KeyF' || d.code === 'KeyJ') && 'underline decoration-2 underline-offset-4',
        ]"
        :aria-label="`${d.latin}: ${d.normal}, shift ${d.shift}`"
        @click="emit('press', d)"
      >
        <span class="absolute top-0.5 left-1 text-[0.5rem] text-slate-400 sm:text-[0.6rem]">{{ d.latin }}</span>
        <span lang="km" class="text-[0.6rem] sm:text-sm" :class="isNext(d) && next?.shift ? 'font-bold text-brand-800 dark:text-brand-100' : 'text-slate-400'">{{ display(d.shift) }}</span>
        <span lang="km" class="text-sm sm:text-xl" :class="isNext(d) && !next?.shift && 'font-bold text-brand-800 dark:text-brand-100'">{{ display(d.normal) }}</span>
      </button>
    </div>
    <div class="flex justify-center">
      <button
        type="button"
        class="h-9 w-1/2 rounded-lg border text-xs"
        :class="next?.code === 'Space' ? 'border-brand-600 bg-brand-100 ring-2 ring-brand-500 dark:bg-brand-900' : 'border-slate-300 bg-white dark:border-slate-700 dark:bg-slate-800'"
        @click="emit('press', 'Space')"
      >space</button>
    </div>
  </div>
</template>
