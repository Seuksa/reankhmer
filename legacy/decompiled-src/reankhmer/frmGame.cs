using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ADODB;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class frmGame : Form
{
	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("tn_txt4")]
	private TextBox _tn_txt4;

	[AccessedThroughProperty("tn_pic4")]
	private PictureBox _tn_pic4;

	[AccessedThroughProperty("Label6")]
	private Label _Label6;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("tn_txt2")]
	private TextBox _tn_txt2;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("pic1")]
	private PictureBox _pic1;

	[AccessedThroughProperty("txt1")]
	private TextBox _txt1;

	[AccessedThroughProperty("pic2")]
	private PictureBox _pic2;

	[AccessedThroughProperty("txt2")]
	private TextBox _txt2;

	[AccessedThroughProperty("pic3")]
	private PictureBox _pic3;

	[AccessedThroughProperty("txt3")]
	private TextBox _txt3;

	[AccessedThroughProperty("pic4")]
	private PictureBox _pic4;

	[AccessedThroughProperty("pic5")]
	private PictureBox _pic5;

	[AccessedThroughProperty("cmdSupports")]
	private Button _cmdSupports;

	[AccessedThroughProperty("cmdReloadPic")]
	private Button _cmdReloadPic;

	[AccessedThroughProperty("txtTime")]
	private TextBox _txtTime;

	[AccessedThroughProperty("txt6")]
	private TextBox _txt6;

	[AccessedThroughProperty("cmdExit")]
	private Button _cmdExit;

	[AccessedThroughProperty("lblType")]
	private Label _lblType;

	[AccessedThroughProperty("cmdStop")]
	private Button _cmdStop;

	[AccessedThroughProperty("tn_pic3")]
	private PictureBox _tn_pic3;

	[AccessedThroughProperty("Label5")]
	private Label _Label5;

	[AccessedThroughProperty("cmdMore")]
	private Button _cmdMore;

	[AccessedThroughProperty("Timer1")]
	private Timer _Timer1;

	[AccessedThroughProperty("Label8")]
	private Label _Label8;

	[AccessedThroughProperty("Label7")]
	private Label _Label7;

	[AccessedThroughProperty("tn_pic5")]
	private PictureBox _tn_pic5;

	[AccessedThroughProperty("tn_txt6")]
	private TextBox _tn_txt6;

	[AccessedThroughProperty("tn_txt5")]
	private TextBox _tn_txt5;

	[AccessedThroughProperty("pic6")]
	private PictureBox _pic6;

	[AccessedThroughProperty("tn_pic6")]
	private PictureBox _tn_pic6;

	[AccessedThroughProperty("txt4")]
	private TextBox _txt4;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("txt5")]
	private TextBox _txt5;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("txtTyping")]
	private TextBox _txtTyping;

	[AccessedThroughProperty("txtName")]
	private TextBox _txtName;

	[AccessedThroughProperty("tn_txt1")]
	private TextBox _tn_txt1;

	[AccessedThroughProperty("tn_pic1")]
	private PictureBox _tn_pic1;

	[AccessedThroughProperty("tn_pic2")]
	private PictureBox _tn_pic2;

	[AccessedThroughProperty("tn_txt3")]
	private TextBox _tn_txt3;

	private IContainer components;

	private int numType;

	private bool isType1;

	private bool isType2;

	private bool isType3;

	private bool isType4;

	private bool isType5;

	private bool isType6;

	private int[] getRand;

	private string[] wordRand;

	private int[] numWord;

	private Connection cnn;

	private Recordset rs_g;

	private int sec;

	private int min;

	private string tm;

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

	internal virtual PictureBox pic1
	{
		get
		{
			return _pic1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic1 != null)
			{
			}
			_pic1 = value;
			if (_pic1 == null)
			{
			}
		}
	}

	internal virtual TextBox txt1
	{
		get
		{
			return _txt1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt1 != null)
			{
			}
			_txt1 = value;
			if (_txt1 == null)
			{
			}
		}
	}

	internal virtual PictureBox pic2
	{
		get
		{
			return _pic2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic2 != null)
			{
			}
			_pic2 = value;
			if (_pic2 == null)
			{
			}
		}
	}

	internal virtual TextBox txt2
	{
		get
		{
			return _txt2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt2 != null)
			{
			}
			_txt2 = value;
			if (_txt2 == null)
			{
			}
		}
	}

	internal virtual PictureBox pic3
	{
		get
		{
			return _pic3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic3 != null)
			{
			}
			_pic3 = value;
			if (_pic3 == null)
			{
			}
		}
	}

	internal virtual TextBox txt3
	{
		get
		{
			return _txt3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt3 != null)
			{
			}
			_txt3 = value;
			if (_txt3 == null)
			{
			}
		}
	}

	internal virtual PictureBox pic4
	{
		get
		{
			return _pic4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic4 != null)
			{
			}
			_pic4 = value;
			if (_pic4 == null)
			{
			}
		}
	}

	internal virtual PictureBox pic5
	{
		get
		{
			return _pic5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic5 != null)
			{
			}
			_pic5 = value;
			if (_pic5 == null)
			{
			}
		}
	}

	internal virtual TextBox txt6
	{
		get
		{
			return _txt6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt6 != null)
			{
			}
			_txt6 = value;
			if (_txt6 == null)
			{
			}
		}
	}

	internal virtual PictureBox pic6
	{
		get
		{
			return _pic6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic6 != null)
			{
			}
			_pic6 = value;
			if (_pic6 == null)
			{
			}
		}
	}

	internal virtual TextBox txt4
	{
		get
		{
			return _txt4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt4 != null)
			{
			}
			_txt4 = value;
			if (_txt4 == null)
			{
			}
		}
	}

	internal virtual TextBox txt5
	{
		get
		{
			return _txt5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt5 != null)
			{
			}
			_txt5 = value;
			if (_txt5 == null)
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

	internal virtual TextBox txtTyping
	{
		get
		{
			return _txtTyping;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtTyping != null)
			{
				_txtTyping.TextChanged -= txtTyping_TextChanged;
				_txtTyping.KeyDown -= txtTyping_KeyDown;
			}
			_txtTyping = value;
			if (_txtTyping != null)
			{
				_txtTyping.TextChanged += txtTyping_TextChanged;
				_txtTyping.KeyDown += txtTyping_KeyDown;
			}
		}
	}

	internal virtual TextBox txtName
	{
		get
		{
			return _txtName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtName != null)
			{
			}
			_txtName = value;
			if (_txtName == null)
			{
			}
		}
	}

	internal virtual PictureBox tn_pic1
	{
		get
		{
			return _tn_pic1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_tn_pic1 != null)
			{
			}
			_tn_pic1 = value;
			if (_tn_pic1 == null)
			{
			}
		}
	}

	internal virtual PictureBox tn_pic2
	{
		get
		{
			return _tn_pic2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_tn_pic2 != null)
			{
			}
			_tn_pic2 = value;
			if (_tn_pic2 == null)
			{
			}
		}
	}

	internal virtual TextBox tn_txt1
	{
		get
		{
			return _tn_txt1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_tn_txt1 != null)
			{
			}
			_tn_txt1 = value;
			if (_tn_txt1 == null)
			{
			}
		}
	}

	internal virtual TextBox tn_txt2
	{
		get
		{
			return _tn_txt2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_tn_txt2 != null)
			{
			}
			_tn_txt2 = value;
			if (_tn_txt2 == null)
			{
			}
		}
	}

	internal virtual PictureBox tn_pic4
	{
		get
		{
			return _tn_pic4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_tn_pic4 != null)
			{
			}
			_tn_pic4 = value;
			if (_tn_pic4 == null)
			{
			}
		}
	}

	internal virtual TextBox tn_txt4
	{
		get
		{
			return _tn_txt4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_tn_txt4 != null)
			{
			}
			_tn_txt4 = value;
			if (_tn_txt4 == null)
			{
			}
		}
	}

	internal virtual TextBox tn_txt3
	{
		get
		{
			return _tn_txt3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_tn_txt3 != null)
			{
			}
			_tn_txt3 = value;
			if (_tn_txt3 == null)
			{
			}
		}
	}

	internal virtual PictureBox tn_pic3
	{
		get
		{
			return _tn_pic3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_tn_pic3 != null)
			{
			}
			_tn_pic3 = value;
			if (_tn_pic3 == null)
			{
			}
		}
	}

	internal virtual PictureBox tn_pic6
	{
		get
		{
			return _tn_pic6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_tn_pic6 != null)
			{
			}
			_tn_pic6 = value;
			if (_tn_pic6 == null)
			{
			}
		}
	}

	internal virtual TextBox tn_txt5
	{
		get
		{
			return _tn_txt5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_tn_txt5 != null)
			{
			}
			_tn_txt5 = value;
			if (_tn_txt5 == null)
			{
			}
		}
	}

	internal virtual TextBox tn_txt6
	{
		get
		{
			return _tn_txt6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_tn_txt6 != null)
			{
			}
			_tn_txt6 = value;
			if (_tn_txt6 == null)
			{
			}
		}
	}

	internal virtual PictureBox tn_pic5
	{
		get
		{
			return _tn_pic5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_tn_pic5 != null)
			{
			}
			_tn_pic5 = value;
			if (_tn_pic5 == null)
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

	internal virtual Label Label5
	{
		get
		{
			return _Label5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Label5 != null)
			{
			}
			_Label5 = value;
			if (_Label5 == null)
			{
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

	internal virtual Label Label7
	{
		get
		{
			return _Label7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Label7 != null)
			{
			}
			_Label7 = value;
			if (_Label7 == null)
			{
			}
		}
	}

	internal virtual Label Label8
	{
		get
		{
			return _Label8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Label8 != null)
			{
			}
			_Label8 = value;
			if (_Label8 == null)
			{
			}
		}
	}

	internal virtual Button cmdMore
	{
		get
		{
			return _cmdMore;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdMore != null)
			{
				_cmdMore.Click -= cmdMore_Click;
			}
			_cmdMore = value;
			if (_cmdMore != null)
			{
				_cmdMore.Click += cmdMore_Click;
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

	internal virtual Label lblType
	{
		get
		{
			return _lblType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblType != null)
			{
			}
			_lblType = value;
			if (_lblType == null)
			{
			}
		}
	}

	internal virtual Button cmdExit
	{
		get
		{
			return _cmdExit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdExit != null)
			{
				_cmdExit.Click -= cmdExit_Click;
			}
			_cmdExit = value;
			if (_cmdExit != null)
			{
				_cmdExit.Click += cmdExit_Click;
			}
		}
	}

	internal virtual Timer Timer1
	{
		get
		{
			return _Timer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Timer1 != null)
			{
				_Timer1.Tick -= Timer1_Tick;
			}
			_Timer1 = value;
			if (_Timer1 != null)
			{
				_Timer1.Tick += Timer1_Tick;
			}
		}
	}

	internal virtual TextBox txtTime
	{
		get
		{
			return _txtTime;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtTime != null)
			{
			}
			_txtTime = value;
			if (_txtTime == null)
			{
			}
		}
	}

	internal virtual Button cmdReloadPic
	{
		get
		{
			return _cmdReloadPic;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdReloadPic != null)
			{
				_cmdReloadPic.Click -= cmdReloadPic_Click;
			}
			_cmdReloadPic = value;
			if (_cmdReloadPic != null)
			{
				_cmdReloadPic.Click += cmdReloadPic_Click;
			}
		}
	}

	internal virtual Button cmdSupports
	{
		get
		{
			return _cmdSupports;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdSupports != null)
			{
				_cmdSupports.Click -= cmdSupports_Click;
			}
			_cmdSupports = value;
			if (_cmdSupports != null)
			{
				_cmdSupports.Click += cmdSupports_Click;
			}
		}
	}

	public frmGame()
	{
		base.Load += frmGame_Load;
		cnn = new ConnectionClass();
		rs_g = new RecordsetClass();
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
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(reankhmer.frmGame));
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Label8 = new System.Windows.Forms.Label();
		this.Label7 = new System.Windows.Forms.Label();
		this.Label6 = new System.Windows.Forms.Label();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.txt1 = new System.Windows.Forms.TextBox();
		this.pic1 = new System.Windows.Forms.PictureBox();
		this.pic2 = new System.Windows.Forms.PictureBox();
		this.txt2 = new System.Windows.Forms.TextBox();
		this.pic3 = new System.Windows.Forms.PictureBox();
		this.txt3 = new System.Windows.Forms.TextBox();
		this.pic4 = new System.Windows.Forms.PictureBox();
		this.pic5 = new System.Windows.Forms.PictureBox();
		this.txt6 = new System.Windows.Forms.TextBox();
		this.pic6 = new System.Windows.Forms.PictureBox();
		this.txt4 = new System.Windows.Forms.TextBox();
		this.txt5 = new System.Windows.Forms.TextBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.tn_pic1 = new System.Windows.Forms.PictureBox();
		this.txtName = new System.Windows.Forms.TextBox();
		this.tn_pic2 = new System.Windows.Forms.PictureBox();
		this.tn_txt1 = new System.Windows.Forms.TextBox();
		this.tn_txt2 = new System.Windows.Forms.TextBox();
		this.tn_pic4 = new System.Windows.Forms.PictureBox();
		this.tn_txt4 = new System.Windows.Forms.TextBox();
		this.tn_txt3 = new System.Windows.Forms.TextBox();
		this.tn_pic3 = new System.Windows.Forms.PictureBox();
		this.tn_pic6 = new System.Windows.Forms.PictureBox();
		this.tn_txt5 = new System.Windows.Forms.TextBox();
		this.tn_txt6 = new System.Windows.Forms.TextBox();
		this.tn_pic5 = new System.Windows.Forms.PictureBox();
		this.txtTime = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.txtTyping = new System.Windows.Forms.TextBox();
		this.cmdMore = new System.Windows.Forms.Button();
		this.cmdStop = new System.Windows.Forms.Button();
		this.lblType = new System.Windows.Forms.Label();
		this.cmdExit = new System.Windows.Forms.Button();
		this.Timer1 = new System.Windows.Forms.Timer(this.components);
		this.cmdReloadPic = new System.Windows.Forms.Button();
		this.cmdSupports = new System.Windows.Forms.Button();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.SuspendLayout();
		this.GroupBox1.AccessibleDescription = resourceManager.GetString("GroupBox1.AccessibleDescription");
		this.GroupBox1.AccessibleName = resourceManager.GetString("GroupBox1.AccessibleName");
		this.GroupBox1.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("GroupBox1.Anchor"));
		this.GroupBox1.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("GroupBox1.BackgroundImage");
		this.GroupBox1.Controls.Add(this.Label8);
		this.GroupBox1.Controls.Add(this.Label7);
		this.GroupBox1.Controls.Add(this.Label6);
		this.GroupBox1.Controls.Add(this.Label5);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.Label3);
		this.GroupBox1.Controls.Add(this.txt1);
		this.GroupBox1.Controls.Add(this.pic1);
		this.GroupBox1.Controls.Add(this.pic2);
		this.GroupBox1.Controls.Add(this.txt2);
		this.GroupBox1.Controls.Add(this.pic3);
		this.GroupBox1.Controls.Add(this.txt3);
		this.GroupBox1.Controls.Add(this.pic4);
		this.GroupBox1.Controls.Add(this.pic5);
		this.GroupBox1.Controls.Add(this.txt6);
		this.GroupBox1.Controls.Add(this.pic6);
		this.GroupBox1.Controls.Add(this.txt4);
		this.GroupBox1.Controls.Add(this.txt5);
		this.GroupBox1.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("GroupBox1.Dock"));
		this.GroupBox1.Enabled = BooleanType.FromObject(resourceManager.GetObject("GroupBox1.Enabled"));
		this.GroupBox1.Font = (System.Drawing.Font)resourceManager.GetObject("GroupBox1.Font");
		this.GroupBox1.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("GroupBox1.ImeMode"));
		this.GroupBox1.Location = (System.Drawing.Point)(resourceManager.GetObject("GroupBox1.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("GroupBox1.RightToLeft"));
		this.GroupBox1.Size = (System.Drawing.Size)(resourceManager.GetObject("GroupBox1.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.GroupBox1.TabIndex = IntegerType.FromObject(resourceManager.GetObject("GroupBox1.TabIndex"));
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = resourceManager.GetString("GroupBox1.Text");
		this.GroupBox1.Visible = BooleanType.FromObject(resourceManager.GetObject("GroupBox1.Visible"));
		this.Label8.AccessibleDescription = resourceManager.GetString("Label8.AccessibleDescription");
		this.Label8.AccessibleName = resourceManager.GetString("Label8.AccessibleName");
		this.Label8.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("Label8.Anchor"));
		this.Label8.AutoSize = BooleanType.FromObject(resourceManager.GetObject("Label8.AutoSize"));
		this.Label8.BackColor = System.Drawing.SystemColors.Desktop;
		this.Label8.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("Label8.Dock"));
		this.Label8.Enabled = BooleanType.FromObject(resourceManager.GetObject("Label8.Enabled"));
		this.Label8.Font = (System.Drawing.Font)resourceManager.GetObject("Label8.Font");
		this.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.Label8.Image = (System.Drawing.Image)resourceManager.GetObject("Label8.Image");
		this.Label8.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label8.ImageAlign"));
		this.Label8.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("Label8.ImageIndex"));
		this.Label8.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("Label8.ImeMode"));
		this.Label8.Location = (System.Drawing.Point)(resourceManager.GetObject("Label8.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.Label8.Name = "Label8";
		this.Label8.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("Label8.RightToLeft"));
		this.Label8.Size = (System.Drawing.Size)(resourceManager.GetObject("Label8.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.Label8.TabIndex = IntegerType.FromObject(resourceManager.GetObject("Label8.TabIndex"));
		this.Label8.Text = resourceManager.GetString("Label8.Text");
		this.Label8.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label8.TextAlign"));
		this.Label8.Visible = BooleanType.FromObject(resourceManager.GetObject("Label8.Visible"));
		this.Label7.AccessibleDescription = resourceManager.GetString("Label7.AccessibleDescription");
		this.Label7.AccessibleName = resourceManager.GetString("Label7.AccessibleName");
		this.Label7.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("Label7.Anchor"));
		this.Label7.AutoSize = BooleanType.FromObject(resourceManager.GetObject("Label7.AutoSize"));
		this.Label7.BackColor = System.Drawing.SystemColors.Desktop;
		this.Label7.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("Label7.Dock"));
		this.Label7.Enabled = BooleanType.FromObject(resourceManager.GetObject("Label7.Enabled"));
		this.Label7.Font = (System.Drawing.Font)resourceManager.GetObject("Label7.Font");
		this.Label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.Label7.Image = (System.Drawing.Image)resourceManager.GetObject("Label7.Image");
		this.Label7.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label7.ImageAlign"));
		this.Label7.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("Label7.ImageIndex"));
		this.Label7.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("Label7.ImeMode"));
		this.Label7.Location = (System.Drawing.Point)(resourceManager.GetObject("Label7.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.Label7.Name = "Label7";
		this.Label7.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("Label7.RightToLeft"));
		this.Label7.Size = (System.Drawing.Size)(resourceManager.GetObject("Label7.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.Label7.TabIndex = IntegerType.FromObject(resourceManager.GetObject("Label7.TabIndex"));
		this.Label7.Text = resourceManager.GetString("Label7.Text");
		this.Label7.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label7.TextAlign"));
		this.Label7.Visible = BooleanType.FromObject(resourceManager.GetObject("Label7.Visible"));
		this.Label6.AccessibleDescription = resourceManager.GetString("Label6.AccessibleDescription");
		this.Label6.AccessibleName = resourceManager.GetString("Label6.AccessibleName");
		this.Label6.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("Label6.Anchor"));
		this.Label6.AutoSize = BooleanType.FromObject(resourceManager.GetObject("Label6.AutoSize"));
		this.Label6.BackColor = System.Drawing.SystemColors.Desktop;
		this.Label6.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("Label6.Dock"));
		this.Label6.Enabled = BooleanType.FromObject(resourceManager.GetObject("Label6.Enabled"));
		this.Label6.Font = (System.Drawing.Font)resourceManager.GetObject("Label6.Font");
		this.Label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.Label6.Image = (System.Drawing.Image)resourceManager.GetObject("Label6.Image");
		this.Label6.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label6.ImageAlign"));
		this.Label6.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("Label6.ImageIndex"));
		this.Label6.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("Label6.ImeMode"));
		this.Label6.Location = (System.Drawing.Point)(resourceManager.GetObject("Label6.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.Label6.Name = "Label6";
		this.Label6.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("Label6.RightToLeft"));
		this.Label6.Size = (System.Drawing.Size)(resourceManager.GetObject("Label6.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.Label6.TabIndex = IntegerType.FromObject(resourceManager.GetObject("Label6.TabIndex"));
		this.Label6.Text = resourceManager.GetString("Label6.Text");
		this.Label6.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label6.TextAlign"));
		this.Label6.Visible = BooleanType.FromObject(resourceManager.GetObject("Label6.Visible"));
		this.Label5.AccessibleDescription = resourceManager.GetString("Label5.AccessibleDescription");
		this.Label5.AccessibleName = resourceManager.GetString("Label5.AccessibleName");
		this.Label5.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("Label5.Anchor"));
		this.Label5.AutoSize = BooleanType.FromObject(resourceManager.GetObject("Label5.AutoSize"));
		this.Label5.BackColor = System.Drawing.SystemColors.Desktop;
		this.Label5.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("Label5.Dock"));
		this.Label5.Enabled = BooleanType.FromObject(resourceManager.GetObject("Label5.Enabled"));
		this.Label5.Font = (System.Drawing.Font)resourceManager.GetObject("Label5.Font");
		this.Label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.Label5.Image = (System.Drawing.Image)resourceManager.GetObject("Label5.Image");
		this.Label5.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label5.ImageAlign"));
		this.Label5.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("Label5.ImageIndex"));
		this.Label5.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("Label5.ImeMode"));
		this.Label5.Location = (System.Drawing.Point)(resourceManager.GetObject("Label5.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.Label5.Name = "Label5";
		this.Label5.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("Label5.RightToLeft"));
		this.Label5.Size = (System.Drawing.Size)(resourceManager.GetObject("Label5.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.Label5.TabIndex = IntegerType.FromObject(resourceManager.GetObject("Label5.TabIndex"));
		this.Label5.Text = resourceManager.GetString("Label5.Text");
		this.Label5.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label5.TextAlign"));
		this.Label5.Visible = BooleanType.FromObject(resourceManager.GetObject("Label5.Visible"));
		this.Label4.AccessibleDescription = resourceManager.GetString("Label4.AccessibleDescription");
		this.Label4.AccessibleName = resourceManager.GetString("Label4.AccessibleName");
		this.Label4.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("Label4.Anchor"));
		this.Label4.AutoSize = BooleanType.FromObject(resourceManager.GetObject("Label4.AutoSize"));
		this.Label4.BackColor = System.Drawing.SystemColors.Desktop;
		this.Label4.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("Label4.Dock"));
		this.Label4.Enabled = BooleanType.FromObject(resourceManager.GetObject("Label4.Enabled"));
		this.Label4.Font = (System.Drawing.Font)resourceManager.GetObject("Label4.Font");
		this.Label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.Label4.Image = (System.Drawing.Image)resourceManager.GetObject("Label4.Image");
		this.Label4.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label4.ImageAlign"));
		this.Label4.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("Label4.ImageIndex"));
		this.Label4.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("Label4.ImeMode"));
		this.Label4.Location = (System.Drawing.Point)(resourceManager.GetObject("Label4.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.Label4.Name = "Label4";
		this.Label4.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("Label4.RightToLeft"));
		this.Label4.Size = (System.Drawing.Size)(resourceManager.GetObject("Label4.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.Label4.TabIndex = IntegerType.FromObject(resourceManager.GetObject("Label4.TabIndex"));
		this.Label4.Text = resourceManager.GetString("Label4.Text");
		this.Label4.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label4.TextAlign"));
		this.Label4.Visible = BooleanType.FromObject(resourceManager.GetObject("Label4.Visible"));
		this.Label3.AccessibleDescription = resourceManager.GetString("Label3.AccessibleDescription");
		this.Label3.AccessibleName = resourceManager.GetString("Label3.AccessibleName");
		this.Label3.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("Label3.Anchor"));
		this.Label3.AutoSize = BooleanType.FromObject(resourceManager.GetObject("Label3.AutoSize"));
		this.Label3.BackColor = System.Drawing.SystemColors.Desktop;
		this.Label3.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("Label3.Dock"));
		this.Label3.Enabled = BooleanType.FromObject(resourceManager.GetObject("Label3.Enabled"));
		this.Label3.Font = (System.Drawing.Font)resourceManager.GetObject("Label3.Font");
		this.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		this.Label3.Image = (System.Drawing.Image)resourceManager.GetObject("Label3.Image");
		this.Label3.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label3.ImageAlign"));
		this.Label3.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("Label3.ImageIndex"));
		this.Label3.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("Label3.ImeMode"));
		this.Label3.Location = (System.Drawing.Point)(resourceManager.GetObject("Label3.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.Label3.Name = "Label3";
		this.Label3.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("Label3.RightToLeft"));
		this.Label3.Size = (System.Drawing.Size)(resourceManager.GetObject("Label3.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.Label3.TabIndex = IntegerType.FromObject(resourceManager.GetObject("Label3.TabIndex"));
		this.Label3.Text = resourceManager.GetString("Label3.Text");
		this.Label3.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label3.TextAlign"));
		this.Label3.Visible = BooleanType.FromObject(resourceManager.GetObject("Label3.Visible"));
		this.txt1.AccessibleDescription = resourceManager.GetString("txt1.AccessibleDescription");
		this.txt1.AccessibleName = resourceManager.GetString("txt1.AccessibleName");
		this.txt1.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("txt1.Anchor"));
		this.txt1.AutoSize = BooleanType.FromObject(resourceManager.GetObject("txt1.AutoSize"));
		this.txt1.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt1.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("txt1.BackgroundImage");
		this.txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt1.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("txt1.Dock"));
		this.txt1.Enabled = BooleanType.FromObject(resourceManager.GetObject("txt1.Enabled"));
		this.txt1.Font = (System.Drawing.Font)resourceManager.GetObject("txt1.Font");
		this.txt1.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("txt1.ImeMode"));
		this.txt1.Location = (System.Drawing.Point)(resourceManager.GetObject("txt1.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.txt1.MaxLength = IntegerType.FromObject(resourceManager.GetObject("txt1.MaxLength"));
		this.txt1.Multiline = BooleanType.FromObject(resourceManager.GetObject("txt1.Multiline"));
		this.txt1.Name = "txt1";
		this.txt1.PasswordChar = CharType.FromObject(resourceManager.GetObject("txt1.PasswordChar"));
		this.txt1.ReadOnly = true;
		this.txt1.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("txt1.RightToLeft"));
		this.txt1.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("txt1.ScrollBars"));
		this.txt1.Size = (System.Drawing.Size)(resourceManager.GetObject("txt1.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.txt1.TabIndex = IntegerType.FromObject(resourceManager.GetObject("txt1.TabIndex"));
		this.txt1.Text = resourceManager.GetString("txt1.Text");
		this.txt1.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("txt1.TextAlign"));
		this.txt1.Visible = BooleanType.FromObject(resourceManager.GetObject("txt1.Visible"));
		this.txt1.WordWrap = BooleanType.FromObject(resourceManager.GetObject("txt1.WordWrap"));
		this.pic1.AccessibleDescription = resourceManager.GetString("pic1.AccessibleDescription");
		this.pic1.AccessibleName = resourceManager.GetString("pic1.AccessibleName");
		this.pic1.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("pic1.Anchor"));
		this.pic1.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("pic1.BackgroundImage");
		this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pic1.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("pic1.Dock"));
		this.pic1.Enabled = BooleanType.FromObject(resourceManager.GetObject("pic1.Enabled"));
		this.pic1.Font = (System.Drawing.Font)resourceManager.GetObject("pic1.Font");
		this.pic1.Image = (System.Drawing.Image)resourceManager.GetObject("pic1.Image");
		this.pic1.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("pic1.ImeMode"));
		this.pic1.Location = (System.Drawing.Point)(resourceManager.GetObject("pic1.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.pic1.Name = "pic1";
		this.pic1.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("pic1.RightToLeft"));
		this.pic1.Size = (System.Drawing.Size)(resourceManager.GetObject("pic1.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.pic1.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)IntegerType.FromObject(resourceManager.GetObject("pic1.SizeMode"));
		this.pic1.TabIndex = IntegerType.FromObject(resourceManager.GetObject("pic1.TabIndex"));
		this.pic1.TabStop = false;
		this.pic1.Text = resourceManager.GetString("pic1.Text");
		this.pic1.Visible = BooleanType.FromObject(resourceManager.GetObject("pic1.Visible"));
		this.pic2.AccessibleDescription = resourceManager.GetString("pic2.AccessibleDescription");
		this.pic2.AccessibleName = resourceManager.GetString("pic2.AccessibleName");
		this.pic2.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("pic2.Anchor"));
		this.pic2.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("pic2.BackgroundImage");
		this.pic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pic2.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("pic2.Dock"));
		this.pic2.Enabled = BooleanType.FromObject(resourceManager.GetObject("pic2.Enabled"));
		this.pic2.Font = (System.Drawing.Font)resourceManager.GetObject("pic2.Font");
		this.pic2.Image = (System.Drawing.Image)resourceManager.GetObject("pic2.Image");
		this.pic2.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("pic2.ImeMode"));
		this.pic2.Location = (System.Drawing.Point)(resourceManager.GetObject("pic2.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.pic2.Name = "pic2";
		this.pic2.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("pic2.RightToLeft"));
		this.pic2.Size = (System.Drawing.Size)(resourceManager.GetObject("pic2.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.pic2.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)IntegerType.FromObject(resourceManager.GetObject("pic2.SizeMode"));
		this.pic2.TabIndex = IntegerType.FromObject(resourceManager.GetObject("pic2.TabIndex"));
		this.pic2.TabStop = false;
		this.pic2.Text = resourceManager.GetString("pic2.Text");
		this.pic2.Visible = BooleanType.FromObject(resourceManager.GetObject("pic2.Visible"));
		this.txt2.AccessibleDescription = resourceManager.GetString("txt2.AccessibleDescription");
		this.txt2.AccessibleName = resourceManager.GetString("txt2.AccessibleName");
		this.txt2.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("txt2.Anchor"));
		this.txt2.AutoSize = BooleanType.FromObject(resourceManager.GetObject("txt2.AutoSize"));
		this.txt2.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt2.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("txt2.BackgroundImage");
		this.txt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt2.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("txt2.Dock"));
		this.txt2.Enabled = BooleanType.FromObject(resourceManager.GetObject("txt2.Enabled"));
		this.txt2.Font = (System.Drawing.Font)resourceManager.GetObject("txt2.Font");
		this.txt2.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("txt2.ImeMode"));
		this.txt2.Location = (System.Drawing.Point)(resourceManager.GetObject("txt2.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.txt2.MaxLength = IntegerType.FromObject(resourceManager.GetObject("txt2.MaxLength"));
		this.txt2.Multiline = BooleanType.FromObject(resourceManager.GetObject("txt2.Multiline"));
		this.txt2.Name = "txt2";
		this.txt2.PasswordChar = CharType.FromObject(resourceManager.GetObject("txt2.PasswordChar"));
		this.txt2.ReadOnly = true;
		this.txt2.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("txt2.RightToLeft"));
		this.txt2.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("txt2.ScrollBars"));
		this.txt2.Size = (System.Drawing.Size)(resourceManager.GetObject("txt2.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.txt2.TabIndex = IntegerType.FromObject(resourceManager.GetObject("txt2.TabIndex"));
		this.txt2.Text = resourceManager.GetString("txt2.Text");
		this.txt2.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("txt2.TextAlign"));
		this.txt2.Visible = BooleanType.FromObject(resourceManager.GetObject("txt2.Visible"));
		this.txt2.WordWrap = BooleanType.FromObject(resourceManager.GetObject("txt2.WordWrap"));
		this.pic3.AccessibleDescription = resourceManager.GetString("pic3.AccessibleDescription");
		this.pic3.AccessibleName = resourceManager.GetString("pic3.AccessibleName");
		this.pic3.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("pic3.Anchor"));
		this.pic3.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("pic3.BackgroundImage");
		this.pic3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pic3.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("pic3.Dock"));
		this.pic3.Enabled = BooleanType.FromObject(resourceManager.GetObject("pic3.Enabled"));
		this.pic3.Font = (System.Drawing.Font)resourceManager.GetObject("pic3.Font");
		this.pic3.Image = (System.Drawing.Image)resourceManager.GetObject("pic3.Image");
		this.pic3.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("pic3.ImeMode"));
		this.pic3.Location = (System.Drawing.Point)(resourceManager.GetObject("pic3.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.pic3.Name = "pic3";
		this.pic3.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("pic3.RightToLeft"));
		this.pic3.Size = (System.Drawing.Size)(resourceManager.GetObject("pic3.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.pic3.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)IntegerType.FromObject(resourceManager.GetObject("pic3.SizeMode"));
		this.pic3.TabIndex = IntegerType.FromObject(resourceManager.GetObject("pic3.TabIndex"));
		this.pic3.TabStop = false;
		this.pic3.Text = resourceManager.GetString("pic3.Text");
		this.pic3.Visible = BooleanType.FromObject(resourceManager.GetObject("pic3.Visible"));
		this.txt3.AccessibleDescription = resourceManager.GetString("txt3.AccessibleDescription");
		this.txt3.AccessibleName = resourceManager.GetString("txt3.AccessibleName");
		this.txt3.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("txt3.Anchor"));
		this.txt3.AutoSize = BooleanType.FromObject(resourceManager.GetObject("txt3.AutoSize"));
		this.txt3.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt3.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("txt3.BackgroundImage");
		this.txt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt3.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("txt3.Dock"));
		this.txt3.Enabled = BooleanType.FromObject(resourceManager.GetObject("txt3.Enabled"));
		this.txt3.Font = (System.Drawing.Font)resourceManager.GetObject("txt3.Font");
		this.txt3.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("txt3.ImeMode"));
		this.txt3.Location = (System.Drawing.Point)(resourceManager.GetObject("txt3.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.txt3.MaxLength = IntegerType.FromObject(resourceManager.GetObject("txt3.MaxLength"));
		this.txt3.Multiline = BooleanType.FromObject(resourceManager.GetObject("txt3.Multiline"));
		this.txt3.Name = "txt3";
		this.txt3.PasswordChar = CharType.FromObject(resourceManager.GetObject("txt3.PasswordChar"));
		this.txt3.ReadOnly = true;
		this.txt3.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("txt3.RightToLeft"));
		this.txt3.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("txt3.ScrollBars"));
		this.txt3.Size = (System.Drawing.Size)(resourceManager.GetObject("txt3.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.txt3.TabIndex = IntegerType.FromObject(resourceManager.GetObject("txt3.TabIndex"));
		this.txt3.Text = resourceManager.GetString("txt3.Text");
		this.txt3.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("txt3.TextAlign"));
		this.txt3.Visible = BooleanType.FromObject(resourceManager.GetObject("txt3.Visible"));
		this.txt3.WordWrap = BooleanType.FromObject(resourceManager.GetObject("txt3.WordWrap"));
		this.pic4.AccessibleDescription = resourceManager.GetString("pic4.AccessibleDescription");
		this.pic4.AccessibleName = resourceManager.GetString("pic4.AccessibleName");
		this.pic4.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("pic4.Anchor"));
		this.pic4.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("pic4.BackgroundImage");
		this.pic4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pic4.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("pic4.Dock"));
		this.pic4.Enabled = BooleanType.FromObject(resourceManager.GetObject("pic4.Enabled"));
		this.pic4.Font = (System.Drawing.Font)resourceManager.GetObject("pic4.Font");
		this.pic4.Image = (System.Drawing.Image)resourceManager.GetObject("pic4.Image");
		this.pic4.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("pic4.ImeMode"));
		this.pic4.Location = (System.Drawing.Point)(resourceManager.GetObject("pic4.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.pic4.Name = "pic4";
		this.pic4.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("pic4.RightToLeft"));
		this.pic4.Size = (System.Drawing.Size)(resourceManager.GetObject("pic4.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.pic4.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)IntegerType.FromObject(resourceManager.GetObject("pic4.SizeMode"));
		this.pic4.TabIndex = IntegerType.FromObject(resourceManager.GetObject("pic4.TabIndex"));
		this.pic4.TabStop = false;
		this.pic4.Text = resourceManager.GetString("pic4.Text");
		this.pic4.Visible = BooleanType.FromObject(resourceManager.GetObject("pic4.Visible"));
		this.pic5.AccessibleDescription = resourceManager.GetString("pic5.AccessibleDescription");
		this.pic5.AccessibleName = resourceManager.GetString("pic5.AccessibleName");
		this.pic5.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("pic5.Anchor"));
		this.pic5.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("pic5.BackgroundImage");
		this.pic5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pic5.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("pic5.Dock"));
		this.pic5.Enabled = BooleanType.FromObject(resourceManager.GetObject("pic5.Enabled"));
		this.pic5.Font = (System.Drawing.Font)resourceManager.GetObject("pic5.Font");
		this.pic5.Image = (System.Drawing.Image)resourceManager.GetObject("pic5.Image");
		this.pic5.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("pic5.ImeMode"));
		this.pic5.Location = (System.Drawing.Point)(resourceManager.GetObject("pic5.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.pic5.Name = "pic5";
		this.pic5.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("pic5.RightToLeft"));
		this.pic5.Size = (System.Drawing.Size)(resourceManager.GetObject("pic5.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.pic5.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)IntegerType.FromObject(resourceManager.GetObject("pic5.SizeMode"));
		this.pic5.TabIndex = IntegerType.FromObject(resourceManager.GetObject("pic5.TabIndex"));
		this.pic5.TabStop = false;
		this.pic5.Text = resourceManager.GetString("pic5.Text");
		this.pic5.Visible = BooleanType.FromObject(resourceManager.GetObject("pic5.Visible"));
		this.txt6.AccessibleDescription = resourceManager.GetString("txt6.AccessibleDescription");
		this.txt6.AccessibleName = resourceManager.GetString("txt6.AccessibleName");
		this.txt6.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("txt6.Anchor"));
		this.txt6.AutoSize = BooleanType.FromObject(resourceManager.GetObject("txt6.AutoSize"));
		this.txt6.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt6.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("txt6.BackgroundImage");
		this.txt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt6.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("txt6.Dock"));
		this.txt6.Enabled = BooleanType.FromObject(resourceManager.GetObject("txt6.Enabled"));
		this.txt6.Font = (System.Drawing.Font)resourceManager.GetObject("txt6.Font");
		this.txt6.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("txt6.ImeMode"));
		this.txt6.Location = (System.Drawing.Point)(resourceManager.GetObject("txt6.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.txt6.MaxLength = IntegerType.FromObject(resourceManager.GetObject("txt6.MaxLength"));
		this.txt6.Multiline = BooleanType.FromObject(resourceManager.GetObject("txt6.Multiline"));
		this.txt6.Name = "txt6";
		this.txt6.PasswordChar = CharType.FromObject(resourceManager.GetObject("txt6.PasswordChar"));
		this.txt6.ReadOnly = true;
		this.txt6.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("txt6.RightToLeft"));
		this.txt6.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("txt6.ScrollBars"));
		this.txt6.Size = (System.Drawing.Size)(resourceManager.GetObject("txt6.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.txt6.TabIndex = IntegerType.FromObject(resourceManager.GetObject("txt6.TabIndex"));
		this.txt6.Text = resourceManager.GetString("txt6.Text");
		this.txt6.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("txt6.TextAlign"));
		this.txt6.Visible = BooleanType.FromObject(resourceManager.GetObject("txt6.Visible"));
		this.txt6.WordWrap = BooleanType.FromObject(resourceManager.GetObject("txt6.WordWrap"));
		this.pic6.AccessibleDescription = resourceManager.GetString("pic6.AccessibleDescription");
		this.pic6.AccessibleName = resourceManager.GetString("pic6.AccessibleName");
		this.pic6.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("pic6.Anchor"));
		this.pic6.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("pic6.BackgroundImage");
		this.pic6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.pic6.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("pic6.Dock"));
		this.pic6.Enabled = BooleanType.FromObject(resourceManager.GetObject("pic6.Enabled"));
		this.pic6.Font = (System.Drawing.Font)resourceManager.GetObject("pic6.Font");
		this.pic6.Image = (System.Drawing.Image)resourceManager.GetObject("pic6.Image");
		this.pic6.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("pic6.ImeMode"));
		this.pic6.Location = (System.Drawing.Point)(resourceManager.GetObject("pic6.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.pic6.Name = "pic6";
		this.pic6.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("pic6.RightToLeft"));
		this.pic6.Size = (System.Drawing.Size)(resourceManager.GetObject("pic6.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.pic6.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)IntegerType.FromObject(resourceManager.GetObject("pic6.SizeMode"));
		this.pic6.TabIndex = IntegerType.FromObject(resourceManager.GetObject("pic6.TabIndex"));
		this.pic6.TabStop = false;
		this.pic6.Text = resourceManager.GetString("pic6.Text");
		this.pic6.Visible = BooleanType.FromObject(resourceManager.GetObject("pic6.Visible"));
		this.txt4.AccessibleDescription = resourceManager.GetString("txt4.AccessibleDescription");
		this.txt4.AccessibleName = resourceManager.GetString("txt4.AccessibleName");
		this.txt4.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("txt4.Anchor"));
		this.txt4.AutoSize = BooleanType.FromObject(resourceManager.GetObject("txt4.AutoSize"));
		this.txt4.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt4.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("txt4.BackgroundImage");
		this.txt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt4.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("txt4.Dock"));
		this.txt4.Enabled = BooleanType.FromObject(resourceManager.GetObject("txt4.Enabled"));
		this.txt4.Font = (System.Drawing.Font)resourceManager.GetObject("txt4.Font");
		this.txt4.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("txt4.ImeMode"));
		this.txt4.Location = (System.Drawing.Point)(resourceManager.GetObject("txt4.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.txt4.MaxLength = IntegerType.FromObject(resourceManager.GetObject("txt4.MaxLength"));
		this.txt4.Multiline = BooleanType.FromObject(resourceManager.GetObject("txt4.Multiline"));
		this.txt4.Name = "txt4";
		this.txt4.PasswordChar = CharType.FromObject(resourceManager.GetObject("txt4.PasswordChar"));
		this.txt4.ReadOnly = true;
		this.txt4.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("txt4.RightToLeft"));
		this.txt4.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("txt4.ScrollBars"));
		this.txt4.Size = (System.Drawing.Size)(resourceManager.GetObject("txt4.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.txt4.TabIndex = IntegerType.FromObject(resourceManager.GetObject("txt4.TabIndex"));
		this.txt4.Text = resourceManager.GetString("txt4.Text");
		this.txt4.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("txt4.TextAlign"));
		this.txt4.Visible = BooleanType.FromObject(resourceManager.GetObject("txt4.Visible"));
		this.txt4.WordWrap = BooleanType.FromObject(resourceManager.GetObject("txt4.WordWrap"));
		this.txt5.AccessibleDescription = resourceManager.GetString("txt5.AccessibleDescription");
		this.txt5.AccessibleName = resourceManager.GetString("txt5.AccessibleName");
		this.txt5.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("txt5.Anchor"));
		this.txt5.AutoSize = BooleanType.FromObject(resourceManager.GetObject("txt5.AutoSize"));
		this.txt5.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt5.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("txt5.BackgroundImage");
		this.txt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt5.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("txt5.Dock"));
		this.txt5.Enabled = BooleanType.FromObject(resourceManager.GetObject("txt5.Enabled"));
		this.txt5.Font = (System.Drawing.Font)resourceManager.GetObject("txt5.Font");
		this.txt5.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("txt5.ImeMode"));
		this.txt5.Location = (System.Drawing.Point)(resourceManager.GetObject("txt5.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.txt5.MaxLength = IntegerType.FromObject(resourceManager.GetObject("txt5.MaxLength"));
		this.txt5.Multiline = BooleanType.FromObject(resourceManager.GetObject("txt5.Multiline"));
		this.txt5.Name = "txt5";
		this.txt5.PasswordChar = CharType.FromObject(resourceManager.GetObject("txt5.PasswordChar"));
		this.txt5.ReadOnly = true;
		this.txt5.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("txt5.RightToLeft"));
		this.txt5.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("txt5.ScrollBars"));
		this.txt5.Size = (System.Drawing.Size)(resourceManager.GetObject("txt5.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.txt5.TabIndex = IntegerType.FromObject(resourceManager.GetObject("txt5.TabIndex"));
		this.txt5.Text = resourceManager.GetString("txt5.Text");
		this.txt5.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("txt5.TextAlign"));
		this.txt5.Visible = BooleanType.FromObject(resourceManager.GetObject("txt5.Visible"));
		this.txt5.WordWrap = BooleanType.FromObject(resourceManager.GetObject("txt5.WordWrap"));
		this.GroupBox2.AccessibleDescription = resourceManager.GetString("GroupBox2.AccessibleDescription");
		this.GroupBox2.AccessibleName = resourceManager.GetString("GroupBox2.AccessibleName");
		this.GroupBox2.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("GroupBox2.Anchor"));
		this.GroupBox2.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("GroupBox2.BackgroundImage");
		this.GroupBox2.Controls.Add(this.Label2);
		this.GroupBox2.Controls.Add(this.tn_pic1);
		this.GroupBox2.Controls.Add(this.txtName);
		this.GroupBox2.Controls.Add(this.tn_pic2);
		this.GroupBox2.Controls.Add(this.tn_txt1);
		this.GroupBox2.Controls.Add(this.tn_txt2);
		this.GroupBox2.Controls.Add(this.tn_pic4);
		this.GroupBox2.Controls.Add(this.tn_txt4);
		this.GroupBox2.Controls.Add(this.tn_txt3);
		this.GroupBox2.Controls.Add(this.tn_pic3);
		this.GroupBox2.Controls.Add(this.tn_pic6);
		this.GroupBox2.Controls.Add(this.tn_txt5);
		this.GroupBox2.Controls.Add(this.tn_txt6);
		this.GroupBox2.Controls.Add(this.tn_pic5);
		this.GroupBox2.Controls.Add(this.txtTime);
		this.GroupBox2.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("GroupBox2.Dock"));
		this.GroupBox2.Enabled = BooleanType.FromObject(resourceManager.GetObject("GroupBox2.Enabled"));
		this.GroupBox2.Font = (System.Drawing.Font)resourceManager.GetObject("GroupBox2.Font");
		this.GroupBox2.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("GroupBox2.ImeMode"));
		this.GroupBox2.Location = (System.Drawing.Point)(resourceManager.GetObject("GroupBox2.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.GroupBox2.Name = "GroupBox2";
		this.GroupBox2.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("GroupBox2.RightToLeft"));
		this.GroupBox2.Size = (System.Drawing.Size)(resourceManager.GetObject("GroupBox2.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.GroupBox2.TabIndex = IntegerType.FromObject(resourceManager.GetObject("GroupBox2.TabIndex"));
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = resourceManager.GetString("GroupBox2.Text");
		this.GroupBox2.Visible = BooleanType.FromObject(resourceManager.GetObject("GroupBox2.Visible"));
		this.Label2.AccessibleDescription = resourceManager.GetString("Label2.AccessibleDescription");
		this.Label2.AccessibleName = resourceManager.GetString("Label2.AccessibleName");
		this.Label2.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("Label2.Anchor"));
		this.Label2.AutoSize = BooleanType.FromObject(resourceManager.GetObject("Label2.AutoSize"));
		this.Label2.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("Label2.Dock"));
		this.Label2.Enabled = BooleanType.FromObject(resourceManager.GetObject("Label2.Enabled"));
		this.Label2.Font = (System.Drawing.Font)resourceManager.GetObject("Label2.Font");
		this.Label2.Image = (System.Drawing.Image)resourceManager.GetObject("Label2.Image");
		this.Label2.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label2.ImageAlign"));
		this.Label2.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("Label2.ImageIndex"));
		this.Label2.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("Label2.ImeMode"));
		this.Label2.Location = (System.Drawing.Point)(resourceManager.GetObject("Label2.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.Label2.Name = "Label2";
		this.Label2.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("Label2.RightToLeft"));
		this.Label2.Size = (System.Drawing.Size)(resourceManager.GetObject("Label2.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.Label2.TabIndex = IntegerType.FromObject(resourceManager.GetObject("Label2.TabIndex"));
		this.Label2.Text = resourceManager.GetString("Label2.Text");
		this.Label2.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label2.TextAlign"));
		this.Label2.Visible = BooleanType.FromObject(resourceManager.GetObject("Label2.Visible"));
		this.tn_pic1.AccessibleDescription = resourceManager.GetString("tn_pic1.AccessibleDescription");
		this.tn_pic1.AccessibleName = resourceManager.GetString("tn_pic1.AccessibleName");
		this.tn_pic1.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("tn_pic1.Anchor"));
		this.tn_pic1.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tn_pic1.BackgroundImage");
		this.tn_pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tn_pic1.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("tn_pic1.Dock"));
		this.tn_pic1.Enabled = BooleanType.FromObject(resourceManager.GetObject("tn_pic1.Enabled"));
		this.tn_pic1.Font = (System.Drawing.Font)resourceManager.GetObject("tn_pic1.Font");
		this.tn_pic1.Image = (System.Drawing.Image)resourceManager.GetObject("tn_pic1.Image");
		this.tn_pic1.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("tn_pic1.ImeMode"));
		this.tn_pic1.Location = (System.Drawing.Point)(resourceManager.GetObject("tn_pic1.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.tn_pic1.Name = "tn_pic1";
		this.tn_pic1.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("tn_pic1.RightToLeft"));
		this.tn_pic1.Size = (System.Drawing.Size)(resourceManager.GetObject("tn_pic1.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.tn_pic1.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)IntegerType.FromObject(resourceManager.GetObject("tn_pic1.SizeMode"));
		this.tn_pic1.TabIndex = IntegerType.FromObject(resourceManager.GetObject("tn_pic1.TabIndex"));
		this.tn_pic1.TabStop = false;
		this.tn_pic1.Text = resourceManager.GetString("tn_pic1.Text");
		this.tn_pic1.Visible = BooleanType.FromObject(resourceManager.GetObject("tn_pic1.Visible"));
		this.txtName.AccessibleDescription = resourceManager.GetString("txtName.AccessibleDescription");
		this.txtName.AccessibleName = resourceManager.GetString("txtName.AccessibleName");
		this.txtName.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("txtName.Anchor"));
		this.txtName.AutoSize = BooleanType.FromObject(resourceManager.GetObject("txtName.AutoSize"));
		this.txtName.BackColor = System.Drawing.SystemColors.ControlLightLight;
		this.txtName.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("txtName.BackgroundImage");
		this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtName.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("txtName.Dock"));
		this.txtName.Enabled = BooleanType.FromObject(resourceManager.GetObject("txtName.Enabled"));
		this.txtName.Font = (System.Drawing.Font)resourceManager.GetObject("txtName.Font");
		this.txtName.ForeColor = System.Drawing.Color.SteelBlue;
		this.txtName.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("txtName.ImeMode"));
		this.txtName.Location = (System.Drawing.Point)(resourceManager.GetObject("txtName.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.txtName.MaxLength = IntegerType.FromObject(resourceManager.GetObject("txtName.MaxLength"));
		this.txtName.Multiline = BooleanType.FromObject(resourceManager.GetObject("txtName.Multiline"));
		this.txtName.Name = "txtName";
		this.txtName.PasswordChar = CharType.FromObject(resourceManager.GetObject("txtName.PasswordChar"));
		this.txtName.ReadOnly = true;
		this.txtName.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("txtName.RightToLeft"));
		this.txtName.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("txtName.ScrollBars"));
		this.txtName.Size = (System.Drawing.Size)(resourceManager.GetObject("txtName.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.txtName.TabIndex = IntegerType.FromObject(resourceManager.GetObject("txtName.TabIndex"));
		this.txtName.Text = resourceManager.GetString("txtName.Text");
		this.txtName.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("txtName.TextAlign"));
		this.txtName.Visible = BooleanType.FromObject(resourceManager.GetObject("txtName.Visible"));
		this.txtName.WordWrap = BooleanType.FromObject(resourceManager.GetObject("txtName.WordWrap"));
		this.tn_pic2.AccessibleDescription = resourceManager.GetString("tn_pic2.AccessibleDescription");
		this.tn_pic2.AccessibleName = resourceManager.GetString("tn_pic2.AccessibleName");
		this.tn_pic2.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("tn_pic2.Anchor"));
		this.tn_pic2.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tn_pic2.BackgroundImage");
		this.tn_pic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tn_pic2.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("tn_pic2.Dock"));
		this.tn_pic2.Enabled = BooleanType.FromObject(resourceManager.GetObject("tn_pic2.Enabled"));
		this.tn_pic2.Font = (System.Drawing.Font)resourceManager.GetObject("tn_pic2.Font");
		this.tn_pic2.Image = (System.Drawing.Image)resourceManager.GetObject("tn_pic2.Image");
		this.tn_pic2.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("tn_pic2.ImeMode"));
		this.tn_pic2.Location = (System.Drawing.Point)(resourceManager.GetObject("tn_pic2.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.tn_pic2.Name = "tn_pic2";
		this.tn_pic2.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("tn_pic2.RightToLeft"));
		this.tn_pic2.Size = (System.Drawing.Size)(resourceManager.GetObject("tn_pic2.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.tn_pic2.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)IntegerType.FromObject(resourceManager.GetObject("tn_pic2.SizeMode"));
		this.tn_pic2.TabIndex = IntegerType.FromObject(resourceManager.GetObject("tn_pic2.TabIndex"));
		this.tn_pic2.TabStop = false;
		this.tn_pic2.Text = resourceManager.GetString("tn_pic2.Text");
		this.tn_pic2.Visible = BooleanType.FromObject(resourceManager.GetObject("tn_pic2.Visible"));
		this.tn_txt1.AccessibleDescription = resourceManager.GetString("tn_txt1.AccessibleDescription");
		this.tn_txt1.AccessibleName = resourceManager.GetString("tn_txt1.AccessibleName");
		this.tn_txt1.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("tn_txt1.Anchor"));
		this.tn_txt1.AutoSize = BooleanType.FromObject(resourceManager.GetObject("tn_txt1.AutoSize"));
		this.tn_txt1.BackColor = System.Drawing.Color.SteelBlue;
		this.tn_txt1.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tn_txt1.BackgroundImage");
		this.tn_txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tn_txt1.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("tn_txt1.Dock"));
		this.tn_txt1.Enabled = BooleanType.FromObject(resourceManager.GetObject("tn_txt1.Enabled"));
		this.tn_txt1.Font = (System.Drawing.Font)resourceManager.GetObject("tn_txt1.Font");
		this.tn_txt1.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.tn_txt1.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("tn_txt1.ImeMode"));
		this.tn_txt1.Location = (System.Drawing.Point)(resourceManager.GetObject("tn_txt1.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.tn_txt1.MaxLength = IntegerType.FromObject(resourceManager.GetObject("tn_txt1.MaxLength"));
		this.tn_txt1.Multiline = BooleanType.FromObject(resourceManager.GetObject("tn_txt1.Multiline"));
		this.tn_txt1.Name = "tn_txt1";
		this.tn_txt1.PasswordChar = CharType.FromObject(resourceManager.GetObject("tn_txt1.PasswordChar"));
		this.tn_txt1.ReadOnly = true;
		this.tn_txt1.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("tn_txt1.RightToLeft"));
		this.tn_txt1.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("tn_txt1.ScrollBars"));
		this.tn_txt1.Size = (System.Drawing.Size)(resourceManager.GetObject("tn_txt1.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.tn_txt1.TabIndex = IntegerType.FromObject(resourceManager.GetObject("tn_txt1.TabIndex"));
		this.tn_txt1.Tag = "6";
		this.tn_txt1.Text = resourceManager.GetString("tn_txt1.Text");
		this.tn_txt1.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("tn_txt1.TextAlign"));
		this.tn_txt1.Visible = BooleanType.FromObject(resourceManager.GetObject("tn_txt1.Visible"));
		this.tn_txt1.WordWrap = BooleanType.FromObject(resourceManager.GetObject("tn_txt1.WordWrap"));
		this.tn_txt2.AccessibleDescription = resourceManager.GetString("tn_txt2.AccessibleDescription");
		this.tn_txt2.AccessibleName = resourceManager.GetString("tn_txt2.AccessibleName");
		this.tn_txt2.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("tn_txt2.Anchor"));
		this.tn_txt2.AutoSize = BooleanType.FromObject(resourceManager.GetObject("tn_txt2.AutoSize"));
		this.tn_txt2.BackColor = System.Drawing.Color.SteelBlue;
		this.tn_txt2.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tn_txt2.BackgroundImage");
		this.tn_txt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tn_txt2.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("tn_txt2.Dock"));
		this.tn_txt2.Enabled = BooleanType.FromObject(resourceManager.GetObject("tn_txt2.Enabled"));
		this.tn_txt2.Font = (System.Drawing.Font)resourceManager.GetObject("tn_txt2.Font");
		this.tn_txt2.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.tn_txt2.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("tn_txt2.ImeMode"));
		this.tn_txt2.Location = (System.Drawing.Point)(resourceManager.GetObject("tn_txt2.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.tn_txt2.MaxLength = IntegerType.FromObject(resourceManager.GetObject("tn_txt2.MaxLength"));
		this.tn_txt2.Multiline = BooleanType.FromObject(resourceManager.GetObject("tn_txt2.Multiline"));
		this.tn_txt2.Name = "tn_txt2";
		this.tn_txt2.PasswordChar = CharType.FromObject(resourceManager.GetObject("tn_txt2.PasswordChar"));
		this.tn_txt2.ReadOnly = true;
		this.tn_txt2.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("tn_txt2.RightToLeft"));
		this.tn_txt2.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("tn_txt2.ScrollBars"));
		this.tn_txt2.Size = (System.Drawing.Size)(resourceManager.GetObject("tn_txt2.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.tn_txt2.TabIndex = IntegerType.FromObject(resourceManager.GetObject("tn_txt2.TabIndex"));
		this.tn_txt2.Tag = "5";
		this.tn_txt2.Text = resourceManager.GetString("tn_txt2.Text");
		this.tn_txt2.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("tn_txt2.TextAlign"));
		this.tn_txt2.Visible = BooleanType.FromObject(resourceManager.GetObject("tn_txt2.Visible"));
		this.tn_txt2.WordWrap = BooleanType.FromObject(resourceManager.GetObject("tn_txt2.WordWrap"));
		this.tn_pic4.AccessibleDescription = resourceManager.GetString("tn_pic4.AccessibleDescription");
		this.tn_pic4.AccessibleName = resourceManager.GetString("tn_pic4.AccessibleName");
		this.tn_pic4.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("tn_pic4.Anchor"));
		this.tn_pic4.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tn_pic4.BackgroundImage");
		this.tn_pic4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tn_pic4.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("tn_pic4.Dock"));
		this.tn_pic4.Enabled = BooleanType.FromObject(resourceManager.GetObject("tn_pic4.Enabled"));
		this.tn_pic4.Font = (System.Drawing.Font)resourceManager.GetObject("tn_pic4.Font");
		this.tn_pic4.Image = (System.Drawing.Image)resourceManager.GetObject("tn_pic4.Image");
		this.tn_pic4.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("tn_pic4.ImeMode"));
		this.tn_pic4.Location = (System.Drawing.Point)(resourceManager.GetObject("tn_pic4.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.tn_pic4.Name = "tn_pic4";
		this.tn_pic4.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("tn_pic4.RightToLeft"));
		this.tn_pic4.Size = (System.Drawing.Size)(resourceManager.GetObject("tn_pic4.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.tn_pic4.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)IntegerType.FromObject(resourceManager.GetObject("tn_pic4.SizeMode"));
		this.tn_pic4.TabIndex = IntegerType.FromObject(resourceManager.GetObject("tn_pic4.TabIndex"));
		this.tn_pic4.TabStop = false;
		this.tn_pic4.Text = resourceManager.GetString("tn_pic4.Text");
		this.tn_pic4.Visible = BooleanType.FromObject(resourceManager.GetObject("tn_pic4.Visible"));
		this.tn_txt4.AccessibleDescription = resourceManager.GetString("tn_txt4.AccessibleDescription");
		this.tn_txt4.AccessibleName = resourceManager.GetString("tn_txt4.AccessibleName");
		this.tn_txt4.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("tn_txt4.Anchor"));
		this.tn_txt4.AutoSize = BooleanType.FromObject(resourceManager.GetObject("tn_txt4.AutoSize"));
		this.tn_txt4.BackColor = System.Drawing.Color.SteelBlue;
		this.tn_txt4.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tn_txt4.BackgroundImage");
		this.tn_txt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tn_txt4.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("tn_txt4.Dock"));
		this.tn_txt4.Enabled = BooleanType.FromObject(resourceManager.GetObject("tn_txt4.Enabled"));
		this.tn_txt4.Font = (System.Drawing.Font)resourceManager.GetObject("tn_txt4.Font");
		this.tn_txt4.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.tn_txt4.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("tn_txt4.ImeMode"));
		this.tn_txt4.Location = (System.Drawing.Point)(resourceManager.GetObject("tn_txt4.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.tn_txt4.MaxLength = IntegerType.FromObject(resourceManager.GetObject("tn_txt4.MaxLength"));
		this.tn_txt4.Multiline = BooleanType.FromObject(resourceManager.GetObject("tn_txt4.Multiline"));
		this.tn_txt4.Name = "tn_txt4";
		this.tn_txt4.PasswordChar = CharType.FromObject(resourceManager.GetObject("tn_txt4.PasswordChar"));
		this.tn_txt4.ReadOnly = true;
		this.tn_txt4.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("tn_txt4.RightToLeft"));
		this.tn_txt4.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("tn_txt4.ScrollBars"));
		this.tn_txt4.Size = (System.Drawing.Size)(resourceManager.GetObject("tn_txt4.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.tn_txt4.TabIndex = IntegerType.FromObject(resourceManager.GetObject("tn_txt4.TabIndex"));
		this.tn_txt4.Tag = "1";
		this.tn_txt4.Text = resourceManager.GetString("tn_txt4.Text");
		this.tn_txt4.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("tn_txt4.TextAlign"));
		this.tn_txt4.Visible = BooleanType.FromObject(resourceManager.GetObject("tn_txt4.Visible"));
		this.tn_txt4.WordWrap = BooleanType.FromObject(resourceManager.GetObject("tn_txt4.WordWrap"));
		this.tn_txt3.AccessibleDescription = resourceManager.GetString("tn_txt3.AccessibleDescription");
		this.tn_txt3.AccessibleName = resourceManager.GetString("tn_txt3.AccessibleName");
		this.tn_txt3.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("tn_txt3.Anchor"));
		this.tn_txt3.AutoSize = BooleanType.FromObject(resourceManager.GetObject("tn_txt3.AutoSize"));
		this.tn_txt3.BackColor = System.Drawing.Color.SteelBlue;
		this.tn_txt3.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tn_txt3.BackgroundImage");
		this.tn_txt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tn_txt3.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("tn_txt3.Dock"));
		this.tn_txt3.Enabled = BooleanType.FromObject(resourceManager.GetObject("tn_txt3.Enabled"));
		this.tn_txt3.Font = (System.Drawing.Font)resourceManager.GetObject("tn_txt3.Font");
		this.tn_txt3.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.tn_txt3.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("tn_txt3.ImeMode"));
		this.tn_txt3.Location = (System.Drawing.Point)(resourceManager.GetObject("tn_txt3.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.tn_txt3.MaxLength = IntegerType.FromObject(resourceManager.GetObject("tn_txt3.MaxLength"));
		this.tn_txt3.Multiline = BooleanType.FromObject(resourceManager.GetObject("tn_txt3.Multiline"));
		this.tn_txt3.Name = "tn_txt3";
		this.tn_txt3.PasswordChar = CharType.FromObject(resourceManager.GetObject("tn_txt3.PasswordChar"));
		this.tn_txt3.ReadOnly = true;
		this.tn_txt3.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("tn_txt3.RightToLeft"));
		this.tn_txt3.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("tn_txt3.ScrollBars"));
		this.tn_txt3.Size = (System.Drawing.Size)(resourceManager.GetObject("tn_txt3.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.tn_txt3.TabIndex = IntegerType.FromObject(resourceManager.GetObject("tn_txt3.TabIndex"));
		this.tn_txt3.Tag = "4";
		this.tn_txt3.Text = resourceManager.GetString("tn_txt3.Text");
		this.tn_txt3.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("tn_txt3.TextAlign"));
		this.tn_txt3.Visible = BooleanType.FromObject(resourceManager.GetObject("tn_txt3.Visible"));
		this.tn_txt3.WordWrap = BooleanType.FromObject(resourceManager.GetObject("tn_txt3.WordWrap"));
		this.tn_pic3.AccessibleDescription = resourceManager.GetString("tn_pic3.AccessibleDescription");
		this.tn_pic3.AccessibleName = resourceManager.GetString("tn_pic3.AccessibleName");
		this.tn_pic3.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("tn_pic3.Anchor"));
		this.tn_pic3.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tn_pic3.BackgroundImage");
		this.tn_pic3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tn_pic3.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("tn_pic3.Dock"));
		this.tn_pic3.Enabled = BooleanType.FromObject(resourceManager.GetObject("tn_pic3.Enabled"));
		this.tn_pic3.Font = (System.Drawing.Font)resourceManager.GetObject("tn_pic3.Font");
		this.tn_pic3.Image = (System.Drawing.Image)resourceManager.GetObject("tn_pic3.Image");
		this.tn_pic3.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("tn_pic3.ImeMode"));
		this.tn_pic3.Location = (System.Drawing.Point)(resourceManager.GetObject("tn_pic3.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.tn_pic3.Name = "tn_pic3";
		this.tn_pic3.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("tn_pic3.RightToLeft"));
		this.tn_pic3.Size = (System.Drawing.Size)(resourceManager.GetObject("tn_pic3.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.tn_pic3.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)IntegerType.FromObject(resourceManager.GetObject("tn_pic3.SizeMode"));
		this.tn_pic3.TabIndex = IntegerType.FromObject(resourceManager.GetObject("tn_pic3.TabIndex"));
		this.tn_pic3.TabStop = false;
		this.tn_pic3.Text = resourceManager.GetString("tn_pic3.Text");
		this.tn_pic3.Visible = BooleanType.FromObject(resourceManager.GetObject("tn_pic3.Visible"));
		this.tn_pic6.AccessibleDescription = resourceManager.GetString("tn_pic6.AccessibleDescription");
		this.tn_pic6.AccessibleName = resourceManager.GetString("tn_pic6.AccessibleName");
		this.tn_pic6.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("tn_pic6.Anchor"));
		this.tn_pic6.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tn_pic6.BackgroundImage");
		this.tn_pic6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tn_pic6.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("tn_pic6.Dock"));
		this.tn_pic6.Enabled = BooleanType.FromObject(resourceManager.GetObject("tn_pic6.Enabled"));
		this.tn_pic6.Font = (System.Drawing.Font)resourceManager.GetObject("tn_pic6.Font");
		this.tn_pic6.Image = (System.Drawing.Image)resourceManager.GetObject("tn_pic6.Image");
		this.tn_pic6.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("tn_pic6.ImeMode"));
		this.tn_pic6.Location = (System.Drawing.Point)(resourceManager.GetObject("tn_pic6.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.tn_pic6.Name = "tn_pic6";
		this.tn_pic6.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("tn_pic6.RightToLeft"));
		this.tn_pic6.Size = (System.Drawing.Size)(resourceManager.GetObject("tn_pic6.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.tn_pic6.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)IntegerType.FromObject(resourceManager.GetObject("tn_pic6.SizeMode"));
		this.tn_pic6.TabIndex = IntegerType.FromObject(resourceManager.GetObject("tn_pic6.TabIndex"));
		this.tn_pic6.TabStop = false;
		this.tn_pic6.Text = resourceManager.GetString("tn_pic6.Text");
		this.tn_pic6.Visible = BooleanType.FromObject(resourceManager.GetObject("tn_pic6.Visible"));
		this.tn_txt5.AccessibleDescription = resourceManager.GetString("tn_txt5.AccessibleDescription");
		this.tn_txt5.AccessibleName = resourceManager.GetString("tn_txt5.AccessibleName");
		this.tn_txt5.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("tn_txt5.Anchor"));
		this.tn_txt5.AutoSize = BooleanType.FromObject(resourceManager.GetObject("tn_txt5.AutoSize"));
		this.tn_txt5.BackColor = System.Drawing.Color.SteelBlue;
		this.tn_txt5.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tn_txt5.BackgroundImage");
		this.tn_txt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tn_txt5.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("tn_txt5.Dock"));
		this.tn_txt5.Enabled = BooleanType.FromObject(resourceManager.GetObject("tn_txt5.Enabled"));
		this.tn_txt5.Font = (System.Drawing.Font)resourceManager.GetObject("tn_txt5.Font");
		this.tn_txt5.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.tn_txt5.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("tn_txt5.ImeMode"));
		this.tn_txt5.Location = (System.Drawing.Point)(resourceManager.GetObject("tn_txt5.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.tn_txt5.MaxLength = IntegerType.FromObject(resourceManager.GetObject("tn_txt5.MaxLength"));
		this.tn_txt5.Multiline = BooleanType.FromObject(resourceManager.GetObject("tn_txt5.Multiline"));
		this.tn_txt5.Name = "tn_txt5";
		this.tn_txt5.PasswordChar = CharType.FromObject(resourceManager.GetObject("tn_txt5.PasswordChar"));
		this.tn_txt5.ReadOnly = true;
		this.tn_txt5.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("tn_txt5.RightToLeft"));
		this.tn_txt5.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("tn_txt5.ScrollBars"));
		this.tn_txt5.Size = (System.Drawing.Size)(resourceManager.GetObject("tn_txt5.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.tn_txt5.TabIndex = IntegerType.FromObject(resourceManager.GetObject("tn_txt5.TabIndex"));
		this.tn_txt5.Tag = "2";
		this.tn_txt5.Text = resourceManager.GetString("tn_txt5.Text");
		this.tn_txt5.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("tn_txt5.TextAlign"));
		this.tn_txt5.Visible = BooleanType.FromObject(resourceManager.GetObject("tn_txt5.Visible"));
		this.tn_txt5.WordWrap = BooleanType.FromObject(resourceManager.GetObject("tn_txt5.WordWrap"));
		this.tn_txt6.AccessibleDescription = resourceManager.GetString("tn_txt6.AccessibleDescription");
		this.tn_txt6.AccessibleName = resourceManager.GetString("tn_txt6.AccessibleName");
		this.tn_txt6.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("tn_txt6.Anchor"));
		this.tn_txt6.AutoSize = BooleanType.FromObject(resourceManager.GetObject("tn_txt6.AutoSize"));
		this.tn_txt6.BackColor = System.Drawing.Color.SteelBlue;
		this.tn_txt6.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tn_txt6.BackgroundImage");
		this.tn_txt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tn_txt6.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("tn_txt6.Dock"));
		this.tn_txt6.Enabled = BooleanType.FromObject(resourceManager.GetObject("tn_txt6.Enabled"));
		this.tn_txt6.Font = (System.Drawing.Font)resourceManager.GetObject("tn_txt6.Font");
		this.tn_txt6.ForeColor = System.Drawing.SystemColors.HighlightText;
		this.tn_txt6.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("tn_txt6.ImeMode"));
		this.tn_txt6.Location = (System.Drawing.Point)(resourceManager.GetObject("tn_txt6.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.tn_txt6.MaxLength = IntegerType.FromObject(resourceManager.GetObject("tn_txt6.MaxLength"));
		this.tn_txt6.Multiline = BooleanType.FromObject(resourceManager.GetObject("tn_txt6.Multiline"));
		this.tn_txt6.Name = "tn_txt6";
		this.tn_txt6.PasswordChar = CharType.FromObject(resourceManager.GetObject("tn_txt6.PasswordChar"));
		this.tn_txt6.ReadOnly = true;
		this.tn_txt6.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("tn_txt6.RightToLeft"));
		this.tn_txt6.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("tn_txt6.ScrollBars"));
		this.tn_txt6.Size = (System.Drawing.Size)(resourceManager.GetObject("tn_txt6.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.tn_txt6.TabIndex = IntegerType.FromObject(resourceManager.GetObject("tn_txt6.TabIndex"));
		this.tn_txt6.Tag = "3";
		this.tn_txt6.Text = resourceManager.GetString("tn_txt6.Text");
		this.tn_txt6.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("tn_txt6.TextAlign"));
		this.tn_txt6.Visible = BooleanType.FromObject(resourceManager.GetObject("tn_txt6.Visible"));
		this.tn_txt6.WordWrap = BooleanType.FromObject(resourceManager.GetObject("tn_txt6.WordWrap"));
		this.tn_pic5.AccessibleDescription = resourceManager.GetString("tn_pic5.AccessibleDescription");
		this.tn_pic5.AccessibleName = resourceManager.GetString("tn_pic5.AccessibleName");
		this.tn_pic5.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("tn_pic5.Anchor"));
		this.tn_pic5.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("tn_pic5.BackgroundImage");
		this.tn_pic5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tn_pic5.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("tn_pic5.Dock"));
		this.tn_pic5.Enabled = BooleanType.FromObject(resourceManager.GetObject("tn_pic5.Enabled"));
		this.tn_pic5.Font = (System.Drawing.Font)resourceManager.GetObject("tn_pic5.Font");
		this.tn_pic5.Image = (System.Drawing.Image)resourceManager.GetObject("tn_pic5.Image");
		this.tn_pic5.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("tn_pic5.ImeMode"));
		this.tn_pic5.Location = (System.Drawing.Point)(resourceManager.GetObject("tn_pic5.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.tn_pic5.Name = "tn_pic5";
		this.tn_pic5.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("tn_pic5.RightToLeft"));
		this.tn_pic5.Size = (System.Drawing.Size)(resourceManager.GetObject("tn_pic5.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.tn_pic5.SizeMode = (System.Windows.Forms.PictureBoxSizeMode)IntegerType.FromObject(resourceManager.GetObject("tn_pic5.SizeMode"));
		this.tn_pic5.TabIndex = IntegerType.FromObject(resourceManager.GetObject("tn_pic5.TabIndex"));
		this.tn_pic5.TabStop = false;
		this.tn_pic5.Text = resourceManager.GetString("tn_pic5.Text");
		this.tn_pic5.Visible = BooleanType.FromObject(resourceManager.GetObject("tn_pic5.Visible"));
		this.txtTime.AccessibleDescription = resourceManager.GetString("txtTime.AccessibleDescription");
		this.txtTime.AccessibleName = resourceManager.GetString("txtTime.AccessibleName");
		this.txtTime.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("txtTime.Anchor"));
		this.txtTime.AutoSize = BooleanType.FromObject(resourceManager.GetObject("txtTime.AutoSize"));
		this.txtTime.BackColor = System.Drawing.SystemColors.ControlLightLight;
		this.txtTime.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("txtTime.BackgroundImage");
		this.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtTime.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("txtTime.Dock"));
		this.txtTime.Enabled = BooleanType.FromObject(resourceManager.GetObject("txtTime.Enabled"));
		this.txtTime.Font = (System.Drawing.Font)resourceManager.GetObject("txtTime.Font");
		this.txtTime.ForeColor = System.Drawing.Color.SteelBlue;
		this.txtTime.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("txtTime.ImeMode"));
		this.txtTime.Location = (System.Drawing.Point)(resourceManager.GetObject("txtTime.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.txtTime.MaxLength = IntegerType.FromObject(resourceManager.GetObject("txtTime.MaxLength"));
		this.txtTime.Multiline = BooleanType.FromObject(resourceManager.GetObject("txtTime.Multiline"));
		this.txtTime.Name = "txtTime";
		this.txtTime.PasswordChar = CharType.FromObject(resourceManager.GetObject("txtTime.PasswordChar"));
		this.txtTime.ReadOnly = true;
		this.txtTime.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("txtTime.RightToLeft"));
		this.txtTime.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("txtTime.ScrollBars"));
		this.txtTime.Size = (System.Drawing.Size)(resourceManager.GetObject("txtTime.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.txtTime.TabIndex = IntegerType.FromObject(resourceManager.GetObject("txtTime.TabIndex"));
		this.txtTime.Text = resourceManager.GetString("txtTime.Text");
		this.txtTime.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("txtTime.TextAlign"));
		this.txtTime.Visible = BooleanType.FromObject(resourceManager.GetObject("txtTime.Visible"));
		this.txtTime.WordWrap = BooleanType.FromObject(resourceManager.GetObject("txtTime.WordWrap"));
		this.Label1.AccessibleDescription = resourceManager.GetString("Label1.AccessibleDescription");
		this.Label1.AccessibleName = resourceManager.GetString("Label1.AccessibleName");
		this.Label1.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("Label1.Anchor"));
		this.Label1.AutoSize = BooleanType.FromObject(resourceManager.GetObject("Label1.AutoSize"));
		this.Label1.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("Label1.Dock"));
		this.Label1.Enabled = BooleanType.FromObject(resourceManager.GetObject("Label1.Enabled"));
		this.Label1.Font = (System.Drawing.Font)resourceManager.GetObject("Label1.Font");
		this.Label1.ForeColor = System.Drawing.Color.Firebrick;
		this.Label1.Image = (System.Drawing.Image)resourceManager.GetObject("Label1.Image");
		this.Label1.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label1.ImageAlign"));
		this.Label1.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("Label1.ImageIndex"));
		this.Label1.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("Label1.ImeMode"));
		this.Label1.Location = (System.Drawing.Point)(resourceManager.GetObject("Label1.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.Label1.Name = "Label1";
		this.Label1.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("Label1.RightToLeft"));
		this.Label1.Size = (System.Drawing.Size)(resourceManager.GetObject("Label1.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.Label1.TabIndex = IntegerType.FromObject(resourceManager.GetObject("Label1.TabIndex"));
		this.Label1.Text = resourceManager.GetString("Label1.Text");
		this.Label1.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("Label1.TextAlign"));
		this.Label1.Visible = BooleanType.FromObject(resourceManager.GetObject("Label1.Visible"));
		this.txtTyping.AccessibleDescription = resourceManager.GetString("txtTyping.AccessibleDescription");
		this.txtTyping.AccessibleName = resourceManager.GetString("txtTyping.AccessibleName");
		this.txtTyping.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("txtTyping.Anchor"));
		this.txtTyping.AutoSize = BooleanType.FromObject(resourceManager.GetObject("txtTyping.AutoSize"));
		this.txtTyping.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("txtTyping.BackgroundImage");
		this.txtTyping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtTyping.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("txtTyping.Dock"));
		this.txtTyping.Enabled = BooleanType.FromObject(resourceManager.GetObject("txtTyping.Enabled"));
		this.txtTyping.Font = (System.Drawing.Font)resourceManager.GetObject("txtTyping.Font");
		this.txtTyping.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("txtTyping.ImeMode"));
		this.txtTyping.Location = (System.Drawing.Point)(resourceManager.GetObject("txtTyping.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.txtTyping.MaxLength = IntegerType.FromObject(resourceManager.GetObject("txtTyping.MaxLength"));
		this.txtTyping.Multiline = BooleanType.FromObject(resourceManager.GetObject("txtTyping.Multiline"));
		this.txtTyping.Name = "txtTyping";
		this.txtTyping.PasswordChar = CharType.FromObject(resourceManager.GetObject("txtTyping.PasswordChar"));
		this.txtTyping.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("txtTyping.RightToLeft"));
		this.txtTyping.ScrollBars = (System.Windows.Forms.ScrollBars)IntegerType.FromObject(resourceManager.GetObject("txtTyping.ScrollBars"));
		this.txtTyping.Size = (System.Drawing.Size)(resourceManager.GetObject("txtTyping.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.txtTyping.TabIndex = IntegerType.FromObject(resourceManager.GetObject("txtTyping.TabIndex"));
		this.txtTyping.Text = resourceManager.GetString("txtTyping.Text");
		this.txtTyping.TextAlign = (System.Windows.Forms.HorizontalAlignment)IntegerType.FromObject(resourceManager.GetObject("txtTyping.TextAlign"));
		this.txtTyping.Visible = BooleanType.FromObject(resourceManager.GetObject("txtTyping.Visible"));
		this.txtTyping.WordWrap = BooleanType.FromObject(resourceManager.GetObject("txtTyping.WordWrap"));
		this.cmdMore.AccessibleDescription = resourceManager.GetString("cmdMore.AccessibleDescription");
		this.cmdMore.AccessibleName = resourceManager.GetString("cmdMore.AccessibleName");
		this.cmdMore.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("cmdMore.Anchor"));
		this.cmdMore.BackColor = System.Drawing.Color.SlateGray;
		this.cmdMore.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cmdMore.BackgroundImage");
		this.cmdMore.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("cmdMore.Dock"));
		this.cmdMore.Enabled = BooleanType.FromObject(resourceManager.GetObject("cmdMore.Enabled"));
		this.cmdMore.FlatStyle = (System.Windows.Forms.FlatStyle)IntegerType.FromObject(resourceManager.GetObject("cmdMore.FlatStyle"));
		this.cmdMore.Font = (System.Drawing.Font)resourceManager.GetObject("cmdMore.Font");
		this.cmdMore.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.cmdMore.Image = (System.Drawing.Image)resourceManager.GetObject("cmdMore.Image");
		this.cmdMore.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("cmdMore.ImageAlign"));
		this.cmdMore.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("cmdMore.ImageIndex"));
		this.cmdMore.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("cmdMore.ImeMode"));
		this.cmdMore.Location = (System.Drawing.Point)(resourceManager.GetObject("cmdMore.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.cmdMore.Name = "cmdMore";
		this.cmdMore.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("cmdMore.RightToLeft"));
		this.cmdMore.Size = (System.Drawing.Size)(resourceManager.GetObject("cmdMore.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.cmdMore.TabIndex = IntegerType.FromObject(resourceManager.GetObject("cmdMore.TabIndex"));
		this.cmdMore.Text = resourceManager.GetString("cmdMore.Text");
		this.cmdMore.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("cmdMore.TextAlign"));
		this.cmdMore.Visible = BooleanType.FromObject(resourceManager.GetObject("cmdMore.Visible"));
		this.cmdStop.AccessibleDescription = resourceManager.GetString("cmdStop.AccessibleDescription");
		this.cmdStop.AccessibleName = resourceManager.GetString("cmdStop.AccessibleName");
		this.cmdStop.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("cmdStop.Anchor"));
		this.cmdStop.BackColor = System.Drawing.Color.SlateGray;
		this.cmdStop.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cmdStop.BackgroundImage");
		this.cmdStop.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("cmdStop.Dock"));
		this.cmdStop.Enabled = BooleanType.FromObject(resourceManager.GetObject("cmdStop.Enabled"));
		this.cmdStop.FlatStyle = (System.Windows.Forms.FlatStyle)IntegerType.FromObject(resourceManager.GetObject("cmdStop.FlatStyle"));
		this.cmdStop.Font = (System.Drawing.Font)resourceManager.GetObject("cmdStop.Font");
		this.cmdStop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.cmdStop.Image = (System.Drawing.Image)resourceManager.GetObject("cmdStop.Image");
		this.cmdStop.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("cmdStop.ImageAlign"));
		this.cmdStop.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("cmdStop.ImageIndex"));
		this.cmdStop.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("cmdStop.ImeMode"));
		this.cmdStop.Location = (System.Drawing.Point)(resourceManager.GetObject("cmdStop.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.cmdStop.Name = "cmdStop";
		this.cmdStop.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("cmdStop.RightToLeft"));
		this.cmdStop.Size = (System.Drawing.Size)(resourceManager.GetObject("cmdStop.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.cmdStop.TabIndex = IntegerType.FromObject(resourceManager.GetObject("cmdStop.TabIndex"));
		this.cmdStop.Text = resourceManager.GetString("cmdStop.Text");
		this.cmdStop.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("cmdStop.TextAlign"));
		this.cmdStop.Visible = BooleanType.FromObject(resourceManager.GetObject("cmdStop.Visible"));
		this.lblType.AccessibleDescription = resourceManager.GetString("lblType.AccessibleDescription");
		this.lblType.AccessibleName = resourceManager.GetString("lblType.AccessibleName");
		this.lblType.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("lblType.Anchor"));
		this.lblType.AutoSize = BooleanType.FromObject(resourceManager.GetObject("lblType.AutoSize"));
		this.lblType.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("lblType.Dock"));
		this.lblType.Enabled = BooleanType.FromObject(resourceManager.GetObject("lblType.Enabled"));
		this.lblType.Font = (System.Drawing.Font)resourceManager.GetObject("lblType.Font");
		this.lblType.ForeColor = System.Drawing.SystemColors.Control;
		this.lblType.Image = (System.Drawing.Image)resourceManager.GetObject("lblType.Image");
		this.lblType.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("lblType.ImageAlign"));
		this.lblType.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("lblType.ImageIndex"));
		this.lblType.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("lblType.ImeMode"));
		this.lblType.Location = (System.Drawing.Point)(resourceManager.GetObject("lblType.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.lblType.Name = "lblType";
		this.lblType.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("lblType.RightToLeft"));
		this.lblType.Size = (System.Drawing.Size)(resourceManager.GetObject("lblType.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.lblType.TabIndex = IntegerType.FromObject(resourceManager.GetObject("lblType.TabIndex"));
		this.lblType.Text = resourceManager.GetString("lblType.Text");
		this.lblType.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("lblType.TextAlign"));
		this.lblType.Visible = BooleanType.FromObject(resourceManager.GetObject("lblType.Visible"));
		this.cmdExit.AccessibleDescription = resourceManager.GetString("cmdExit.AccessibleDescription");
		this.cmdExit.AccessibleName = resourceManager.GetString("cmdExit.AccessibleName");
		this.cmdExit.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("cmdExit.Anchor"));
		this.cmdExit.BackColor = System.Drawing.Color.SlateGray;
		this.cmdExit.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cmdExit.BackgroundImage");
		this.cmdExit.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("cmdExit.Dock"));
		this.cmdExit.Enabled = BooleanType.FromObject(resourceManager.GetObject("cmdExit.Enabled"));
		this.cmdExit.FlatStyle = (System.Windows.Forms.FlatStyle)IntegerType.FromObject(resourceManager.GetObject("cmdExit.FlatStyle"));
		this.cmdExit.Font = (System.Drawing.Font)resourceManager.GetObject("cmdExit.Font");
		this.cmdExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.cmdExit.Image = (System.Drawing.Image)resourceManager.GetObject("cmdExit.Image");
		this.cmdExit.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("cmdExit.ImageAlign"));
		this.cmdExit.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("cmdExit.ImageIndex"));
		this.cmdExit.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("cmdExit.ImeMode"));
		this.cmdExit.Location = (System.Drawing.Point)(resourceManager.GetObject("cmdExit.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.cmdExit.Name = "cmdExit";
		this.cmdExit.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("cmdExit.RightToLeft"));
		this.cmdExit.Size = (System.Drawing.Size)(resourceManager.GetObject("cmdExit.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.cmdExit.TabIndex = IntegerType.FromObject(resourceManager.GetObject("cmdExit.TabIndex"));
		this.cmdExit.Text = resourceManager.GetString("cmdExit.Text");
		this.cmdExit.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("cmdExit.TextAlign"));
		this.cmdExit.Visible = BooleanType.FromObject(resourceManager.GetObject("cmdExit.Visible"));
		this.Timer1.Interval = 1000;
		this.cmdReloadPic.AccessibleDescription = resourceManager.GetString("cmdReloadPic.AccessibleDescription");
		this.cmdReloadPic.AccessibleName = resourceManager.GetString("cmdReloadPic.AccessibleName");
		this.cmdReloadPic.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("cmdReloadPic.Anchor"));
		this.cmdReloadPic.BackColor = System.Drawing.Color.SlateGray;
		this.cmdReloadPic.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cmdReloadPic.BackgroundImage");
		this.cmdReloadPic.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("cmdReloadPic.Dock"));
		this.cmdReloadPic.Enabled = BooleanType.FromObject(resourceManager.GetObject("cmdReloadPic.Enabled"));
		this.cmdReloadPic.FlatStyle = (System.Windows.Forms.FlatStyle)IntegerType.FromObject(resourceManager.GetObject("cmdReloadPic.FlatStyle"));
		this.cmdReloadPic.Font = (System.Drawing.Font)resourceManager.GetObject("cmdReloadPic.Font");
		this.cmdReloadPic.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.cmdReloadPic.Image = (System.Drawing.Image)resourceManager.GetObject("cmdReloadPic.Image");
		this.cmdReloadPic.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("cmdReloadPic.ImageAlign"));
		this.cmdReloadPic.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("cmdReloadPic.ImageIndex"));
		this.cmdReloadPic.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("cmdReloadPic.ImeMode"));
		this.cmdReloadPic.Location = (System.Drawing.Point)(resourceManager.GetObject("cmdReloadPic.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.cmdReloadPic.Name = "cmdReloadPic";
		this.cmdReloadPic.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("cmdReloadPic.RightToLeft"));
		this.cmdReloadPic.Size = (System.Drawing.Size)(resourceManager.GetObject("cmdReloadPic.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.cmdReloadPic.TabIndex = IntegerType.FromObject(resourceManager.GetObject("cmdReloadPic.TabIndex"));
		this.cmdReloadPic.Text = resourceManager.GetString("cmdReloadPic.Text");
		this.cmdReloadPic.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("cmdReloadPic.TextAlign"));
		this.cmdReloadPic.Visible = BooleanType.FromObject(resourceManager.GetObject("cmdReloadPic.Visible"));
		this.cmdSupports.AccessibleDescription = resourceManager.GetString("cmdSupports.AccessibleDescription");
		this.cmdSupports.AccessibleName = resourceManager.GetString("cmdSupports.AccessibleName");
		this.cmdSupports.Anchor = (System.Windows.Forms.AnchorStyles)IntegerType.FromObject(resourceManager.GetObject("cmdSupports.Anchor"));
		this.cmdSupports.BackColor = System.Drawing.Color.SlateGray;
		this.cmdSupports.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("cmdSupports.BackgroundImage");
		this.cmdSupports.Dock = (System.Windows.Forms.DockStyle)IntegerType.FromObject(resourceManager.GetObject("cmdSupports.Dock"));
		this.cmdSupports.Enabled = BooleanType.FromObject(resourceManager.GetObject("cmdSupports.Enabled"));
		this.cmdSupports.FlatStyle = (System.Windows.Forms.FlatStyle)IntegerType.FromObject(resourceManager.GetObject("cmdSupports.FlatStyle"));
		this.cmdSupports.Font = (System.Drawing.Font)resourceManager.GetObject("cmdSupports.Font");
		this.cmdSupports.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.cmdSupports.Image = (System.Drawing.Image)resourceManager.GetObject("cmdSupports.Image");
		this.cmdSupports.ImageAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("cmdSupports.ImageAlign"));
		this.cmdSupports.ImageIndex = IntegerType.FromObject(resourceManager.GetObject("cmdSupports.ImageIndex"));
		this.cmdSupports.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("cmdSupports.ImeMode"));
		this.cmdSupports.Location = (System.Drawing.Point)(resourceManager.GetObject("cmdSupports.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.cmdSupports.Name = "cmdSupports";
		this.cmdSupports.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("cmdSupports.RightToLeft"));
		this.cmdSupports.Size = (System.Drawing.Size)(resourceManager.GetObject("cmdSupports.Size") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.cmdSupports.TabIndex = IntegerType.FromObject(resourceManager.GetObject("cmdSupports.TabIndex"));
		this.cmdSupports.Text = resourceManager.GetString("cmdSupports.Text");
		this.cmdSupports.TextAlign = (System.Drawing.ContentAlignment)IntegerType.FromObject(resourceManager.GetObject("cmdSupports.TextAlign"));
		this.cmdSupports.Visible = BooleanType.FromObject(resourceManager.GetObject("cmdSupports.Visible"));
		this.AccessibleDescription = resourceManager.GetString("$this.AccessibleDescription");
		this.AccessibleName = resourceManager.GetString("$this.AccessibleName");
		this.AllowDrop = true;
		this.AutoScaleBaseSize = (System.Drawing.Size)(resourceManager.GetObject("$this.AutoScaleBaseSize") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.AutoScroll = BooleanType.FromObject(resourceManager.GetObject("$this.AutoScroll"));
		this.AutoScrollMargin = (System.Drawing.Size)(resourceManager.GetObject("$this.AutoScrollMargin") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.AutoScrollMinSize = (System.Drawing.Size)(resourceManager.GetObject("$this.AutoScrollMinSize") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.BackgroundImage = (System.Drawing.Image)resourceManager.GetObject("$this.BackgroundImage");
		this.ClientSize = (System.Drawing.Size)(resourceManager.GetObject("$this.ClientSize") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.Controls.Add(this.lblType);
		this.Controls.Add(this.cmdMore);
		this.Controls.Add(this.txtTyping);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.cmdStop);
		this.Controls.Add(this.cmdExit);
		this.Controls.Add(this.cmdReloadPic);
		this.Controls.Add(this.cmdSupports);
		this.Enabled = BooleanType.FromObject(resourceManager.GetObject("$this.Enabled"));
		this.Font = (System.Drawing.Font)resourceManager.GetObject("$this.Font");
		this.Icon = (System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
		this.ImeMode = (System.Windows.Forms.ImeMode)IntegerType.FromObject(resourceManager.GetObject("$this.ImeMode"));
		this.KeyPreview = true;
		((System.Windows.Forms.Control)this).Location = (System.Drawing.Point)(resourceManager.GetObject("$this.Location") ?? System.Activator.CreateInstance(typeof(System.Drawing.Point)));
		this.MaximumSize = (System.Drawing.Size)(resourceManager.GetObject("$this.MaximumSize") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.MinimumSize = (System.Drawing.Size)(resourceManager.GetObject("$this.MinimumSize") ?? System.Activator.CreateInstance(typeof(System.Drawing.Size)));
		this.Name = "frmGame";
		this.RightToLeft = (System.Windows.Forms.RightToLeft)IntegerType.FromObject(resourceManager.GetObject("$this.RightToLeft"));
		this.StartPosition = (System.Windows.Forms.FormStartPosition)IntegerType.FromObject(resourceManager.GetObject("$this.StartPosition"));
		this.Text = resourceManager.GetString("$this.Text");
		this.TransparencyKey = System.Drawing.Color.FromArgb(255, 192, 128);
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.ResumeLayout(false);
	}

	private void frmGame_Load(object sender, EventArgs e)
	{
		txtTyping.Focus();
		txtTyping.Select(0, Strings.Len(txtTyping.Text));
		isType_all(t: false);
		cmdStop.Text = "&Play";
		txtTyping.Enabled = false;
		cnn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + Application.StartupPath + "\\reankhmer.mdb";
		string source;
		if (DoubleType.FromString(lblType.Text) == 1.0)
		{
			source = "SELECT word FROM tblDictionary";
			tn_txt_text("0");
		}
		else
		{
			source = "SELECT phrase FROM tblPhrase";
			tn_txt_text("2");
		}
		cnn.Open();
		rs_g.Open(source, cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic);
		generateRand();
		putPicture();
		putWord();
		sec = 0;
		min = 0;
		txtTime.Text = "00:00";
	}

	public void firstScore()
	{
		if (DoubleType.FromString(lblType.Text) == 1.0)
		{
			tn_txt_text("0");
		}
		else
		{
			tn_txt_text("2");
		}
	}

	public void isType(bool t1, bool t2, bool t3, bool t4, bool t5, bool t6)
	{
		isType1 = t1;
		isType2 = t2;
		isType3 = t3;
		isType4 = t4;
		isType5 = t5;
		isType6 = t6;
	}

	public void isType_all(bool t)
	{
		isType1 = t;
		isType2 = t;
		isType3 = t;
		isType4 = t;
		isType5 = t;
		isType6 = t;
	}

	public void tn_txt_text(string s)
	{
		tn_txt1.Text = s;
		tn_txt2.Text = s;
		tn_txt3.Text = s;
		tn_txt4.Text = s;
		tn_txt5.Text = s;
		tn_txt6.Text = s;
	}

	private void txtTyping_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if ((Strings.Len(txtTyping.Text) < Strings.Len(txt1.Text)) & !isType1)
			{
				string text = Strings.Trim(txt1.Text);
				if (StringType.StrCmp(text.Substring(0, Strings.Len(txtTyping.Text)), Strings.Trim(txtTyping.Text), false) == 0)
				{
					txt1.ForeColor = Color.Red;
				}
				else
				{
					txt1.ForeColor = Color.Black;
				}
			}
			else if ((Strings.Len(txtTyping.Text) == Strings.Len(txt1.Text)) & !isType1)
			{
				string text = Strings.Trim(txt1.Text);
				if (StringType.StrCmp(text.Substring(0, Strings.Len(txtTyping.Text)), Strings.Trim(txtTyping.Text), false) == 0)
				{
					txt1.BackColor = Color.LightBlue;
					int num = IntegerType.FromString(tn_txt1.Text);
					int num2 = IntegerType.FromObject(tn_txt1.Tag);
					num += num2;
					tn_txt1.Text = StringType.FromInteger(num);
					isType1 = true;
				}
			}
			else if ((Strings.Len(txtTyping.Text) > Strings.Len(txt1.Text)) & !isType1)
			{
				txt1.ForeColor = Color.Black;
				txt1.BackColor = Color.White;
			}
			if ((Strings.Len(txtTyping.Text) < Strings.Len(txt2.Text)) & !isType2)
			{
				string text = Strings.Trim(txt2.Text);
				string text2 = Strings.Trim(txtTyping.Text);
				if (StringType.StrCmp(text.Substring(0, Strings.Len(txtTyping.Text)), Strings.Trim(txtTyping.Text), false) == 0)
				{
					txt2.ForeColor = Color.Red;
				}
				else
				{
					txt2.ForeColor = Color.Black;
				}
			}
			else if ((Strings.Len(txtTyping.Text) == Strings.Len(txt2.Text)) & !isType2)
			{
				string text = Strings.Trim(txt2.Text);
				if (StringType.StrCmp(text.Substring(0, Strings.Len(txtTyping.Text)), Strings.Trim(txtTyping.Text), false) == 0)
				{
					txt2.BackColor = Color.LightBlue;
					int num = IntegerType.FromString(tn_txt2.Text);
					int num2 = IntegerType.FromObject(tn_txt2.Tag);
					num += num2;
					tn_txt2.Text = StringType.FromInteger(num);
					isType2 = true;
				}
			}
			else if ((Strings.Len(txtTyping.Text) > Strings.Len(txt2.Text)) & !isType2)
			{
				txt2.ForeColor = Color.Black;
				txt2.BackColor = Color.White;
			}
			if ((Strings.Len(txtTyping.Text) < Strings.Len(txt3.Text)) & !isType3)
			{
				string text = Strings.Trim(txt3.Text);
				if (StringType.StrCmp(text.Substring(0, Strings.Len(txtTyping.Text)), Strings.Trim(txtTyping.Text), false) == 0)
				{
					txt3.ForeColor = Color.Red;
				}
				else
				{
					txt3.ForeColor = Color.Black;
				}
			}
			else if ((Strings.Len(txtTyping.Text) == Strings.Len(txt3.Text)) & !isType3)
			{
				string text = Strings.Trim(txt3.Text);
				if (StringType.StrCmp(text.Substring(0, Strings.Len(txtTyping.Text)), Strings.Trim(txtTyping.Text), false) == 0)
				{
					txt3.BackColor = Color.LightBlue;
					int num = IntegerType.FromString(tn_txt3.Text);
					int num2 = IntegerType.FromObject(tn_txt3.Tag);
					num += num2;
					tn_txt3.Text = StringType.FromInteger(num);
					isType3 = true;
				}
			}
			else if ((Strings.Len(txtTyping.Text) > Strings.Len(txt3.Text)) & !isType3)
			{
				txt3.ForeColor = Color.Black;
				txt3.BackColor = Color.White;
			}
			if ((Strings.Len(txtTyping.Text) < Strings.Len(txt4.Text)) & !isType4)
			{
				string text = Strings.Trim(txt4.Text);
				if (StringType.StrCmp(text.Substring(0, Strings.Len(txtTyping.Text)), Strings.Trim(txtTyping.Text), false) == 0)
				{
					txt4.ForeColor = Color.Red;
				}
				else
				{
					txt4.ForeColor = Color.Black;
				}
			}
			else if ((Strings.Len(txtTyping.Text) == Strings.Len(txt4.Text)) & !isType4)
			{
				string text = Strings.Trim(txt4.Text);
				if (StringType.StrCmp(text.Substring(0, Strings.Len(txtTyping.Text)), Strings.Trim(txtTyping.Text), false) == 0)
				{
					txt4.BackColor = Color.LightBlue;
					int num = IntegerType.FromString(tn_txt4.Text);
					int num2 = IntegerType.FromObject(tn_txt4.Tag);
					num += num2;
					tn_txt4.Text = StringType.FromInteger(num);
					isType4 = true;
				}
			}
			else if ((Strings.Len(txtTyping.Text) > Strings.Len(txt4.Text)) & !isType4)
			{
				txt4.ForeColor = Color.Black;
				txt4.BackColor = Color.White;
			}
			if ((Strings.Len(txtTyping.Text) < Strings.Len(txt5.Text)) & !isType5)
			{
				string text = Strings.Trim(txt5.Text);
				string text3 = Strings.Trim(txtTyping.Text);
				if (StringType.StrCmp(text.Substring(0, Strings.Len(txtTyping.Text)), Strings.Trim(txtTyping.Text), false) == 0)
				{
					txt5.ForeColor = Color.Red;
				}
				else
				{
					txt5.ForeColor = Color.Black;
				}
			}
			else if ((Strings.Len(txtTyping.Text) == Strings.Len(txt5.Text)) & !isType5)
			{
				string text = Strings.Trim(txt5.Text);
				if (StringType.StrCmp(text.Substring(0, Strings.Len(txtTyping.Text)), Strings.Trim(txtTyping.Text), false) == 0)
				{
					txt5.BackColor = Color.LightBlue;
					int num = IntegerType.FromString(tn_txt5.Text);
					int num2 = IntegerType.FromObject(tn_txt5.Tag);
					num += num2;
					tn_txt5.Text = StringType.FromInteger(num);
					isType5 = true;
				}
			}
			else if ((Strings.Len(txtTyping.Text) > Strings.Len(txt5.Text)) & !isType5)
			{
				txt5.ForeColor = Color.Black;
				txt5.BackColor = Color.White;
			}
			if ((Strings.Len(txtTyping.Text) < Strings.Len(txt6.Text)) & !isType6)
			{
				string text = Strings.Trim(txt6.Text);
				if (StringType.StrCmp(text.Substring(0, Strings.Len(txtTyping.Text)), Strings.Trim(txtTyping.Text), false) == 0)
				{
					txt6.ForeColor = Color.Red;
				}
				else
				{
					txt6.ForeColor = Color.Black;
				}
			}
			else if ((Strings.Len(txtTyping.Text) == Strings.Len(txt6.Text)) & !isType6)
			{
				string text = Strings.Trim(txt6.Text);
				if (StringType.StrCmp(text.Substring(0, Strings.Len(txtTyping.Text)), Strings.Trim(txtTyping.Text), false) == 0)
				{
					txt6.BackColor = Color.LightBlue;
					int num = IntegerType.FromString(tn_txt6.Text);
					int num2 = IntegerType.FromObject(tn_txt6.Tag);
					num += num2;
					tn_txt6.Text = StringType.FromInteger(num);
					isType6 = true;
				}
			}
			else if ((Strings.Len(txtTyping.Text) > Strings.Len(txt6.Text)) & !isType6)
			{
				txt6.ForeColor = Color.Black;
				txt6.BackColor = Color.White;
			}
		}
	}

	private void cmdMore_Click(object sender, EventArgs e)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		if (min < 2)
		{
			isType_all(t: false);
			txtNormal();
			txtTyping.Focus();
			generateRand();
			putWord();
		}
		else
		{
			Interaction.MsgBox((object)"Sorry! you cannot continue playing the game. It's over time!\r\nClick Stop button to see the result.", (MsgBoxStyle)64, (object)"Game Over");
		}
	}

	private void generateRand()
	{
		int num = 12;
		int num2 = 1;
		getRand = null;
		numWord = null;
		wordRand = null;
		VBMath.Randomize();
		checked
		{
			while (true)
			{
				double a = Conversion.Int((float)(num - num2 + 1) * VBMath.Rnd() + (float)num2);
				if (checkRand((int)Math.Round(a), getRand))
				{
					if (Information.IsNothing((object)getRand))
					{
						getRand = new int[1];
					}
					else
					{
						getRand = (int[])Utils.CopyArray((Array)getRand, (Array)new int[Information.UBound((Array)getRand, 1) + 1 + 1]);
					}
					getRand[Information.UBound((Array)getRand, 1)] = (int)Math.Round(a);
					if (Information.UBound((Array)getRand, 1) == 5)
					{
						break;
					}
				}
			}
			num2 = 0;
			num = rs_g.RecordCount - 1;
			while (true)
			{
				double a = Conversion.Int((float)(num - num2 + 1) * VBMath.Rnd() + (float)num2);
				if (checkRand((int)Math.Round(a), numWord))
				{
					if (Information.IsNothing((object)numWord))
					{
						numWord = new int[1];
					}
					else
					{
						numWord = (int[])Utils.CopyArray((Array)numWord, (Array)new int[Information.UBound((Array)numWord, 1) + 1 + 1]);
					}
					numWord[Information.UBound((Array)numWord, 1)] = (int)Math.Round(a);
					if (Information.UBound((Array)numWord, 1) == 5)
					{
						break;
					}
				}
			}
			rs_g.MoveFirst();
			int num3 = rs_g.RecordCount - 1;
			for (int i = 0; i <= num3; i++)
			{
				int num4 = Information.UBound((Array)numWord, 1);
				for (int j = 0; j <= num4; j++)
				{
					if (numWord[j] == i)
					{
						if (Information.IsNothing((object)wordRand))
						{
							wordRand = new string[1];
						}
						else
						{
							wordRand = (string[])Utils.CopyArray((Array)wordRand, (Array)new string[Information.UBound((Array)wordRand, 1) + 1 + 1]);
						}
						wordRand[Information.UBound((Array)wordRand, 1)] = StringType.FromObject(rs_g.Fields[0].Value);
					}
				}
				rs_g.MoveNext();
			}
		}
	}

	private bool checkRand(int num, int[] getR)
	{
		if (!Information.IsNothing((object)getR))
		{
			int num2 = Information.UBound((Array)getR, 1);
			for (int i = 0; i <= num2; i = checked(i + 1))
			{
				if (num == getR[i])
				{
					return false;
				}
			}
		}
		return true;
	}

	private void putPicture()
	{
		if (!Information.IsNothing((object)getRand))
		{
			pic1.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromInteger(getRand[0]) + ".jpg");
			tn_pic1.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromInteger(getRand[0]) + ".jpg");
			pic2.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromInteger(getRand[1]) + ".jpg");
			tn_pic2.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromInteger(getRand[1]) + ".jpg");
			pic3.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromInteger(getRand[2]) + ".jpg");
			tn_pic3.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromInteger(getRand[2]) + ".jpg");
			pic4.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromInteger(getRand[3]) + ".jpg");
			tn_pic4.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromInteger(getRand[3]) + ".jpg");
			pic5.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromInteger(getRand[4]) + ".jpg");
			tn_pic5.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromInteger(getRand[4]) + ".jpg");
			pic6.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromInteger(getRand[5]) + ".jpg");
			tn_pic6.Image = Image.FromFile(Application.StartupPath + "\\images\\" + StringType.FromInteger(getRand[5]) + ".jpg");
		}
		else
		{
			generateRand();
			putPicture();
		}
	}

	private void txtNormal()
	{
		txt1.ForeColor = Color.Black;
		txt1.BackColor = Color.White;
		txt2.ForeColor = Color.Black;
		txt2.BackColor = Color.White;
		txt3.ForeColor = Color.Black;
		txt3.BackColor = Color.White;
		txt4.ForeColor = Color.Black;
		txt4.BackColor = Color.White;
		txt5.ForeColor = Color.Black;
		txt5.BackColor = Color.White;
		txt6.ForeColor = Color.Black;
		txt6.BackColor = Color.White;
	}

	private void putWord()
	{
		if (!Information.IsNothing((object)wordRand))
		{
			txt1.Text = wordRand[0];
			txt2.Text = wordRand[1];
			txt3.Text = wordRand[2];
			txt4.Text = wordRand[3];
			txt5.Text = wordRand[4];
			txt6.Text = wordRand[5];
		}
	}

	private void cmdStop_Click(object sender, EventArgs e)
	{
		if (StringType.StrCmp(cmdStop.Text, "&Play", false) == 0)
		{
			cmdStop.Text = "&Stop";
			txtTyping.Enabled = true;
			txtTyping.Focus();
			txtTyping.Select(0, Strings.Len(txtTyping.Text));
			if (min == 2)
			{
				txtTime.Text = "00:00";
				min = 0;
				sec = 0;
				firstScore();
			}
			Timer1.Start();
			return;
		}
		int num = IntegerType.FromObject(ObjectType.AddObj(ObjectType.AddObj(Conversion.Int((object)tn_txt1.Text), Conversion.Int((object)tn_txt2.Text)), Conversion.Int((object)tn_txt3.Text)));
		num = IntegerType.FromObject(ObjectType.AddObj(ObjectType.AddObj((object)num, Conversion.Int((object)tn_txt4.Text)), Conversion.Int((object)tn_txt5.Text)));
		num = IntegerType.FromObject(ObjectType.AddObj((object)num, Conversion.Int((object)tn_txt6.Text)));
		if (min == 2)
		{
			txtTime.Text = "00:00";
		}
		cmdStop.Text = "&Play";
		txtTyping.Enabled = false;
		Timer1.Stop();
		frmGameResult frmGameResult2 = new frmGameResult();
		frmGameResult2.txtResult.Text = checkLevel(num);
		frmGameResult2.Show();
	}

	private void cmdExit_Click(object sender, EventArgs e)
	{
		frmUserGame frmUserGame2 = new frmUserGame();
		Close();
		frmUserGame2.Close();
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			sec++;
			if (sec == 60)
			{
				min++;
				sec = 0;
			}
			tm = string.Concat(str3: (sec < 10) ? ("0" + StringType.FromInteger(sec)) : ("" + StringType.FromInteger(sec)), str0: "0", str1: StringType.FromInteger(min), str2: ":");
			txtTime.Text = tm;
			if (min == 2)
			{
				Timer1.Stop();
				txtTyping.Enabled = false;
				Interaction.MsgBox((object)"Time is over! Try again!\r\nClick STOP button to see the result", (MsgBoxStyle)64, (object)"Time is over!");
			}
		}
	}

	private void txtTyping_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Return)
		{
			txtTyping.Text = "";
			if (isType1 & isType2 & isType3 & isType4 & isType5 & isType6)
			{
				generateRand();
				putWord();
				isType_all(t: false);
				txtNormal();
			}
		}
	}

	private string checkLevel(int getS)
	{
		int num = 15;
		int num2 = 30;
		int num3 = 55;
		int num4 = 75;
		int num5 = 100;
		string text = "Hello " + txtName.Text + "\r\n";
		if (getS > num5)
		{
			text = text + "Your score: " + StringType.FromInteger(getS) + "\t. You are EXCELLENT!";
		}
		else if (getS > num4)
		{
			text = text + "Your score: " + StringType.FromInteger(getS) + "\tGOOD!";
		}
		else if (getS > num3)
		{
			text = text + "Your score: " + StringType.FromInteger(getS) + "\tFAIR!";
		}
		else if (getS > num2)
		{
			text = text + "Your score: " + StringType.FromInteger(getS) + "\tNORMAL!";
		}
		else if (getS > num)
		{
			text = text + "Your score: " + StringType.FromInteger(getS) + "\tWEAK! Try again!";
		}
		else if (getS < num)
		{
			text = text + "Your score: " + StringType.FromInteger(getS) + "\tSO WEAK!";
		}
		text += "\r\n____________________________________________";
		text += "\r\nIf you need full Khmer Unicode Typing.";
		return text + "\r\nOn menu bar, click HELP -> SUPPORT";
	}

	private void cmdReloadPic_Click(object sender, EventArgs e)
	{
		generateRand();
		putPicture();
	}

	private void cmdSupports_Click(object sender, EventArgs e)
	{
		frmSupport frmSupport2 = new frmSupport();
		frmSupport2.MdiParent = MdiParent;
		frmSupport2.Show();
	}
}
