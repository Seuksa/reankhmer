<script setup lang="ts">
/** Bilingual text for Vue islands; same markup as T.astro. */
defineProps<{ km: string; en: string; stack?: boolean }>();
</script>

<template>
  <span class="t" :class="{ 't-stack': stack }"><span lang="km" class="t-km">{{ km }}</span><span lang="en" class="t-en">{{ en }}</span></span>
</template>
