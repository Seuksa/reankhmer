// Spaced-repetition review (FSRS) for letters, vowel sounds, numbers and spelling words.
// Words only become cards when the learner misses them in the spelling games (see SpellingGame.vue).
// Every card is a "listen and pick" question, graded automatically:
// wrong first answer -> Again (the card returns later in the session), right -> Good, right within 2.5 s -> Easy.
import { createEmptyCard, fsrs, Rating, type Card, type Grade } from 'ts-fsrs';
import { loadProgress, progress, saveCards, type StoredCardLike } from './progress';
import { spellingChoices } from './spelling';

export interface ReviewItem {
  id: string;            // "c:1", "v:3:2", "n:five", "w:karch"
  kind: 'consonant' | 'vowel' | 'number' | 'word';
  audio: string;         // /assets/...
  answer: string;        // what the learner must pick
  pool: string;          // items in the same pool are used as wrong options
  series?: 1 | 2;
}

export interface StoredCard extends Omit<Card, 'due' | 'last_review'> { due: string; last_review?: string }

const scheduler = fsrs({ enable_fuzz: true });
export const NEW_PER_DAY = 10;

/** Local calendar date (YYYY-MM-DD), so "new cards per day" resets at the learner's midnight, not UTC. */
const today = () => new Date().toLocaleDateString('en-CA');
const toCard = (c: StoredCard | StoredCardLike): Card => (c = c as StoredCard, ({ ...c, due: new Date(c.due), last_review: c.last_review ? new Date(c.last_review) : undefined }));
const toStored = (c: Card): StoredCard => ({ ...c, due: c.due.toISOString(), last_review: c.last_review?.toISOString() });

export function dueIds(items: ReviewItem[], now = new Date()): string[] {
  const cards = progress.cards ?? {};
  return items
    .filter((i) => cards[i.id] && new Date(cards[i.id].due) <= now)
    .sort((a, b) => cards[a.id].due.localeCompare(cards[b.id].due))
    .map((i) => i.id);
}

export function newIdsLeftToday(items: ReviewItem[]): string[] {
  const cards = progress.cards ?? {};
  const used = progress.reviewDay?.date === today() ? progress.reviewDay.newCount : 0;
  const left = Math.max(0, NEW_PER_DAY - used);
  // Items the learner already met (heard) come first, then the rest in course order.
  // Words are never introduced as new cards here: they enter review from the spelling games.
  const fresh = items.filter((i) => !cards[i.id] && i.kind !== 'word');
  const heard = fresh.filter((i) => progress.heard[i.id]);
  const rest = fresh.filter((i) => !progress.heard[i.id]);
  return [...heard, ...rest].slice(0, left).map((i) => i.id);
}

export async function sessionIds(items: ReviewItem[]) {
  await loadProgress();
  return { due: dueIds(items), fresh: newIdsLeftToday(items) };
}

/** countNew=false: the card comes from a game, so it does not use up today's new-card allowance. */
export function grade(id: string, rating: Grade, countNew = true) {
  const cards = { ...(progress.cards ?? {}) };
  const isNew = !cards[id];
  const card = isNew ? createEmptyCard(new Date()) : toCard(cards[id]);
  cards[id] = toStored(scheduler.next(card, new Date(), rating).card) as unknown as StoredCardLike;
  const day = progress.reviewDay?.date === today() ? { ...progress.reviewDay } : { date: today(), newCount: 0, reviews: 0 };
  if (isNew && countNew) day.newCount++;
  day.reviews = (day.reviews ?? 0) + 1;
  saveCards(cards, day);
}

export function ratingFor(correctFirstTry: boolean, slipped: boolean, ms: number): Grade {
  if (!correctFirstTry && !slipped) return Rating.Again;
  if (slipped) return Rating.Hard;
  return ms < 2500 ? Rating.Easy : Rating.Good;
}
export { Rating };

/** Four options: the answer plus three others from the same pool, shuffled. */
export function options(item: ReviewItem, items: ReviewItem[]): string[] {
  if (item.kind === 'word') {
    const asWord = (i: ReviewItem) => ({ id: i.id, key: i.id, km: i.answer, audio: i.audio, set: i.pool });
    return spellingChoices(asWord(item), items.filter((i) => i.kind === 'word').map(asWord));
  }
  const others = [...new Set(items.filter((i) => i.pool === item.pool && i.answer !== item.answer).map((i) => i.answer))];
  const pick = others.sort(() => Math.random() - 0.5).slice(0, 3);
  return [item.answer, ...pick].sort(() => Math.random() - 0.5);
}
