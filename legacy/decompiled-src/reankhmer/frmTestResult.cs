using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace reankhmer;

public class frmTestResult : Form
{
	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("txtResult")]
	private TextBox _txtResult;

	[AccessedThroughProperty("PictureBox1")]
	private PictureBox _PictureBox1;

	[AccessedThroughProperty("lblScore")]
	private Label _lblScore;

	[AccessedThroughProperty("lblAns")]
	private Label _lblAns;

	[AccessedThroughProperty("cmdOk")]
	private Button _cmdOk;

	[AccessedThroughProperty("Label3")]
	private Label _Label3;

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

	internal virtual Label lblScore
	{
		get
		{
			return _lblScore;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblScore != null)
			{
			}
			_lblScore = value;
			if (_lblScore == null)
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

	internal virtual Button cmdOk
	{
		get
		{
			return _cmdOk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdOk != null)
			{
				_cmdOk.Click -= cmdOk_Click;
			}
			_cmdOk = value;
			if (_cmdOk != null)
			{
				_cmdOk.Click += cmdOk_Click;
			}
		}
	}

	internal virtual TextBox txtResult
	{
		get
		{
			return _txtResult;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtResult != null)
			{
			}
			_txtResult = value;
			if (_txtResult == null)
			{
			}
		}
	}

	internal virtual Label lblAns
	{
		get
		{
			return _lblAns;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblAns != null)
			{
			}
			_lblAns = value;
			if (_lblAns == null)
			{
			}
		}
	}

	public frmTestResult()
	{
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
		System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(reankhmer.frmTestResult));
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.lblScore = new System.Windows.Forms.Label();
		this.txtResult = new System.Windows.Forms.TextBox();
		this.Label3 = new System.Windows.Forms.Label();
		this.cmdOk = new System.Windows.Forms.Button();
		this.lblAns = new System.Windows.Forms.Label();
		this.SuspendLayout();
		this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.PictureBox1.Image = (System.Drawing.Image)resourceManager.GetObject("PictureBox1.Image");
		System.Windows.Forms.PictureBox pictureBox = this.PictureBox1;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		pictureBox.Location = location;
		this.PictureBox1.Name = "PictureBox1";
		System.Windows.Forms.PictureBox pictureBox2 = this.PictureBox1;
		System.Drawing.Size size = new System.Drawing.Size(104, 264);
		pictureBox2.Size = size;
		this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.PictureBox1.TabIndex = 0;
		this.PictureBox1.TabStop = false;
		this.Label1.Font = new System.Drawing.Font("Arial", 20.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.Color.Red;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(104, 0);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(344, 48);
		label2.Size = size;
		this.Label1.TabIndex = 1;
		this.Label1.Text = "Test Result:";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Label label3 = this.Label2;
		location = new System.Drawing.Point(120, 56);
		label3.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label4 = this.Label2;
		size = new System.Drawing.Size(80, 23);
		label4.Size = size;
		this.Label2.TabIndex = 2;
		this.Label2.Text = "Your score: ";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblScore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Label label5 = this.lblScore;
		location = new System.Drawing.Point(200, 56);
		label5.Location = location;
		this.lblScore.Name = "lblScore";
		System.Windows.Forms.Label label6 = this.lblScore;
		size = new System.Drawing.Size(64, 23);
		label6.Size = size;
		this.lblScore.TabIndex = 3;
		this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtResult.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox = this.txtResult;
		location = new System.Drawing.Point(112, 106);
		textBox.Location = location;
		this.txtResult.Multiline = true;
		this.txtResult.Name = "txtResult";
		this.txtResult.ReadOnly = true;
		this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox2 = this.txtResult;
		size = new System.Drawing.Size(320, 126);
		textBox2.Size = size;
		this.txtResult.TabIndex = 4;
		this.txtResult.Text = "";
		this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label3.ForeColor = System.Drawing.Color.ForestGreen;
		System.Windows.Forms.Label label7 = this.Label3;
		location = new System.Drawing.Point(109, 82);
		label7.Location = location;
		this.Label3.Name = "Label3";
		this.Label3.TabIndex = 5;
		this.Label3.Text = "Result:";
		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.cmdOk.BackColor = System.Drawing.Color.SlateGray;
		this.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdOk.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Button button = this.cmdOk;
		location = new System.Drawing.Point(368, 240);
		button.Location = location;
		this.cmdOk.Name = "cmdOk";
		System.Windows.Forms.Button button2 = this.cmdOk;
		size = new System.Drawing.Size(64, 24);
		button2.Size = size;
		this.cmdOk.TabIndex = 6;
		this.cmdOk.Text = "&OK";
		this.lblAns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblAns.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.Label label8 = this.lblAns;
		location = new System.Drawing.Point(280, 56);
		label8.Location = location;
		this.lblAns.Name = "lblAns";
		System.Windows.Forms.Label label9 = this.lblAns;
		size = new System.Drawing.Size(152, 23);
		label9.Size = size;
		this.lblAns.TabIndex = 7;
		this.lblAns.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(438, 264);
		this.ClientSize = size;
		this.ControlBox = false;
		this.Controls.Add(this.lblAns);
		this.Controls.Add(this.cmdOk);
		this.Controls.Add(this.Label3);
		this.Controls.Add(this.txtResult);
		this.Controls.Add(this.lblScore);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.PictureBox1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.Name = "frmTestResult";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Chapter 4 - Test Result";
		this.ResumeLayout(false);
	}

	private void cmdOk_Click(object sender, EventArgs e)
	{
		Close();
	}
}
