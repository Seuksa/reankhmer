// Sharing a picture made on this device (report, certificate): the phone's share sheet when it
// can take files (Telegram, Messenger, WhatsApp…), otherwise a download.

export function saveFile(f: File) {
  const a = document.createElement('a');
  a.href = URL.createObjectURL(f);
  a.download = f.name;
  a.click();
  setTimeout(() => URL.revokeObjectURL(a.href), 5000);
}

/** Returns 'shared' (share sheet opened) or 'saved' (downloaded instead). */
export async function sharePicture(blob: Blob, name: string, title = 'ReanKhmer'): Promise<'shared' | 'saved'> {
  const file = new File([blob], name, { type: 'image/png' });
  if (navigator.canShare?.({ files: [file] })) {
    await navigator.share({ files: [file], title }).catch(() => {});
    return 'shared';
  }
  saveFile(file);
  return 'saved';
}

/** A safe file name from a learner's name (keeps Khmer letters). */
export const fileSafe = (s: string) => s.replace(/[^\p{L}\p{M}\p{N}]+/gu, '-').replace(/^-|-$/g, '') || 'reankhmer';

/** Waits for the site fonts so Khmer is shaped correctly on a canvas. */
export const FONT = '"Kantumruy Pro Variable", "Noto Sans Khmer", system-ui, sans-serif';
export const SERIF = '"Noto Serif Khmer Variable", "Kantumruy Pro Variable", serif';
export async function fontsReady() {
  await Promise.all([
    document.fonts.load(`700 40px ${FONT}`, 'ករៀនខ្មែរ A'),
    document.fonts.load(`400 28px ${FONT}`, 'ករៀន A'),
    document.fonts.load(`700 40px ${SERIF}`, 'ករៀនខ្មែរ'),
  ]).catch(() => {});
}
