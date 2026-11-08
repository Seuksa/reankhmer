using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class frmHelp : Form
{
	[AccessedThroughProperty("rdbHelps")]
	private RadioButton _rdbHelps;

	[AccessedThroughProperty("rdbPractices")]
	private RadioButton _rdbPractices;

	[AccessedThroughProperty("cmdSearch")]
	private Button _cmdSearch;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("rdbTools")]
	private RadioButton _rdbTools;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("rdbChapters")]
	private RadioButton _rdbChapters;

	[AccessedThroughProperty("rdbInstall")]
	private RadioButton _rdbInstall;

	[AccessedThroughProperty("txtSearch")]
	private TextBox _txtSearch;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("rtbHelp")]
	private RichTextBox _rtbHelp;

	[AccessedThroughProperty("cmdNext")]
	private Button _cmdNext;

	[AccessedThroughProperty("cmdPrint")]
	private Button _cmdPrint;

	[AccessedThroughProperty("PrintDocument1")]
	private PrintDocument _PrintDocument1;

	[AccessedThroughProperty("cboSubContents")]
	private ComboBox _cboSubContents;

	[AccessedThroughProperty("cmdClose")]
	private Button _cmdClose;

	[AccessedThroughProperty("txtIntro")]
	private TextBox _txtIntro;

	[AccessedThroughProperty("lblHelp")]
	private Label _lblHelp;

	private int getW;

	private int getH;

	private int gW;

	private int gH;

	private IContainer components;

	[SpecialName]
	private int _0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar;

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

	internal virtual RichTextBox rtbHelp
	{
		get
		{
			return _rtbHelp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rtbHelp != null)
			{
				_rtbHelp.LinkClicked -= rtbHelp_LinkClicked;
			}
			_rtbHelp = value;
			if (_rtbHelp != null)
			{
				_rtbHelp.LinkClicked += rtbHelp_LinkClicked;
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

	internal virtual RadioButton rdbInstall
	{
		get
		{
			return _rdbInstall;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdbInstall != null)
			{
				_rdbInstall.CheckedChanged -= rdbInstall_CheckedChanged;
			}
			_rdbInstall = value;
			if (_rdbInstall != null)
			{
				_rdbInstall.CheckedChanged += rdbInstall_CheckedChanged;
			}
		}
	}

	internal virtual RadioButton rdbChapters
	{
		get
		{
			return _rdbChapters;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdbChapters != null)
			{
				_rdbChapters.CheckedChanged -= rdbChapters_CheckedChanged;
			}
			_rdbChapters = value;
			if (_rdbChapters != null)
			{
				_rdbChapters.CheckedChanged += rdbChapters_CheckedChanged;
			}
		}
	}

	internal virtual RadioButton rdbTools
	{
		get
		{
			return _rdbTools;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdbTools != null)
			{
				_rdbTools.CheckedChanged -= rdbTools_CheckedChanged;
			}
			_rdbTools = value;
			if (_rdbTools != null)
			{
				_rdbTools.CheckedChanged += rdbTools_CheckedChanged;
			}
		}
	}

	internal virtual RadioButton rdbPractices
	{
		get
		{
			return _rdbPractices;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdbPractices != null)
			{
				_rdbPractices.CheckedChanged -= rdbPractices_CheckedChanged;
			}
			_rdbPractices = value;
			if (_rdbPractices != null)
			{
				_rdbPractices.CheckedChanged += rdbPractices_CheckedChanged;
			}
		}
	}

	internal virtual RadioButton rdbHelps
	{
		get
		{
			return _rdbHelps;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdbHelps != null)
			{
				_rdbHelps.CheckedChanged -= rdbHelps_CheckedChanged;
			}
			_rdbHelps = value;
			if (_rdbHelps != null)
			{
				_rdbHelps.CheckedChanged += rdbHelps_CheckedChanged;
			}
		}
	}

	internal virtual ComboBox cboSubContents
	{
		get
		{
			return _cboSubContents;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cboSubContents != null)
			{
				_cboSubContents.SelectedIndexChanged -= cboSubContents_SelectedIndexChanged;
			}
			_cboSubContents = value;
			if (_cboSubContents != null)
			{
				_cboSubContents.SelectedIndexChanged += cboSubContents_SelectedIndexChanged;
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

	internal virtual TextBox txtSearch
	{
		get
		{
			return _txtSearch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtSearch != null)
			{
			}
			_txtSearch = value;
			if (_txtSearch == null)
			{
			}
		}
	}

	internal virtual Button cmdSearch
	{
		get
		{
			return _cmdSearch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdSearch != null)
			{
				_cmdSearch.Click -= cmdSearch_Click;
			}
			_cmdSearch = value;
			if (_cmdSearch != null)
			{
				_cmdSearch.Click += cmdSearch_Click;
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

	internal virtual Button cmdPrint
	{
		get
		{
			return _cmdPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdPrint != null)
			{
				_cmdPrint.Click -= cmdPrint_Click;
			}
			_cmdPrint = value;
			if (_cmdPrint != null)
			{
				_cmdPrint.Click += cmdPrint_Click;
			}
		}
	}

	internal virtual PrintDocument PrintDocument1
	{
		get
		{
			return _PrintDocument1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_PrintDocument1 != null)
			{
				_PrintDocument1.PrintPage -= PrintDocument1_PrintPage;
			}
			_PrintDocument1 = value;
			if (_PrintDocument1 != null)
			{
				_PrintDocument1.PrintPage += PrintDocument1_PrintPage;
			}
		}
	}

	public frmHelp()
	{
		base.Load += frmHelp_Load;
		base.Resize += frmHelp_Resize;
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
		this.lblHelp = new System.Windows.Forms.Label();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.rdbInstall = new System.Windows.Forms.RadioButton();
		this.rdbChapters = new System.Windows.Forms.RadioButton();
		this.rdbTools = new System.Windows.Forms.RadioButton();
		this.rdbPractices = new System.Windows.Forms.RadioButton();
		this.rdbHelps = new System.Windows.Forms.RadioButton();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.cboSubContents = new System.Windows.Forms.ComboBox();
		this.txtIntro = new System.Windows.Forms.TextBox();
		this.cmdClose = new System.Windows.Forms.Button();
		this.rtbHelp = new System.Windows.Forms.RichTextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.txtSearch = new System.Windows.Forms.TextBox();
		this.cmdSearch = new System.Windows.Forms.Button();
		this.cmdNext = new System.Windows.Forms.Button();
		this.cmdPrint = new System.Windows.Forms.Button();
		this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.SuspendLayout();
		this.lblHelp.BackColor = System.Drawing.Color.SteelBlue;
		this.lblHelp.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblHelp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Label label = this.lblHelp;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		label.Location = location;
		this.lblHelp.Name = "lblHelp";
		System.Windows.Forms.Label label2 = this.lblHelp;
		System.Drawing.Size size = new System.Drawing.Size(728, 32);
		label2.Size = size;
		this.lblHelp.TabIndex = 33;
		this.lblHelp.Text = "Application Help:";
		this.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.GroupBox1.Controls.Add(this.rdbInstall);
		this.GroupBox1.Controls.Add(this.rdbChapters);
		this.GroupBox1.Controls.Add(this.rdbTools);
		this.GroupBox1.Controls.Add(this.rdbPractices);
		this.GroupBox1.Controls.Add(this.rdbHelps);
		this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox1.ForeColor = System.Drawing.Color.DarkOliveGreen;
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(8, 40);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		size = new System.Drawing.Size(200, 144);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 34;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Help Contents:";
		this.rdbInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rdbInstall.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.RadioButton radioButton = this.rdbInstall;
		location = new System.Drawing.Point(8, 16);
		radioButton.Location = location;
		this.rdbInstall.Name = "rdbInstall";
		System.Windows.Forms.RadioButton radioButton2 = this.rdbInstall;
		size = new System.Drawing.Size(184, 24);
		radioButton2.Size = size;
		this.rdbInstall.TabIndex = 0;
		this.rdbInstall.Text = "How to install ReanKhmer";
		this.rdbChapters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rdbChapters.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.RadioButton radioButton3 = this.rdbChapters;
		location = new System.Drawing.Point(8, 40);
		radioButton3.Location = location;
		this.rdbChapters.Name = "rdbChapters";
		System.Windows.Forms.RadioButton radioButton4 = this.rdbChapters;
		size = new System.Drawing.Size(184, 24);
		radioButton4.Size = size;
		this.rdbChapters.TabIndex = 0;
		this.rdbChapters.Text = "Chapters";
		this.rdbTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rdbTools.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.RadioButton radioButton5 = this.rdbTools;
		location = new System.Drawing.Point(8, 64);
		radioButton5.Location = location;
		this.rdbTools.Name = "rdbTools";
		System.Windows.Forms.RadioButton radioButton6 = this.rdbTools;
		size = new System.Drawing.Size(184, 24);
		radioButton6.Size = size;
		this.rdbTools.TabIndex = 0;
		this.rdbTools.Text = "Tools";
		this.rdbPractices.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rdbPractices.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.RadioButton radioButton7 = this.rdbPractices;
		location = new System.Drawing.Point(8, 88);
		radioButton7.Location = location;
		this.rdbPractices.Name = "rdbPractices";
		System.Windows.Forms.RadioButton radioButton8 = this.rdbPractices;
		size = new System.Drawing.Size(184, 24);
		radioButton8.Size = size;
		this.rdbPractices.TabIndex = 0;
		this.rdbPractices.Text = "Practices";
		this.rdbHelps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rdbHelps.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.RadioButton radioButton9 = this.rdbHelps;
		location = new System.Drawing.Point(8, 112);
		radioButton9.Location = location;
		this.rdbHelps.Name = "rdbHelps";
		System.Windows.Forms.RadioButton radioButton10 = this.rdbHelps;
		size = new System.Drawing.Size(184, 24);
		radioButton10.Size = size;
		this.rdbHelps.TabIndex = 0;
		this.rdbHelps.Text = "Helps";
		this.GroupBox2.Controls.Add(this.cboSubContents);
		this.GroupBox2.Controls.Add(this.txtIntro);
		this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox2.ForeColor = System.Drawing.Color.Crimson;
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox2;
		location = new System.Drawing.Point(8, 192);
		groupBox3.Location = location;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox2;
		size = new System.Drawing.Size(200, 152);
		groupBox4.Size = size;
		this.GroupBox2.TabIndex = 36;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Sub Contents";
		this.cboSubContents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.ComboBox comboBox = this.cboSubContents;
		location = new System.Drawing.Point(8, 120);
		comboBox.Location = location;
		this.cboSubContents.Name = "cboSubContents";
		System.Windows.Forms.ComboBox comboBox2 = this.cboSubContents;
		size = new System.Drawing.Size(184, 21);
		comboBox2.Size = size;
		this.cboSubContents.TabIndex = 1;
		this.txtIntro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtIntro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox = this.txtIntro;
		location = new System.Drawing.Point(8, 16);
		textBox.Location = location;
		this.txtIntro.Multiline = true;
		this.txtIntro.Name = "txtIntro";
		this.txtIntro.ReadOnly = true;
		System.Windows.Forms.TextBox textBox2 = this.txtIntro;
		size = new System.Drawing.Size(184, 96);
		textBox2.Size = size;
		this.txtIntro.TabIndex = 0;
		this.txtIntro.Text = "";
		this.cmdClose.BackColor = System.Drawing.Color.SlateGray;
		this.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdClose.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button = this.cmdClose;
		location = new System.Drawing.Point(8, 352);
		button.Location = location;
		this.cmdClose.Name = "cmdClose";
		System.Windows.Forms.Button button2 = this.cmdClose;
		size = new System.Drawing.Size(88, 24);
		button2.Size = size;
		this.cmdClose.TabIndex = 37;
		this.cmdClose.Text = "&Close";
		this.rtbHelp.AutoWordSelection = true;
		this.rtbHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.rtbHelp.HideSelection = false;
		System.Windows.Forms.RichTextBox richTextBox = this.rtbHelp;
		location = new System.Drawing.Point(216, 72);
		richTextBox.Location = location;
		this.rtbHelp.Name = "rtbHelp";
		this.rtbHelp.ReadOnly = true;
		this.rtbHelp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
		System.Windows.Forms.RichTextBox richTextBox2 = this.rtbHelp;
		size = new System.Drawing.Size(504, 312);
		richTextBox2.Size = size;
		this.rtbHelp.TabIndex = 38;
		this.rtbHelp.Text = "";
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Label label3 = this.Label1;
		location = new System.Drawing.Point(216, 48);
		label3.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label4 = this.Label1;
		size = new System.Drawing.Size(72, 24);
		label4.Size = size;
		this.Label1.TabIndex = 39;
		this.Label1.Text = "Search:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtSearch.Font = new System.Drawing.Font("Verdana", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox3 = this.txtSearch;
		location = new System.Drawing.Point(288, 48);
		textBox3.Location = location;
		this.txtSearch.Name = "txtSearch";
		System.Windows.Forms.TextBox textBox4 = this.txtSearch;
		size = new System.Drawing.Size(288, 23);
		textBox4.Size = size;
		this.txtSearch.TabIndex = 40;
		this.txtSearch.Text = "";
		this.cmdSearch.BackColor = System.Drawing.Color.SlateGray;
		this.cmdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button3 = this.cmdSearch;
		location = new System.Drawing.Point(582, 48);
		button3.Location = location;
		this.cmdSearch.Name = "cmdSearch";
		System.Windows.Forms.Button button4 = this.cmdSearch;
		size = new System.Drawing.Size(72, 23);
		button4.Size = size;
		this.cmdSearch.TabIndex = 41;
		this.cmdSearch.Text = "&Search";
		this.cmdNext.BackColor = System.Drawing.Color.SlateGray;
		this.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdNext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button5 = this.cmdNext;
		location = new System.Drawing.Point(656, 48);
		button5.Location = location;
		this.cmdNext.Name = "cmdNext";
		System.Windows.Forms.Button button6 = this.cmdNext;
		size = new System.Drawing.Size(64, 23);
		button6.Size = size;
		this.cmdNext.TabIndex = 41;
		this.cmdNext.Text = "&Next";
		this.cmdPrint.BackColor = System.Drawing.Color.SlateGray;
		this.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdPrint.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdPrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button7 = this.cmdPrint;
		location = new System.Drawing.Point(104, 352);
		button7.Location = location;
		this.cmdPrint.Name = "cmdPrint";
		System.Windows.Forms.Button button8 = this.cmdPrint;
		size = new System.Drawing.Size(80, 23);
		button8.Size = size;
		this.cmdPrint.TabIndex = 42;
		this.cmdPrint.Text = "&Print";
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(726, 408);
		this.ClientSize = size;
		this.Controls.Add(this.cmdPrint);
		this.Controls.Add(this.cmdSearch);
		this.Controls.Add(this.txtSearch);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.rtbHelp);
		this.Controls.Add(this.cmdClose);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.lblHelp);
		this.Controls.Add(this.cmdNext);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.Name = "frmHelp";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "ReanKhmer :: Help";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.ResumeLayout(false);
	}

	private void cmdClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void frmHelp_Load(object sender, EventArgs e)
	{
		rtbHelp.Text = "Please Click one Help Contents";
		getW = rtbHelp.Width;
		getH = rtbHelp.Height;
		if (rdbInstall.Checked)
		{
			rdbInstall_CheckedChanged(RuntimeHelpers.GetObjectValue(sender), e);
		}
		if (rdbChapters.Checked)
		{
			rdbChapters_CheckedChanged(RuntimeHelpers.GetObjectValue(sender), e);
		}
		if (rdbTools.Checked)
		{
			rdbTools_CheckedChanged(RuntimeHelpers.GetObjectValue(sender), e);
		}
		if (rdbPractices.Checked)
		{
			rdbPractices_CheckedChanged(RuntimeHelpers.GetObjectValue(sender), e);
		}
		if (rdbHelps.Checked)
		{
			rdbHelps_CheckedChanged(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void frmHelp_Resize(object sender, EventArgs e)
	{
		lblHelp.Width = Width;
		checked
		{
			if (Width > getW)
			{
				gW = Width - getW - 245;
				rtbHelp.Width = getW + gW;
			}
			else if (getW > Width)
			{
				gW = getW - Width;
				rtbHelp.Width = Width - gW - 245;
			}
			if (Height > getH)
			{
				gH = Height - getH - 112;
				rtbHelp.Height = getH + gH;
			}
			else if (getH > Height)
			{
				gH = getH - Height;
				rtbHelp.Height = Height - gH - 100;
			}
		}
	}

	private void rdbInstall_CheckedChanged(object sender, EventArgs e)
	{
		rtbHelp.LoadFile(Application.StartupPath + "\\help\\install.rtf");
		txtIntro.Text = "You will know about how to install ReanKhmer Window Application. You must follow the instruction so you can use ReanKhmer well.";
		cboSubContents.Items.Clear();
		ComboBox.ObjectCollection items = cboSubContents.Items;
		items.Add("How to install");
		items.Add("Before install");
		items = null;
	}

	private void cboSubContents_SelectedIndexChanged(object sender, EventArgs e)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		int num = rtbHelp.Find(cboSubContents.Text, RichTextBoxFinds.None);
		if (num == -1)
		{
			Interaction.MsgBox((object)"Not found!", (MsgBoxStyle)64, (object)"Not found");
			return;
		}
		rtbHelp.Select(num, cboSubContents.Text.Length);
		rtbHelp.ScrollToCaret();
	}

	private void cmdSearch_Click(object sender, EventArgs e)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		int num = rtbHelp.Find(txtSearch.Text, RichTextBoxFinds.None);
		if (num == -1)
		{
			Interaction.MsgBox((object)"Search Not found!", (MsgBoxStyle)64, (object)"Not found");
			return;
		}
		rtbHelp.Select(num, txtSearch.Text.Length);
		rtbHelp.ScrollToCaret();
	}

	private void cmdNext_Click(object sender, EventArgs e)
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		string text = default(string);
		if (StringType.StrCmp(txtSearch.Text, "", false) != 0)
		{
			text = txtSearch.Text;
		}
		else if (StringType.StrCmp(cboSubContents.Text, "", false) != 0)
		{
			text = cboSubContents.Text;
		}
		checked
		{
			int num = Strings.InStr(rtbHelp.SelectionStart + 2, rtbHelp.Text, text, (CompareMethod)0);
			if (num == 0)
			{
				Interaction.MsgBox((object)"No more match!", (MsgBoxStyle)64, (object)"Not found");
				return;
			}
			rtbHelp.Select(num - 1, text.Length);
			rtbHelp.ScrollToCaret();
		}
	}

	private void rdbChapters_CheckedChanged(object sender, EventArgs e)
	{
		rtbHelp.LoadFile(Application.StartupPath + "\\help\\chapters.rtf");
		txtIntro.Text = "This is about the lessons in ReanKhmer Application.";
		cboSubContents.Items.Clear();
		ComboBox.ObjectCollection items = cboSubContents.Items;
		items.Add("Chapter 1");
		items.Add("Chapter 2");
		items.Add("Chapter 3");
		items.Add("Chapter 4");
		items.Add("Chapter 5");
		items = null;
	}

	private void rdbTools_CheckedChanged(object sender, EventArgs e)
	{
		rtbHelp.LoadFile(Application.StartupPath + "\\help\\tools.rtf");
		txtIntro.Text = "More on Tools on Menu bar in the ReanKhmer";
		cboSubContents.Items.Clear();
		ComboBox.ObjectCollection items = cboSubContents.Items;
		items.Add("Dictionary");
		items.Add("Conversation");
		items.Add("Writing board");
		items.Add("Khmer Language");
		items = null;
	}

	private void rdbPractices_CheckedChanged(object sender, EventArgs e)
	{
		rtbHelp.LoadFile(Application.StartupPath + "\\help\\practices.rtf");
		txtIntro.Text = "Practices, there are two part Game and Tests.";
		cboSubContents.Items.Clear();
		ComboBox.ObjectCollection items = cboSubContents.Items;
		items.Add("Game");
		items.Add("Tests");
		items = null;
	}

	private void rdbHelps_CheckedChanged(object sender, EventArgs e)
	{
		rtbHelp.LoadFile(Application.StartupPath + "\\help\\help.rtf");
		txtIntro.Text = "Just to tell you more what are having in the help contents.";
		cboSubContents.Items.Clear();
		ComboBox.ObjectCollection items = cboSubContents.Items;
		items.Add("About us");
		items.Add("Application Help");
		items.Add("Supports");
		items.Add("About ReanKhmer");
		items = null;
	}

	private void rtbHelp_LinkClicked(object sender, LinkClickedEventArgs e)
	{
		Process.Start(e.LinkText);
	}

	private void cmdPrint_Click(object sender, EventArgs e)
	{
		PrintDocument1.Print();
	}

	private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
	{
		Font font = new Font("Khmer OS System", 12f);
		string text = rtbHelp.Text;
		PageSettings defaultPageSettings = PrintDocument1.DefaultPageSettings;
		checked
		{
			int num = defaultPageSettings.PaperSize.Height - defaultPageSettings.Margins.Top - defaultPageSettings.Margins.Bottom;
			int num2 = defaultPageSettings.PaperSize.Width - defaultPageSettings.Margins.Left - defaultPageSettings.Margins.Right;
			int left = PrintDocument1.DefaultPageSettings.Margins.Left;
			int top = PrintDocument1.DefaultPageSettings.Margins.Top;
			defaultPageSettings = null;
			if (PrintDocument1.DefaultPageSettings.Landscape)
			{
				int num3 = num;
				num = num2;
				num2 = num3;
			}
			int num4 = (int)Math.Round((double)num / (double)font.Height);
			RectangleF layoutRectangle = new RectangleF(left, top, num2, num);
			StringFormat stringFormat = new StringFormat(StringFormatFlags.LineLimit);
			Graphics graphics = e.Graphics;
			string obj = Strings.Mid(text, _0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar + 1);
			SizeF layoutArea = new SizeF(num2, num);
			graphics.MeasureString(obj, font, layoutArea, stringFormat, out var charactersFitted, out var _);
			e.Graphics.DrawString(Strings.Mid(text, _0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar + 1), font, Brushes.Black, layoutRectangle, stringFormat);
			_0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar += charactersFitted;
			if (_0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar < text.Length)
			{
				e.HasMorePages = true;
				return;
			}
			e.HasMorePages = false;
			_0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar = 0;
		}
	}
}
