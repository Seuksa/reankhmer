using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace reankhmer;

public class frmConversationInto : Form
{
	[AccessedThroughProperty("txtTitle")]
	private TextBox _txtTitle;

	[AccessedThroughProperty("cmdClose")]
	private Button _cmdClose;

	[AccessedThroughProperty("lblChapter")]
	private Label _lblChapter;

	[AccessedThroughProperty("txtIntro")]
	private TextBox _txtIntro;

	private IContainer components;

	internal virtual TextBox txtTitle
	{
		get
		{
			return _txtTitle;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtTitle != null)
			{
			}
			_txtTitle = value;
			if (_txtTitle == null)
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

	public frmConversationInto()
	{
		base.Resize += frmConversationInto_Resize;
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
		this.txtTitle = new System.Windows.Forms.TextBox();
		this.lblChapter = new System.Windows.Forms.Label();
		this.txtIntro = new System.Windows.Forms.TextBox();
		this.cmdClose = new System.Windows.Forms.Button();
		this.SuspendLayout();
		this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtTitle.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox = this.txtTitle;
		System.Drawing.Point location = new System.Drawing.Point(8, 56);
		textBox.Location = location;
		this.txtTitle.Name = "txtTitle";
		this.txtTitle.ReadOnly = true;
		System.Windows.Forms.TextBox textBox2 = this.txtTitle;
		System.Drawing.Size size = new System.Drawing.Size(584, 31);
		textBox2.Size = size;
		this.txtTitle.TabIndex = 0;
		this.txtTitle.Text = "";
		this.lblChapter.BackColor = System.Drawing.Color.SteelBlue;
		this.lblChapter.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblChapter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Label label = this.lblChapter;
		location = new System.Drawing.Point(0, 0);
		label.Location = location;
		this.lblChapter.Name = "lblChapter";
		System.Windows.Forms.Label label2 = this.lblChapter;
		size = new System.Drawing.Size(608, 32);
		label2.Size = size;
		this.lblChapter.TabIndex = 33;
		this.lblChapter.Text = "Chapter 5 :: Khmer Conversation,";
		this.lblChapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.txtIntro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtIntro.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox3 = this.txtIntro;
		location = new System.Drawing.Point(8, 96);
		textBox3.Location = location;
		this.txtIntro.Multiline = true;
		this.txtIntro.Name = "txtIntro";
		this.txtIntro.ReadOnly = true;
		this.txtIntro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox4 = this.txtIntro;
		size = new System.Drawing.Size(584, 232);
		textBox4.Size = size;
		this.txtIntro.TabIndex = 0;
		this.txtIntro.Text = "";
		this.cmdClose.BackColor = System.Drawing.SystemColors.AppWorkspace;
		this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		System.Windows.Forms.Button button = this.cmdClose;
		location = new System.Drawing.Point(520, 336);
		button.Location = location;
		this.cmdClose.Name = "cmdClose";
		this.cmdClose.TabIndex = 34;
		this.cmdClose.Text = "&Close";
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(608, 370);
		this.ClientSize = size;
		this.Controls.Add(this.cmdClose);
		this.Controls.Add(this.lblChapter);
		this.Controls.Add(this.txtTitle);
		this.Controls.Add(this.txtIntro);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.MaximizeBox = false;
		this.Name = "frmConversationInto";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Introduction :: Khmer Conversation";
		this.ResumeLayout(false);
	}

	private void frmConversationInto_Resize(object sender, EventArgs e)
	{
		lblChapter.Width = Width;
	}

	private void cmdClose_Click(object sender, EventArgs e)
	{
		Close();
	}
}
