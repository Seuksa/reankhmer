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

public class frmChapter5 : Form
{
	[AccessedThroughProperty("txtCon1")]
	private TextBox _txtCon1;

	[AccessedThroughProperty("cmdResult")]
	private Button _cmdResult;

	[AccessedThroughProperty("lblNum")]
	private Label _lblNum;

	[AccessedThroughProperty("lblChapter")]
	private Label _lblChapter;

	[AccessedThroughProperty("cmdHelp")]
	private Button _cmdHelp;

	[AccessedThroughProperty("txtVocabulary")]
	private TextBox _txtVocabulary;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("Label6")]
	private Label _Label6;

	[AccessedThroughProperty("cmdIntroduction")]
	private Button _cmdIntroduction;

	[AccessedThroughProperty("cmdNextTest")]
	private Button _cmdNextTest;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("cmdNext")]
	private Button _cmdNext;

	[AccessedThroughProperty("cmdReloadTest")]
	private Button _cmdReloadTest;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("txtTest3")]
	private TextBox _txtTest3;

	[AccessedThroughProperty("txtTest2")]
	private TextBox _txtTest2;

	[AccessedThroughProperty("txtTest1")]
	private TextBox _txtTest1;

	[AccessedThroughProperty("txtAnswer")]
	private TextBox _txtAnswer;

	[AccessedThroughProperty("lblQuestion")]
	private Label _lblQuestion;

	[AccessedThroughProperty("grbTest")]
	private GroupBox _grbTest;

	[AccessedThroughProperty("txtCon2")]
	private TextBox _txtCon2;

	[AccessedThroughProperty("pic_con2")]
	private PictureBox _pic_con2;

	[AccessedThroughProperty("cboLesson")]
	private ComboBox _cboLesson;

	[AccessedThroughProperty("pic_con1")]
	private PictureBox _pic_con1;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("lblLes_hide")]
	private Label _lblLes_hide;

	[AccessedThroughProperty("txtLesTitle")]
	private TextBox _txtLesTitle;

	[AccessedThroughProperty("lblTitle")]
	private Label _lblTitle;

	[AccessedThroughProperty("lblChap_hide")]
	private Label _lblChap_hide;

	[AccessedThroughProperty("picLes")]
	private PictureBox _picLes;

	[AccessedThroughProperty("lblFlash_hide")]
	private Label _lblFlash_hide;

	[AccessedThroughProperty("GroupBox3")]
	private GroupBox _GroupBox3;

	[AccessedThroughProperty("cmdReload")]
	private Button _cmdReload;

	[AccessedThroughProperty("cmdClose")]
	private Button _cmdClose;

	[AccessedThroughProperty("cmdEnable")]
	private Button _cmdEnable;

	[AccessedThroughProperty("cmdDictionary")]
	private Button _cmdDictionary;

	private IContainer components;

	private Application app;

	private Connection cnn;

	private Recordset rst;

	private Recordset rst_t;

	private string getIntro;

	private string sound1;

	private string sound2;

	private int num_quest;

	private string test_check;

	private int clickNum;

	private int getScore;

	private const int SND_LOOP = 8;

	private const int SND_ASYNC = 1;

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

	internal virtual Button cmdEnable
	{
		get
		{
			return _cmdEnable;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdEnable != null)
			{
				_cmdEnable.Click -= cmdEnable_Click;
			}
			_cmdEnable = value;
			if (_cmdEnable != null)
			{
				_cmdEnable.Click += cmdEnable_Click;
			}
		}
	}

	internal virtual GroupBox GroupBox3
	{
		get
		{
			return _GroupBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_GroupBox3 != null)
			{
			}
			_GroupBox3 = value;
			if (_GroupBox3 == null)
			{
			}
		}
	}

	internal virtual PictureBox picLes
	{
		get
		{
			return _picLes;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_picLes != null)
			{
			}
			_picLes = value;
			if (_picLes == null)
			{
			}
		}
	}

	internal virtual TextBox txtLesTitle
	{
		get
		{
			return _txtLesTitle;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtLesTitle != null)
			{
			}
			_txtLesTitle = value;
			if (_txtLesTitle == null)
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

	internal virtual TextBox txtCon1
	{
		get
		{
			return _txtCon1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtCon1 != null)
			{
			}
			_txtCon1 = value;
			if (_txtCon1 == null)
			{
			}
		}
	}

	internal virtual PictureBox pic_con1
	{
		get
		{
			return _pic_con1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic_con1 != null)
			{
				_pic_con1.Click -= pic_con1_Click;
			}
			_pic_con1 = value;
			if (_pic_con1 != null)
			{
				_pic_con1.Click += pic_con1_Click;
			}
		}
	}

	internal virtual PictureBox pic_con2
	{
		get
		{
			return _pic_con2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic_con2 != null)
			{
				_pic_con2.Click -= pic_con2_Click;
			}
			_pic_con2 = value;
			if (_pic_con2 != null)
			{
				_pic_con2.Click += pic_con2_Click;
			}
		}
	}

	internal virtual TextBox txtCon2
	{
		get
		{
			return _txtCon2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtCon2 != null)
			{
			}
			_txtCon2 = value;
			if (_txtCon2 == null)
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

	internal virtual GroupBox grbTest
	{
		get
		{
			return _grbTest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_grbTest != null)
			{
			}
			_grbTest = value;
			if (_grbTest == null)
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

	internal virtual Label lblQuestion
	{
		get
		{
			return _lblQuestion;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblQuestion != null)
			{
			}
			_lblQuestion = value;
			if (_lblQuestion == null)
			{
			}
		}
	}

	internal virtual TextBox txtAnswer
	{
		get
		{
			return _txtAnswer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtAnswer != null)
			{
				_txtAnswer.Click -= txtAnswer_Click;
			}
			_txtAnswer = value;
			if (_txtAnswer != null)
			{
				_txtAnswer.Click += txtAnswer_Click;
			}
		}
	}

	internal virtual TextBox txtTest1
	{
		get
		{
			return _txtTest1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtTest1 != null)
			{
				_txtTest1.Click -= txtTest1_Click;
			}
			_txtTest1 = value;
			if (_txtTest1 != null)
			{
				_txtTest1.Click += txtTest1_Click;
			}
		}
	}

	internal virtual TextBox txtTest2
	{
		get
		{
			return _txtTest2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtTest2 != null)
			{
				_txtTest2.Click -= txtTest2_Click;
			}
			_txtTest2 = value;
			if (_txtTest2 != null)
			{
				_txtTest2.Click += txtTest2_Click;
			}
		}
	}

	internal virtual TextBox txtTest3
	{
		get
		{
			return _txtTest3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtTest3 != null)
			{
				_txtTest3.Click -= txtTest3_Click;
			}
			_txtTest3 = value;
			if (_txtTest3 != null)
			{
				_txtTest3.Click += txtTest3_Click;
			}
		}
	}

	internal virtual Button cmdReloadTest
	{
		get
		{
			return _cmdReloadTest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdReloadTest != null)
			{
				_cmdReloadTest.Click -= cmdReloadTest_Click;
			}
			_cmdReloadTest = value;
			if (_cmdReloadTest != null)
			{
				_cmdReloadTest.Click += cmdReloadTest_Click;
			}
		}
	}

	internal virtual Button cmdNextTest
	{
		get
		{
			return _cmdNextTest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdNextTest != null)
			{
				_cmdNextTest.Click -= cmdNextTest_Click;
			}
			_cmdNextTest = value;
			if (_cmdNextTest != null)
			{
				_cmdNextTest.Click += cmdNextTest_Click;
			}
		}
	}

	internal virtual Button cmdIntroduction
	{
		get
		{
			return _cmdIntroduction;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdIntroduction != null)
			{
				_cmdIntroduction.Click -= cmdIntroduction_Click;
			}
			_cmdIntroduction = value;
			if (_cmdIntroduction != null)
			{
				_cmdIntroduction.Click += cmdIntroduction_Click;
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

	internal virtual Label Label6
	{
		get
		{
			return _Label6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Label6 != null)
			{
			}
			_Label6 = value;
			if (_Label6 == null)
			{
			}
		}
	}

	internal virtual Button cmdHelp
	{
		get
		{
			return _cmdHelp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdHelp != null)
			{
				_cmdHelp.Click -= cmdHelp_Click;
			}
			_cmdHelp = value;
			if (_cmdHelp != null)
			{
				_cmdHelp.Click += cmdHelp_Click;
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

	public frmChapter5()
	{
		base.Load += frmChapter5_Load;
		base.Resize += frmChapter5_Resize;
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
		this.lblChapter = new System.Windows.Forms.Label();
		this.lblTitle = new System.Windows.Forms.Label();
		this.picLes = new System.Windows.Forms.PictureBox();
		this.txtLesTitle = new System.Windows.Forms.TextBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.cmdNext = new System.Windows.Forms.Button();
		this.Label1 = new System.Windows.Forms.Label();
		this.txtCon1 = new System.Windows.Forms.TextBox();
		this.pic_con1 = new System.Windows.Forms.PictureBox();
		this.pic_con2 = new System.Windows.Forms.PictureBox();
		this.txtCon2 = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.cmdReload = new System.Windows.Forms.Button();
		this.cmdEnable = new System.Windows.Forms.Button();
		this.cmdDictionary = new System.Windows.Forms.Button();
		this.txtVocabulary = new System.Windows.Forms.TextBox();
		this.grbTest = new System.Windows.Forms.GroupBox();
		this.cmdResult = new System.Windows.Forms.Button();
		this.lblQuestion = new System.Windows.Forms.Label();
		this.txtAnswer = new System.Windows.Forms.TextBox();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.txtTest1 = new System.Windows.Forms.TextBox();
		this.txtTest2 = new System.Windows.Forms.TextBox();
		this.txtTest3 = new System.Windows.Forms.TextBox();
		this.cmdReloadTest = new System.Windows.Forms.Button();
		this.cmdNextTest = new System.Windows.Forms.Button();
		this.cmdIntroduction = new System.Windows.Forms.Button();
		this.cmdHelp = new System.Windows.Forms.Button();
		this.cmdClose = new System.Windows.Forms.Button();
		this.cboLesson = new System.Windows.Forms.ComboBox();
		this.Label6 = new System.Windows.Forms.Label();
		this.lblFlash_hide = new System.Windows.Forms.Label();
		this.lblLes_hide = new System.Windows.Forms.Label();
		this.lblChap_hide = new System.Windows.Forms.Label();
		this.lblNum = new System.Windows.Forms.Label();
		this.GroupBox1.SuspendLayout();
		this.grbTest.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.SuspendLayout();
		this.lblChapter.BackColor = System.Drawing.Color.SteelBlue;
		this.lblChapter.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblChapter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Label label = this.lblChapter;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		label.Location = location;
		this.lblChapter.Name = "lblChapter";
		System.Windows.Forms.Label label2 = this.lblChapter;
		System.Drawing.Size size = new System.Drawing.Size(472, 32);
		label2.Size = size;
		this.lblChapter.TabIndex = 32;
		this.lblChapter.Text = "Chapter 1: Chapter title";
		this.lblChapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblTitle.BackColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.Label label3 = this.lblTitle;
		location = new System.Drawing.Point(0, 0);
		label3.Location = location;
		this.lblTitle.Name = "lblTitle";
		System.Windows.Forms.Label label4 = this.lblTitle;
		size = new System.Drawing.Size(720, 40);
		label4.Size = size;
		this.lblTitle.TabIndex = 31;
		this.picLes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox = this.picLes;
		location = new System.Drawing.Point(8, 80);
		pictureBox.Location = location;
		this.picLes.Name = "picLes";
		System.Windows.Forms.PictureBox pictureBox2 = this.picLes;
		size = new System.Drawing.Size(200, 136);
		pictureBox2.Size = size;
		this.picLes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picLes.TabIndex = 33;
		this.picLes.TabStop = false;
		this.txtLesTitle.BackColor = System.Drawing.SystemColors.Window;
		this.txtLesTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtLesTitle.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox = this.txtLesTitle;
		location = new System.Drawing.Point(8, 56);
		textBox.Location = location;
		this.txtLesTitle.Name = "txtLesTitle";
		this.txtLesTitle.ReadOnly = true;
		System.Windows.Forms.TextBox textBox2 = this.txtLesTitle;
		size = new System.Drawing.Size(200, 27);
		textBox2.Size = size;
		this.txtLesTitle.TabIndex = 34;
		this.txtLesTitle.Text = "";
		this.GroupBox1.Controls.Add(this.cmdNext);
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.Controls.Add(this.txtCon1);
		this.GroupBox1.Controls.Add(this.pic_con1);
		this.GroupBox1.Controls.Add(this.pic_con2);
		this.GroupBox1.Controls.Add(this.txtCon2);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.cmdReload);
		this.GroupBox1.Controls.Add(this.cmdEnable);
		this.GroupBox1.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(216, 56);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		size = new System.Drawing.Size(496, 280);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 35;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Conversation::Click picture to listen, Next and Reload to restart";
		this.cmdNext.BackColor = System.Drawing.SystemColors.AppWorkspace;
		this.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdNext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button = this.cmdNext;
		location = new System.Drawing.Point(408, 96);
		button.Location = location;
		this.cmdNext.Name = "cmdNext";
		System.Windows.Forms.Button button2 = this.cmdNext;
		size = new System.Drawing.Size(80, 23);
		button2.Size = size;
		this.cmdNext.TabIndex = 50;
		this.cmdNext.Text = "&Next >>";
		this.Label1.BackColor = System.Drawing.SystemColors.Desktop;
		System.Windows.Forms.Label label5 = this.Label1;
		location = new System.Drawing.Point(176, 248);
		label5.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label6 = this.Label1;
		size = new System.Drawing.Size(88, 8);
		label6.Size = size;
		this.Label1.TabIndex = 2;
		this.txtCon1.BackColor = System.Drawing.SystemColors.Info;
		this.txtCon1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCon1.Font = new System.Drawing.Font("Khmer OS System", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox3 = this.txtCon1;
		location = new System.Drawing.Point(240, 24);
		textBox3.Location = location;
		this.txtCon1.Multiline = true;
		this.txtCon1.Name = "txtCon1";
		this.txtCon1.ReadOnly = true;
		System.Windows.Forms.TextBox textBox4 = this.txtCon1;
		size = new System.Drawing.Size(248, 56);
		textBox4.Size = size;
		this.txtCon1.TabIndex = 1;
		this.txtCon1.Text = "";
		this.pic_con1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pic_con1.Cursor = System.Windows.Forms.Cursors.Hand;
		System.Windows.Forms.PictureBox pictureBox3 = this.pic_con1;
		location = new System.Drawing.Point(8, 24);
		pictureBox3.Location = location;
		this.pic_con1.Name = "pic_con1";
		System.Windows.Forms.PictureBox pictureBox4 = this.pic_con1;
		size = new System.Drawing.Size(224, 152);
		pictureBox4.Size = size;
		this.pic_con1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pic_con1.TabIndex = 0;
		this.pic_con1.TabStop = false;
		this.pic_con2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pic_con2.Cursor = System.Windows.Forms.Cursors.Hand;
		System.Windows.Forms.PictureBox pictureBox5 = this.pic_con2;
		location = new System.Drawing.Point(264, 123);
		pictureBox5.Location = location;
		this.pic_con2.Name = "pic_con2";
		System.Windows.Forms.PictureBox pictureBox6 = this.pic_con2;
		size = new System.Drawing.Size(224, 152);
		pictureBox6.Size = size;
		this.pic_con2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pic_con2.TabIndex = 0;
		this.pic_con2.TabStop = false;
		this.txtCon2.BackColor = System.Drawing.SystemColors.Info;
		this.txtCon2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtCon2.Font = new System.Drawing.Font("Khmer OS System", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox5 = this.txtCon2;
		location = new System.Drawing.Point(8, 184);
		textBox5.Location = location;
		this.txtCon2.Multiline = true;
		this.txtCon2.Name = "txtCon2";
		this.txtCon2.ReadOnly = true;
		System.Windows.Forms.TextBox textBox6 = this.txtCon2;
		size = new System.Drawing.Size(248, 56);
		textBox6.Size = size;
		this.txtCon2.TabIndex = 1;
		this.txtCon2.Text = "";
		this.Label2.BackColor = System.Drawing.SystemColors.Desktop;
		System.Windows.Forms.Label label7 = this.Label2;
		location = new System.Drawing.Point(176, 240);
		label7.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label8 = this.Label2;
		size = new System.Drawing.Size(8, 16);
		label8.Size = size;
		this.Label2.TabIndex = 2;
		this.Label3.BackColor = System.Drawing.SystemColors.Desktop;
		System.Windows.Forms.Label label9 = this.Label3;
		location = new System.Drawing.Point(320, 80);
		label9.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label10 = this.Label3;
		size = new System.Drawing.Size(8, 16);
		label10.Size = size;
		this.Label3.TabIndex = 2;
		this.Label4.BackColor = System.Drawing.SystemColors.Desktop;
		System.Windows.Forms.Label label11 = this.Label4;
		location = new System.Drawing.Point(232, 88);
		label11.Location = location;
		this.Label4.Name = "Label4";
		System.Windows.Forms.Label label12 = this.Label4;
		size = new System.Drawing.Size(88, 8);
		label12.Size = size;
		this.Label4.TabIndex = 2;
		this.cmdReload.BackColor = System.Drawing.SystemColors.AppWorkspace;
		this.cmdReload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdReload.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button3 = this.cmdReload;
		location = new System.Drawing.Point(332, 96);
		button3.Location = location;
		this.cmdReload.Name = "cmdReload";
		System.Windows.Forms.Button button4 = this.cmdReload;
		size = new System.Drawing.Size(72, 23);
		button4.Size = size;
		this.cmdReload.TabIndex = 50;
		this.cmdReload.Text = "&Reload";
		this.cmdEnable.BackColor = System.Drawing.SystemColors.AppWorkspace;
		this.cmdEnable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdEnable.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button5 = this.cmdEnable;
		location = new System.Drawing.Point(8, 248);
		button5.Location = location;
		this.cmdEnable.Name = "cmdEnable";
		System.Windows.Forms.Button button6 = this.cmdEnable;
		size = new System.Drawing.Size(160, 23);
		button6.Size = size;
		this.cmdEnable.TabIndex = 50;
		this.cmdEnable.Text = "Enable Test";
		this.cmdDictionary.BackColor = System.Drawing.SystemColors.AppWorkspace;
		this.cmdDictionary.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdDictionary.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button7 = this.cmdDictionary;
		location = new System.Drawing.Point(8, 312);
		button7.Location = location;
		this.cmdDictionary.Name = "cmdDictionary";
		System.Windows.Forms.Button button8 = this.cmdDictionary;
		size = new System.Drawing.Size(200, 23);
		button8.Size = size;
		this.cmdDictionary.TabIndex = 49;
		this.cmdDictionary.Text = "&Check vocabularies in dictionary";
		this.txtVocabulary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtVocabulary.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox7 = this.txtVocabulary;
		location = new System.Drawing.Point(8, 222);
		textBox7.Location = location;
		this.txtVocabulary.Multiline = true;
		this.txtVocabulary.Name = "txtVocabulary";
		this.txtVocabulary.ReadOnly = true;
		this.txtVocabulary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox8 = this.txtVocabulary;
		size = new System.Drawing.Size(200, 88);
		textBox8.Size = size;
		this.txtVocabulary.TabIndex = 48;
		this.txtVocabulary.Text = "";
		this.grbTest.Controls.Add(this.cmdResult);
		this.grbTest.Controls.Add(this.lblQuestion);
		this.grbTest.Controls.Add(this.txtAnswer);
		this.grbTest.Controls.Add(this.GroupBox3);
		this.grbTest.Controls.Add(this.cmdReloadTest);
		this.grbTest.Controls.Add(this.cmdNextTest);
		this.grbTest.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.GroupBox groupBox3 = this.grbTest;
		location = new System.Drawing.Point(8, 352);
		groupBox3.Location = location;
		this.grbTest.Name = "grbTest";
		System.Windows.Forms.GroupBox groupBox4 = this.grbTest;
		size = new System.Drawing.Size(616, 128);
		groupBox4.Size = size;
		this.grbTest.TabIndex = 50;
		this.grbTest.TabStop = false;
		this.grbTest.Text = "Test :: You must click Enable Test to start the test";
		this.cmdResult.BackColor = System.Drawing.Color.SlateGray;
		this.cmdResult.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdResult.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdResult.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button9 = this.cmdResult;
		location = new System.Drawing.Point(539, 96);
		button9.Location = location;
		this.cmdResult.Name = "cmdResult";
		System.Windows.Forms.Button button10 = this.cmdResult;
		size = new System.Drawing.Size(72, 23);
		button10.Size = size;
		this.cmdResult.TabIndex = 3;
		this.cmdResult.Text = "Res&ult";
		this.lblQuestion.ForeColor = System.Drawing.Color.IndianRed;
		System.Windows.Forms.Label label13 = this.lblQuestion;
		location = new System.Drawing.Point(8, 24);
		label13.Location = location;
		this.lblQuestion.Name = "lblQuestion";
		System.Windows.Forms.Label label14 = this.lblQuestion;
		size = new System.Drawing.Size(96, 23);
		label14.Size = size;
		this.lblQuestion.TabIndex = 2;
		this.lblQuestion.Text = "PART 1 :: A";
		this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.txtAnswer.BackColor = System.Drawing.SystemColors.Info;
		this.txtAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtAnswer.Cursor = System.Windows.Forms.Cursors.Hand;
		this.txtAnswer.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtAnswer.ForeColor = System.Drawing.SystemColors.MenuText;
		System.Windows.Forms.TextBox textBox9 = this.txtAnswer;
		location = new System.Drawing.Point(104, 24);
		textBox9.Location = location;
		this.txtAnswer.Name = "txtAnswer";
		this.txtAnswer.ReadOnly = true;
		System.Windows.Forms.TextBox textBox10 = this.txtAnswer;
		size = new System.Drawing.Size(432, 27);
		textBox10.Size = size;
		this.txtAnswer.TabIndex = 1;
		this.txtAnswer.Text = "";
		this.GroupBox3.Controls.Add(this.txtTest1);
		this.GroupBox3.Controls.Add(this.txtTest2);
		this.GroupBox3.Controls.Add(this.txtTest3);
		this.GroupBox3.Font = new System.Drawing.Font("Verdana", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.GroupBox groupBox5 = this.GroupBox3;
		location = new System.Drawing.Point(8, 64);
		groupBox5.Location = location;
		this.GroupBox3.Name = "GroupBox3";
		System.Windows.Forms.GroupBox groupBox6 = this.GroupBox3;
		size = new System.Drawing.Size(528, 56);
		groupBox6.Size = size;
		this.GroupBox3.TabIndex = 0;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Click text below to order the part of conversation";
		this.txtTest1.BackColor = System.Drawing.SystemColors.InactiveCaption;
		this.txtTest1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtTest1.Cursor = System.Windows.Forms.Cursors.Hand;
		this.txtTest1.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtTest1.ForeColor = System.Drawing.SystemColors.HighlightText;
		System.Windows.Forms.TextBox textBox11 = this.txtTest1;
		location = new System.Drawing.Point(8, 23);
		textBox11.Location = location;
		this.txtTest1.Name = "txtTest1";
		this.txtTest1.ReadOnly = true;
		System.Windows.Forms.TextBox textBox12 = this.txtTest1;
		size = new System.Drawing.Size(168, 27);
		textBox12.Size = size;
		this.txtTest1.TabIndex = 0;
		this.txtTest1.Text = "";
		this.txtTest1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtTest2.BackColor = System.Drawing.SystemColors.InactiveCaption;
		this.txtTest2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtTest2.Cursor = System.Windows.Forms.Cursors.Hand;
		this.txtTest2.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtTest2.ForeColor = System.Drawing.SystemColors.HighlightText;
		System.Windows.Forms.TextBox textBox13 = this.txtTest2;
		location = new System.Drawing.Point(184, 23);
		textBox13.Location = location;
		this.txtTest2.Name = "txtTest2";
		this.txtTest2.ReadOnly = true;
		System.Windows.Forms.TextBox textBox14 = this.txtTest2;
		size = new System.Drawing.Size(168, 27);
		textBox14.Size = size;
		this.txtTest2.TabIndex = 0;
		this.txtTest2.Text = "";
		this.txtTest2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtTest3.BackColor = System.Drawing.SystemColors.InactiveCaption;
		this.txtTest3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtTest3.Cursor = System.Windows.Forms.Cursors.Hand;
		this.txtTest3.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.txtTest3.ForeColor = System.Drawing.SystemColors.HighlightText;
		System.Windows.Forms.TextBox textBox15 = this.txtTest3;
		location = new System.Drawing.Point(360, 23);
		textBox15.Location = location;
		this.txtTest3.Name = "txtTest3";
		this.txtTest3.ReadOnly = true;
		System.Windows.Forms.TextBox textBox16 = this.txtTest3;
		size = new System.Drawing.Size(160, 27);
		textBox16.Size = size;
		this.txtTest3.TabIndex = 0;
		this.txtTest3.Text = "";
		this.txtTest3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.cmdReloadTest.BackColor = System.Drawing.Color.SlateGray;
		this.cmdReloadTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdReloadTest.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdReloadTest.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button11 = this.cmdReloadTest;
		location = new System.Drawing.Point(539, 72);
		button11.Location = location;
		this.cmdReloadTest.Name = "cmdReloadTest";
		System.Windows.Forms.Button button12 = this.cmdReloadTest;
		size = new System.Drawing.Size(72, 23);
		button12.Size = size;
		this.cmdReloadTest.TabIndex = 3;
		this.cmdReloadTest.Text = "Reloa&d";
		this.cmdNextTest.BackColor = System.Drawing.Color.SlateGray;
		this.cmdNextTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdNextTest.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdNextTest.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Button button13 = this.cmdNextTest;
		location = new System.Drawing.Point(539, 25);
		button13.Location = location;
		this.cmdNextTest.Name = "cmdNextTest";
		System.Windows.Forms.Button button14 = this.cmdNextTest;
		size = new System.Drawing.Size(72, 23);
		button14.Size = size;
		this.cmdNextTest.TabIndex = 3;
		this.cmdNextTest.Text = "N&ext";
		this.cmdIntroduction.BackColor = System.Drawing.SystemColors.AppWorkspace;
		this.cmdIntroduction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdIntroduction.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button15 = this.cmdIntroduction;
		location = new System.Drawing.Point(632, 392);
		button15.Location = location;
		this.cmdIntroduction.Name = "cmdIntroduction";
		System.Windows.Forms.Button button16 = this.cmdIntroduction;
		size = new System.Drawing.Size(80, 23);
		button16.Size = size;
		this.cmdIntroduction.TabIndex = 49;
		this.cmdIntroduction.Text = "&Introduction";
		this.cmdHelp.BackColor = System.Drawing.SystemColors.AppWorkspace;
		this.cmdHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdHelp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button17 = this.cmdHelp;
		location = new System.Drawing.Point(632, 424);
		button17.Location = location;
		this.cmdHelp.Name = "cmdHelp";
		System.Windows.Forms.Button button18 = this.cmdHelp;
		size = new System.Drawing.Size(80, 23);
		button18.Size = size;
		this.cmdHelp.TabIndex = 49;
		this.cmdHelp.Text = "Help";
		this.cmdClose.BackColor = System.Drawing.SystemColors.AppWorkspace;
		this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button19 = this.cmdClose;
		location = new System.Drawing.Point(632, 456);
		button19.Location = location;
		this.cmdClose.Name = "cmdClose";
		System.Windows.Forms.Button button20 = this.cmdClose;
		size = new System.Drawing.Size(80, 23);
		button20.Size = size;
		this.cmdClose.TabIndex = 49;
		this.cmdClose.Text = "&CLOSE";
		this.cboLesson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboLesson.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.ComboBox comboBox = this.cboLesson;
		location = new System.Drawing.Point(656, 8);
		comboBox.Location = location;
		this.cboLesson.Name = "cboLesson";
		System.Windows.Forms.ComboBox comboBox2 = this.cboLesson;
		size = new System.Drawing.Size(56, 22);
		comboBox2.Size = size;
		this.cboLesson.Sorted = true;
		this.cboLesson.TabIndex = 54;
		this.Label6.BackColor = System.Drawing.Color.SteelBlue;
		this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Label label15 = this.Label6;
		location = new System.Drawing.Point(600, 8);
		label15.Location = location;
		this.Label6.Name = "Label6";
		System.Windows.Forms.Label label16 = this.Label6;
		size = new System.Drawing.Size(56, 23);
		label16.Size = size;
		this.Label6.TabIndex = 53;
		this.Label6.Text = "Lesson:";
		this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblFlash_hide.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label17 = this.lblFlash_hide;
		location = new System.Drawing.Point(296, 488);
		label17.Location = location;
		this.lblFlash_hide.Name = "lblFlash_hide";
		System.Windows.Forms.Label label18 = this.lblFlash_hide;
		size = new System.Drawing.Size(40, 16);
		label18.Size = size;
		this.lblFlash_hide.TabIndex = 58;
		this.lblFlash_hide.Text = "kor.swf";
		this.lblLes_hide.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblLes_hide.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label19 = this.lblLes_hide;
		location = new System.Drawing.Point(256, 488);
		label19.Location = location;
		this.lblLes_hide.Name = "lblLes_hide";
		System.Windows.Forms.Label label20 = this.lblLes_hide;
		size = new System.Drawing.Size(32, 16);
		label20.Size = size;
		this.lblLes_hide.TabIndex = 57;
		this.lblLes_hide.Text = "Lesson";
		this.lblChap_hide.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblChap_hide.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label21 = this.lblChap_hide;
		location = new System.Drawing.Point(208, 488);
		label21.Location = location;
		this.lblChap_hide.Name = "lblChap_hide";
		System.Windows.Forms.Label label22 = this.lblChap_hide;
		size = new System.Drawing.Size(32, 16);
		label22.Size = size;
		this.lblChap_hide.TabIndex = 56;
		this.lblChap_hide.Text = "chapter";
		this.lblNum.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label23 = this.lblNum;
		location = new System.Drawing.Point(152, 488);
		label23.Location = location;
		this.lblNum.Name = "lblNum";
		System.Windows.Forms.Label label24 = this.lblNum;
		size = new System.Drawing.Size(48, 23);
		label24.Size = size;
		this.lblNum.TabIndex = 55;
		this.lblNum.Text = "5";
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(720, 506);
		this.ClientSize = size;
		this.Controls.Add(this.lblFlash_hide);
		this.Controls.Add(this.lblLes_hide);
		this.Controls.Add(this.lblChap_hide);
		this.Controls.Add(this.lblNum);
		this.Controls.Add(this.cboLesson);
		this.Controls.Add(this.Label6);
		this.Controls.Add(this.grbTest);
		this.Controls.Add(this.cmdDictionary);
		this.Controls.Add(this.txtVocabulary);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.txtLesTitle);
		this.Controls.Add(this.picLes);
		this.Controls.Add(this.lblChapter);
		this.Controls.Add(this.lblTitle);
		this.Controls.Add(this.cmdIntroduction);
		this.Controls.Add(this.cmdHelp);
		this.Controls.Add(this.cmdClose);
		this.Name = "frmChapter5";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Khmer Conversations";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.GroupBox1.ResumeLayout(false);
		this.grbTest.ResumeLayout(false);
		this.GroupBox3.ResumeLayout(false);
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

	private void cmdClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void frmChapter5_Load(object sender, EventArgs e)
	{
		Recordset recordset = new RecordsetClass();
		string connectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + Application.StartupPath + "\\reankhmer.mdb";
		cnn.ConnectionString = connectionString;
		cnn.Open();
		string source = "Select ch_title, ch_desc,les_num From tblChapter ch, tblLesson les Where ch.ch_id=les.ch_id and ch.ch_num=" + lblNum.Text;
		recordset.Open(source, cnn, CursorTypeEnum.adOpenKeyset, LockTypeEnum.adLockOptimistic);
		recordset.MoveFirst();
		lblChap_hide.Text = StringType.FromObject(recordset.Fields["ch_title"].Value);
		lblChapter.Text = "Chapter " + lblNum.Text + ": ";
		lblChapter.Text += lblChap_hide.Text;
		while (!recordset.EOF)
		{
			cboLesson.Items.Add(IntegerType.FromObject(recordset.Fields["les_num"].Value));
			recordset.MoveNext();
		}
		cboLesson.SelectedIndex = 0;
		test_check = "";
		clickNum = 0;
		grbTest.Enabled = false;
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
		if (rst_t.State == 1)
		{
			rst_t.Close();
		}
		queryLes_test();
		rst_t.MoveFirst();
		getTest_in2box();
	}

	public void queryLes()
	{
		string source = "Select les_title,article,getLink,vocabulary,filename,desc,getSound From tblLesson les, tblSubLesson sub, tblChapter ch Where les.les_id=sub.les_id and ch.ch_id=les.ch_id and ch_num=" + lblNum.Text + " and les.les_num=" + cboLesson.Text;
		rst.Open(source, cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic);
	}

	public void valueTobox()
	{
		lblLes_hide.Text = StringType.FromObject(rst.Fields["les_title"].Value);
		txtLesTitle.Text = "";
		txtLesTitle.Text = lblLes_hide.Text;
		picLes.Image = Image.FromFile(Application.StartupPath + "\\images\\conversation\\" + StringType.FromObject(rst.Fields["getLink"].Value));
		getIntro = StringType.FromObject(rst.Fields["article"].Value);
		txtVocabulary.Text = StringType.FromObject(rst.Fields["vocabulary"].Value);
		conInBox();
	}

	public void conInBox()
	{
		if (!rst.EOF)
		{
			pic_con1.Image = Image.FromFile(Application.StartupPath + "\\images\\conversation\\" + StringType.FromObject(rst.Fields["filename"].Value));
			txtCon1.Text = StringType.FromObject(rst.Fields["desc"].Value);
			sound1 = Application.StartupPath + "\\conversation\\" + StringType.FromObject(rst.Fields["getSound"].Value) + ".mp3";
			if (!rst.EOF)
			{
				rst.MoveNext();
				pic_con2.Image = Image.FromFile(Application.StartupPath + "\\images\\conversation\\" + StringType.FromObject(rst.Fields["filename"].Value));
				txtCon2.Text = StringType.FromObject(rst.Fields["desc"].Value);
				sound2 = Application.StartupPath + "\\conversation\\" + StringType.FromObject(rst.Fields["getSound"].Value) + ".mp3";
			}
		}
	}

	public void queryLes_test()
	{
		Recordset recordset = new RecordsetClass();
		string source = "Select question,answer,check From tblLesson les, tblChapter ch, tblTest ts, tblTest_res trs Where ch.ch_id=les.ch_id and ch_num=5 and les.les_id=ts.les_id and ts.test_id=trs.test_id and les.les_num=" + cboLesson.Text + " ORDER BY rang, test_res_id";
		string source2 = "Select count(test_id) as allQ From tblLesson les, tblChapter ch, tblTest ts Where ch.ch_id=les.ch_id and ch_num=5 and les.les_id=ts.les_id and les.les_num=" + cboLesson.Text;
		rst_t.Open(source, cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic);
		if (recordset.State == 1)
		{
			recordset.Close();
		}
		recordset.Open(source2, cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic);
		num_quest = IntegerType.FromObject(recordset.Fields["allQ"].Value);
	}

	private void getTest_in2box()
	{
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		if (!rst_t.EOF)
		{
			lblQuestion.Text = StringType.FromObject(rst_t.Fields["question"].Value);
			txtTest1.Text = StringType.FromObject(rst_t.Fields["answer"].Value);
			txtTest1.Tag = StringType.FromObject(rst_t.Fields["check"].Value);
			rst_t.MoveNext();
			if (rst_t.EOF)
			{
				rst_t.MovePrevious();
			}
			txtTest2.Text = StringType.FromObject(rst_t.Fields["answer"].Value);
			txtTest2.Tag = StringType.FromObject(rst_t.Fields["check"].Value);
			rst_t.MoveNext();
			if (rst_t.EOF)
			{
				rst_t.MovePrevious();
			}
			txtTest3.Text = StringType.FromObject(rst_t.Fields["answer"].Value);
			txtTest3.Tag = StringType.FromObject(rst_t.Fields["check"].Value);
		}
		else
		{
			Interaction.MsgBox((object)"You have finish the test. Click RESULT Button to see the result. Click RELOAD Button to start doing the test again.", (MsgBoxStyle)64, (object)"Test Finished");
		}
	}

	private void frmChapter5_Resize(object sender, EventArgs e)
	{
		lblTitle.Width = Width;
	}

	private void cmdNext_Click(object sender, EventArgs e)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if (!rst.EOF)
		{
			rst.MoveNext();
			conInBox();
		}
		else
		{
			Interaction.MsgBox((object)"The conversation already finish, choose another lesson to learn.", (MsgBoxStyle)64, (object)"End of Conversation");
		}
	}

	private void cmdReload_Click(object sender, EventArgs e)
	{
		rst.MoveFirst();
		conInBox();
	}

	private void pic_con1_Click(object sender, EventArgs e)
	{
		stopSound(sound2);
		pSound(sound1);
	}

	private void pic_con2_Click(object sender, EventArgs e)
	{
		stopSound(sound1);
		pSound(sound2);
	}

	private void txtTest1_Click(object sender, EventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (clickNum == 3)
		{
			Interaction.MsgBox((object)"You already fill the sentence, to refill click Answer box to clear.", (MsgBoxStyle)64, (object)"Can't Click");
			return;
		}
		TextBox textBox = txtAnswer;
		textBox.Text = textBox.Text + txtTest1.Text + " ";
		test_check = StringType.FromObject(ObjectType.StrCatObj((object)test_check, txtTest1.Tag));
		checked
		{
			clickNum++;
		}
	}

	private void txtTest2_Click(object sender, EventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (clickNum == 3)
		{
			Interaction.MsgBox((object)"You already fill the sentence, to refill click Answer box to clear.", (MsgBoxStyle)64, (object)"Can't Click");
			return;
		}
		TextBox textBox = txtAnswer;
		textBox.Text = textBox.Text + txtTest2.Text + " ";
		test_check = StringType.FromObject(ObjectType.StrCatObj((object)test_check, txtTest2.Tag));
		checked
		{
			clickNum++;
		}
	}

	private void txtTest3_Click(object sender, EventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (clickNum == 3)
		{
			Interaction.MsgBox((object)"You already fill the sentence, to refill click Answer box to clear.", (MsgBoxStyle)64, (object)"Can't Click");
			return;
		}
		TextBox textBox = txtAnswer;
		textBox.Text = textBox.Text + txtTest3.Text + " ";
		test_check = StringType.FromObject(ObjectType.StrCatObj((object)test_check, txtTest3.Tag));
		checked
		{
			clickNum++;
		}
	}

	private void txtAnswer_Click(object sender, EventArgs e)
	{
		txtAnswer.Text = "";
		clickNum = 0;
		test_check = "";
	}

	private void cmdNextTest_Click(object sender, EventArgs e)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (StringType.StrCmp(test_check, "123", false) == 0)
			{
				getScore += 3;
			}
			txtAnswer_Click(RuntimeHelpers.GetObjectValue(sender), e);
			if (!rst_t.EOF)
			{
				rst_t.MoveNext();
				getTest_in2box();
			}
			else
			{
				Interaction.MsgBox((object)"Please click Reload to re-do or click Result to see the result. You can click Disable Test Button to see the conversation article.", (MsgBoxStyle)64, (object)"End of Test");
			}
		}
	}

	private void cmdReloadTest_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		if ((int)Interaction.MsgBox((object)"If you reload your score will cut 10 if your total score greater than 10, do you want to do?", (MsgBoxStyle)4, (object)"Confirm") != 7)
		{
			rst_t.MoveFirst();
			getTest_in2box();
			checked
			{
				if (getScore > 10)
				{
					getScore -= 10;
				}
			}
		}
	}

	private void cmdResult_Click(object sender, EventArgs e)
	{
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		Interaction.MsgBox((object)string.Concat(str3: (getScore > 90) ? "Excellenct" : ((getScore > 80) ? "Very Good" : ((getScore > 70) ? "Good" : ((getScore > 60) ? "Fair" : ((getScore > 50) ? "Medium. You need to do more test." : ((getScore <= 40) ? "So poor. Start the lesson again and try again. Be patient!" : "Weak. You need to listen and read carefully."))))), str0: "Your score is ", str1: StringType.FromInteger(getScore), str2: "\r\n"), (MsgBoxStyle)64, (object)"Conversation :: Test Result");
	}

	private void cmdIntroduction_Click(object sender, EventArgs e)
	{
		frmConversationInto frmConversationInto2 = new frmConversationInto();
		frmConversationInto2.txtTitle.Text = txtLesTitle.Text;
		frmConversationInto2.txtIntro.Text = getIntro;
		frmConversationInto2.MdiParent = MdiParent;
		frmConversationInto2.Show();
	}

	private void cmdEnable_Click(object sender, EventArgs e)
	{
		if (StringType.StrCmp(cmdEnable.Text, "Enable Test", false) == 0)
		{
			cmdEnable.Text = "Disable Test";
			grbTest.Enabled = true;
			txtCon1.Visible = false;
			txtCon2.Visible = false;
		}
		else
		{
			cmdEnable.Text = "Enable Test";
			grbTest.Enabled = false;
			txtCon1.Visible = true;
			txtCon2.Visible = true;
		}
	}

	private void cmdHelp_Click(object sender, EventArgs e)
	{
		frmHelp frmHelp2 = new frmHelp();
		frmHelp2.MdiParent = MdiParent;
		frmHelp2.rdbChapters.Checked = true;
		frmHelp2.cboSubContents.SelectedIndex = 4;
		frmHelp2.Show();
	}

	private void cmdDictionary_Click(object sender, EventArgs e)
	{
		frmDictionary frmDictionary2 = new frmDictionary();
		frmDictionary2.MdiParent = MdiParent;
		frmDictionary2.txtSearch.Focus();
		frmDictionary2.Show();
	}
}
