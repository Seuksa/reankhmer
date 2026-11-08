using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace reankhmer;

public class frmKeyboard : Form
{
	[AccessedThroughProperty("picBoard")]
	private PictureBox _picBoard;

	private IContainer components;

	internal virtual PictureBox picBoard
	{
		get
		{
			return _picBoard;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_picBoard != null)
			{
			}
			_picBoard = value;
			if (_picBoard == null)
			{
			}
		}
	}

	public frmKeyboard()
	{
		base.Load += frmKeyboard_Load;
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
		this.picBoard = new System.Windows.Forms.PictureBox();
		this.SuspendLayout();
		this.picBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox = this.picBoard;
		System.Drawing.Point location = new System.Drawing.Point(5, 8);
		pictureBox.Location = location;
		this.picBoard.Name = "picBoard";
		System.Windows.Forms.PictureBox pictureBox2 = this.picBoard;
		System.Drawing.Size size = new System.Drawing.Size(600, 384);
		pictureBox2.Size = size;
		this.picBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.picBoard.TabIndex = 0;
		this.picBoard.TabStop = false;
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(612, 410);
		this.ClientSize = size;
		this.Controls.Add(this.picBoard);
		this.Name = "frmKeyboard";
		this.Text = "Khmer Unicode Keyboard";
		this.ResumeLayout(false);
	}

	private void frmKeyboard_Load(object sender, EventArgs e)
	{
		picBoard.Image = Image.FromFile(Application.StartupPath + "\\support\\installHelp\\khmerKeyboard.jpg");
	}
}
