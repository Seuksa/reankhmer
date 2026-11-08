using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class frmFirst : Form
{
	[AccessedThroughProperty("lblFirst")]
	private Label _lblFirst;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("Label5")]
	private Label _Label5;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("pRupp")]
	private PictureBox _pRupp;

	[AccessedThroughProperty("pH")]
	private PictureBox _pH;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

	[AccessedThroughProperty("lbl1")]
	private Label _lbl1;

	[AccessedThroughProperty("Timer1")]
	private Timer _Timer1;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	private IContainer components;

	private int mn;

	private int walk;

	private const int SND_LOOP = 8;

	private const int SND_ASYNC = 1;

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

	internal virtual PictureBox pRupp
	{
		get
		{
			return _pRupp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pRupp != null)
			{
			}
			_pRupp = value;
			if (_pRupp == null)
			{
			}
		}
	}

	internal virtual PictureBox pH
	{
		get
		{
			return _pH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pH != null)
			{
			}
			_pH = value;
			if (_pH == null)
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

	internal virtual Label lbl1
	{
		get
		{
			return _lbl1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lbl1 != null)
			{
			}
			_lbl1 = value;
			if (_lbl1 == null)
			{
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

	internal virtual Label lblFirst
	{
		get
		{
			return _lblFirst;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblFirst != null)
			{
			}
			_lblFirst = value;
			if (_lblFirst == null)
			{
			}
		}
	}

	[STAThread]
	public static void Main()
	{
		Application.Run(new frmFirst());
	}

	public frmFirst()
	{
		base.Load += frmFirst_Load;
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
		System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(reankhmer.frmFirst));
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.pRupp = new System.Windows.Forms.PictureBox();
		this.pH = new System.Windows.Forms.PictureBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.lbl1 = new System.Windows.Forms.Label();
		this.Timer1 = new System.Windows.Forms.Timer(this.components);
		this.Label5 = new System.Windows.Forms.Label();
		this.lblFirst = new System.Windows.Forms.Label();
		this.SuspendLayout();
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.Color.IndianRed;
		System.Windows.Forms.Label label = this.Label1;
		System.Drawing.Point location = new System.Drawing.Point(88, 16);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		System.Drawing.Size size = new System.Drawing.Size(336, 23);
		label2.Size = size;
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Kingdom of Cambodia";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.Label2.Font = new System.Drawing.Font("Verdana", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label2.ForeColor = System.Drawing.Color.ForestGreen;
		System.Windows.Forms.Label label3 = this.Label2;
		location = new System.Drawing.Point(88, 48);
		label3.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label4 = this.Label2;
		size = new System.Drawing.Size(336, 23);
		label4.Size = size;
		this.Label2.TabIndex = 0;
		this.Label2.Text = "Nation  Religion  King";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.pRupp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox = this.pRupp;
		location = new System.Drawing.Point(16, 48);
		pictureBox.Location = location;
		this.pRupp.Name = "pRupp";
		System.Windows.Forms.PictureBox pictureBox2 = this.pRupp;
		size = new System.Drawing.Size(80, 72);
		pictureBox2.Size = size;
		this.pRupp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pRupp.TabIndex = 1;
		this.pRupp.TabStop = false;
		this.pH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox3 = this.pH;
		location = new System.Drawing.Point(360, 48);
		pictureBox3.Location = location;
		this.pH.Name = "pH";
		System.Windows.Forms.PictureBox pictureBox4 = this.pH;
		size = new System.Drawing.Size(168, 72);
		pictureBox4.Size = size;
		this.pH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pH.TabIndex = 2;
		this.pH.TabStop = false;
		this.Label3.Font = new System.Drawing.Font("Verdana", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label3.ForeColor = System.Drawing.Color.Black;
		System.Windows.Forms.Label label5 = this.Label3;
		location = new System.Drawing.Point(88, 196);
		label5.Location = location;
		this.Label3.Name = "Label3";
		System.Windows.Forms.Label label6 = this.Label3;
		size = new System.Drawing.Size(336, 23);
		label6.Size = size;
		this.Label3.TabIndex = 0;
		this.Label3.Text = "Learning Khmer";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.TextBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
		this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.TextBox1.Font = new System.Drawing.Font("Khmer OS Freehand", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.TextBox1.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.TextBox textBox = this.TextBox1;
		location = new System.Drawing.Point(88, 152);
		textBox.Location = location;
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.ReadOnly = true;
		System.Windows.Forms.TextBox textBox2 = this.TextBox1;
		size = new System.Drawing.Size(336, 44);
		textBox2.Size = size;
		this.TextBox1.TabIndex = 3;
		this.TextBox1.Text = "បង\u17d2រ\u17c0នភ\u17b6ស\u17b6ខ\u17d2ម\u17c2រ";
		this.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.Label4.Font = new System.Drawing.Font("Verdana", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label4.ForeColor = System.Drawing.Color.Black;
		System.Windows.Forms.Label label7 = this.Label4;
		location = new System.Drawing.Point(8, 227);
		label7.Location = location;
		this.Label4.Name = "Label4";
		System.Windows.Forms.Label label8 = this.Label4;
		size = new System.Drawing.Size(512, 23);
		label8.Size = size;
		this.Label4.TabIndex = 0;
		this.Label4.Text = "Lecturer: Mr. Meas Vandeth";
		this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lbl1.Font = new System.Drawing.Font("Verdana", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lbl1.ForeColor = System.Drawing.Color.Black;
		System.Windows.Forms.Label label9 = this.lbl1;
		location = new System.Drawing.Point(8, 256);
		label9.Location = location;
		this.lbl1.Name = "lbl1";
		System.Windows.Forms.Label label10 = this.lbl1;
		size = new System.Drawing.Size(512, 104);
		label10.Size = size;
		this.lbl1.TabIndex = 0;
		this.lbl1.Text = "Lecturer: Mr. Meas Vandeth";
		this.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.Timer1.Interval = 1000;
		this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.Label5.Font = new System.Drawing.Font("Verdana", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label5.ForeColor = System.Drawing.Color.IndianRed;
		System.Windows.Forms.Label label11 = this.Label5;
		location = new System.Drawing.Point(88, 128);
		label11.Location = location;
		this.Label5.Name = "Label5";
		System.Windows.Forms.Label label12 = this.Label5;
		size = new System.Drawing.Size(336, 24);
		label12.Size = size;
		this.Label5.TabIndex = 4;
		this.Label5.Text = "Science Fair 2006";
		this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.lblFirst.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label13 = this.lblFirst;
		location = new System.Drawing.Point(472, 176);
		label13.Location = location;
		this.lblFirst.Name = "lblFirst";
		System.Windows.Forms.Label label14 = this.lblFirst;
		size = new System.Drawing.Size(48, 23);
		label14.Size = size;
		this.lblFirst.TabIndex = 5;
		this.lblFirst.Text = "0";
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(536, 370);
		this.ClientSize = size;
		this.ControlBox = false;
		this.Controls.Add(this.lblFirst);
		this.Controls.Add(this.Label5);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.pH);
		this.Controls.Add(this.pRupp);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.Label3);
		this.Controls.Add(this.Label4);
		this.Controls.Add(this.lbl1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.Icon = (System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
		this.Name = "frmFirst";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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

	private void frmFirst_Load(object sender, EventArgs e)
	{
		string text = Application.StartupPath + "\\flash\\reankhmer_start_1.mp3";
		string lpstrCommand = "PLAY " + text;
		string lpstrReturnString = StringType.FromInteger(0);
		long num = mciSendString(ref lpstrCommand, ref lpstrReturnString, 0L, 0L);
		pRupp.Image = Image.FromFile(Application.StartupPath + "\\images\\rupp_logo.JPG");
		pH.Image = Image.FromFile(Application.StartupPath + "\\images\\heinrich.JPG");
		lbl1.Text = "Students: \r\nMr. Sok Pongsa Metrey\r\nMrs. Sok Leaksmy\r\nMr. Ouk Sidavy";
		mn = 10;
		walk = 0;
		Timer1.Start();
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		checked
		{
			walk++;
			if (walk == mn)
			{
				if (StringType.StrCmp(lblFirst.Text, "0", false) == 0)
				{
					Hide();
					Timer1.Stop();
					frmMain frmMain2 = new frmMain();
					frmMain2.Show();
				}
				else
				{
					Close();
				}
			}
		}
	}
}
