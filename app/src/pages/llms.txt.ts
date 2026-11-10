// /llms.txt: a plain-text guide to the site for AI assistants and answer engines (llmstxt.org).
// Built from the lesson content, so it stays in step with the site.
import type { APIRoute } from 'astro';
import { chapters, CHAPTER_TITLE, lessonHref, lessonTitle } from '../lib/content';

export const GET: APIRoute = ({ site }) => {
  const u = (p: string) => new URL(p, site).toString();
  const lessons = chapters.flatMap((ch) => [
    ``,
    `### Chapter ${ch.number}: ${CHAPTER_TITLE[ch.number].en} (${CHAPTER_TITLE[ch.number].km})`,
    ...ch.lessons.map((l) => {
      const t = lessonTitle(ch.number, l);
      return `- [${t.en}](${u(lessonHref(ch.number, l.number))}): ${t.km}`;
    }),
  ]);
  const body = [
    `# ReanKhmer (រៀនខ្មែរ)`,
    ``,
    `> Free, bilingual (Khmer–English) course to learn to read, hear, write and speak Khmer (Cambodian), for beginners and for Khmer families abroad. Recordings by native speakers. Works offline as an installable web app; no account, no ads.`,
    ``,
    `ReanKhmer was first built in 2006 by three students at the Royal University of Phnom Penh, with native speakers recorded at CSC Cambodia. It was rebuilt for the web in 2026 with those original recordings and animations. It is free, without ads, and needs no account; learner progress and voice recordings stay on the learner's own device. Story: https://seuksa.com/blog/reankhmer-story/`,
    ``,
    `## Start here`,
    `- [Consonants](${u('/letters')}): the 33 Khmer consonants in two series, with sound, name and romanisation`,
    `- [Vowels](${u('/vowels')}): dependent vowels with both consonant series (ក and គ)`,
    `- [Numbers](${u('/numbers')}): Khmer digits and numbers from zero to a million`,
    `- [All lessons](${u('/lessons')}): the full course in order`,
    ``,
    `## Practice`,
    `- [Daily review](${u('/review')}): listen and pick, with spaced repetition of missed items`,
    `- [Spelling games](${u('/spelling')}): hear a word and pick it, or build it from its letters`,
    `- [Speaking practice](${u('/speak')}): listen, record yourself, compare loudness and pitch`,
    `- [Writing](${u('/writing')}): stroke-order animations, then trace`,
    `- [Syllables](${u('/syllables')}): consonant + vowel + subscript builder with audio`,
    `- [Typing](${u('/typing')}): the NiDA Khmer keyboard and a typing game`,
    ``,
    `## Lessons`,
    ...lessons,
    ``,
    `## About`,
    `- Part of Seuksa (https://seuksa.com), education for Khmer society. Site: ${u('/')}`,
  ].join('\n');
  return new Response(body + '\n', { headers: { 'Content-Type': 'text/plain; charset=utf-8' } });
};
