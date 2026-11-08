using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ADODB;
using AxShockwaveFlashObjects;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class frmChapter1 : Form
{
	[AccessedThroughProperty("cdlColor")]
	private ColorDialog _cdlColor;

	[AccessedThroughProperty("cmdPre")]
	private Button _cmdPre;

	[AccessedThroughProperty("cmdConsonant")]
	private Button _cmdConsonant;

	[AccessedThroughProperty("cboSize")]
	private ComboBox _cboSize;

	[AccessedThroughProperty("cmdNext")]
	private Button _cmdNext;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("txtIntro")]
	private TextBox _txtIntro;

	[AccessedThroughProperty("lblChapter")]
	private Label _lblChapter;

	[AccessedThroughProperty("lblDraw")]
	private Label _lblDraw;

	[AccessedThroughProperty("lblFlash_hide")]
	private Label _lblFlash_hide;

	[AccessedThroughProperty("lblChap_hide")]
	private Label _lblChap_hide;

	[AccessedThroughProperty("exFlash")]
	private AxShockwaveFlash _exFlash;

	[AccessedThroughProperty("lblLesson")]
	private TextBox _lblLesson;

	[AccessedThroughProperty("cmdIndependence")]
	private Button _cmdIndependence;

	[AccessedThroughProperty("lblLes_hide")]
	private Label _lblLes_hide;

	[AccessedThroughProperty("cmdNumber")]
	private Button _cmdNumber;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("cboLesson")]
	private ComboBox _cboLesson;

	[AccessedThroughProperty("lblTitle")]
	private Label _lblTitle;

	[AccessedThroughProperty("cmdColor")]
	private Button _cmdColor;

	[AccessedThroughProperty("cmdClear")]
	private Button _cmdClear;

	[AccessedThroughProperty("cmdVowel")]
	private Button _cmdVowel;

	private IContainer components;

	private Application app;

	private int meW;

	private int meH;

	private int tvW;

	private int tvH;

	private Brush br;

	private Pen p;

	private int x;

	private int y;

	private int ex;

	private int ey;

	private bool isDown;

	private OleDbConnection con;

	private DataSet ds;

	private Connection cnn;

	private Recordset rst;

	internal virtual Label lblDraw
	{
		get
		{
			return _lblDraw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblDraw != null)
			{
				_lblDraw.MouseMove -= lblDraw_MouseMove;
				_lblDraw.MouseDown -= lblDraw_MouseDown;
				_lblDraw.MouseUp -= lblDraw_MouseUp;
			}
			_lblDraw = value;
			if (_lblDraw != null)
			{
				_lblDraw.MouseMove += lblDraw_MouseMove;
				_lblDraw.MouseDown += lblDraw_MouseDown;
				_lblDraw.MouseUp += lblDraw_MouseUp;
			}
		}
	}

	internal virtual Label Label4
	{
		get
		{
			return _Label4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Label4 != null)
			{
			}
			_Label4 = value;
			if (_Label4 == null)
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

	internal virtual ColorDialog cdlColor
	{
		get
		{
			return _cdlColor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cdlColor != null)
			{
			}
			_cdlColor = value;
			if (_cdlColor == null)
			{
			}
		}
	}

	internal virtual ComboBox cboSize
	{
		get
		{
			return _cboSize;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cboSize != null)
			{
				_cboSize.SelectedIndexChanged -= cboSize_SelectedIndexChanged;
			}
			_cboSize = value;
			if (_cboSize != null)
			{
				_cboSize.SelectedIndexChanged += cboSize_SelectedIndexChanged;
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

	internal virtual Button cmdColor
	{
		get
		{
			return _cmdColor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdColor != null)
			{
				_cmdColor.Click -= cmdColor_Click;
			}
			_cmdColor = value;
			if (_cmdColor != null)
			{
				_cmdColor.Click += cmdColor_Click;
			}
		}
	}

	internal virtual Button cmdClear
	{
		get
		{
			return _cmdClear;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdClear != null)
			{
				_cmdClear.Click -= cmdClear_Click;
			}
			_cmdClear = value;
			if (_cmdClear != null)
			{
				_cmdClear.Click += cmdClear_Click;
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

	public frmChapter1()
	{
		base.Load += frmLesson_Load;
		base.Resize += frmCh1_Resize;
		br = new SolidBrush(Color.Black);
		p = new Pen(br, 3f);
		con = new OleDbConnection();
		ds = new DataSet();
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
		System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(reankhmer.frmChapter1));
		this.lblDraw = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.cboSize = new System.Windows.Forms.ComboBox();
		this.cmdNext = new System.Windows.Forms.Button();
		this.cmdPre = new System.Windows.Forms.Button();
		this.cdlColor = new System.Windows.Forms.ColorDialog();
		this.lblTitle = new System.Windows.Forms.Label();
		this.lblChapter = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.txtIntro = new System.Windows.Forms.TextBox();
		this.lblFlash_hide = new System.Windows.Forms.Label();
		this.lblChap_hide = new System.Windows.Forms.Label();
		this.lblLes_hide = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.cboLesson = new System.Windows.Forms.ComboBox();
		this.cmdColor = new System.Windows.Forms.Button();
		this.cmdClear = new System.Windows.Forms.Button();
		this.cmdConsonant = new System.Windows.Forms.Button();
		this.cmdVowel = new System.Windows.Forms.Button();
		this.lblLesson = new System.Windows.Forms.TextBox();
		this.cmdNumber = new System.Windows.Forms.Button();
		this.exFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();
		this.cmdIndependence = new System.Windows.Forms.Button();
		((System.ComponentModel.ISupportInitialize)this.exFlash).BeginInit();
		this.SuspendLayout();
		this.lblDraw.BackColor = System.Drawing.Color.SteelBlue;
		this.lblDraw.Cursor = System.Windows.Forms.Cursors.Hand;
		System.Windows.Forms.Label label = this.lblDraw;
		System.Drawing.Point location = new System.Drawing.Point(368, 80);
		label.Location = location;
		this.lblDraw.Name = "lblDraw";
		System.Windows.Forms.Label label2 = this.lblDraw;
		System.Drawing.Size size = new System.Drawing.Size(328, 232);
		label2.Size = size;
		this.lblDraw.TabIndex = 4;
		this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Label label3 = this.Label4;
		location = new System.Drawing.Point(368, 320);
		label3.Location = location;
		this.Label4.Name = "Label4";
		System.Windows.Forms.Label label4 = this.Label4;
		size = new System.Drawing.Size(63, 23);
		label4.Size = size;
		this.Label4.TabIndex = 8;
		this.Label4.Text = "Pen size:";
		this.cboSize.BackColor = System.Drawing.SystemColors.Window;
		this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSize.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.ComboBox comboBox = this.cboSize;
		location = new System.Drawing.Point(440, 320);
		comboBox.Location = location;
		this.cboSize.Name = "cboSize";
		System.Windows.Forms.ComboBox comboBox2 = this.cboSize;
		size = new System.Drawing.Size(56, 22);
		comboBox2.Size = size;
		this.cboSize.TabIndex = 9;
		this.cmdNext.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Button button = this.cmdNext;
		location = new System.Drawing.Point(320, 56);
		button.Location = location;
		this.cmdNext.Name = "cmdNext";
		System.Windows.Forms.Button button2 = this.cmdNext;
		size = new System.Drawing.Size(24, 23);
		button2.Size = size;
		this.cmdNext.TabIndex = 10;
		this.cmdNext.Text = ">";
		this.cmdPre.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Button button3 = this.cmdPre;
		location = new System.Drawing.Point(40, 56);
		button3.Location = location;
		this.cmdPre.Name = "cmdPre";
		System.Windows.Forms.Button button4 = this.cmdPre;
		size = new System.Drawing.Size(24, 23);
		button4.Size = size;
		this.cmdPre.TabIndex = 10;
		this.cmdPre.Text = "<";
		this.lblTitle.BackColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.Label label5 = this.lblTitle;
		location = new System.Drawing.Point(0, 0);
		label5.Location = location;
		this.lblTitle.Name = "lblTitle";
		System.Windows.Forms.Label label6 = this.lblTitle;
		size = new System.Drawing.Size(712, 40);
		label6.Size = size;
		this.lblTitle.TabIndex = 11;
		this.lblChapter.BackColor = System.Drawing.Color.SteelBlue;
		this.lblChapter.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblChapter.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Label label7 = this.lblChapter;
		location = new System.Drawing.Point(4, 5);
		label7.Location = location;
		this.lblChapter.Name = "lblChapter";
		System.Windows.Forms.Label label8 = this.lblChapter;
		size = new System.Drawing.Size(416, 32);
		label8.Size = size;
		this.lblChapter.TabIndex = 12;
		this.lblChapter.Text = "Chapter 1: Chapter title";
		this.lblChapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Label label9 = this.Label2;
		location = new System.Drawing.Point(40, 352);
		label9.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label10 = this.Label2;
		size = new System.Drawing.Size(120, 16);
		label10.Size = size;
		this.Label2.TabIndex = 14;
		this.Label2.Text = "Introduction";
		this.txtIntro.AutoSize = false;
		this.txtIntro.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txtIntro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtIntro.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox = this.txtIntro;
		location = new System.Drawing.Point(40, 368);
		textBox.Location = location;
		this.txtIntro.Multiline = true;
		this.txtIntro.Name = "txtIntro";
		this.txtIntro.ReadOnly = true;
		this.txtIntro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox2 = this.txtIntro;
		size = new System.Drawing.Size(656, 100);
		textBox2.Size = size;
		this.txtIntro.TabIndex = 15;
		this.txtIntro.Text = "";
		this.lblFlash_hide.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label11 = this.lblFlash_hide;
		location = new System.Drawing.Point(0, 88);
		label11.Location = location;
		this.lblFlash_hide.Name = "lblFlash_hide";
		System.Windows.Forms.Label label12 = this.lblFlash_hide;
		size = new System.Drawing.Size(40, 16);
		label12.Size = size;
		this.lblFlash_hide.TabIndex = 20;
		this.lblFlash_hide.Text = "kor.swf";
		this.lblChap_hide.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblChap_hide.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label13 = this.lblChap_hide;
		location = new System.Drawing.Point(8, 112);
		label13.Location = location;
		this.lblChap_hide.Name = "lblChap_hide";
		System.Windows.Forms.Label label14 = this.lblChap_hide;
		size = new System.Drawing.Size(32, 16);
		label14.Size = size;
		this.lblChap_hide.TabIndex = 21;
		this.lblChap_hide.Text = "chapter";
		this.lblLes_hide.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblLes_hide.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label15 = this.lblLes_hide;
		location = new System.Drawing.Point(8, 136);
		label15.Location = location;
		this.lblLes_hide.Name = "lblLes_hide";
		System.Windows.Forms.Label label16 = this.lblLes_hide;
		size = new System.Drawing.Size(32, 16);
		label16.Size = size;
		this.lblLes_hide.TabIndex = 21;
		this.lblLes_hide.Text = "Lesson";
		this.Label1.BackColor = System.Drawing.Color.SteelBlue;
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Label label17 = this.Label1;
		location = new System.Drawing.Point(584, 8);
		label17.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label18 = this.Label1;
		size = new System.Drawing.Size(56, 23);
		label18.Size = size;
		this.Label1.TabIndex = 23;
		this.Label1.Text = "Lesson:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cboLesson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboLesson.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.ComboBox comboBox3 = this.cboLesson;
		location = new System.Drawing.Point(640, 8);
		comboBox3.Location = location;
		this.cboLesson.Name = "cboLesson";
		System.Windows.Forms.ComboBox comboBox4 = this.cboLesson;
		size = new System.Drawing.Size(56, 22);
		comboBox4.Size = size;
		this.cboLesson.Sorted = true;
		this.cboLesson.TabIndex = 24;
		this.cmdColor.BackColor = System.Drawing.Color.SlateGray;
		this.cmdColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdColor.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdColor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button5 = this.cmdColor;
		location = new System.Drawing.Point(512, 320);
		button5.Location = location;
		this.cmdColor.Name = "cmdColor";
		this.cmdColor.TabIndex = 25;
		this.cmdColor.Text = "&Color";
		this.cmdClear.BackColor = System.Drawing.Color.SlateGray;
		this.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdClear.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button6 = this.cmdClear;
		location = new System.Drawing.Point(624, 320);
		button6.Location = location;
		this.cmdClear.Name = "cmdClear";
		this.cmdClear.TabIndex = 25;
		this.cmdClear.Text = "Cl&ear";
		this.cmdConsonant.BackColor = System.Drawing.Color.SlateGray;
		this.cmdConsonant.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdConsonant.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdConsonant.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button7 = this.cmdConsonant;
		location = new System.Drawing.Point(208, 320);
		button7.Location = location;
		this.cmdConsonant.Name = "cmdConsonant";
		System.Windows.Forms.Button button8 = this.cmdConsonant;
		size = new System.Drawing.Size(136, 23);
		button8.Size = size;
		this.cmdConsonant.TabIndex = 26;
		this.cmdConsonant.Text = "All &Consonants";
		this.cmdVowel.BackColor = System.Drawing.Color.SlateGray;
		this.cmdVowel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdVowel.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdVowel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button9 = this.cmdVowel;
		location = new System.Drawing.Point(368, 56);
		button9.Location = location;
		this.cmdVowel.Name = "cmdVowel";
		this.cmdVowel.TabIndex = 27;
		this.cmdVowel.Text = "&Vowels";
		this.lblLesson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.TextBox textBox3 = this.lblLesson;
		location = new System.Drawing.Point(64, 51);
		textBox3.Location = location;
		this.lblLesson.Name = "lblLesson";
		this.lblLesson.ReadOnly = true;
		System.Windows.Forms.TextBox textBox4 = this.lblLesson;
		size = new System.Drawing.Size(256, 31);
		textBox4.Size = size;
		this.lblLesson.TabIndex = 28;
		this.lblLesson.Text = "";
		this.lblLesson.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.cmdNumber.BackColor = System.Drawing.Color.SlateGray;
		this.cmdNumber.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdNumber.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button10 = this.cmdNumber;
		location = new System.Drawing.Point(624, 56);
		button10.Location = location;
		this.cmdNumber.Name = "cmdNumber";
		System.Windows.Forms.Button button11 = this.cmdNumber;
		size = new System.Drawing.Size(72, 23);
		button11.Size = size;
		this.cmdNumber.TabIndex = 27;
		this.cmdNumber.Text = "&Numbers";
		this.exFlash.Enabled = true;
		AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash = this.exFlash;
		location = new System.Drawing.Point(40, 88);
		axShockwaveFlash.Location = location;
		this.exFlash.Name = "exFlash";
		this.exFlash.OcxState = (System.Windows.Forms.AxHost.State)resourceManager.GetObject("exFlash.OcxState");
		AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash2 = this.exFlash;
		size = new System.Drawing.Size(304, 224);
		axShockwaveFlash2.Size = size;
		this.exFlash.TabIndex = 37;
		this.cmdIndependence.BackColor = System.Drawing.Color.SlateGray;
		this.cmdIndependence.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdIndependence.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdIndependence.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button12 = this.cmdIndependence;
		location = new System.Drawing.Point(456, 56);
		button12.Location = location;
		this.cmdIndependence.Name = "cmdIndependence";
		System.Windows.Forms.Button button13 = this.cmdIndependence;
		size = new System.Drawing.Size(160, 24);
		button13.Size = size;
		this.cmdIndependence.TabIndex = 27;
		this.cmdIndependence.Text = "&Independence Vowels";
		size = new System.Drawing.Size(6, 24);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(704, 482);
		this.ClientSize = size;
		this.Controls.Add(this.exFlash);
		this.Controls.Add(this.lblLesson);
		this.Controls.Add(this.cmdVowel);
		this.Controls.Add(this.cmdConsonant);
		this.Controls.Add(this.cmdColor);
		this.Controls.Add(this.cboLesson);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.lblChap_hide);
		this.Controls.Add(this.lblFlash_hide);
		this.Controls.Add(this.txtIntro);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.lblChapter);
		this.Controls.Add(this.lblTitle);
		this.Controls.Add(this.cmdNext);
		this.Controls.Add(this.cboSize);
		this.Controls.Add(this.Label4);
		this.Controls.Add(this.lblDraw);
		this.Controls.Add(this.cmdPre);
		this.Controls.Add(this.lblLes_hide);
		this.Controls.Add(this.cmdClear);
		this.Controls.Add(this.cmdNumber);
		this.Controls.Add(this.cmdIndependence);
		this.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Name = "frmChapter1";
		this.Text = "Rean Khmer Software";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		((System.ComponentModel.ISupportInitialize)this.exFlash).EndInit();
		this.ResumeLayout(false);
	}

	private void frmCh1_Resize(object sender, EventArgs e)
	{
		lblTitle.Width = Width;
	}

	private void lblDraw_MouseDown(object sender, MouseEventArgs e)
	{
		x = e.X;
		y = e.Y;
		isDown = true;
	}

	private void lblDraw_MouseMove(object sender, MouseEventArgs e)
	{
		if (isDown)
		{
			lblDraw.CreateGraphics().DrawLine(p, x, y, e.X, e.Y);
			x = e.X;
			y = e.Y;
		}
	}

	private void lblDraw_MouseUp(object sender, MouseEventArgs e)
	{
		isDown = false;
	}

	private void btnDClear_ClickEvent(object sender, EventArgs e)
	{
		lblDraw.CreateGraphics().Clear(lblDraw.BackColor);
	}

	private void btnColor_ClickEvent(object sender, EventArgs e)
	{
		if (cdlColor.ShowDialog() == DialogResult.OK)
		{
			p.Color = cdlColor.Color;
		}
	}

	private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
	{
		p.Width = SingleType.FromString(cboSize.Text);
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

	private void frmLesson_Load(object sender, EventArgs e)
	{
		Recordset recordset = new RecordsetClass();
		string connectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + Application.StartupPath + "\\reankhmer.mdb";
		cnn.ConnectionString = connectionString;
		cnn.Open();
		string source = "Select ch_title, ch_desc,les_num From tblChapter ch, tblLesson les Where ch.ch_id=les.ch_id and ch.ch_num=1";
		recordset.Open(source, cnn, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic);
		recordset.MoveFirst();
		lblChap_hide.Text = StringType.FromObject(recordset.Fields["ch_title"].Value);
		txtIntro.Text = StringType.FromObject(recordset.Fields["ch_desc"].Value);
		lblChapter.Text = "Chapter 1: ";
		lblChapter.Text += lblChap_hide.Text;
		while (!recordset.EOF)
		{
			cboLesson.Items.Add(IntegerType.FromObject(recordset.Fields["les_num"].Value));
			recordset.MoveNext();
		}
		cboLesson.SelectedIndex = 0;
		ComboBox comboBox = cboSize;
		comboBox.Items.Add(2);
		comboBox.Items.Add(4);
		comboBox.Items.Add(6);
		comboBox.Items.Add(8);
		comboBox.Items.Add(10);
		comboBox = null;
	}

	public void valueTobox()
	{
		lblFlash_hide.Text = StringType.FromObject(rst.Fields["filename"].Value);
		lblLes_hide.Text = StringType.FromObject(rst.Fields["les_title"].Value);
		lblLesson.Text = "";
		lblLesson.Text = lblLes_hide.Text;
		exFlash.Movie = Application.StartupPath + "\\flash\\" + lblFlash_hide.Text;
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
		string source = "Select les_title,filename From tblLesson les, tblSubLesson sub, tblChapter ch Where les.les_id=sub.les_id and ch.ch_id=les.ch_id and ch_num=1 and les.les_num=" + cboLesson.Text;
		rst.Open(source, cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic);
	}

	private void cmdColor_Click(object sender, EventArgs e)
	{
		if (cdlColor.ShowDialog() == DialogResult.OK)
		{
			p.Color = cdlColor.Color;
		}
	}

	private void cmdClear_Click(object sender, EventArgs e)
	{
		lblDraw.CreateGraphics().Clear(lblDraw.BackColor);
	}

	private void cmdVowel_Click(object sender, EventArgs e)
	{
		frmVowels frmVowels2 = new frmVowels();
		frmVowels2.MdiParent = MdiParent;
		frmVowels2.Show();
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

	private void cmdIndependence_Click(object sender, EventArgs e)
	{
		frmIndependence frmIndependence2 = new frmIndependence();
		frmIndependence2.MdiParent = MdiParent;
		frmIndependence2.Show();
	}
}
