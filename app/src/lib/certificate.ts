// A chapter certificate with the learner's name, drawn on this device (A4 landscape proportions,
// so it prints well and shares as a picture). Nothing is uploaded.
import { CHAPTER_TITLE } from './chapter-titles';
import { kd } from './plan';
import { FONT, SERIF, fontsReady } from './share';
import type { Badge } from './awards';

export async function drawCertificate(name: string, badge: Badge): Promise<Blob> {
  await fontsReady();
  const W = 1754, H = 1240; // A4 landscape at 150 dpi
  const c = document.createElement('canvas');
  c.width = W; c.height = H;
  const g = c.getContext('2d')!;
  const teal = '#0f766e', gold = '#b45309', ink = '#0f172a', soft = '#475569';

  // paper and double border
  g.fillStyle = '#fffdf7'; g.fillRect(0, 0, W, H);
  g.strokeStyle = teal; g.lineWidth = 14; g.strokeRect(40, 40, W - 80, H - 80);
  g.strokeStyle = gold; g.lineWidth = 3; g.strokeRect(70, 70, W - 140, H - 140);
  // corner ornaments
  for (const [x, y] of [[70, 70], [W - 70, 70], [70, H - 70], [W - 70, H - 70]]) {
    g.beginPath(); g.arc(x, y, 18, 0, Math.PI * 2); g.fillStyle = gold; g.fill();
  }

  const text = (s: string, y: number, size: number, color: string, weight = 400, font = FONT) => {
    g.font = `${weight} ${size}px ${font}`; g.fillStyle = color; g.textAlign = 'center';
    // shrink long lines (long names, long chapter titles) to fit inside the border
    let sz = size;
    while (g.measureText(s).width > W - 260 && sz > 20) { sz -= 2; g.font = `${weight} ${sz}px ${font}`; }
    g.fillText(s, W / 2, y);
  };

  text('រៀនខ្មែរ · ReanKhmer', 145, 38, teal, 600);
  text('វិញ្ញាបនបត្រ', 265, 96, ink, 700, SERIF);
  text('Certificate of achievement', 380, 44, soft, 400);

  text('សូមបញ្ជាក់ថា · This certifies that', 475, 36, soft);
  text(name, 610, 120, teal, 700, SERIF);
  g.strokeStyle = gold; g.lineWidth = 3; g.beginPath(); g.moveTo(W / 2 - 420, 660); g.lineTo(W / 2 + 420, 660); g.stroke();

  const ch = badge.chapter ?? 0;
  const t = CHAPTER_TITLE[ch] ?? { km: '', en: '' };
  text(`បានរៀនចប់ ជំពូកទី ${kd(ch)}៖ ${t.km}`, 755, 50, ink, 600);
  text(`has finished Chapter ${ch}: ${t.en}`, 820, 40, soft);

  // the badge as a seal
  const sx = W / 2, sy = 970;
  g.beginPath(); g.arc(sx, sy, 92, 0, Math.PI * 2); g.fillStyle = teal; g.fill();
  g.beginPath(); g.arc(sx, sy, 78, 0, Math.PI * 2); g.strokeStyle = '#fde68a'; g.lineWidth = 4; g.stroke();
  g.font = `700 ${badge.icon.length > 2 ? 64 : 80}px ${SERIF}`; g.fillStyle = '#ffffff'; g.textAlign = 'center'; g.textBaseline = 'middle';
  g.fillText(badge.icon, sx, sy + 4);
  g.textBaseline = 'alphabetic';
  text(`${badge.title.km} · ${badge.title.en}`, 1105, 34, gold, 600);

  const when = new Date(badge.earned ?? Date.now());
  const dateEn = when.toLocaleDateString('en-GB', { day: 'numeric', month: 'long', year: 'numeric' });
  g.font = `400 30px ${FONT}`; g.fillStyle = soft;
  g.textAlign = 'left'; g.fillText(dateEn, 150, H - 120);
  g.textAlign = 'right'; g.fillText('rean.seuksa.com', W - 150, H - 120);

  return new Promise((ok, no) => c.toBlob((b) => (b ? ok(b) : no(new Error('canvas'))), 'image/png'));
}
