using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class frmDragDrop : Form
{
	[AccessedThroughProperty("PictureBox1")]
	private PictureBox _PictureBox1;

	[AccessedThroughProperty("PictureBox2")]
	private PictureBox _PictureBox2;

	private IContainer components;

	private const int CTL = 8;

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
				_PictureBox1.DragLeave -= PictureBox1_DragLeave;
				_PictureBox1.DragDrop -= PictureBox1_DragDrop;
				_PictureBox1.DragEnter -= PictureBox1_DragEnter;
				_PictureBox1.MouseDown -= PictureBox1_MouseDown;
			}
			_PictureBox1 = value;
			if (_PictureBox1 != null)
			{
				_PictureBox1.DragLeave += PictureBox1_DragLeave;
				_PictureBox1.DragDrop += PictureBox1_DragDrop;
				_PictureBox1.DragEnter += PictureBox1_DragEnter;
				_PictureBox1.MouseDown += PictureBox1_MouseDown;
			}
		}
	}

	internal virtual PictureBox PictureBox2
	{
		get
		{
			return _PictureBox2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_PictureBox2 != null)
			{
				_PictureBox2.MouseDown -= PictureBox2_MouseDown;
				_PictureBox2.DragLeave -= PictureBox2_DragLeave;
				_PictureBox2.DragEnter -= PictureBox2_DragEnter;
				_PictureBox2.DragDrop -= PictureBox2_DragDrop;
			}
			_PictureBox2 = value;
			if (_PictureBox2 != null)
			{
				_PictureBox2.MouseDown += PictureBox2_MouseDown;
				_PictureBox2.DragLeave += PictureBox2_DragLeave;
				_PictureBox2.DragEnter += PictureBox2_DragEnter;
				_PictureBox2.DragDrop += PictureBox2_DragDrop;
			}
		}
	}

	public frmDragDrop()
	{
		base.Load += frmDragDrop_Load;
		base.MouseDown += frmDragDrop_MouseDown;
		base.DragDrop += frmDragDrop_DragDrop;
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
		System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(reankhmer.frmDragDrop));
		this.PictureBox1 = new System.Windows.Forms.PictureBox();
		this.PictureBox2 = new System.Windows.Forms.PictureBox();
		this.SuspendLayout();
		this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.PictureBox1.Image = (System.Drawing.Image)resourceManager.GetObject("PictureBox1.Image");
		System.Windows.Forms.PictureBox pictureBox = this.PictureBox1;
		System.Drawing.Point location = new System.Drawing.Point(16, 24);
		pictureBox.Location = location;
		this.PictureBox1.Name = "PictureBox1";
		System.Windows.Forms.PictureBox pictureBox2 = this.PictureBox1;
		System.Drawing.Size size = new System.Drawing.Size(144, 128);
		pictureBox2.Size = size;
		this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.PictureBox1.TabIndex = 0;
		this.PictureBox1.TabStop = false;
		this.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox3 = this.PictureBox2;
		location = new System.Drawing.Point(320, 24);
		pictureBox3.Location = location;
		this.PictureBox2.Name = "PictureBox2";
		System.Windows.Forms.PictureBox pictureBox4 = this.PictureBox2;
		size = new System.Drawing.Size(136, 128);
		pictureBox4.Size = size;
		this.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.PictureBox2.TabIndex = 1;
		this.PictureBox2.TabStop = false;
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(480, 270);
		this.ClientSize = size;
		this.Controls.Add(this.PictureBox2);
		this.Controls.Add(this.PictureBox1);
		this.Name = "frmDragDrop";
		this.Text = "frmDragDrop";
		this.ResumeLayout(false);
	}

	private void frmDragDrop_Load(object sender, EventArgs e)
	{
		PictureBox1.AllowDrop = true;
		PictureBox2.AllowDrop = true;
		PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\images\\3.jpg");
	}

	private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			PictureBox1.DoDragDrop(PictureBox1.Image, DragDropEffects.Copy);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			MessageBox.Show("It looks like no the picture... Try again :-)", "Hmmmnnnn...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			PictureBox1.Image = Image.FromFile(Application.StartupPath + "\\images\\3.jpg");
			ProjectData.ClearProjectError();
		}
	}

	private void PictureBox1_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.Bitmap))
		{
			e.Effect = DragDropEffects.Copy;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	private void PictureBox2_DragDrop(object sender, DragEventArgs e)
	{
		PictureBox2.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
	}

	private void frmDragDrop_MouseDown(object sender, MouseEventArgs e)
	{
		PictureBox1.DoDragDrop(PictureBox1.Image, DragDropEffects.Copy | DragDropEffects.Move);
	}

	private void frmDragDrop_DragDrop(object sender, DragEventArgs e)
	{
		BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
	}

	private void PictureBox1_DragDrop(object sender, DragEventArgs e)
	{
		PictureBox1.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
	}

	private void PictureBox1_DragLeave(object sender, EventArgs e)
	{
		PictureBox1.Image = null;
	}

	private void PictureBox2_DragEnter(object sender, DragEventArgs e)
	{
		if (e.Data.GetDataPresent(DataFormats.Bitmap))
		{
			e.Effect = DragDropEffects.Copy;
		}
		else
		{
			e.Effect = DragDropEffects.None;
		}
	}

	private void PictureBox2_DragLeave(object sender, EventArgs e)
	{
		PictureBox2.Image = null;
	}

	private void PictureBox2_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			PictureBox2.DoDragDrop(PictureBox2.Image, DragDropEffects.Copy);
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			MessageBox.Show("It looks like the dog ate my picture... Try again :-)", "Hmmmnnnn...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			PictureBox2.Image = Image.FromFile("me.jpg");
			ProjectData.ClearProjectError();
		}
	}
}
