using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace reankhmer;

public class frmSupport : Form
{
	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("cmdInstallKhmer")]
	private Button _cmdInstallKhmer;

	[AccessedThroughProperty("txtKhmerUnicode")]
	private TextBox _txtKhmerUnicode;

	[AccessedThroughProperty("cmdInstallHelp")]
	private Button _cmdInstallHelp;

	[AccessedThroughProperty("cmdKeyboard")]
	private Button _cmdKeyboard;

	[AccessedThroughProperty("lblHelp")]
	private Label _lblHelp;

	[AccessedThroughProperty("txtTyping")]
	private TextBox _txtTyping;

	[AccessedThroughProperty("cmdTyping")]
	private Button _cmdTyping;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("PictureBox1")]
	private PictureBox _PictureBox1;

	[AccessedThroughProperty("cmdClose")]
	private Button _cmdClose;

	private IContainer components;

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

	internal virtual TextBox txtKhmerUnicode
	{
		get
		{
			return _txtKhmerUnicode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtKhmerUnicode != null)
			{
			}
			_txtKhmerUnicode = value;
			if (_txtKhmerUnicode == null)
			{
			}
		}
	}

	internal virtual Button cmdInstallKhmer
	{
		get
		{
			return _cmdInstallKhmer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdInstallKhmer != null)
			{
				_cmdInstallKhmer.Click -= cmdInstallKhmer_Click;
			}
			_cmdInstallKhmer = value;
			if (_cmdInstallKhmer != null)
			{
				_cmdInstallKhmer.Click += cmdInstallKhmer_Click;
			}
		}
	}

	internal virtual Button cmdInstallHelp
	{
		get
		{
			return _cmdInstallHelp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdInstallHelp != null)
			{
				_cmdInstallHelp.Click -= cmdInstallHelp_Click;
			}
			_cmdInstallHelp = value;
			if (_cmdInstallHelp != null)
			{
				_cmdInstallHelp.Click += cmdInstallHelp_Click;
			}
		}
	}

	internal virtual Button cmdKeyboard
	{
		get
		{
			return _cmdKeyboard;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdKeyboard != null)
			{
				_cmdKeyboard.Click -= cmdKeyboard_Click;
			}
			_cmdKeyboard = value;
			if (_cmdKeyboard != null)
			{
				_cmdKeyboard.Click += cmdKeyboard_Click;
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
			}
			_txtTyping = value;
			if (_txtTyping == null)
			{
			}
		}
	}

	internal virtual Button cmdTyping
	{
		get
		{
			return _cmdTyping;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdTyping != null)
			{
				_cmdTyping.Click -= cmdTyping_Click;
			}
			_cmdTyping = value;
			if (_cmdTyping != null)
			{
				_cmdTyping.Click += cmdTyping_Click;
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

	internal virtual Label lblHelp
	{
		get
		{
			return _lblHelp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblHelp != null)
			{
			}
			_lblHelp = value;
			if (_lblHelp == null)
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

	public frmSupport()
	{
		base.Load += frmSupport_Load;
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
		System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(reankhmer.frmSupport));
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.txtKhmerUnicode = new System.Windows.Forms.TextBox();
		this.cmdInstallKhmer = new System.Windows.Forms.Button();
		this.cmdInstallHelp = new System.Windows.Forms.Button();
		this.cmdKeyboard = new System.Windows.Forms.Button();
		this.txtTyping = new System.Windows.Forms.TextBox();
		this.cmdTyping = new System.Windows.Forms.Button();
		this.cmdClose = new System.Windows.Forms.Button();
		this.lblHelp = new System.Windows.Forms.Label();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.SuspendLayout();
		this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.PictureBox1.Image = (System.Drawing.Image)resourceManager.GetObject("PictureBox1.Image");
		System.Windows.Forms.PictureBox pictureBox = this.PictureBox1;
		System.Drawing.Point location = new System.Drawing.Point(0, -8);
		pictureBox.Location = location;
		this.PictureBox1.Name = "PictureBox1";
		System.Windows.Forms.PictureBox pictureBox2 = this.PictureBox1;
		System.Drawing.Size size = new System.Drawing.Size(88, 424);
		pictureBox2.Size = size;
		this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.PictureBox1.TabIndex = 0;
		this.PictureBox1.TabStop = false;
		this.txtKhmerUnicode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.TextBox textBox = this.txtKhmerUnicode;
		location = new System.Drawing.Point(96, 72);
		textBox.Location = location;
		this.txtKhmerUnicode.Multiline = true;
		this.txtKhmerUnicode.Name = "txtKhmerUnicode";
		this.txtKhmerUnicode.ReadOnly = true;
		System.Windows.Forms.TextBox textBox2 = this.txtKhmerUnicode;
		size = new System.Drawing.Size(504, 80);
		textBox2.Size = size;
		this.txtKhmerUnicode.TabIndex = 1;
		this.txtKhmerUnicode.Text = "";
		this.cmdInstallKhmer.BackColor = System.Drawing.Color.SlateGray;
		this.cmdInstallKhmer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdInstallKhmer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdInstallKhmer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button = this.cmdInstallKhmer;
		location = new System.Drawing.Point(488, 48);
		button.Location = location;
		this.cmdInstallKhmer.Name = "cmdInstallKhmer";
		System.Windows.Forms.Button button2 = this.cmdInstallKhmer;
		size = new System.Drawing.Size(112, 23);
		button2.Size = size;
		this.cmdInstallKhmer.TabIndex = 2;
		this.cmdInstallKhmer.Text = "&Install Unicode";
		this.cmdInstallHelp.BackColor = System.Drawing.Color.SlateGray;
		this.cmdInstallHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdInstallHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdInstallHelp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button3 = this.cmdInstallHelp;
		location = new System.Drawing.Point(360, 48);
		button3.Location = location;
		this.cmdInstallHelp.Name = "cmdInstallHelp";
		System.Windows.Forms.Button button4 = this.cmdInstallHelp;
		size = new System.Drawing.Size(120, 23);
		button4.Size = size;
		this.cmdInstallHelp.TabIndex = 2;
		this.cmdInstallHelp.Text = "Installation Help";
		this.cmdKeyboard.BackColor = System.Drawing.Color.SlateGray;
		this.cmdKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdKeyboard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button5 = this.cmdKeyboard;
		location = new System.Drawing.Point(240, 48);
		button5.Location = location;
		this.cmdKeyboard.Name = "cmdKeyboard";
		System.Windows.Forms.Button button6 = this.cmdKeyboard;
		size = new System.Drawing.Size(112, 23);
		button6.Size = size;
		this.cmdKeyboard.TabIndex = 2;
		this.cmdKeyboard.Text = "The &Keyboard";
		this.txtTyping.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.TextBox textBox3 = this.txtTyping;
		location = new System.Drawing.Point(96, 192);
		textBox3.Location = location;
		this.txtTyping.Multiline = true;
		this.txtTyping.Name = "txtTyping";
		this.txtTyping.ReadOnly = true;
		System.Windows.Forms.TextBox textBox4 = this.txtTyping;
		size = new System.Drawing.Size(504, 48);
		textBox4.Size = size;
		this.txtTyping.TabIndex = 1;
		this.txtTyping.Text = "";
		this.cmdTyping.BackColor = System.Drawing.Color.SlateGray;
		this.cmdTyping.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdTyping.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdTyping.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button7 = this.cmdTyping;
		location = new System.Drawing.Point(488, 168);
		button7.Location = location;
		this.cmdTyping.Name = "cmdTyping";
		System.Windows.Forms.Button button8 = this.cmdTyping;
		size = new System.Drawing.Size(112, 23);
		button8.Size = size;
		this.cmdTyping.TabIndex = 2;
		this.cmdTyping.Text = "&Install Typing";
		this.cmdClose.BackColor = System.Drawing.Color.SlateGray;
		this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button9 = this.cmdClose;
		location = new System.Drawing.Point(512, 376);
		button9.Location = location;
		this.cmdClose.Name = "cmdClose";
		System.Windows.Forms.Button button10 = this.cmdClose;
		size = new System.Drawing.Size(88, 32);
		button10.Size = size;
		this.cmdClose.TabIndex = 38;
		this.cmdClose.Text = "&Close";
		this.lblHelp.BackColor = System.Drawing.Color.SteelBlue;
		this.lblHelp.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblHelp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Label label = this.lblHelp;
		location = new System.Drawing.Point(88, 0);
		label.Location = location;
		this.lblHelp.Name = "lblHelp";
		System.Windows.Forms.Label label2 = this.lblHelp;
		size = new System.Drawing.Size(528, 32);
		label2.Size = size;
		this.lblHelp.TabIndex = 39;
		this.lblHelp.Text = "Application Supports";
		this.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.Color.Crimson;
		System.Windows.Forms.Label label3 = this.Label1;
		location = new System.Drawing.Point(96, 48);
		label3.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label4 = this.Label1;
		size = new System.Drawing.Size(104, 23);
		label4.Size = size;
		this.Label1.TabIndex = 40;
		this.Label1.Text = "Khmer Unicode:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label2.ForeColor = System.Drawing.Color.Crimson;
		System.Windows.Forms.Label label5 = this.Label2;
		location = new System.Drawing.Point(96, 168);
		label5.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label6 = this.Label2;
		size = new System.Drawing.Size(152, 23);
		label6.Size = size;
		this.Label2.TabIndex = 40;
		this.Label2.Text = "Khmer Unicode Typing:";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(610, 410);
		this.ClientSize = size;
		this.ControlBox = false;
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.lblHelp);
		this.Controls.Add(this.cmdClose);
		this.Controls.Add(this.cmdInstallKhmer);
		this.Controls.Add(this.txtKhmerUnicode);
		this.Controls.Add(this.PictureBox1);
		this.Controls.Add(this.cmdInstallHelp);
		this.Controls.Add(this.cmdKeyboard);
		this.Controls.Add(this.txtTyping);
		this.Controls.Add(this.cmdTyping);
		this.Controls.Add(this.Label2);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.MaximizeBox = false;
		this.Name = "frmSupport";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "ReanKhmer Support";
		this.ResumeLayout(false);
	}

	private void frmSupport_Load(object sender, EventArgs e)
	{
		txtKhmerUnicode.Text = "Since the arrival of computers in Cambodia from the 80's, there was a need to be able to represent the Khmer script, or language, digitally. Since that time there have been many attempts to construct a system for writing the complex Khmer script. Khmer Unicode is the only globally standardised encoding, or recording, of the Khmer script.";
		txtTyping.Text = "Khmer Unicode typing is a software help you to learn Khmer Unicode Typing from the beginning. It is simple and easy to learn.";
	}

	private void cmdInstallKhmer_Click(object sender, EventArgs e)
	{
		string text = Application.StartupPath + "\\support\\khmerUnicode\\KhmerUnicode1.2.5.FindUsp.exe";
		Interaction.Shell(text, (AppWinStyle)1, false, -1);
	}

	private void cmdInstallHelp_Click(object sender, EventArgs e)
	{
		frmInstallUnicodeHelp frmInstallUnicodeHelp2 = new frmInstallUnicodeHelp();
		frmInstallUnicodeHelp2.MdiParent = MdiParent;
		frmInstallUnicodeHelp2.Show();
	}

	private void cmdKeyboard_Click(object sender, EventArgs e)
	{
		frmKeyboard frmKeyboard2 = new frmKeyboard();
		frmKeyboard2.MdiParent = MdiParent;
		frmKeyboard2.Show();
	}

	private void cmdTyping_Click(object sender, EventArgs e)
	{
		string text = Application.StartupPath + "\\support\\KhmerUnicodeTyping1.0.exe";
		Interaction.Shell(text, (AppWinStyle)1, false, -1);
	}

	private void cmdClose_Click(object sender, EventArgs e)
	{
		Close();
	}
}
