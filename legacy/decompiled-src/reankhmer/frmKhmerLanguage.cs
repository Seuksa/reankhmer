using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace reankhmer;

public class frmKhmerLanguage : Form
{
	[AccessedThroughProperty("txtIntro")]
	private TextBox _txtIntro;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("cmdVowel")]
	private Button _cmdVowel;

	[AccessedThroughProperty("cmdNumber")]
	private Button _cmdNumber;

	[AccessedThroughProperty("cmdIndependence")]
	private Button _cmdIndependence;

	[AccessedThroughProperty("PrintDocument1")]
	private PrintDocument _PrintDocument1;

	[AccessedThroughProperty("cmdPrint")]
	private Button _cmdPrint;

	[AccessedThroughProperty("lblTitle")]
	private Label _lblTitle;

	[AccessedThroughProperty("cmdClose")]
	private Button _cmdClose;

	[AccessedThroughProperty("cmdConsonant")]
	private Button _cmdConsonant;

	[AccessedThroughProperty("cboKhmer")]
	private ComboBox _cboKhmer;

	private IContainer components;

	[SpecialName]
	private int _0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar;

	internal virtual TextBox txtIntro
	{
		get
		{
			return _txtIntro;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtIntro != null)
			{
			}
			_txtIntro = value;
			if (_txtIntro == null)
			{
			}
		}
	}

	internal virtual Button cmdVowel
	{
		get
		{
			return _cmdVowel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdVowel != null)
			{
				_cmdVowel.Click -= cmdVowel_Click;
			}
			_cmdVowel = value;
			if (_cmdVowel != null)
			{
				_cmdVowel.Click += cmdVowel_Click;
			}
		}
	}

	internal virtual Button cmdConsonant
	{
		get
		{
			return _cmdConsonant;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdConsonant != null)
			{
				_cmdConsonant.Click -= cmdConsonant_Click;
			}
			_cmdConsonant = value;
			if (_cmdConsonant != null)
			{
				_cmdConsonant.Click += cmdConsonant_Click;
			}
		}
	}

	internal virtual Button cmdNumber
	{
		get
		{
			return _cmdNumber;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdNumber != null)
			{
				_cmdNumber.Click -= cmdNumber_Click;
			}
			_cmdNumber = value;
			if (_cmdNumber != null)
			{
				_cmdNumber.Click += cmdNumber_Click;
			}
		}
	}

	internal virtual Button cmdClose
	{
		get
		{
			return _cmdClose;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdClose != null)
			{
				_cmdClose.Click -= cmdClose_Click;
			}
			_cmdClose = value;
			if (_cmdClose != null)
			{
				_cmdClose.Click += cmdClose_Click;
			}
		}
	}

	internal virtual Label lblTitle
	{
		get
		{
			return _lblTitle;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblTitle != null)
			{
			}
			_lblTitle = value;
			if (_lblTitle == null)
			{
			}
		}
	}

	internal virtual TextBox TextBox1
	{
		get
		{
			return _TextBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_TextBox1 != null)
			{
			}
			_TextBox1 = value;
			if (_TextBox1 == null)
			{
			}
		}
	}

	internal virtual Button cmdPrint
	{
		get
		{
			return _cmdPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdPrint != null)
			{
				_cmdPrint.Click -= cmdPrint_Click;
			}
			_cmdPrint = value;
			if (_cmdPrint != null)
			{
				_cmdPrint.Click += cmdPrint_Click;
			}
		}
	}

	internal virtual PrintDocument PrintDocument1
	{
		get
		{
			return _PrintDocument1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_PrintDocument1 != null)
			{
				_PrintDocument1.PrintPage -= PrintDocument1_PrintPage;
			}
			_PrintDocument1 = value;
			if (_PrintDocument1 != null)
			{
				_PrintDocument1.PrintPage += PrintDocument1_PrintPage;
			}
		}
	}

	internal virtual Label Label1
	{
		get
		{
			return _Label1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Label1 != null)
			{
			}
			_Label1 = value;
			if (_Label1 == null)
			{
			}
		}
	}

	internal virtual ComboBox cboKhmer
	{
		get
		{
			return _cboKhmer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cboKhmer != null)
			{
				_cboKhmer.SelectedIndexChanged -= cboKhmer_SelectedIndexChanged;
			}
			_cboKhmer = value;
			if (_cboKhmer != null)
			{
				_cboKhmer.SelectedIndexChanged += cboKhmer_SelectedIndexChanged;
			}
		}
	}

	internal virtual Button cmdIndependence
	{
		get
		{
			return _cmdIndependence;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdIndependence != null)
			{
				_cmdIndependence.Click -= cmdIndependence_Click;
			}
			_cmdIndependence = value;
			if (_cmdIndependence != null)
			{
				_cmdIndependence.Click += cmdIndependence_Click;
			}
		}
	}

	public frmKhmerLanguage()
	{
		base.Load += frmKhmerLanguage_Load;
		base.Resize += frmKhmerLanguage_Resize;
		InitializeComponent();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	[System.Diagnostics.DebuggerStepThrough]
	private void InitializeComponent()
	{
		this.txtIntro = new System.Windows.Forms.TextBox();
		this.cmdVowel = new System.Windows.Forms.Button();
		this.cmdConsonant = new System.Windows.Forms.Button();
		this.cmdNumber = new System.Windows.Forms.Button();
		this.cmdClose = new System.Windows.Forms.Button();
		this.lblTitle = new System.Windows.Forms.Label();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.cmdPrint = new System.Windows.Forms.Button();
		this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
		this.Label1 = new System.Windows.Forms.Label();
		this.cboKhmer = new System.Windows.Forms.ComboBox();
		this.cmdIndependence = new System.Windows.Forms.Button();
		this.SuspendLayout();
		this.txtIntro.AutoSize = false;
		this.txtIntro.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txtIntro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtIntro.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox = this.txtIntro;
		System.Drawing.Point location = new System.Drawing.Point(12, 80);
		textBox.Location = location;
		this.txtIntro.Multiline = true;
		this.txtIntro.Name = "txtIntro";
		this.txtIntro.ReadOnly = true;
		this.txtIntro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox2 = this.txtIntro;
		System.Drawing.Size size = new System.Drawing.Size(656, 216);
		textBox2.Size = size;
		this.txtIntro.TabIndex = 16;
		this.txtIntro.Text = "";
		this.cmdVowel.BackColor = System.Drawing.Color.SlateGray;
		this.cmdVowel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdVowel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdVowel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button = this.cmdVowel;
		location = new System.Drawing.Point(254, 304);
		button.Location = location;
		this.cmdVowel.Name = "cmdVowel";
		this.cmdVowel.TabIndex = 30;
		this.cmdVowel.Text = "&Vowels";
		this.cmdConsonant.BackColor = System.Drawing.Color.SlateGray;
		this.cmdConsonant.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdConsonant.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdConsonant.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button2 = this.cmdConsonant;
		location = new System.Drawing.Point(152, 304);
		button2.Location = location;
		this.cmdConsonant.Name = "cmdConsonant";
		System.Windows.Forms.Button button3 = this.cmdConsonant;
		size = new System.Drawing.Size(96, 23);
		button3.Size = size;
		this.cmdConsonant.TabIndex = 28;
		this.cmdConsonant.Text = "&Consonants";
		this.cmdNumber.BackColor = System.Drawing.Color.SlateGray;
		this.cmdNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button4 = this.cmdNumber;
		location = new System.Drawing.Point(498, 304);
		button4.Location = location;
		this.cmdNumber.Name = "cmdNumber";
		this.cmdNumber.TabIndex = 29;
		this.cmdNumber.Text = "&Numbers";
		this.cmdClose.BackColor = System.Drawing.Color.SlateGray;
		this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button5 = this.cmdClose;
		location = new System.Drawing.Point(578, 304);
		button5.Location = location;
		this.cmdClose.Name = "cmdClose";
		this.cmdClose.TabIndex = 29;
		this.cmdClose.Text = "Clo&se";
		this.lblTitle.BackColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.Label label = this.lblTitle;
		location = new System.Drawing.Point(0, 0);
		label.Location = location;
		this.lblTitle.Name = "lblTitle";
		System.Windows.Forms.Label label2 = this.lblTitle;
		size = new System.Drawing.Size(712, 40);
		label2.Size = size;
		this.lblTitle.TabIndex = 31;
		this.TextBox1.BackColor = System.Drawing.Color.SteelBlue;
		this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TextBox1.Font = new System.Drawing.Font("Khmer OS Freehand", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.TextBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
		System.Windows.Forms.TextBox textBox3 = this.TextBox1;
		location = new System.Drawing.Point(8, 0);
		textBox3.Location = location;
		this.TextBox1.Name = "TextBox1";
		System.Windows.Forms.TextBox textBox4 = this.TextBox1;
		size = new System.Drawing.Size(280, 37);
		textBox4.Size = size;
		this.TextBox1.TabIndex = 32;
		this.TextBox1.Text = "ភ\u17b6ស\u17b6ខ\u17d2ម\u17c2រ - Khmer Language";
		this.cmdPrint.BackColor = System.Drawing.Color.SlateGray;
		this.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdPrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button6 = this.cmdPrint;
		location = new System.Drawing.Point(592, 48);
		button6.Location = location;
		this.cmdPrint.Name = "cmdPrint";
		this.cmdPrint.TabIndex = 33;
		this.cmdPrint.Text = "&Print";
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Label label3 = this.Label1;
		location = new System.Drawing.Point(16, 48);
		label3.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label4 = this.Label1;
		size = new System.Drawing.Size(136, 24);
		label4.Size = size;
		this.Label1.TabIndex = 34;
		this.Label1.Text = "About Khmer Language:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		System.Windows.Forms.ComboBox comboBox = this.cboKhmer;
		location = new System.Drawing.Point(160, 48);
		comboBox.Location = location;
		this.cboKhmer.Name = "cboKhmer";
		System.Windows.Forms.ComboBox comboBox2 = this.cboKhmer;
		size = new System.Drawing.Size(256, 21);
		comboBox2.Size = size;
		this.cboKhmer.TabIndex = 35;
		this.cmdIndependence.BackColor = System.Drawing.Color.SlateGray;
		this.cmdIndependence.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdIndependence.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdIndependence.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button7 = this.cmdIndependence;
		location = new System.Drawing.Point(334, 304);
		button7.Location = location;
		this.cmdIndependence.Name = "cmdIndependence";
		System.Windows.Forms.Button button8 = this.cmdIndependence;
		size = new System.Drawing.Size(160, 24);
		button8.Size = size;
		this.cmdIndependence.TabIndex = 36;
		this.cmdIndependence.Text = "&Independence Vowels";
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(680, 344);
		this.ClientSize = size;
		this.Controls.Add(this.cmdIndependence);
		this.Controls.Add(this.cboKhmer);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.cmdPrint);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.lblTitle);
		this.Controls.Add(this.cmdVowel);
		this.Controls.Add(this.cmdConsonant);
		this.Controls.Add(this.cmdNumber);
		this.Controls.Add(this.txtIntro);
		this.Controls.Add(this.cmdClose);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.Name = "frmKhmerLanguage";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Khmer Language";
		this.ResumeLayout(false);
	}

	private void frmKhmerLanguage_Load(object sender, EventArgs e)
	{
		ComboBox comboBox = cboKhmer;
		comboBox.Items.Add("Introduction");
		comboBox.Items.Add("Cambodian System of Writing");
		comboBox.Items.Add("Consonants");
		comboBox.Items.Add("Vowels");
		comboBox.Items.Add("Numbers");
		comboBox.Items.Add("Words with no written vowel");
		comboBox.Items.Add("Consonant clusters and subscript");
		comboBox.Items.Add("Consonant clusters and vowels");
		comboBox.Items.Add("Zero Consonant");
		comboBox.Items.Add("Independent vowel symbols");
		comboBox.Items.Add("The Symbol (')");
		comboBox.Items.Add("The Symbol ('')");
		comboBox = null;
		cboKhmer.SelectedIndex = 0;
	}

	private void cmdNumber_Click(object sender, EventArgs e)
	{
		frmNumbers frmNumbers2 = new frmNumbers();
		frmNumbers2.MdiParent = MdiParent;
		frmNumbers2.Show();
	}

	private void cmdConsonant_Click(object sender, EventArgs e)
	{
		frmConsonants frmConsonants2 = new frmConsonants();
		frmConsonants2.MdiParent = MdiParent;
		frmConsonants2.Show();
	}

	private void cmdVowel_Click(object sender, EventArgs e)
	{
		frmVowels frmVowels2 = new frmVowels();
		frmVowels2.MdiParent = MdiParent;
		frmVowels2.Show();
	}

	private void cmdClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void cmdPrint_Click(object sender, EventArgs e)
	{
		PrintDocument1.Print();
	}

	private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
	{
		Font font = new Font("Verdana", 10f);
		string text = cboKhmer.Text + "\r\n\r\n" + txtIntro.Text;
		PageSettings defaultPageSettings = PrintDocument1.DefaultPageSettings;
		checked
		{
			int num = defaultPageSettings.PaperSize.Height - defaultPageSettings.Margins.Top - defaultPageSettings.Margins.Bottom;
			int num2 = defaultPageSettings.PaperSize.Width - defaultPageSettings.Margins.Left - defaultPageSettings.Margins.Right;
			int left = PrintDocument1.DefaultPageSettings.Margins.Left;
			int top = PrintDocument1.DefaultPageSettings.Margins.Top;
			defaultPageSettings = null;
			if (PrintDocument1.DefaultPageSettings.Landscape)
			{
				int num3 = num;
				num = num2;
				num2 = num3;
			}
			int num4 = (int)Math.Round((double)num / (double)font.Height);
			RectangleF layoutRectangle = new RectangleF(left, top, num2, num);
			StringFormat stringFormat = new StringFormat(StringFormatFlags.LineLimit);
			Graphics graphics = e.Graphics;
			string obj = Strings.Mid(text, _0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar + 1);
			SizeF layoutArea = new SizeF(num2, num);
			graphics.MeasureString(obj, font, layoutArea, stringFormat, out var charactersFitted, out var _);
			e.Graphics.DrawString(Strings.Mid(text, _0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar + 1), font, Brushes.Black, layoutRectangle, stringFormat);
			_0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar += charactersFitted;
			if (_0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar < text.Length)
			{
				e.HasMorePages = true;
				return;
			}
			e.HasMorePages = false;
			_0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar = 0;
		}
	}

	private void frmKhmerLanguage_Resize(object sender, EventArgs e)
	{
		lblTitle.Width = Width;
	}

	private void cboKhmer_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (cboKhmer.SelectedIndex)
		{
		case 0:
			txtIntro.Font = new Font("verdana", 10f);
			txtIntro.Text = "Khmer Language:\r\n\r\nCambodian or Khmer is the native language of people living in Cambodia, South Vietnam, Thailand and Laos. Khmer is a member of the Mon-Khmer family of languages which extends from India to the South China Sea.\r\n\r\nSince at least the first century of the Christian era the Khmer people in what is today Cambodia have been subjected to the influence of Indian culture. This influence can be seen very clearly in Khmer art, religion, philosophy, and especially in Khmer Language. Two distinct Indo-European linguistic influences have modified and augmented the Khmer lexicon. The first of these, associated with the spread of the Brahman and Mahayana Buddhist religions, was Sanskrit. The second, associated with Hinayana Buddhism, was Pali, from which extensive borrowing was made starting in about the 15th century. To a much lesser extent Khmer has borrowed from Thai, Chinese, Vietnamese, Lao, and French. The Thai borrowings were often in the courtly or administrative spheres, and the Chinese were mainly terms associated with cooking or business. Most of the words borrowed from French relate to modern industrial technology and science.";
			break;
		case 1:
			txtIntro.Font = new Font("verdana", 10f);
			txtIntro.Text = "Cambodian is written across the page from left to right. The Cambodian alphabet, although unique to Cambodia, bears some close similarities to the Thai and Lao alphabets. All have developed from an alphabet that originated in south India.\r\n\r\nIn Camboda there are two distinct styles of script –uk-sor ch’ree-ung or ‘slanted script’ and uk-sor mool or ‘rounded script’. The former is the most common and that used in this book. Newspapers, books and all typewritten material use this form of script. The more ornate rounded script is used for headings in public notices, names of buildings, titles of books and so on.\r\n\r\nThere are no spaces between words in Cambodian; when spaces do occur in Cambodian writing, they serve as punctuation marks, rather like commas. Certain vowels symbols appear above the consonant, rather than after it, while others are written beneath, in front of, or even surrounding the consonant on three sides. A further unusual feature for the westerner is that when two consonants occur at the beginning of a word – for example in the word srok – the second consonant is written using a special subscript from beneath the first consonant.";
			break;
		case 2:
			txtIntro.Font = new Font("verdana", 10f);
			txtIntro.Text = "Cambodian consonants are classified as belonging to either the first series (sometimes called first register) or second series (or second register). Since the series or register of the initial consonant in a word will determine how that word is pronounced, it is essential to remember which series each consonant belongs to.\r\n\r\nThere are 33 consonants in Cambodian script.";
			break;
		case 3:
			txtIntro.Font = new Font("verdana", 10f);
			txtIntro.Text = "Nearly every vowel symbol or configuration has two possible pronunciations in Cambodian – a ‘first series pronunciation’ used when the preceding consonant belongs to the first series, and a ‘second series pronunciation’ used when the preceding consonant belongs to the second series. There are three vowel symbols that are pronounced the same regardless of the series of the initial consonant.\r\n\r\nThere are 24 vowels and 11 independent vowels.";
			break;
		case 4:
			txtIntro.Font = new Font("Khmer OS System", 10f);
			txtIntro.Text = "In our software, we provide you a reading system of number. You can see the number from 0 to 9 and you can put the amount of number from 0 to million to read in Khmer.\r\n\r\nNotice that the words for six, seven, eight etc. are literally ‘five-one’, ‘five-two’, ‘five-tree’ etc.\r\n\r\nThe number scripts are (0-9): ០, ១, ២, ៣,\u200b៤, ៥, ៦, ៧, ៨, ៩";
			break;
		case 5:
			txtIntro.Font = new Font("Khmer OS System", 10f);
			txtIntro.Text = "Many Khmer words consist of simply two consonants, with no vowel symbol appearing, eg. ដង, មក. These words are usually pronounced with an inherent –or sound. Some common words with an initial second series consonant are, however, pronounced with an inherent –oa sound.";
			break;
		case 6:
			txtIntro.Font = new Font("verdana", 10f);
			txtIntro.Text = "When two consonant sounds occur together at the beginning of a word –e.g: t’wer, s’ray, kroo, etc. –the second consonant symbol is written underneath the initial consonant. Each consonant symbol in Cambodian has in addition to its normal form a subscript form. Thus, for every consonant symbol, it is also necessary to learn a subscript form. In some cases the subscript consonant are very similar to their ‘parent’ consonants; in other instances there is virtually no resemblance whatsoever.";
			break;
		case 7:
			txtIntro.Font = new Font("Khmer OS System", 10f);
			txtIntro.Text = "If the initial consonant and subscript consonant both belong to the same series then the vowel will take that series. But if an initial consonant belonging to the first series is followed by one of the subscript consonants above, then the vowel takes the first series pronunciation.\r\n\r\nNote: Khmer words never end with an –s sound, although the letter ស occurs at the end of many words. In such cases the preceding vowel is pronounced with marked aspiration at the end, which is represented in the transcription by –h.";
			break;
		case 8:
			txtIntro.Font = new Font("Khmer OS System", 10f);
			txtIntro.Text = "When we have learned vowel symbols, a dash has been used to represent the position of the consonant in relation to the vowel symbol. When a word begins with a vowel sound, a consonant symbol still has to be substituted in the appropriate position. Thus a word that begins with an –aa sound cannot simply start with the letter \u17b6 because, as we have already seen, this letter must always follow a consonant. The ‘zero consonant’ serves this function, producing no sound of its own when it occurs with a written vowel symbol.";
			break;
		case 9:
			txtIntro.Font = new Font("verdana", 10f);
			txtIntro.Text = "There some words in Cambodian which begin with a vowel sound, but instead of being written with ‘zero consonant’ they are written with special ‘independent’ (because they do not appear on top of or underneath a consonant) vowel symbols. Some appear in very common words –others you may never come across.";
			break;
		case 10:
			txtIntro.Font = new Font("Khmer OS System", 10f);
			txtIntro.Text = "This symbol is called bon-dtok. It occurs on the final consonant of a word. It can influence the pronunciation of a word in a number of different ways. If the word begins with a first series consonant and is written with the vowel \u17b6 , then the symbol has the effect of shortening the vowel sound. If the word begins with a second series consonant and is written with the vowel \u17b6, then the symbol has the effect of changing the pronunciation a follows:\r\n\r\nIf the final consonant is ក, ខ, គ, ឃ, ង then the vowel is pronounced –ay-uk: ន\u17b6ក\u17cb  ព\u17b6ក\u17cb\r\n\r\nWith any other final consonant, the vowel is pronounced –oa-u: ម\u17b6ន\u17cb   ទ\u17b6ន\u17cb\r\n\r\nIf the word begins with a first series consonant, then the symbol simply shortens the inherent vowel –or to –o: ដប  ដប\u17cb\r\n\r\nIf the word begins with a second series consonant and ends with ប, ផ, ព, ភ, ម then the vowel is pronounced –OO:  លប\u17cb\r\n\r\nIf the word begins with a second series consonant and ends with any consonant other than those in the last example, then the vowel is pronounced –oo-u: លក\u17cb";
			break;
		case 11:
			txtIntro.Font = new Font("Khmer OS System", 10f);
			txtIntro.Text = "This symbol (called t’meun gon-dao – ‘rat’s teeth’) serves two distinct functions:\r\n\r\nIt changes the pronunciation of the consonants ប and ប\u17b6 from b to bp: ប\u17c9\u17bbន\u17d2ម\u17b6ន  ប\u17c9\u17bbន\u17d2ត\u17c2  ប\u17c9\u17b6\r\n\r\nIt converts the following second series consonants into first series consoants: ង, ញ, ម, យ, រ៖ យ\u17c9\u17b6ង, ម\u17c9\u17c2ត\u17d2រ, ម\u17c9\u17c4ង, រ\u17c9\u17c3";
			break;
		}
	}

	private void cmdIndependence_Click(object sender, EventArgs e)
	{
		frmIndependence frmIndependence2 = new frmIndependence();
		frmIndependence2.MdiParent = this;
		frmIndependence2.Show();
	}
}
