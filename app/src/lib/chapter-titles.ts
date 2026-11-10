// Chapter names, in their own tiny module so browser code (badges, certificates) can use them
// without pulling in the lesson content.
export interface Bi { km: string; en: string }

export const CHAPTER_TITLE: Record<number, Bi> = {
  1: { km: 'ព្យញ្ជនៈ និង ស្រៈ', en: 'Consonants & vowels' },
  2: { km: 'ការប្រកបពាក្យ', en: 'Spelling with final consonants' },
  3: { km: 'ជើងអក្សរ', en: 'Subscript consonants' },
  4: { km: 'អំណាន', en: 'Reading' },
  5: { km: 'សន្ទនា', en: 'Conversation' },
};
