using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ADODB;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class frmChapter4 : Form
{
	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("lblTitle")]
	private Label _lblTitle;

	[AccessedThroughProperty("lblLesson")]
	private TextBox _lblLesson;

	[AccessedThroughProperty("cmdStop")]
	private Button _cmdStop;

	[AccessedThroughProperty("cboLesson")]
	private ComboBox _cboLesson;

	[AccessedThroughProperty("lblLes_hide")]
	private Label _lblLes_hide;

	[AccessedThroughProperty("lblNum")]
	private Label _lblNum;

	[AccessedThroughProperty("picArticle")]
	private PictureBox _picArticle;

	[AccessedThroughProperty("txtVocabulary")]
	private TextBox _txtVocabulary;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("cmdDictionary")]
	private Button _cmdDictionary;

	[AccessedThroughProperty("cmdRead")]
	private Button _cmdRead;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("Panel1")]
	private Panel _Panel1;

	[AccessedThroughProperty("txtArticle")]
	private TextBox _txtArticle;

	[AccessedThroughProperty("txtQuest")]
	private TextBox _txtQuest;

	[AccessedThroughProperty("lblChap_hide")]
	private Label _lblChap_hide;

	[AccessedThroughProperty("rdoAns1")]
	private RadioButton _rdoAns1;

	[AccessedThroughProperty("rdoAns2")]
	private RadioButton _rdoAns2;

	[AccessedThroughProperty("rdoAns3")]
	private RadioButton _rdoAns3;

	[AccessedThroughProperty("cmdReload")]
	private Button _cmdReload;

	[AccessedThroughProperty("txtScore")]
	private TextBox _txtScore;

	[AccessedThroughProperty("cmdResult")]
	private Button _cmdResult;

	[AccessedThroughProperty("cmdNext")]
	private Button _cmdNext;

	[AccessedThroughProperty("rdo_txt3")]
	private TextBox _rdo_txt3;

	[AccessedThroughProperty("cmdClose")]
	private Button _cmdClose;

	[AccessedThroughProperty("lblImg_hide")]
	private Label _lblImg_hide;

	[AccessedThroughProperty("rdo_txt2")]
	private TextBox _rdo_txt2;

	[AccessedThroughProperty("txtPicDesc")]
	private TextBox _txtPicDesc;

	[AccessedThroughProperty("cmdPicNext")]
	private Button _cmdPicNext;

	[AccessedThroughProperty("cmdPicPre")]
	private Button _cmdPicPre;

	[AccessedThroughProperty("rdo_txt1")]
	private TextBox _rdo_txt1;

	[AccessedThroughProperty("lblChapter")]
	private Label _lblChapter;

	private IContainer components;

	private Application app;

	private Connection cnn;

	private Recordset rst;

	private Recordset rst_t;

	private int test_score;

	private int num_did;

	private int num_quest;

	private string getAllAns;

	private int checkNum;

	private string getSound;

	private const int LOW = 3;

	private const int MEDIUM = 5;

	private const int HIGHT = 8;

	private const int SND_LOOP = 8;

	private const int SND_ASYNC = 1;

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

	internal virtual PictureBox picArticle
	{
		get
		{
			return _picArticle;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_picArticle != null)
			{
			}
			_picArticle = value;
			if (_picArticle == null)
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

	internal virtual GroupBox GroupBox1
	{
		get
		{
			return _GroupBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_GroupBox1 != null)
			{
			}
			_GroupBox1 = value;
			if (_GroupBox1 == null)
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

	internal virtual GroupBox GroupBox2
	{
		get
		{
			return _GroupBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_GroupBox2 != null)
			{
			}
			_GroupBox2 = value;
			if (_GroupBox2 == null)
			{
			}
		}
	}

	internal virtual Panel Panel1
	{
		get
		{
			return _Panel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Panel1 != null)
			{
			}
			_Panel1 = value;
			if (_Panel1 == null)
			{
			}
		}
	}

	internal virtual TextBox txtArticle
	{
		get
		{
			return _txtArticle;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtArticle != null)
			{
			}
			_txtArticle = value;
			if (_txtArticle == null)
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

	internal virtual TextBox txtQuest
	{
		get
		{
			return _txtQuest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtQuest != null)
			{
			}
			_txtQuest = value;
			if (_txtQuest == null)
			{
			}
		}
	}

	internal virtual RadioButton rdoAns1
	{
		get
		{
			return _rdoAns1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdoAns1 != null)
			{
			}
			_rdoAns1 = value;
			if (_rdoAns1 == null)
			{
			}
		}
	}

	internal virtual RadioButton rdoAns2
	{
		get
		{
			return _rdoAns2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdoAns2 != null)
			{
			}
			_rdoAns2 = value;
			if (_rdoAns2 == null)
			{
			}
		}
	}

	internal virtual RadioButton rdoAns3
	{
		get
		{
			return _rdoAns3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdoAns3 != null)
			{
			}
			_rdoAns3 = value;
			if (_rdoAns3 == null)
			{
			}
		}
	}

	internal virtual Button cmdReload
	{
		get
		{
			return _cmdReload;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdReload != null)
			{
				_cmdReload.Click -= cmdReload_Click;
			}
			_cmdReload = value;
			if (_cmdReload != null)
			{
				_cmdReload.Click += cmdReload_Click;
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

	internal virtual TextBox txtScore
	{
		get
		{
			return _txtScore;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtScore != null)
			{
			}
			_txtScore = value;
			if (_txtScore == null)
			{
			}
		}
	}

	internal virtual Button cmdResult
	{
		get
		{
			return _cmdResult;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdResult != null)
			{
				_cmdResult.Click -= cmdResult_Click;
			}
			_cmdResult = value;
			if (_cmdResult != null)
			{
				_cmdResult.Click += cmdResult_Click;
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

	internal virtual Label lblImg_hide
	{
		get
		{
			return _lblImg_hide;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblImg_hide != null)
			{
			}
			_lblImg_hide = value;
			if (_lblImg_hide == null)
			{
			}
		}
	}

	internal virtual TextBox txtPicDesc
	{
		get
		{
			return _txtPicDesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtPicDesc != null)
			{
			}
			_txtPicDesc = value;
			if (_txtPicDesc == null)
			{
			}
		}
	}

	internal virtual Button cmdPicNext
	{
		get
		{
			return _cmdPicNext;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdPicNext != null)
			{
				_cmdPicNext.Click -= cmdPicNext_Click;
			}
			_cmdPicNext = value;
			if (_cmdPicNext != null)
			{
				_cmdPicNext.Click += cmdPicNext_Click;
			}
		}
	}

	internal virtual Button cmdPicPre
	{
		get
		{
			return _cmdPicPre;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdPicPre != null)
			{
				_cmdPicPre.Click -= cmdPicPre_Click;
			}
			_cmdPicPre = value;
			if (_cmdPicPre != null)
			{
				_cmdPicPre.Click += cmdPicPre_Click;
			}
		}
	}

	internal virtual TextBox rdo_txt1
	{
		get
		{
			return _rdo_txt1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdo_txt1 != null)
			{
			}
			_rdo_txt1 = value;
			if (_rdo_txt1 == null)
			{
			}
		}
	}

	internal virtual TextBox rdo_txt2
	{
		get
		{
			return _rdo_txt2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdo_txt2 != null)
			{
			}
			_rdo_txt2 = value;
			if (_rdo_txt2 == null)
			{
			}
		}
	}

	internal virtual TextBox rdo_txt3
	{
		get
		{
			return _rdo_txt3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdo_txt3 != null)
			{
			}
			_rdo_txt3 = value;
			if (_rdo_txt3 == null)
			{
			}
		}
	}

	internal virtual Button cmdRead
	{
		get
		{
			return _cmdRead;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdRead != null)
			{
				_cmdRead.Click -= cmdRead_Click;
			}
			_cmdRead = value;
			if (_cmdRead != null)
			{
				_cmdRead.Click += cmdRead_Click;
			}
		}
	}

	internal virtual Button cmdStop
	{
		get
		{
			return _cmdStop;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdStop != null)
			{
				_cmdStop.Click -= cmdStop_Click;
			}
			_cmdStop = value;
			if (_cmdStop != null)
			{
				_cmdStop.Click += cmdStop_Click;
			}
		}
	}

	public frmChapter4()
	{
		base.Load += frmChapter4_Load;
		base.Resize += frmChapter4_Resize;
		cnn = new ConnectionClass();
		rst = new RecordsetClass();
		rst_t = new RecordsetClass();
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
		this.cboLesson = new System.Windows.Forms.ComboBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.lblChapter = new System.Windows.Forms.Label();
		this.lblTitle = new System.Windows.Forms.Label();
		this.txtArticle = new System.Windows.Forms.TextBox();
		this.picArticle = new System.Windows.Forms.PictureBox();
		this.lblLesson = new System.Windows.Forms.TextBox();
		this.txtPicDesc = new System.Windows.Forms.TextBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.cmdDictionary = new System.Windows.Forms.Button();
		this.txtVocabulary = new System.Windows.Forms.TextBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.rdo_txt1 = new System.Windows.Forms.TextBox();
		this.Panel1 = new System.Windows.Forms.Panel();
		this.txtScore = new System.Windows.Forms.TextBox();
		this.cmdReload = new System.Windows.Forms.Button();
		this.cmdNext = new System.Windows.Forms.Button();
		this.cmdResult = new System.Windows.Forms.Button();
		this.cmdClose = new System.Windows.Forms.Button();
		this.rdoAns3 = new System.Windows.Forms.RadioButton();
		this.rdoAns2 = new System.Windows.Forms.RadioButton();
		this.rdoAns1 = new System.Windows.Forms.RadioButton();
		this.txtQuest = new System.Windows.Forms.TextBox();
		this.rdo_txt2 = new System.Windows.Forms.TextBox();
		this.rdo_txt3 = new System.Windows.Forms.TextBox();
		this.cmdPicNext = new System.Windows.Forms.Button();
		this.cmdPicPre = new System.Windows.Forms.Button();
		this.lblChap_hide = new System.Windows.Forms.Label();
		this.lblImg_hide = new System.Windows.Forms.Label();
		this.lblLes_hide = new System.Windows.Forms.Label();
		this.lblNum = new System.Windows.Forms.Label();
		this.cmdRead = new System.Windows.Forms.Button();
		this.cmdStop = new System.Windows.Forms.Button();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.Panel1.SuspendLayout();
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
		this.cboLesson.TabIndex = 32;
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
		this.Label1.TabIndex = 31;
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
		this.lblChapter.TabIndex = 30;
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
		this.lblTitle.TabIndex = 29;
		this.txtArticle.AutoSize = false;
		this.txtArticle.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txtArticle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtArticle.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox = this.txtArticle;
		location = new System.Drawing.Point(272, 96);
		textBox.Location = location;
		this.txtArticle.Multiline = true;
		this.txtArticle.Name = "txtArticle";
		this.txtArticle.ReadOnly = true;
		this.txtArticle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox2 = this.txtArticle;
		size = new System.Drawing.Size(432, 208);
		textBox2.Size = size;
		this.txtArticle.TabIndex = 35;
		this.txtArticle.Text = "";
		this.picArticle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox = this.picArticle;
		location = new System.Drawing.Point(8, 96);
		pictureBox.Location = location;
		this.picArticle.Name = "picArticle";
		System.Windows.Forms.PictureBox pictureBox2 = this.picArticle;
		size = new System.Drawing.Size(256, 208);
		pictureBox2.Size = size;
		this.picArticle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picArticle.TabIndex = 37;
		this.picArticle.TabStop = false;
		this.lblLesson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblLesson.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox3 = this.lblLesson;
		location = new System.Drawing.Point(280, 70);
		textBox3.Location = location;
		this.lblLesson.Name = "lblLesson";
		this.lblLesson.ReadOnly = true;
		System.Windows.Forms.TextBox textBox4 = this.lblLesson;
		size = new System.Drawing.Size(400, 31);
		textBox4.Size = size;
		this.lblLesson.TabIndex = 43;
		this.lblLesson.Text = "";
		this.lblLesson.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtPicDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtPicDesc.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox5 = this.txtPicDesc;
		location = new System.Drawing.Point(32, 70);
		textBox5.Location = location;
		this.txtPicDesc.Name = "txtPicDesc";
		this.txtPicDesc.ReadOnly = true;
		System.Windows.Forms.TextBox textBox6 = this.txtPicDesc;
		size = new System.Drawing.Size(208, 31);
		textBox6.Size = size;
		this.txtPicDesc.TabIndex = 44;
		this.txtPicDesc.Text = "";
		this.txtPicDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.GroupBox1.Controls.Add(this.cmdDictionary);
		this.GroupBox1.Controls.Add(this.txtVocabulary);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(8, 336);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		size = new System.Drawing.Size(256, 144);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 45;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Vocabularies:";
		this.cmdDictionary.BackColor = System.Drawing.Color.SlateGray;
		this.cmdDictionary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdDictionary.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button = this.cmdDictionary;
		location = new System.Drawing.Point(104, 112);
		button.Location = location;
		this.cmdDictionary.Name = "cmdDictionary";
		System.Windows.Forms.Button button2 = this.cmdDictionary;
		size = new System.Drawing.Size(144, 23);
		button2.Size = size;
		this.cmdDictionary.TabIndex = 47;
		this.cmdDictionary.Text = "&Check in dictionary";
		this.txtVocabulary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtVocabulary.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox7 = this.txtVocabulary;
		location = new System.Drawing.Point(8, 16);
		textBox7.Location = location;
		this.txtVocabulary.Multiline = true;
		this.txtVocabulary.Name = "txtVocabulary";
		this.txtVocabulary.ReadOnly = true;
		this.txtVocabulary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox8 = this.txtVocabulary;
		size = new System.Drawing.Size(240, 88);
		textBox8.Size = size;
		this.txtVocabulary.TabIndex = 0;
		this.txtVocabulary.Text = "";
		this.GroupBox2.Controls.Add(this.rdo_txt1);
		this.GroupBox2.Controls.Add(this.Panel1);
		this.GroupBox2.Controls.Add(this.rdoAns3);
		this.GroupBox2.Controls.Add(this.rdoAns2);
		this.GroupBox2.Controls.Add(this.rdoAns1);
		this.GroupBox2.Controls.Add(this.txtQuest);
		this.GroupBox2.Controls.Add(this.rdo_txt2);
		this.GroupBox2.Controls.Add(this.rdo_txt3);
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox2;
		location = new System.Drawing.Point(272, 336);
		groupBox3.Location = location;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox2;
		size = new System.Drawing.Size(432, 144);
		groupBox4.Size = size;
		this.GroupBox2.TabIndex = 46;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Exercise:";
		this.rdo_txt1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.rdo_txt1.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox9 = this.rdo_txt1;
		location = new System.Drawing.Point(32, 64);
		textBox9.Location = location;
		this.rdo_txt1.Name = "rdo_txt1";
		this.rdo_txt1.ReadOnly = true;
		System.Windows.Forms.TextBox textBox10 = this.rdo_txt1;
		size = new System.Drawing.Size(192, 24);
		textBox10.Size = size;
		this.rdo_txt1.TabIndex = 5;
		this.rdo_txt1.Text = "";
		this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.Panel1.Controls.Add(this.txtScore);
		this.Panel1.Controls.Add(this.cmdReload);
		this.Panel1.Controls.Add(this.cmdNext);
		this.Panel1.Controls.Add(this.cmdResult);
		this.Panel1.Controls.Add(this.cmdClose);
		System.Windows.Forms.Panel panel = this.Panel1;
		location = new System.Drawing.Point(232, 64);
		panel.Location = location;
		this.Panel1.Name = "Panel1";
		System.Windows.Forms.Panel panel2 = this.Panel1;
		size = new System.Drawing.Size(192, 72);
		panel2.Size = size;
		this.Panel1.TabIndex = 4;
		this.txtScore.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txtScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.TextBox textBox11 = this.txtScore;
		location = new System.Drawing.Point(72, 8);
		textBox11.Location = location;
		this.txtScore.Name = "txtScore";
		this.txtScore.ReadOnly = true;
		System.Windows.Forms.TextBox textBox12 = this.txtScore;
		size = new System.Drawing.Size(112, 20);
		textBox12.Size = size;
		this.txtScore.TabIndex = 1;
		this.txtScore.Text = "0";
		this.txtScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.cmdReload.BackColor = System.Drawing.Color.SlateGray;
		this.cmdReload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdReload.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button3 = this.cmdReload;
		location = new System.Drawing.Point(8, 40);
		button3.Location = location;
		this.cmdReload.Name = "cmdReload";
		System.Windows.Forms.Button button4 = this.cmdReload;
		size = new System.Drawing.Size(56, 23);
		button4.Size = size;
		this.cmdReload.TabIndex = 0;
		this.cmdReload.Text = "&Reload";
		this.cmdNext.BackColor = System.Drawing.Color.SlateGray;
		this.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdNext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Button button5 = this.cmdNext;
		location = new System.Drawing.Point(8, 8);
		button5.Location = location;
		this.cmdNext.Name = "cmdNext";
		System.Windows.Forms.Button button6 = this.cmdNext;
		size = new System.Drawing.Size(56, 23);
		button6.Size = size;
		this.cmdNext.TabIndex = 0;
		this.cmdNext.Text = "&Next";
		this.cmdResult.BackColor = System.Drawing.Color.SlateGray;
		this.cmdResult.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdResult.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Button button7 = this.cmdResult;
		location = new System.Drawing.Point(72, 40);
		button7.Location = location;
		this.cmdResult.Name = "cmdResult";
		System.Windows.Forms.Button button8 = this.cmdResult;
		size = new System.Drawing.Size(56, 23);
		button8.Size = size;
		this.cmdResult.TabIndex = 0;
		this.cmdResult.Text = "&Result";
		this.cmdClose.BackColor = System.Drawing.Color.SlateGray;
		this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button9 = this.cmdClose;
		location = new System.Drawing.Point(136, 40);
		button9.Location = location;
		this.cmdClose.Name = "cmdClose";
		System.Windows.Forms.Button button10 = this.cmdClose;
		size = new System.Drawing.Size(48, 23);
		button10.Size = size;
		this.cmdClose.TabIndex = 0;
		this.cmdClose.Text = "Clo&se";
		this.rdoAns3.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.RadioButton radioButton = this.rdoAns3;
		location = new System.Drawing.Point(16, 117);
		radioButton.Location = location;
		this.rdoAns3.Name = "rdoAns3";
		System.Windows.Forms.RadioButton radioButton2 = this.rdoAns3;
		size = new System.Drawing.Size(16, 24);
		radioButton2.Size = size;
		this.rdoAns3.TabIndex = 3;
		this.rdoAns3.Text = "RadioButton3";
		this.rdoAns2.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.RadioButton radioButton3 = this.rdoAns2;
		location = new System.Drawing.Point(16, 89);
		radioButton3.Location = location;
		this.rdoAns2.Name = "rdoAns2";
		System.Windows.Forms.RadioButton radioButton4 = this.rdoAns2;
		size = new System.Drawing.Size(16, 24);
		radioButton4.Size = size;
		this.rdoAns2.TabIndex = 2;
		this.rdoAns2.Text = "RadioButton2";
		this.rdoAns1.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.RadioButton radioButton5 = this.rdoAns1;
		location = new System.Drawing.Point(16, 59);
		radioButton5.Location = location;
		this.rdoAns1.Name = "rdoAns1";
		System.Windows.Forms.RadioButton radioButton6 = this.rdoAns1;
		size = new System.Drawing.Size(16, 32);
		radioButton6.Size = size;
		this.rdoAns1.TabIndex = 1;
		this.rdoAns1.Text = "RadioButton1";
		this.txtQuest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtQuest.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox13 = this.txtQuest;
		location = new System.Drawing.Point(8, 24);
		textBox13.Location = location;
		this.txtQuest.Name = "txtQuest";
		this.txtQuest.ReadOnly = true;
		System.Windows.Forms.TextBox textBox14 = this.txtQuest;
		size = new System.Drawing.Size(416, 31);
		textBox14.Size = size;
		this.txtQuest.TabIndex = 0;
		this.txtQuest.Text = "";
		this.txtQuest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.rdo_txt2.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.rdo_txt2.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox15 = this.rdo_txt2;
		location = new System.Drawing.Point(32, 88);
		textBox15.Location = location;
		this.rdo_txt2.Name = "rdo_txt2";
		this.rdo_txt2.ReadOnly = true;
		System.Windows.Forms.TextBox textBox16 = this.rdo_txt2;
		size = new System.Drawing.Size(192, 24);
		textBox16.Size = size;
		this.rdo_txt2.TabIndex = 5;
		this.rdo_txt2.Text = "";
		this.rdo_txt3.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.rdo_txt3.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox17 = this.rdo_txt3;
		location = new System.Drawing.Point(32, 112);
		textBox17.Location = location;
		this.rdo_txt3.Name = "rdo_txt3";
		this.rdo_txt3.ReadOnly = true;
		System.Windows.Forms.TextBox textBox18 = this.rdo_txt3;
		size = new System.Drawing.Size(192, 24);
		textBox18.Size = size;
		this.rdo_txt3.TabIndex = 5;
		this.rdo_txt3.Text = "";
		this.cmdPicNext.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Button button11 = this.cmdPicNext;
		location = new System.Drawing.Point(240, 72);
		button11.Location = location;
		this.cmdPicNext.Name = "cmdPicNext";
		System.Windows.Forms.Button button12 = this.cmdPicNext;
		size = new System.Drawing.Size(24, 23);
		button12.Size = size;
		this.cmdPicNext.TabIndex = 48;
		this.cmdPicNext.Text = ">";
		this.cmdPicPre.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Button button13 = this.cmdPicPre;
		location = new System.Drawing.Point(8, 72);
		button13.Location = location;
		this.cmdPicPre.Name = "cmdPicPre";
		System.Windows.Forms.Button button14 = this.cmdPicPre;
		size = new System.Drawing.Size(24, 23);
		button14.Size = size;
		this.cmdPicPre.TabIndex = 47;
		this.cmdPicPre.Text = "<";
		this.lblChap_hide.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblChap_hide.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label7 = this.lblChap_hide;
		location = new System.Drawing.Point(272, 312);
		label7.Location = location;
		this.lblChap_hide.Name = "lblChap_hide";
		System.Windows.Forms.Label label8 = this.lblChap_hide;
		size = new System.Drawing.Size(32, 16);
		label8.Size = size;
		this.lblChap_hide.TabIndex = 49;
		this.lblChap_hide.Text = "chapter";
		this.lblImg_hide.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label9 = this.lblImg_hide;
		location = new System.Drawing.Point(344, 312);
		label9.Location = location;
		this.lblImg_hide.Name = "lblImg_hide";
		System.Windows.Forms.Label label10 = this.lblImg_hide;
		size = new System.Drawing.Size(40, 16);
		label10.Size = size;
		this.lblImg_hide.TabIndex = 52;
		this.lblImg_hide.Text = "kor.swf";
		this.lblLes_hide.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblLes_hide.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label11 = this.lblLes_hide;
		location = new System.Drawing.Point(304, 312);
		label11.Location = location;
		this.lblLes_hide.Name = "lblLes_hide";
		System.Windows.Forms.Label label12 = this.lblLes_hide;
		size = new System.Drawing.Size(32, 16);
		label12.Size = size;
		this.lblLes_hide.TabIndex = 51;
		this.lblLes_hide.Text = "Lesson";
		this.lblNum.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label13 = this.lblNum;
		location = new System.Drawing.Point(200, 312);
		label13.Location = location;
		this.lblNum.Name = "lblNum";
		System.Windows.Forms.Label label14 = this.lblNum;
		size = new System.Drawing.Size(48, 23);
		label14.Size = size;
		this.lblNum.TabIndex = 50;
		this.lblNum.Text = "2";
		this.cmdRead.BackColor = System.Drawing.SystemColors.AppWorkspace;
		this.cmdRead.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdRead.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button15 = this.cmdRead;
		location = new System.Drawing.Point(536, 312);
		button15.Location = location;
		this.cmdRead.Name = "cmdRead";
		this.cmdRead.TabIndex = 53;
		this.cmdRead.Text = "&Read Article";
		this.cmdStop.BackColor = System.Drawing.SystemColors.AppWorkspace;
		this.cmdStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdStop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button16 = this.cmdStop;
		location = new System.Drawing.Point(616, 312);
		button16.Location = location;
		this.cmdStop.Name = "cmdStop";
		System.Windows.Forms.Button button17 = this.cmdStop;
		size = new System.Drawing.Size(88, 23);
		button17.Size = size;
		this.cmdStop.TabIndex = 53;
		this.cmdStop.Text = "Stop Reading";
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(722, 487);
		this.ClientSize = size;
		this.Controls.Add(this.cmdRead);
		this.Controls.Add(this.lblImg_hide);
		this.Controls.Add(this.lblLes_hide);
		this.Controls.Add(this.lblNum);
		this.Controls.Add(this.lblChap_hide);
		this.Controls.Add(this.cmdPicNext);
		this.Controls.Add(this.cmdPicPre);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.txtPicDesc);
		this.Controls.Add(this.lblLesson);
		this.Controls.Add(this.picArticle);
		this.Controls.Add(this.txtArticle);
		this.Controls.Add(this.cboLesson);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.lblChapter);
		this.Controls.Add(this.lblTitle);
		this.Controls.Add(this.cmdStop);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.Name = "frmChapter4";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "frmChapter4";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.Panel1.ResumeLayout(false);
		this.ResumeLayout(false);
	}

	[DllImport("winmm.dll", CharSet = CharSet.Ansi, EntryPoint = "sndPlaySoundA", ExactSpelling = true, SetLastError = true)]
	private static extern long sndPlaySound([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszSoundName, long uFlags);

	private void playSound(string filename)
	{
		long num = sndPlaySound(ref filename, 1L);
	}

	[DllImport("winmm.dll", CharSet = CharSet.Ansi, EntryPoint = "mciSendStringA", ExactSpelling = true, SetLastError = true)]
	private static extern long mciSendString([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpstrCommand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpstrReturnString, long uReturnLength, long hwndCallback);

	private void pSound(string filename)
	{
		string lpstrCommand = "PLAY " + filename;
		string lpstrReturnString = StringType.FromInteger(0);
		long num = mciSendString(ref lpstrCommand, ref lpstrReturnString, 0L, 0L);
	}

	private void stopSound(string filename)
	{
		string lpstrCommand = "STOP " + filename;
		string lpstrReturnString = StringType.FromInteger(0);
		long num = mciSendString(ref lpstrCommand, ref lpstrReturnString, 0L, 0L);
	}

	private void frmChapter4_Load(object sender, EventArgs e)
	{
		Recordset recordset = new RecordsetClass();
		string connectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + Application.StartupPath + "\\reankhmer.mdb";
		cnn.ConnectionString = connectionString;
		cnn.Open();
		string source = "Select ch_title, ch_desc,les_num From tblChapter ch, tblLesson les Where ch.ch_id=les.ch_id and ch.ch_num=4";
		recordset.Open(source, cnn, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic);
		recordset.MoveFirst();
		lblChap_hide.Text = StringType.FromObject(recordset.Fields["ch_title"].Value);
		lblChapter.Text = "Chapter 4: ";
		lblChapter.Text += lblChap_hide.Text;
		while (!recordset.EOF)
		{
			cboLesson.Items.Add(IntegerType.FromObject(recordset.Fields["les_num"].Value));
			recordset.MoveNext();
		}
		cboLesson.SelectedIndex = 0;
	}

	public void queryLes()
	{
		string source = "Select article,getLink,vocabulary,les_title,filename,desc From tblLesson les, tblSubLesson sub, tblChapter ch Where les.les_id=sub.les_id and ch.ch_id=les.ch_id and ch_num=4 and les.les_num=" + cboLesson.Text;
		rst.Open(source, cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic);
	}

	public void queryLes_test()
	{
		Recordset recordset = new RecordsetClass();
		string source = "Select question,answer,check From tblLesson les, tblChapter ch, tblTest ts, tblTest_res trs Where ch.ch_id=les.ch_id and ch_num=4 and les.les_id=ts.les_id and ts.test_id=trs.test_id and les.les_num=" + cboLesson.Text + " ORDER BY rang, test_res_id";
		string source2 = "Select count(test_id) as allQ From tblLesson les, tblChapter ch, tblTest ts Where ch.ch_id=les.ch_id and ch_num=4 and les.les_id=ts.les_id and les.les_num=" + cboLesson.Text;
		rst_t.Open(source, cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic);
		if (recordset.State == 1)
		{
			recordset.Close();
		}
		recordset.Open(source2, cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic);
		num_quest = IntegerType.FromObject(recordset.Fields["allQ"].Value);
	}

	private void cboLesson_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (rst.State == 1)
		{
			rst.Close();
		}
		if (rst_t.State == 1)
		{
			rst_t.Close();
		}
		queryLes();
		rst.MoveFirst();
		valueTobox();
		queryLes_test();
		rst_t.MoveFirst();
		getTest_in2box();
	}

	public void valueTobox()
	{
		lblImg_hide.Text = StringType.FromObject(rst.Fields["filename"].Value);
		lblLes_hide.Text = StringType.FromObject(rst.Fields["les_title"].Value);
		lblLesson.Text = "";
		lblLesson.Text = lblLes_hide.Text;
		picArticle.Image = Image.FromFile(Application.StartupPath + "\\images\\" + lblImg_hide.Text);
		txtPicDesc.Text = StringType.FromObject(rst.Fields["desc"].Value);
		getSound = Application.StartupPath + "\\reading\\" + StringType.FromObject(rst.Fields["getLink"].Value) + ".mp3";
		txtVocabulary.Text = StringType.FromObject(rst.Fields["vocabulary"].Value);
		txtArticle.Text = "\r\n" + StringType.FromObject(rst.Fields["article"].Value);
	}

	private void getTest_in2box()
	{
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		if (!rst_t.EOF)
		{
			txtQuest.Text = StringType.FromObject(rst_t.Fields["question"].Value);
			rdo_txt1.Text = StringType.FromObject(rst_t.Fields["answer"].Value);
			rdoAns1.Tag = StringType.FromObject(rst_t.Fields["check"].Value);
			rst_t.MoveNext();
			if (rst_t.EOF)
			{
				rst_t.MovePrevious();
			}
			rdo_txt2.Text = StringType.FromObject(rst_t.Fields["answer"].Value);
			rdoAns2.Tag = StringType.FromObject(rst_t.Fields["check"].Value);
			rst_t.MoveNext();
			if (rst_t.EOF)
			{
				rst_t.MovePrevious();
			}
			rdo_txt3.Text = StringType.FromObject(rst_t.Fields["answer"].Value);
			rdoAns3.Tag = StringType.FromObject(rst_t.Fields["check"].Value);
		}
		else
		{
			Interaction.MsgBox((object)"You have finish the test. Click RESULT Button to see the result. Click RELOAD Button to start doing the test again.", (MsgBoxStyle)64, (object)"Test Finished");
		}
	}

	private void cmdPicNext_Click(object sender, EventArgs e)
	{
		rst.MoveNext();
		if (rst.EOF)
		{
			rst.MovePrevious();
		}
		picArticle.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromObject(rst.Fields["filename"].Value));
		txtPicDesc.Text = StringType.FromObject(rst.Fields["desc"].Value);
	}

	private void cmdPicPre_Click(object sender, EventArgs e)
	{
		rst.MovePrevious();
		if (rst.BOF)
		{
			rst.MoveNext();
		}
		picArticle.Image = Image.FromFile(Application.StartupPath + "\\images\\" + lblImg_hide.Text);
		txtPicDesc.Text = StringType.FromObject(rst.Fields["desc"].Value);
	}

	private void cmdNext_Click(object sender, EventArgs e)
	{
		checked
		{
			if (rdoAns1.Checked)
			{
				if (ObjectType.ObjTst(rdoAns1.Tag, (object)1, false) == 0)
				{
					test_score += 3;
					num_did++;
					getAllAns = string.Concat(getAllAns, txtQuest.Text + "\t(" + rdo_txt1.Text, ")\r\n");
				}
				checkNum++;
			}
			if (rdoAns2.Checked)
			{
				if (ObjectType.ObjTst(rdoAns2.Tag, (object)1, false) == 0)
				{
					test_score += 3;
					num_did++;
					getAllAns = string.Concat(getAllAns, txtQuest.Text + "\t(" + rdo_txt2.Text, ")\r\n");
				}
				checkNum++;
			}
			if (rdoAns3.Checked)
			{
				if (ObjectType.ObjTst(rdoAns3.Tag, (object)1, false) == 0)
				{
					test_score += 3;
					num_did++;
					getAllAns = string.Concat(getAllAns, txtQuest.Text + "\t(" + rdo_txt3.Text, ")\r\n");
				}
				checkNum++;
			}
			txtScore.Text = StringType.FromInteger(test_score);
			if (!rst_t.EOF)
			{
				rst_t.MoveNext();
			}
			rdoRelease(t: false);
			getTest_in2box();
		}
	}

	private void cmdReload_Click(object sender, EventArgs e)
	{
		txtScore.Text = StringType.FromInteger(0);
		test_score = 0;
		num_did = 0;
		checkNum = 0;
		rst_t.MoveFirst();
		rdoRelease(t: false);
		getTest_in2box();
	}

	private void cmdClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void cmdDictionary_Click(object sender, EventArgs e)
	{
		frmDictionary frmDictionary2 = new frmDictionary();
		frmDictionary2.MdiParent = MdiParent;
		frmDictionary2.txtSearch.Focus();
		frmDictionary2.Show();
	}

	private void rdoRelease(bool t)
	{
		rdoAns1.Checked = t;
		rdoAns2.Checked = t;
		rdoAns3.Checked = t;
	}

	private void cmdResult_Click(object sender, EventArgs e)
	{
		frmTestResult frmTestResult2 = new frmTestResult();
		frmTestResult2.lblScore.Text = txtScore.Text;
		frmTestResult2.lblAns.Text = StringType.FromInteger(num_did) + "/" + StringType.FromInteger(num_quest) + " correct answer.";
		if (num_did > 0)
		{
			frmTestResult2.txtResult.Text = getAllAns;
			int num = checked(num_quest - checkNum);
			if (num > 0)
			{
				TextBox txtResult = frmTestResult2.txtResult;
				txtResult.Text = txtResult.Text + "\r\nYou still have " + StringType.FromInteger(num) + " question(s) not done!";
			}
		}
		else
		{
			frmTestResult2.txtResult.Text = "You must do the test by choosing a choice!";
		}
		frmTestResult2.Show();
	}

	private void frmChapter4_Resize(object sender, EventArgs e)
	{
		lblTitle.Width = Width;
	}

	private void cmdRead_Click(object sender, EventArgs e)
	{
		pSound(getSound);
	}

	private void cmdStop_Click(object sender, EventArgs e)
	{
		stopSound(getSound);
	}
}
