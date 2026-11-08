using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class frmFreeDrawing : Form
{
	[AccessedThroughProperty("Label4")]
	private Label _Label4;

	[AccessedThroughProperty("cmdClear")]
	private Button _cmdClear;

	[AccessedThroughProperty("lblDraw")]
	private Label _lblDraw;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("cmdColor")]
	private Button _cmdColor;

	[AccessedThroughProperty("cboSize")]
	private ComboBox _cboSize;

	[AccessedThroughProperty("cdlColor")]
	private ColorDialog _cdlColor;

	private Brush br;

	private Pen p;

	private int x;

	private int y;

	private int ex;

	private int ey;

	private bool isDown;

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

	internal virtual Button cmdColor
	{
		get
		{
			return _cmdColor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdColor != null)
			{
				_cmdColor.Click -= cmdColor_Click;
			}
			_cmdColor = value;
			if (_cmdColor != null)
			{
				_cmdColor.Click += cmdColor_Click;
			}
		}
	}

	internal virtual ComboBox cboSize
	{
		get
		{
			return _cboSize;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cboSize != null)
			{
				_cboSize.SelectedIndexChanged -= cboSize_SelectedIndexChanged;
			}
			_cboSize = value;
			if (_cboSize != null)
			{
				_cboSize.SelectedIndexChanged += cboSize_SelectedIndexChanged;
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

	internal virtual Label lblDraw
	{
		get
		{
			return _lblDraw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblDraw != null)
			{
				_lblDraw.MouseUp -= lblDraw_MouseUp;
				_lblDraw.MouseMove -= lblDraw_MouseMove;
				_lblDraw.MouseDown -= lblDraw_MouseDown;
				_lblDraw.Click -= lblDraw_Click;
			}
			_lblDraw = value;
			if (_lblDraw != null)
			{
				_lblDraw.MouseUp += lblDraw_MouseUp;
				_lblDraw.MouseMove += lblDraw_MouseMove;
				_lblDraw.MouseDown += lblDraw_MouseDown;
				_lblDraw.Click += lblDraw_Click;
			}
		}
	}

	internal virtual Button cmdClear
	{
		get
		{
			return _cmdClear;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdClear != null)
			{
				_cmdClear.Click -= cmdClear_Click;
			}
			_cmdClear = value;
			if (_cmdClear != null)
			{
				_cmdClear.Click += cmdClear_Click;
			}
		}
	}

	internal virtual ColorDialog cdlColor
	{
		get
		{
			return _cdlColor;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cdlColor != null)
			{
			}
			_cdlColor = value;
			if (_cdlColor == null)
			{
			}
		}
	}

	public frmFreeDrawing()
	{
		base.Load += frmFreeDrawing_Load;
		br = new SolidBrush(Color.Black);
		p = new Pen(br, 3f);
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
		this.cmdColor = new System.Windows.Forms.Button();
		this.cboSize = new System.Windows.Forms.ComboBox();
		this.Label4 = new System.Windows.Forms.Label();
		this.lblDraw = new System.Windows.Forms.Label();
		this.cmdClear = new System.Windows.Forms.Button();
		this.cdlColor = new System.Windows.Forms.ColorDialog();
		this.GroupBox1.SuspendLayout();
		this.SuspendLayout();
		this.GroupBox1.Controls.Add(this.cmdColor);
		this.GroupBox1.Controls.Add(this.cboSize);
		this.GroupBox1.Controls.Add(this.Label4);
		this.GroupBox1.Controls.Add(this.lblDraw);
		this.GroupBox1.Controls.Add(this.cmdClear);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		System.Drawing.Point location = new System.Drawing.Point(8, 6);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		System.Drawing.Size size = new System.Drawing.Size(600, 416);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 1;
		this.GroupBox1.TabStop = false;
		this.cmdColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		System.Windows.Forms.Button button = this.cmdColor;
		location = new System.Drawing.Point(408, 388);
		button.Location = location;
		this.cmdColor.Name = "cmdColor";
		this.cmdColor.TabIndex = 30;
		this.cmdColor.Text = "&Color";
		this.cboSize.BackColor = System.Drawing.SystemColors.Window;
		this.cboSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboSize.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.ComboBox comboBox = this.cboSize;
		location = new System.Drawing.Point(336, 388);
		comboBox.Location = location;
		this.cboSize.Name = "cboSize";
		System.Windows.Forms.ComboBox comboBox2 = this.cboSize;
		size = new System.Drawing.Size(56, 22);
		comboBox2.Size = size;
		this.cboSize.TabIndex = 28;
		this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.Label label = this.Label4;
		location = new System.Drawing.Point(264, 388);
		label.Location = location;
		this.Label4.Name = "Label4";
		System.Windows.Forms.Label label2 = this.Label4;
		size = new System.Drawing.Size(63, 23);
		label2.Size = size;
		this.Label4.TabIndex = 27;
		this.Label4.Text = "Pen size:";
		this.lblDraw.BackColor = System.Drawing.Color.SteelBlue;
		this.lblDraw.Cursor = System.Windows.Forms.Cursors.Hand;
		System.Windows.Forms.Label label3 = this.lblDraw;
		location = new System.Drawing.Point(8, 16);
		label3.Location = location;
		this.lblDraw.Name = "lblDraw";
		System.Windows.Forms.Label label4 = this.lblDraw;
		size = new System.Drawing.Size(584, 368);
		label4.Size = size;
		this.lblDraw.TabIndex = 26;
		this.cmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		System.Windows.Forms.Button button2 = this.cmdClear;
		location = new System.Drawing.Point(518, 388);
		button2.Location = location;
		this.cmdClear.Name = "cmdClear";
		this.cmdClear.TabIndex = 29;
		this.cmdClear.Text = "Cl&ear";
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(616, 428);
		this.ClientSize = size;
		this.Controls.Add(this.GroupBox1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.Name = "frmFreeDrawing";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Writing Board";
		this.GroupBox1.ResumeLayout(false);
		this.ResumeLayout(false);
	}

	private void cmdColor_Click(object sender, EventArgs e)
	{
		if (cdlColor.ShowDialog() == DialogResult.OK)
		{
			p.Color = cdlColor.Color;
		}
	}

	private void cmdClear_Click(object sender, EventArgs e)
	{
		lblDraw.CreateGraphics().Clear(lblDraw.BackColor);
	}

	private void frmFreeDrawing_Load(object sender, EventArgs e)
	{
		ComboBox comboBox = cboSize;
		comboBox.Items.Add(2);
		comboBox.Items.Add(4);
		comboBox.Items.Add(6);
		comboBox.Items.Add(8);
		comboBox.Items.Add(10);
		comboBox = null;
	}

	private void lblDraw_Click(object sender, EventArgs e)
	{
	}

	private void lblDraw_MouseDown(object sender, MouseEventArgs e)
	{
		x = e.X;
		y = e.Y;
		isDown = true;
	}

	private void lblDraw_MouseMove(object sender, MouseEventArgs e)
	{
		if (isDown)
		{
			lblDraw.CreateGraphics().DrawLine(p, x, y, e.X, e.Y);
			x = e.X;
			y = e.Y;
		}
	}

	private void lblDraw_MouseUp(object sender, MouseEventArgs e)
	{
		isDown = false;
	}

	private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
	{
		p.Width = SingleType.FromString(cboSize.Text);
	}
}
