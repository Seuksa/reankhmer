using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace reankhmer;

public class frmInstallUnicodeHelp : Form
{
	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("cmdInstallKhmer")]
	private Button _cmdInstallKhmer;

	[AccessedThroughProperty("txtDesc")]
	private TextBox _txtDesc;

	[AccessedThroughProperty("lblTitle")]
	private Label _lblTitle;

	[AccessedThroughProperty("cboStep")]
	private ComboBox _cboStep;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("cmdClose")]
	private Button _cmdClose;

	[AccessedThroughProperty("picUnicode")]
	private PictureBox _picUnicode;

	private IContainer components;

	private string picPath;

	private string desc;

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

	internal virtual PictureBox picUnicode
	{
		get
		{
			return _picUnicode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_picUnicode != null)
			{
			}
			_picUnicode = value;
			if (_picUnicode == null)
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

	internal virtual ComboBox cboStep
	{
		get
		{
			return _cboStep;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cboStep != null)
			{
				_cboStep.SelectedIndexChanged -= cboStep_SelectedIndexChanged;
			}
			_cboStep = value;
			if (_cboStep != null)
			{
				_cboStep.SelectedIndexChanged += cboStep_SelectedIndexChanged;
			}
		}
	}

	internal virtual TextBox txtDesc
	{
		get
		{
			return _txtDesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtDesc != null)
			{
			}
			_txtDesc = value;
			if (_txtDesc == null)
			{
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

	public frmInstallUnicodeHelp()
	{
		base.Load += frmInstallUnicodeHelp_Load;
		base.Resize += frmInstallUnicodeHelp_Resize;
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
		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.lblTitle = new System.Windows.Forms.Label();
		this.picUnicode = new System.Windows.Forms.PictureBox();
		this.txtDesc = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.cboStep = new System.Windows.Forms.ComboBox();
		this.cmdClose = new System.Windows.Forms.Button();
		this.cmdInstallKhmer = new System.Windows.Forms.Button();
		this.SuspendLayout();
		this.TextBox1.BackColor = System.Drawing.Color.SteelBlue;
		this.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.TextBox1.Font = new System.Drawing.Font("Khmer OS Freehand", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.TextBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
		System.Windows.Forms.TextBox textBox = this.TextBox1;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		textBox.Location = location;
		this.TextBox1.Name = "TextBox1";
		System.Windows.Forms.TextBox textBox2 = this.TextBox1;
		System.Drawing.Size size = new System.Drawing.Size(360, 37);
		textBox2.Size = size;
		this.TextBox1.TabIndex = 40;
		this.TextBox1.Text = "ខ\u17d2ម\u17c2រយ\u17c9\u17bcន\u17b8ក\u17bcដ\u17c8 - Khmer Unicode (Installation help)";
		this.lblTitle.BackColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.Label label = this.lblTitle;
		location = new System.Drawing.Point(0, 0);
		label.Location = location;
		this.lblTitle.Name = "lblTitle";
		System.Windows.Forms.Label label2 = this.lblTitle;
		size = new System.Drawing.Size(712, 40);
		label2.Size = size;
		this.lblTitle.TabIndex = 39;
		this.picUnicode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox = this.picUnicode;
		location = new System.Drawing.Point(8, 56);
		pictureBox.Location = location;
		this.picUnicode.Name = "picUnicode";
		System.Windows.Forms.PictureBox pictureBox2 = this.picUnicode;
		size = new System.Drawing.Size(312, 248);
		pictureBox2.Size = size;
		this.picUnicode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picUnicode.TabIndex = 41;
		this.picUnicode.TabStop = false;
		this.txtDesc.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.TextBox textBox3 = this.txtDesc;
		location = new System.Drawing.Point(328, 88);
		textBox3.Location = location;
		this.txtDesc.Multiline = true;
		this.txtDesc.Name = "txtDesc";
		this.txtDesc.ReadOnly = true;
		System.Windows.Forms.TextBox textBox4 = this.txtDesc;
		size = new System.Drawing.Size(352, 216);
		textBox4.Size = size;
		this.txtDesc.TabIndex = 42;
		this.txtDesc.Text = "";
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Label label3 = this.Label1;
		location = new System.Drawing.Point(432, 56);
		label3.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label4 = this.Label1;
		size = new System.Drawing.Size(120, 24);
		label4.Size = size;
		this.Label1.TabIndex = 43;
		this.Label1.Text = "Installation step:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		System.Windows.Forms.ComboBox comboBox = this.cboStep;
		location = new System.Drawing.Point(560, 56);
		comboBox.Location = location;
		this.cboStep.Name = "cboStep";
		System.Windows.Forms.ComboBox comboBox2 = this.cboStep;
		size = new System.Drawing.Size(121, 21);
		comboBox2.Size = size;
		this.cboStep.TabIndex = 44;
		this.cmdClose.BackColor = System.Drawing.Color.SlateGray;
		this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button = this.cmdClose;
		location = new System.Drawing.Point(608, 312);
		button.Location = location;
		this.cmdClose.Name = "cmdClose";
		this.cmdClose.TabIndex = 45;
		this.cmdClose.Text = "Clo&se";
		this.cmdInstallKhmer.BackColor = System.Drawing.Color.SlateGray;
		this.cmdInstallKhmer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdInstallKhmer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdInstallKhmer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button2 = this.cmdInstallKhmer;
		location = new System.Drawing.Point(248, 312);
		button2.Location = location;
		this.cmdInstallKhmer.Name = "cmdInstallKhmer";
		this.cmdInstallKhmer.TabIndex = 46;
		this.cmdInstallKhmer.Text = "&Install";
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(684, 344);
		this.ClientSize = size;
		this.ControlBox = false;
		this.Controls.Add(this.cmdInstallKhmer);
		this.Controls.Add(this.cmdClose);
		this.Controls.Add(this.cboStep);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.txtDesc);
		this.Controls.Add(this.picUnicode);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.lblTitle);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.Name = "frmInstallUnicodeHelp";
		this.Text = "Khmer Unicode :: Installation Help";
		this.ResumeLayout(false);
	}

	private void frmInstallUnicodeHelp_Load(object sender, EventArgs e)
	{
		ComboBox.ObjectCollection items = cboStep.Items;
		items.Add(1);
		items.Add(2);
		items.Add(3);
		items.Add(4);
		items.Add(5);
		items = null;
		cboStep.SelectedIndex = 0;
		picPath = Application.StartupPath + "\\support\\installHelp\\1.jpg";
		desc = "Khmer Unicode version 1.2.5:: Click Install button to start.\r\nAfter click install you will see the screen like the picture on your left.\r\nClick Next >>";
	}

	private void frmInstallUnicodeHelp_Resize(object sender, EventArgs e)
	{
		lblTitle.Width = Width;
	}

	private void cboStep_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (cboStep.SelectedIndex)
		{
		case 0:
			picPath = Application.StartupPath + "\\support\\installHelp\\" + cboStep.Text + ".jpg";
			desc = "Khmer Unicode version 1.2.5:: Click Install button to start.\r\nAfter click install you will see the screen like the picture on your left.\r\nClick Next >>";
			break;
		case 1:
			picPath = Application.StartupPath + "\\support\\installHelp\\" + cboStep.Text + ".jpg";
			desc = "When this box pops-up click the (Complex & kbd) button (this can take a few moments to install, so please be patient). It is possible that you will need your Windows XP cd at this time - so if you are asked for it, please insert it into your cd-rom.";
			break;
		case 2:
			picPath = Application.StartupPath + "\\support\\installHelp\\" + cboStep.Text + ".jpg";
			desc = "When the text (Complex script enabled/Keyboard layout added.) appears click the (Close) button.";
			break;
		case 3:
			picPath = Application.StartupPath + "\\support\\installHelp\\" + cboStep.Text + ".jpg";
			desc = "To finish off the installation, click the (Exit) button";
			break;
		case 4:
			picPath = Application.StartupPath + "\\support\\installHelp\\" + cboStep.Text + ".jpg";
			desc = "Now you should see a new button in the lower right corner of your screen saying either, (EN) or (CA). When you want to type in English, make sure (EN) is showing, and when you want to type in Khmer Unicode, make sure the (CA) is showing. To switch between the two langauges, you can click on the button and select (like the picture above shows), or you can press the (Alt) key and the (shift) key which is on the right hand side of your keyboard (if you press the shift key that is on the left hand side of your keyboard it will not switch)\r\n\r\n(Ref: www.sbbic.org; For: ReanKhmer Software by: camtutorials@yahoo.com)";
			break;
		}
		picUnicode.Image = Image.FromFile(picPath);
		txtDesc.Text = desc;
	}

	private void cmdClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void cmdInstallKhmer_Click(object sender, EventArgs e)
	{
		string text = Application.StartupPath + "\\support\\khmerUnicode\\KhmerUnicode1.2.5.FindUsp.exe";
		Interaction.Shell(text, (AppWinStyle)1, false, -1);
	}
}
