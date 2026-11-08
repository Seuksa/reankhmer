using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ADODB;
using AxShockwaveFlashObjects;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class frmChapter2 : Form
{
	[AccessedThroughProperty("aFlash")]
	private AxShockwaveFlash _aFlash;

	[AccessedThroughProperty("PictureBox1")]
	private PictureBox _PictureBox1;

	[AccessedThroughProperty("cmdNext")]
	private Button _cmdNext;

	[AccessedThroughProperty("cmdDictionary")]
	private Button _cmdDictionary;

	[AccessedThroughProperty("lblLesson")]
	private TextBox _lblLesson;

	[AccessedThroughProperty("cmdPre")]
	private Button _cmdPre;

	[AccessedThroughProperty("txtVocabulary")]
	private TextBox _txtVocabulary;

	[AccessedThroughProperty("lblNum")]
	private Label _lblNum;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("txtExample")]
	private TextBox _txtExample;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("cboLesson")]
	private ComboBox _cboLesson;

	[AccessedThroughProperty("lblTitle")]
	private Label _lblTitle;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("txtIntro")]
	private TextBox _txtIntro;

	[AccessedThroughProperty("lblLes_hide")]
	private Label _lblLes_hide;

	[AccessedThroughProperty("lblChapter")]
	private Label _lblChapter;

	[AccessedThroughProperty("lblFlash_hide")]
	private Label _lblFlash_hide;

	[AccessedThroughProperty("lblChap_hide")]
	private Label _lblChap_hide;

	[AccessedThroughProperty("exFlash")]
	private AxShockwaveFlash _exFlash;

	private IContainer components;

	private Application app;

	private Connection cnn;

	private Recordset rst;

	internal virtual ComboBox cboLesson
	{
		get
		{
			return _cboLesson;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cboLesson != null)
			{
				_cboLesson.SelectedIndexChanged -= cboLesson_SelectedIndexChanged;
			}
			_cboLesson = value;
			if (_cboLesson != null)
			{
				_cboLesson.SelectedIndexChanged += cboLesson_SelectedIndexChanged;
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

	internal virtual Label lblChapter
	{
		get
		{
			return _lblChapter;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblChapter != null)
			{
			}
			_lblChapter = value;
			if (_lblChapter == null)
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

	internal virtual Button cmdNext
	{
		get
		{
			return _cmdNext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdNext != null)
			{
				_cmdNext.Click -= cmdNext_Click;
			}
			_cmdNext = value;
			if (_cmdNext != null)
			{
				_cmdNext.Click += cmdNext_Click;
			}
		}
	}

	internal virtual Button cmdPre
	{
		get
		{
			return _cmdPre;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdPre != null)
			{
				_cmdPre.Click -= cmdPre_Click;
			}
			_cmdPre = value;
			if (_cmdPre != null)
			{
				_cmdPre.Click += cmdPre_Click;
			}
		}
	}

	internal virtual Label Label2
	{
		get
		{
			return _Label2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Label2 != null)
			{
			}
			_Label2 = value;
			if (_Label2 == null)
			{
			}
		}
	}

	internal virtual Label Label3
	{
		get
		{
			return _Label3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Label3 != null)
			{
			}
			_Label3 = value;
			if (_Label3 == null)
			{
			}
		}
	}

	internal virtual TextBox txtExample
	{
		get
		{
			return _txtExample;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtExample != null)
			{
			}
			_txtExample = value;
			if (_txtExample == null)
			{
			}
		}
	}

	internal virtual Label lblNum
	{
		get
		{
			return _lblNum;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblNum != null)
			{
			}
			_lblNum = value;
			if (_lblNum == null)
			{
			}
		}
	}

	internal virtual Label lblChap_hide
	{
		get
		{
			return _lblChap_hide;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblChap_hide != null)
			{
			}
			_lblChap_hide = value;
			if (_lblChap_hide == null)
			{
			}
		}
	}

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

	internal virtual Label lblLes_hide
	{
		get
		{
			return _lblLes_hide;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblLes_hide != null)
			{
			}
			_lblLes_hide = value;
			if (_lblLes_hide == null)
			{
			}
		}
	}

	internal virtual Label lblFlash_hide
	{
		get
		{
			return _lblFlash_hide;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblFlash_hide != null)
			{
			}
			_lblFlash_hide = value;
			if (_lblFlash_hide == null)
			{
			}
		}
	}

	internal virtual TextBox lblLesson
	{
		get
		{
			return _lblLesson;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblLesson != null)
			{
			}
			_lblLesson = value;
			if (_lblLesson == null)
			{
			}
		}
	}

	internal virtual TextBox txtVocabulary
	{
		get
		{
			return _txtVocabulary;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtVocabulary != null)
			{
			}
			_txtVocabulary = value;
			if (_txtVocabulary == null)
			{
			}
		}
	}

	internal virtual Button cmdDictionary
	{
		get
		{
			return _cmdDictionary;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdDictionary != null)
			{
				_cmdDictionary.Click -= cmdDictionary_Click;
			}
			_cmdDictionary = value;
			if (_cmdDictionary != null)
			{
				_cmdDictionary.Click += cmdDictionary_Click;
			}
		}
	}

	internal virtual PictureBox PictureBox1
	{
		get
		{
			return _PictureBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_PictureBox1 != null)
			{
			}
			_PictureBox1 = value;
			if (_PictureBox1 == null)
			{
			}
		}
	}

	internal virtual AxShockwaveFlash aFlash
	{
		get
		{
			return _aFlash;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_aFlash != null)
			{
			}
			_aFlash = value;
			if (_aFlash == null)
			{
			}
		}
	}

	internal virtual AxShockwaveFlash exFlash
	{
		get
		{
			return _exFlash;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_exFlash != null)
			{
			}
			_exFlash = value;
			if (_exFlash == null)
			{
			}
		}
	}

	public frmChapter2()
	{
		base.Load += frmChapter2_Load;
		base.Resize += frmChapter2_Resize;
		cnn = new ConnectionClass();
		rst = new RecordsetClass();
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
		System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(reankhmer.frmChapter2));
		this.cboLesson = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.lblChapter = new System.Windows.Forms.Label();
		this.lblTitle = new System.Windows.Forms.Label();
		this.cmdNext = new System.Windows.Forms.Button();
		this.cmdPre = new System.Windows.Forms.Button();
		this.txtExample = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.txtIntro = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.lblNum = new System.Windows.Forms.Label();
		this.lblChap_hide = new System.Windows.Forms.Label();
		this.lblLes_hide = new System.Windows.Forms.Label();
		this.lblFlash_hide = new System.Windows.Forms.Label();
		this.lblLesson = new System.Windows.Forms.TextBox();
		this.txtVocabulary = new System.Windows.Forms.TextBox();
		this.cmdDictionary = new System.Windows.Forms.Button();
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.aFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();
		this.exFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();
		((System.ComponentModel.ISupportInitialize)this.aFlash).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.exFlash).BeginInit();
		this.SuspendLayout();
		this.cboLesson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboLesson.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.ComboBox comboBox = this.cboLesson;
		System.Drawing.Point location = new System.Drawing.Point(636, 8);
		comboBox.Location = location;
		this.cboLesson.Name = "cboLesson";
		System.Windows.Forms.ComboBox comboBox2 = this.cboLesson;
		System.Drawing.Size size = new System.Drawing.Size(56, 22);
		comboBox2.Size = size;
		this.cboLesson.Sorted = true;
		this.cboLesson.TabIndex = 28;
		this.Label1.BackColor = System.Drawing.Color.SteelBlue;
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(580, 8);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(56, 23);
		label2.Size = size;
		this.Label1.TabIndex = 27;
		this.Label1.Text = "Lesson:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblChapter.BackColor = System.Drawing.Color.SteelBlue;
		this.lblChapter.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblChapter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Label label3 = this.lblChapter;
		location = new System.Drawing.Point(0, 0);
		label3.Location = location;
		this.lblChapter.Name = "lblChapter";
		System.Windows.Forms.Label label4 = this.lblChapter;
		size = new System.Drawing.Size(472, 32);
		label4.Size = size;
		this.lblChapter.TabIndex = 26;
		this.lblChapter.Text = "Chapter 1: Chapter title";
		this.lblChapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblTitle.BackColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.Label label5 = this.lblTitle;
		location = new System.Drawing.Point(-4, 0);
		label5.Location = location;
		this.lblTitle.Name = "lblTitle";
		System.Windows.Forms.Label label6 = this.lblTitle;
		size = new System.Drawing.Size(712, 40);
		label6.Size = size;
		this.lblTitle.TabIndex = 25;
		this.cmdNext.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Button button = this.cmdNext;
		location = new System.Drawing.Point(296, 56);
		button.Location = location;
		this.cmdNext.Name = "cmdNext";
		System.Windows.Forms.Button button2 = this.cmdNext;
		size = new System.Drawing.Size(24, 23);
		button2.Size = size;
		this.cmdNext.TabIndex = 31;
		this.cmdNext.Text = ">";
		this.cmdPre.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Button button3 = this.cmdPre;
		location = new System.Drawing.Point(16, 56);
		button3.Location = location;
		this.cmdPre.Name = "cmdPre";
		System.Windows.Forms.Button button4 = this.cmdPre;
		size = new System.Drawing.Size(24, 23);
		button4.Size = size;
		this.cmdPre.TabIndex = 30;
		this.cmdPre.Text = "<";
		this.txtExample.AutoSize = false;
		this.txtExample.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txtExample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtExample.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox = this.txtExample;
		location = new System.Drawing.Point(328, 80);
		textBox.Location = location;
		this.txtExample.Multiline = true;
		this.txtExample.Name = "txtExample";
		this.txtExample.ReadOnly = true;
		this.txtExample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox2 = this.txtExample;
		size = new System.Drawing.Size(360, 112);
		textBox2.Size = size;
		this.txtExample.TabIndex = 34;
		this.txtExample.Text = "";
		this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Label label7 = this.Label2;
		location = new System.Drawing.Point(328, 64);
		label7.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label8 = this.Label2;
		size = new System.Drawing.Size(104, 16);
		label8.Size = size;
		this.Label2.TabIndex = 33;
		this.Label2.Text = "Example:";
		this.txtIntro.AutoSize = false;
		this.txtIntro.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txtIntro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtIntro.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox3 = this.txtIntro;
		location = new System.Drawing.Point(16, 352);
		textBox3.Location = location;
		this.txtIntro.Multiline = true;
		this.txtIntro.Name = "txtIntro";
		this.txtIntro.ReadOnly = true;
		this.txtIntro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox4 = this.txtIntro;
		size = new System.Drawing.Size(672, 100);
		textBox4.Size = size;
		this.txtIntro.TabIndex = 37;
		this.txtIntro.Text = "";
		this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Label label9 = this.Label3;
		location = new System.Drawing.Point(16, 336);
		label9.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label10 = this.Label3;
		size = new System.Drawing.Size(128, 16);
		label10.Size = size;
		this.Label3.TabIndex = 36;
		this.Label3.Text = "Introduction";
		this.lblNum.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label11 = this.lblNum;
		location = new System.Drawing.Point(256, 320);
		label11.Location = location;
		this.lblNum.Name = "lblNum";
		System.Windows.Forms.Label label12 = this.lblNum;
		size = new System.Drawing.Size(48, 23);
		label12.Size = size;
		this.lblNum.TabIndex = 38;
		this.lblNum.Text = "2";
		this.lblChap_hide.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblChap_hide.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label13 = this.lblChap_hide;
		location = new System.Drawing.Point(312, 320);
		label13.Location = location;
		this.lblChap_hide.Name = "lblChap_hide";
		System.Windows.Forms.Label label14 = this.lblChap_hide;
		size = new System.Drawing.Size(32, 16);
		label14.Size = size;
		this.lblChap_hide.TabIndex = 39;
		this.lblChap_hide.Text = "chapter";
		this.lblLes_hide.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblLes_hide.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label15 = this.lblLes_hide;
		location = new System.Drawing.Point(360, 320);
		label15.Location = location;
		this.lblLes_hide.Name = "lblLes_hide";
		System.Windows.Forms.Label label16 = this.lblLes_hide;
		size = new System.Drawing.Size(32, 16);
		label16.Size = size;
		this.lblLes_hide.TabIndex = 40;
		this.lblLes_hide.Text = "Lesson";
		this.lblFlash_hide.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label17 = this.lblFlash_hide;
		location = new System.Drawing.Point(400, 320);
		label17.Location = location;
		this.lblFlash_hide.Name = "lblFlash_hide";
		System.Windows.Forms.Label label18 = this.lblFlash_hide;
		size = new System.Drawing.Size(40, 16);
		label18.Size = size;
		this.lblFlash_hide.TabIndex = 41;
		this.lblFlash_hide.Text = "kor.swf";
		this.lblLesson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.TextBox textBox5 = this.lblLesson;
		location = new System.Drawing.Point(40, 52);
		textBox5.Location = location;
		this.lblLesson.Name = "lblLesson";
		this.lblLesson.ReadOnly = true;
		System.Windows.Forms.TextBox textBox6 = this.lblLesson;
		size = new System.Drawing.Size(256, 31);
		textBox6.Size = size;
		this.lblLesson.TabIndex = 42;
		this.lblLesson.Text = "";
		this.lblLesson.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtVocabulary.AutoSize = false;
		this.txtVocabulary.BackColor = System.Drawing.SystemColors.Control;
		this.txtVocabulary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtVocabulary.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox7 = this.txtVocabulary;
		location = new System.Drawing.Point(328, 232);
		textBox7.Location = location;
		this.txtVocabulary.Multiline = true;
		this.txtVocabulary.Name = "txtVocabulary";
		this.txtVocabulary.ReadOnly = true;
		System.Windows.Forms.TextBox textBox8 = this.txtVocabulary;
		size = new System.Drawing.Size(296, 80);
		textBox8.Size = size;
		this.txtVocabulary.TabIndex = 34;
		this.txtVocabulary.Text = "";
		this.cmdDictionary.BackColor = System.Drawing.Color.SlateGray;
		this.cmdDictionary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdDictionary.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdDictionary.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button5 = this.cmdDictionary;
		location = new System.Drawing.Point(328, 203);
		button5.Location = location;
		this.cmdDictionary.Name = "cmdDictionary";
		System.Windows.Forms.Button button6 = this.cmdDictionary;
		size = new System.Drawing.Size(296, 24);
		button6.Size = size;
		this.cmdDictionary.TabIndex = 43;
		this.cmdDictionary.Text = "Check &Vocabularies below in Dictionary";
		this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		System.Windows.Forms.PictureBox pictureBox = this.PictureBox1;
		location = new System.Drawing.Point(632, 208);
		pictureBox.Location = location;
		this.PictureBox1.Name = "PictureBox1";
		System.Windows.Forms.PictureBox pictureBox2 = this.PictureBox1;
		size = new System.Drawing.Size(56, 50);
		pictureBox2.Size = size;
		this.PictureBox1.TabIndex = 44;
		this.PictureBox1.TabStop = false;
		this.aFlash.Enabled = true;
		AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash = this.aFlash;
		location = new System.Drawing.Point(16, 88);
		axShockwaveFlash.Location = location;
		this.aFlash.Name = "aFlash";
		this.aFlash.OcxState = (System.Windows.Forms.AxHost.State)resourceManager.GetObject("aFlash.OcxState");
		AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash2 = this.aFlash;
		size = new System.Drawing.Size(304, 224);
		axShockwaveFlash2.Size = size;
		this.aFlash.TabIndex = 45;
		this.exFlash.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
		this.exFlash.Enabled = true;
		AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash3 = this.exFlash;
		location = new System.Drawing.Point(635, 212);
		axShockwaveFlash3.Location = location;
		this.exFlash.Name = "exFlash";
		this.exFlash.OcxState = (System.Windows.Forms.AxHost.State)resourceManager.GetObject("exFlash.OcxState");
		AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash4 = this.exFlash;
		size = new System.Drawing.Size(51, 42);
		axShockwaveFlash4.Size = size;
		this.exFlash.TabIndex = 46;
		size = new System.Drawing.Size(6, 24);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(704, 482);
		this.ClientSize = size;
		this.Controls.Add(this.exFlash);
		this.Controls.Add(this.aFlash);
		this.Controls.Add(this.PictureBox1);
		this.Controls.Add(this.cmdDictionary);
		this.Controls.Add(this.lblLesson);
		this.Controls.Add(this.lblFlash_hide);
		this.Controls.Add(this.lblLes_hide);
		this.Controls.Add(this.lblChap_hide);
		this.Controls.Add(this.lblNum);
		this.Controls.Add(this.txtIntro);
		this.Controls.Add(this.Label3);
		this.Controls.Add(this.txtExample);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.cmdNext);
		this.Controls.Add(this.cmdPre);
		this.Controls.Add(this.cboLesson);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.lblChapter);
		this.Controls.Add(this.lblTitle);
		this.Controls.Add(this.txtVocabulary);
		this.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Name = "frmChapter2";
		this.Text = "frmChapter2";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		((System.ComponentModel.ISupportInitialize)this.aFlash).EndInit();
		((System.ComponentModel.ISupportInitialize)this.exFlash).EndInit();
		this.ResumeLayout(false);
	}

	private void frmChapter2_Load(object sender, EventArgs e)
	{
		Recordset recordset = new RecordsetClass();
		string connectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + Application.StartupPath + "\\reankhmer.mdb";
		cnn.ConnectionString = connectionString;
		cnn.Open();
		string source = "Select ch_title, ch_desc,les_num From tblChapter ch, tblLesson les Where ch.ch_id=les.ch_id and ch.ch_num=" + lblNum.Text;
		recordset.Open(source, cnn, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic);
		recordset.MoveFirst();
		lblChap_hide.Text = StringType.FromObject(recordset.Fields["ch_title"].Value);
		txtIntro.Text = StringType.FromObject(recordset.Fields["ch_desc"].Value);
		lblChapter.Text = "Chapter " + lblNum.Text + ": ";
		lblChapter.Text += lblChap_hide.Text;
		while (!recordset.EOF)
		{
			cboLesson.Items.Add(IntegerType.FromObject(recordset.Fields["les_num"].Value));
			recordset.MoveNext();
		}
		cboLesson.SelectedIndex = 0;
	}

	private void cboLesson_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (rst.State == 1)
		{
			rst.Close();
		}
		queryLes();
		rst.MoveFirst();
		valueTobox();
	}

	public void queryLes()
	{
		string source = "Select les_title,article,getLink,vocabulary,filename From tblLesson les, tblSubLesson sub, tblChapter ch Where les.les_id=sub.les_id and ch.ch_id=les.ch_id and ch_num=" + lblNum.Text + " and les.les_num=" + cboLesson.Text;
		rst.Open(source, cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic);
	}

	public void valueTobox()
	{
		lblFlash_hide.Text = StringType.FromObject(rst.Fields["filename"].Value);
		lblLes_hide.Text = StringType.FromObject(rst.Fields["les_title"].Value);
		lblLesson.Text = "";
		lblLesson.Text = lblLes_hide.Text;
		aFlash.Movie = Application.StartupPath + "\\flash\\spelling\\" + lblFlash_hide.Text;
		txtExample.Text = StringType.FromObject(rst.Fields["article"].Value);
		exFlash.Movie = Application.StartupPath + "\\flash\\spelling\\" + StringType.FromObject(rst.Fields["getLink"].Value);
		txtVocabulary.Text = StringType.FromObject(rst.Fields["vocabulary"].Value);
	}

	private void cmdNext_Click(object sender, EventArgs e)
	{
		rst.MoveNext();
		if (rst.EOF)
		{
			rst.MovePrevious();
		}
		valueTobox();
	}

	private void cmdPre_Click(object sender, EventArgs e)
	{
		rst.MovePrevious();
		if (rst.BOF)
		{
			rst.MoveNext();
		}
		valueTobox();
	}

	private void frmChapter2_Resize(object sender, EventArgs e)
	{
		lblTitle.Width = Width;
	}

	private void cmdDictionary_Click(object sender, EventArgs e)
	{
		frmDictionary frmDictionary2 = new frmDictionary();
		frmDictionary2.MdiParent = MdiParent;
		frmDictionary2.Show();
	}
}
