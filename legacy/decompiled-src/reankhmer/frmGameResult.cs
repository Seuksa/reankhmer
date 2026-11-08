using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace reankhmer;

public class frmGameResult : Form
{
	[AccessedThroughProperty("cmdOk")]
	private Button _cmdOk;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("txtResult")]
	private TextBox _txtResult;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	private IContainer components;

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

	public frmGameResult()
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
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.cmdOk = new System.Windows.Forms.Button();
		this.txtResult = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.GroupBox1.SuspendLayout();
		this.SuspendLayout();
		this.GroupBox1.Controls.Add(this.cmdOk);
		this.GroupBox1.Controls.Add(this.txtResult);
		this.GroupBox1.Controls.Add(this.Label1);
		this.GroupBox1.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		System.Drawing.Point location = new System.Drawing.Point(8, 8);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		System.Drawing.Size size = new System.Drawing.Size(400, 200);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.cmdOk.BackColor = System.Drawing.Color.SlateGray;
		this.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdOk.ForeColor = System.Drawing.Color.AliceBlue;
		System.Windows.Forms.Button button = this.cmdOk;
		location = new System.Drawing.Point(304, 166);
		button.Location = location;
		this.cmdOk.Name = "cmdOk";
		System.Windows.Forms.Button button2 = this.cmdOk;
		size = new System.Drawing.Size(80, 29);
		button2.Size = size;
		this.cmdOk.TabIndex = 2;
		this.cmdOk.Text = "&OK";
		this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtResult.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox = this.txtResult;
		location = new System.Drawing.Point(8, 40);
		textBox.Location = location;
		this.txtResult.Multiline = true;
		this.txtResult.Name = "txtResult";
		this.txtResult.ReadOnly = true;
		System.Windows.Forms.TextBox textBox2 = this.txtResult;
		size = new System.Drawing.Size(376, 120);
		textBox2.Size = size;
		this.txtResult.TabIndex = 1;
		this.txtResult.Text = "";
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(8, 11);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(208, 24);
		label2.Size = size;
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Result:";
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(416, 216);
		this.ClientSize = size;
		this.ControlBox = false;
		this.Controls.Add(this.GroupBox1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.Name = "frmGameResult";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.GroupBox1.ResumeLayout(false);
		this.ResumeLayout(false);
	}

	private void cmdOk_Click(object sender, EventArgs e)
	{
		Close();
	}
}
