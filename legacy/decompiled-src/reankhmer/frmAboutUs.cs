using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace reankhmer;

public class frmAboutUs : Form
{
	[AccessedThroughProperty("picD")]
	private PictureBox _picD;

	[AccessedThroughProperty("txtContact")]
	private RichTextBox _txtContact;

	[AccessedThroughProperty("txtL")]
	private TextBox _txtL;

	[AccessedThroughProperty("txtD")]
	private TextBox _txtD;

	[AccessedThroughProperty("picL")]
	private PictureBox _picL;

	[AccessedThroughProperty("TextBox1")]
	private TextBox _TextBox1;

	[AccessedThroughProperty("lblTitle")]
	private Label _lblTitle;

	[AccessedThroughProperty("picM")]
	private PictureBox _picM;

	[AccessedThroughProperty("txtM")]
	private TextBox _txtM;

	private IContainer components;

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

	internal virtual PictureBox picM
	{
		get
		{
			return _picM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_picM != null)
			{
			}
			_picM = value;
			if (_picM == null)
			{
			}
		}
	}

	internal virtual PictureBox picL
	{
		get
		{
			return _picL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_picL != null)
			{
			}
			_picL = value;
			if (_picL == null)
			{
			}
		}
	}

	internal virtual PictureBox picD
	{
		get
		{
			return _picD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_picD != null)
			{
			}
			_picD = value;
			if (_picD == null)
			{
			}
		}
	}

	internal virtual TextBox txtM
	{
		get
		{
			return _txtM;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtM != null)
			{
			}
			_txtM = value;
			if (_txtM == null)
			{
			}
		}
	}

	internal virtual TextBox txtL
	{
		get
		{
			return _txtL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtL != null)
			{
			}
			_txtL = value;
			if (_txtL == null)
			{
			}
		}
	}

	internal virtual TextBox txtD
	{
		get
		{
			return _txtD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtD != null)
			{
			}
			_txtD = value;
			if (_txtD == null)
			{
			}
		}
	}

	internal virtual RichTextBox txtContact
	{
		get
		{
			return _txtContact;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtContact != null)
			{
				_txtContact.LinkClicked -= txtContact_LinkClicked;
			}
			_txtContact = value;
			if (_txtContact != null)
			{
				_txtContact.LinkClicked += txtContact_LinkClicked;
			}
		}
	}

	public frmAboutUs()
	{
		base.Load += frmAboutUs_Load;
		base.Resize += frmAboutUs_Resize;
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
		this.picM = new System.Windows.Forms.PictureBox();
		this.picL = new System.Windows.Forms.PictureBox();
		this.picD = new System.Windows.Forms.PictureBox();
		this.txtM = new System.Windows.Forms.TextBox();
		this.txtL = new System.Windows.Forms.TextBox();
		this.txtD = new System.Windows.Forms.TextBox();
		this.txtContact = new System.Windows.Forms.RichTextBox();
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
		this.TextBox1.TabIndex = 42;
		this.TextBox1.Text = "ក\u17d2រ\u17bbម MLD -  MLD Team";
		this.lblTitle.BackColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.Label label = this.lblTitle;
		location = new System.Drawing.Point(0, 0);
		label.Location = location;
		this.lblTitle.Name = "lblTitle";
		System.Windows.Forms.Label label2 = this.lblTitle;
		size = new System.Drawing.Size(712, 40);
		label2.Size = size;
		this.lblTitle.TabIndex = 41;
		this.picM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox = this.picM;
		location = new System.Drawing.Point(8, 56);
		pictureBox.Location = location;
		this.picM.Name = "picM";
		System.Windows.Forms.PictureBox pictureBox2 = this.picM;
		size = new System.Drawing.Size(176, 168);
		pictureBox2.Size = size;
		this.picM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picM.TabIndex = 43;
		this.picM.TabStop = false;
		this.picL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox3 = this.picL;
		location = new System.Drawing.Point(201, 56);
		pictureBox3.Location = location;
		this.picL.Name = "picL";
		System.Windows.Forms.PictureBox pictureBox4 = this.picL;
		size = new System.Drawing.Size(187, 168);
		pictureBox4.Size = size;
		this.picL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picL.TabIndex = 43;
		this.picL.TabStop = false;
		this.picD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox5 = this.picD;
		location = new System.Drawing.Point(408, 56);
		pictureBox5.Location = location;
		this.picD.Name = "picD";
		System.Windows.Forms.PictureBox pictureBox6 = this.picD;
		size = new System.Drawing.Size(184, 168);
		pictureBox6.Size = size;
		this.picD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picD.TabIndex = 43;
		this.picD.TabStop = false;
		this.txtM.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txtM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtM.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtM.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.TextBox textBox3 = this.txtM;
		location = new System.Drawing.Point(8, 232);
		textBox3.Location = location;
		this.txtM.Multiline = true;
		this.txtM.Name = "txtM";
		this.txtM.ReadOnly = true;
		System.Windows.Forms.TextBox textBox4 = this.txtM;
		size = new System.Drawing.Size(176, 88);
		textBox4.Size = size;
		this.txtM.TabIndex = 44;
		this.txtM.Text = "";
		this.txtM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtL.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txtL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtL.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtL.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.TextBox textBox5 = this.txtL;
		location = new System.Drawing.Point(205, 232);
		textBox5.Location = location;
		this.txtL.Multiline = true;
		this.txtL.Name = "txtL";
		this.txtL.ReadOnly = true;
		System.Windows.Forms.TextBox textBox6 = this.txtL;
		size = new System.Drawing.Size(187, 88);
		textBox6.Size = size;
		this.txtL.TabIndex = 44;
		this.txtL.Text = "";
		this.txtL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtD.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txtD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtD.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.txtD.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.TextBox textBox7 = this.txtD;
		location = new System.Drawing.Point(408, 232);
		textBox7.Location = location;
		this.txtD.Multiline = true;
		this.txtD.Name = "txtD";
		this.txtD.ReadOnly = true;
		System.Windows.Forms.TextBox textBox8 = this.txtD;
		size = new System.Drawing.Size(184, 88);
		textBox8.Size = size;
		this.txtD.TabIndex = 44;
		this.txtD.Text = "";
		this.txtD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtContact.BackColor = System.Drawing.SystemColors.Info;
		this.txtContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtContact.Font = new System.Drawing.Font("Arial", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.RichTextBox richTextBox = this.txtContact;
		location = new System.Drawing.Point(8, 328);
		richTextBox.Location = location;
		this.txtContact.Name = "txtContact";
		this.txtContact.ReadOnly = true;
		System.Windows.Forms.RichTextBox richTextBox2 = this.txtContact;
		size = new System.Drawing.Size(584, 64);
		richTextBox2.Size = size;
		this.txtContact.TabIndex = 45;
		this.txtContact.Text = "";
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(598, 400);
		this.ClientSize = size;
		this.Controls.Add(this.txtContact);
		this.Controls.Add(this.txtM);
		this.Controls.Add(this.picM);
		this.Controls.Add(this.TextBox1);
		this.Controls.Add(this.lblTitle);
		this.Controls.Add(this.picL);
		this.Controls.Add(this.picD);
		this.Controls.Add(this.txtL);
		this.Controls.Add(this.txtD);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.MaximizeBox = false;
		this.Name = "frmAboutUs";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "ReanKhmer :: MLD Team";
		this.ResumeLayout(false);
	}

	private void frmAboutUs_Load(object sender, EventArgs e)
	{
		picM.Image = Image.FromFile(Application.StartupPath + "\\images\\tn_metrey.jpg");
		picL.Image = Image.FromFile(Application.StartupPath + "\\images\\tn_leaksmy.jpg");
		picD.Image = Image.FromFile(Application.StartupPath + "\\images\\tn_davy.jpg");
		txtM.Text = "ស\u17bbខ ពង\u17d2ស\u17b6 ម\u17c1ត\u17d2រ\u17b8\r\nMr. Sok Pongsa Metrey\r\nmetrey_r@yahoo.com";
		txtL.Text = "ស\u17bbខ លក\u17d2ខស\u17d2ម\u17c9\u17b8\r\nMrs. Sok Leaksmy\r\nsok_leaksmy@yahoo.com";
		txtD.Text = "អ\u17ca\u17bbក ស\u17ca\u17b8ដ\u17b6វ\u17b8\r\nMr. Ouk Sidavy\r\nbisliebistise@yahoo.com";
		txtContact.Text = "Contact our team at: \tMobile: (+855)12 1856 900\r\nEmail: camtutorials@yahoo.com\tWebsite: http://d.1asphost.com/campro/";
	}

	private void frmAboutUs_Resize(object sender, EventArgs e)
	{
		lblTitle.Width = Width;
	}

	private void txtContact_LinkClicked(object sender, LinkClickedEventArgs e)
	{
		Process.Start(e.LinkText);
	}
}
