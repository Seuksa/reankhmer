using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace reankhmer;

public class frmGrammar : Form
{
	[AccessedThroughProperty("cmdClose")]
	private Button _cmdClose;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("cmdPrint")]
	private Button _cmdPrint;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("txtGrammar")]
	private TextBox _txtGrammar;

	[AccessedThroughProperty("lblTitle")]
	private Label _lblTitle;

	[AccessedThroughProperty("cboGrammar")]
	private ComboBox _cboGrammar;

	[AccessedThroughProperty("PrintDocument1")]
	private PrintDocument _PrintDocument1;

	private IContainer components;

	[SpecialName]
	private int _0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar;

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

	internal virtual TextBox txtGrammar
	{
		get
		{
			return _txtGrammar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtGrammar != null)
			{
			}
			_txtGrammar = value;
			if (_txtGrammar == null)
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

	internal virtual ComboBox cboGrammar
	{
		get
		{
			return _cboGrammar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cboGrammar != null)
			{
				_cboGrammar.SelectedIndexChanged -= cboGrammar_SelectedIndexChanged;
			}
			_cboGrammar = value;
			if (_cboGrammar != null)
			{
				_cboGrammar.SelectedIndexChanged += cboGrammar_SelectedIndexChanged;
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

	public frmGrammar()
	{
		base.Load += frmGrammar_Load;
		base.Resize += frmGrammar_Resize;
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
		this.cboGrammar = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.lblTitle = new System.Windows.Forms.Label();
		this.txtGrammar = new System.Windows.Forms.TextBox();
		this.cmdPrint = new System.Windows.Forms.Button();
		this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
		this.cmdClose = new System.Windows.Forms.Button();
		this.SuspendLayout();
		this.cboGrammar.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.ComboBox comboBox = this.cboGrammar;
		System.Drawing.Point location = new System.Drawing.Point(144, 48);
		comboBox.Location = location;
		this.cboGrammar.Name = "cboGrammar";
		System.Windows.Forms.ComboBox comboBox2 = this.cboGrammar;
		System.Drawing.Size size = new System.Drawing.Size(520, 32);
		comboBox2.Size = size;
		this.cboGrammar.TabIndex = 40;
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(8, 56);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(136, 24);
		label2.Size = size;
		this.Label1.TabIndex = 39;
		this.Label1.Text = "About Khmer Grammar:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.TextBox1.BackColor = System.Drawing.Color.SteelBlue;
		this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TextBox1.Font = new System.Drawing.Font("Khmer OS Freehand", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.TextBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
		System.Windows.Forms.TextBox textBox = this.TextBox1;
		location = new System.Drawing.Point(0, 0);
		textBox.Location = location;
		this.TextBox1.Name = "TextBox1";
		System.Windows.Forms.TextBox textBox2 = this.TextBox1;
		size = new System.Drawing.Size(280, 37);
		textBox2.Size = size;
		this.TextBox1.TabIndex = 38;
		this.TextBox1.Text = "វ\u17c1យ\u17d2យ\u17b6ករណ\u17cd - Grammar Summary";
		this.lblTitle.BackColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.Label label3 = this.lblTitle;
		location = new System.Drawing.Point(0, 0);
		label3.Location = location;
		this.lblTitle.Name = "lblTitle";
		System.Windows.Forms.Label label4 = this.lblTitle;
		size = new System.Drawing.Size(712, 40);
		label4.Size = size;
		this.lblTitle.TabIndex = 37;
		this.txtGrammar.AutoSize = false;
		this.txtGrammar.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txtGrammar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtGrammar.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox3 = this.txtGrammar;
		location = new System.Drawing.Point(8, 85);
		textBox3.Location = location;
		this.txtGrammar.Multiline = true;
		this.txtGrammar.Name = "txtGrammar";
		this.txtGrammar.ReadOnly = true;
		this.txtGrammar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox4 = this.txtGrammar;
		size = new System.Drawing.Size(656, 216);
		textBox4.Size = size;
		this.txtGrammar.TabIndex = 36;
		this.txtGrammar.Text = "";
		this.cmdPrint.BackColor = System.Drawing.Color.SlateGray;
		this.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdPrint.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Button button = this.cmdPrint;
		location = new System.Drawing.Point(496, 304);
		button.Location = location;
		this.cmdPrint.Name = "cmdPrint";
		this.cmdPrint.TabIndex = 41;
		this.cmdPrint.Text = "&Print";
		this.cmdClose.BackColor = System.Drawing.Color.SlateGray;
		this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button2 = this.cmdClose;
		location = new System.Drawing.Point(576, 304);
		button2.Location = location;
		this.cmdClose.Name = "cmdClose";
		this.cmdClose.TabIndex = 42;
		this.cmdClose.Text = "Clo&se";
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(682, 378);
		this.ClientSize = size;
		this.Controls.Add(this.cmdClose);
		this.Controls.Add(this.cmdPrint);
		this.Controls.Add(this.cboGrammar);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.lblTitle);
		this.Controls.Add(this.txtGrammar);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.Name = "frmGrammar";
		this.Text = "Cambodian Grammar Summary";
		this.ResumeLayout(false);
	}

	private void cmdPrint_Click(object sender, EventArgs e)
	{
		PrintDocument1.Print();
	}

	private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
	{
		Font font = new Font("Verdana", 10f);
		string text = cboGrammar.Text + "\r\n\r\n" + txtGrammar.Text;
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

	private void cboGrammar_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (cboGrammar.SelectedIndex)
		{
		case 0:
			txtGrammar.Text = "ល\u17d2ប\u17c7 is a group of words which have enough meanings and are ended by mark: (។), (?) or (!).\r\n\r\nEx: ក\u17bcនច\u17bcលរ\u17c0នន\u17c5ម\u17c9\u17c4ង ១២ ន\u17b7ង ៣០ ន\u17b6ទ\u17b8។\r\nត\u17beក\u17bcនទ\u17c5រ\u17c0នម\u17c9\u17c4ងប\u17c9\u17bbន\u17d2ម\u17b6ន?\r\nជ\u17b7តដល\u17cbម\u17c9\u17c4ងហ\u17beយ! ប\u17d2រយ\u17d0ត\u17d2នទ\u17c5ស\u17b6ល\u17b6ម\u17b7នទ\u17b6ន\u17cbព\u17c1លណ\u17b6\u17ce!\r\n\r\nល\u17d2ប\u17c7 has 4 kinds:\r\nល\u17d2ប\u17c7បញ\u17d2ជ\u17b6ក\u17cb (Certified sentence): is a sentence for showing and is ended by a mark (។).\r\n\tEx: ស\u17c5ម\u17b6នព\u17c4ត ន\u17b7ងច\u17c1កទ\u17bb\u17c6។ \r\nល\u17d2ប\u17c7ស\u17c6ន\u17bdរ (Interrogative sentence): is a sentence for asking and is ended by a mark (?).\r\n\tEx: ត\u17beអ\u17d2នកណ\u17b6ធ\u17d2វ\u17beច\u17c6ន\u17b8ស\u17c6រ\u17b6ប\u17cbឯង?\r\nល\u17d2ប\u17c7ឧទ\u17b6ន (Exclamation sentence): is a sentence for showing excited expression and are ended by a mark (!).\r\n\tEx: អ\u17c3យ\u17c9\u17b6! អ\u17d2នកទ\u17b6\u17c6ងអស\u17cbគ\u17d2ន\u17b6ឆ\u17d2ល\u17b6តណ\u17b6ស\u17cb!\r\nល\u17d2ប\u17c7បញ\u17d2ជ\u17b6 (Imperative sentence): is a sentence to order or suggest someone to do something and is ended by a mark (។).\r\n\tEx: ក\u17bb\u17c6ដ\u17beររហ\u17c1តរហ\u17bcតន\u17c5ព\u17c1លក\u17c6ព\u17bbងរ\u17c0ន។";
			break;
		case 1:
			txtGrammar.Text = "A sentence has 2 parts of a group of words.\r\nកន\u17d2ស\u17c4មប\u17d2រធ\u17b6ន  tell about people (animals, objects) are mentioned in a sentence.\r\n\r\nEx: ផ\u17d2ទ\u17c7យ\u17beងស\u17d2អ\u17b6តណ\u17b6ស\u17cb។\tWord: ផ\u17d2ទ\u17c7យ\u17beង ជ\u17b6កន\u17d2ស\u17c4មប\u17d2រធ\u17b6ន។\r\n\r\nកន\u17d2ស\u17c4មក\u17b7រ\u17b7យ\u17b6 tell about action or state of predicate subjects and predicate verbs are started by verbs.\r\nEx: អ\u17b6វន\u17c1\u17c7ថ\u17d2ម\u17b8ជ\u17b6ន\u17b7ច\u17d2ច។\tWord: ថ\u17d2ម\u17b8ជ\u17b6ន\u17b7ច\u17d2ច ជ\u17b6កន\u17d2ស\u17c4មក\u17b7រ\u17b7យ\u17b6។";
			break;
		case 2:
			txtGrammar.Text = "ន\u17b6ម is a word identifying people, animal, plant, object, time and place.\r\nEx: ធ\u17b8ត\u17b6ស\u17d2រល\u17b6ញ\u17cbឆ\u17d2ក\u17c2។\tWords: ធ\u17b8ត\u17b6 and ឆ\u17d2ក\u17c2 ជ\u17b6ន\u17b6ម។";
			break;
		case 3:
			txtGrammar.Text = "ក\u17b7រ\u17b7យ\u17b6ស\u17d0ព\u17d2ទ is a word showing about physical and mental actions and movement of  objects or nature.\r\nEx: ស\u17c6ស\u17d2រល\u17b6ញ\u17cbស\u17c5។\tWord: ស\u17d2រល\u17b6ញ\u17cb ជ\u17b6ក\u17b7រ\u17b7យ\u17b6ស\u17d0ព\u17d2ទ។";
			break;
		case 4:
			txtGrammar.Text = "គ\u17bbណន\u17b6ម is a word identifying a state of noun which is left of it.\r\nEx: ត\u17bbល\u17b6ជ\u17b6ក\u17d2ម\u17c1ងឆ\u17d2ល\u17b6ត។\r\nស\u17c5ម\u17b6នរ\u17bcបរ\u17b6ងអ\u17b6ក\u17d2រក\u17cb។\r\nWords: ឆ\u17d2ល\u17b6ត and អ\u17b6ក\u17d2រក\u17cb ជ\u17b6គ\u17bbណន\u17b6ម។";
			break;
		case 5:
			txtGrammar.Text = "គ\u17bbណក\u17b7រ\u17b7យ\u17b6 is a word identifying a state of adjective or verb which is left of it.\r\nEx: គ\u17b6ត\u17cbច\u17d2រ\u17c0ងព\u17b7រ\u17c4\u17c7។\r\nន\u17b6ងរត\u17cbយ\u17c9\u17b6ងល\u17bfន។\r\nWords: ព\u17b7រ\u17c4\u17c7 and យ\u17c9\u17b6ងល\u17bfន ជ\u17b6គ\u17bbណក\u17b7រ\u17b7យ\u17b6។";
			break;
		case 6:
			txtGrammar.Text = "ព\u17b6ក\u17d2យន\u17d0យដ\u17bcច is a word which can be used to replace another word and has repeated meanings.\r\nEx: ស\u17bbខ\u17b6សប\u17d2ប\u17b6យច\u17b7ត\u17d2ត ព\u17d2រ\u17c4\u17c7មន\u17bbស\u17d2សក\u17d2ន\u17bbងផ\u17d2ទ\u17c7រ\u17b8ករ\u17b6យ។\r\nWords: សប\u17d2ប\u17b6យច\u17b7ត\u17d2ត and រ\u17b8ករ\u17b6យ ជ\u17b6ព\u17b6ក\u17d2យន\u17d0យដ\u17bcច។";
			break;
		case 7:
			txtGrammar.Text = "ព\u17b6ក\u17d2យន\u17d0យផ\u17d2ទ\u17bbយ is a word which means the opposite of another word.\r\nEx: ច\u17b7ន\u17d2ត\u17b6ស\u17d2រល\u17b6ញ\u17cbមន\u17bbស\u17d2សល\u17d2អ ត\u17c2ន\u17b6ងស\u17d2អប\u17cbមន\u17bbស\u17d2សអ\u17b6ក\u17d2រក\u17cb។\r\nWords: ស\u17d2រល\u17b6ញ\u17cb and ស\u17d2អប\u17cb ជ\u17b6ព\u17b6ក\u17d2យន\u17d0យផ\u17d2ទ\u17bbយ។";
			break;
		case 8:
			txtGrammar.Text = "ឈ\u17d2ន\u17b6ប\u17cbចង is a word which links different parts of a sentence.\r\nWords: ន\u17b7ង រ\u17ba ត\u17c2 ហ\u17beយន\u17b7ង រ\u17baក\u17cf ប\u17c9\u17bbន\u17d2ត\u17c2 ជ\u17b6ឈ\u17d2ន\u17b6ប\u17cbចង។\r\nEx: អ\u17d2នកភ\u17bcម\u17b7យ\u17beង ដ\u17b6\u17c6កប\u17d2ប\u17b6ស ន\u17b7ងថ\u17d2ន\u17b6\u17c6ជក\u17cb។\r\nត\u17beអ\u17d2នករស\u17cbន\u17c5ត\u17c6បន\u17cbភ\u17d2ន\u17c6 រ\u17baត\u17c6បន\u17cbទ\u17c6ន\u17b6ប។";
			break;
		case 9:
			txtGrammar.Text = "ធ\u17d2ន\u17b6ក\u17cb; is a word which is used with a noun/pronoun to show how it is linked to another word.\r\nWords: ក\u17d2ប\u17c2រ ជ\u17b7ត ល\u17be ក\u17d2រ\u17c4យ... ជ\u17b6ធ\u17d2ន\u17b6ក\u17cb។\r\nEx: ម\u17d2ត\u17b6យយ\u17beងដ\u17b6\u17c6ត\u17d2រក\u17bdន ក\u17d2ប\u17c2រអណ\u17d2ត\u17bcងទ\u17b9ក។\r\nជនជ\u17b6ត\u17b7ភ\u17b6គត\u17b7ច ច\u17d2រ\u17beនដ\u17b6\u17c6ដ\u17c6ន\u17b6\u17c6ល\u17beភ\u17d2ន\u17c6។";
			break;
		case 10:
			txtGrammar.Text = "Simple statements can be turned into questions by adding the question word dtay? (ទ\u17c1?) at the end of the sentence:\r\nEx: ភ\u17b6ស\u17b6ខ\u17d2ម\u17c2រព\u17b7ប\u17b6ក។ pee-a-saa k’mai bpi-baak (Cambodian is difficult.)\r\nភ\u17b6ស\u17b6ខ\u17d2ម\u17c2រព\u17b7ប\u17b6កទ\u17c1? pee-a-saa k’mai bpi-baak dtay? (Is Cambodian difficult?)\r\n\r\nAnother common question form, similar to the English ‘…, isn’t it?’ , ‘…, aren’t they?’ is formed by adding mairn dtay? (ម\u17c2នទ\u17c1?) at the end of the sentence:\r\nមកព\u17b8ភ\u17d2ន\u17c6ព\u17c1ញម\u17c2នទ\u17c1? moak bpee p’nOOm bpeun mairn dtay? ((You) come from Phnom Penh, don’t you?)\r\n៥០០រ\u17c0លម\u17c2នទ\u17c1? bprum roy ree-ul mairn dtay? (It’s 500 riels, isn’t it?)\r\n\r\nOther useful question words are:\r\nay/a-way? (អ\u17b8/អ\u17d2វ\u17b8? What)\r\n\tល\u17c4កឈ\u17d2ម\u17c4\u17c7អ\u17b8? loak ch’moo-ah ay? (What is your name?)\r\n\tល\u17c4កធ\u17d2វ\u17beក\u17b6រអ\u17b8? loak t’wer gaa ay? (What (job) do you do?)\r\n\r\nbpon-maan? (ប\u17c9\u17bbន\u17d2ម\u17b6ន? How much/how many?)\r\n\tថ\u17d2ល\u17c3ប\u17c9\u17bbន\u17d2ម\u17b6ន? t’lai bpon-maan? (How much is the price?)\r\n\tអ\u17b6យ\u17bbប\u17c9\u17bbន\u17d2ម\u17b6នឆ\u17d2ន\u17b6\u17c6ហ\u17beយ? aa-yOO bpon-maan ch’num hai-ee? (How old are you?)\r\n\r\n(ai) naa/(ee)-naa? (ឯណ\u17b6? (at) where?)\r\n\tន\u17c5ឯណ\u17b6? nou ai-naa? (Where is (it)?)\r\n\tរ\u17c0នន\u17c5ឯណ\u17b6? ree-un nou ai-naa? (Where do (you) study?)\r\n\r\nNotice that ai/ee is dropped in sentence like these:\r\n\tមកព\u17b8ណ\u17b6? moak bpee naa? (Where do (you) come from?)\r\n\tល\u17c4កទ\u17c5ណ\u17b6? loak dtou naa? (Where are you going?)\r\n\r\nnay-uk naa? (នរណ\u17b6? who?)\r\n\tអ\u17d2នកណ\u17b6ប\u17d2រ\u17b6ប\u17cbគ\u17b6ត\u17cb? nay-uk naa bprup goa-ut? (Who told him?)\r\n\tយ\u17beងទ\u17c5ជ\u17bdបអ\u17d2នកណ\u17b6? yerng dtou joo-up nay-uk naa? (Who are we going to meet?)\r\n\r\nmaych baan jee-a/hait ay baan jee-a (ម\u17c9\u17c1ចប\u17b6នជ\u17b6/ហ\u17c1ត\u17bbអ\u17b8ប\u17b6នជ\u17b6…? Why?)\r\n\tម\u17c9\u17c1ចប\u17b6នជ\u17b6ល\u17c4កម\u17b7នទ\u17c5? maych baan jee-a loak meun dtou? (Why aren’t you going?)\r\n\tហ\u17c1ត\u17bbអ\u17b8ប\u17b6នជ\u17b6ល\u17c4កច\u17c1\u17c7ភ\u17b6ស\u17b6ខ\u17d2ម\u17c2រ? hait ay baan jee-a loak jeh pee-a-saa k’mai? (Why can you speak Cambodian?)\r\n\r\n(bpee) ong-gul? ((ព\u17b8)អង\u17d2ក\u17b6ល\u17cb? When?)\r\n\tIf a question refers to the future, use ong-ul? (អង\u17d2ក\u17b6ល\u17cb?), and if it refers to the past use bpee ong-gul? (ព\u17b8អង\u17d2ក\u17b6ល\u17cb?)\r\n\tល\u17c4កមកដល\u17cbព\u17b8អង\u17d2ក\u17b6ល\u17cb? loak moak dol bpee ong-gul? (When did you arrive?)\r\n\tយ\u17beងច\u17c1ញអង\u17d2ក\u17b6ល\u17cb? yerng jeuñ ong-gul? (When are we leaving?)";
			break;
		case 11:
			txtGrammar.Text = "The negative is formed by placing meun (ម\u17b7ន) in front of the adjective or main verb and, optionally, dtay (ទ\u17c1) at the end of the phrase or sentence:\r\nម\u17b7នឆ\u17d2ង\u17b6យទ\u17c1 meun ch’ngai dtay  (not far)\r\nម\u17b7នស\u17d2រ\u17bdលទ\u17c1 meun s’roo-ul dtay (not easy)\r\n\r\nThe negative of mee-un, ‘to have’ , is k’mee-un or meun mee-un:\r\nគ\u17d2ម\u17b6នល\u17bbយទ\u17c1 k'mee-un loo-ee dtay. ((They) don’t have any money.)";
			break;
		case 12:
			txtGrammar.Text = "The order of words in a sentence tends to follow the pattern (subject + verb + object). Relative clauses are introduced by the word dail (ដ\u17c2ល= which, where, who, that etc.):\r\nស\u17b6ល\u17b6ដ\u17c2លគ\u17c1បង\u17d2រ\u17c0នថ\u17c3 saalaa dail gay bong-ree-un tai (The school where they teach Thai.)\r\nបងស\u17d2រ\u17b8ដ\u17c2លជ\u17b6គ\u17d2រ\u17bc borng s’ray dail jee-a kroo (My older sister who is a teacher.)\r\nផ\u17d2ទ\u17c7ដ\u17c2លយ\u17beងទ\u17b7ញ p’dtay-ah dail yerng dteuñ (The house which we bought.)";
			break;
		}
	}

	private void frmGrammar_Load(object sender, EventArgs e)
	{
		ComboBox.ObjectCollection items = cboGrammar.Items;
		items.Add("១- ល\u17d2ប\u17c7 (Sentence)");
		items.Add("២- កន\u17d2ស\u17c4មប\u17d2រធ\u17b6ន ន\u17b7ង កន\u17d2ស\u17c4មក\u17b7រ\u17b7យ\u17b6 (Predicate subjects and predicate verbs)");
		items.Add("៣- ន\u17b6ម (Noun)");
		items.Add("៤- ក\u17b7រ\u17b7យ\u17b6ស\u17d0ព\u17d2ទ (Verb)");
		items.Add("៥- គ\u17bbណន\u17b6ម (Adjective)");
		items.Add("៦- គ\u17bbណក\u17b7រ\u17b7យ\u17b6 (Adverb)");
		items.Add("៧- ព\u17b6ក\u17d2យន\u17d0យដ\u17bcច (Synonym)");
		items.Add("៨- ព\u17b6ក\u17d2យន\u17d0យផ\u17d2ទ\u17bbយ (Antonym)");
		items.Add("៩- ឈ\u17d2ន\u17b6ប\u17cbចង (Conjunction)");
		items.Add("១០- ធ\u17d2ន\u17b6ក\u17cb (Preposition)");
		items.Add("១១- ប\u17d2រយ\u17c4គស\u17c6ន\u17bdរ (Question Sentence)");
		items.Add("១២- ប\u17d2រយ\u17c4គបដ\u17b7ស\u17c1ធ (Negative sentences)");
		items.Add("១៣- ល\u17c6ដ\u17b6ប\u17cbព\u17b6ក\u17d2យ (Word order)");
		items = null;
		cboGrammar.SelectedIndex = 0;
	}

	private void cmdClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void frmGrammar_Resize(object sender, EventArgs e)
	{
		lblTitle.Width = Width;
	}
}
