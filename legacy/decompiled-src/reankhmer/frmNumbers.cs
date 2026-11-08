using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxShockwaveFlashObjects;

namespace reankhmer;

public class frmNumbers : Form
{
	[AccessedThroughProperty("aFlash")]
	private AxShockwaveFlash _aFlash;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

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

	internal virtual AxShockwaveFlash aFlash
	{
		get
		{
			return _aFlash;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_aFlash != null)
			{
			}
			_aFlash = value;
			if (_aFlash == null)
			{
			}
		}
	}

	public frmNumbers()
	{
		base.Load += frmNumbers_Load;
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
		System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(reankhmer.frmNumbers));
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.aFlash = new AxShockwaveFlashObjects.AxShockwaveFlash();
		this.GroupBox1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.aFlash).BeginInit();
		this.SuspendLayout();
		this.GroupBox1.Controls.Add(this.aFlash);
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		System.Drawing.Point location = new System.Drawing.Point(8, 6);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		System.Drawing.Size size = new System.Drawing.Size(600, 416);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 2;
		this.GroupBox1.TabStop = false;
		this.aFlash.ContainingControl = this;
		this.aFlash.Enabled = true;
		AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash = this.aFlash;
		location = new System.Drawing.Point(8, 11);
		axShockwaveFlash.Location = location;
		this.aFlash.Name = "aFlash";
		this.aFlash.OcxState = (System.Windows.Forms.AxHost.State)resourceManager.GetObject("aFlash.OcxState");
		AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash2 = this.aFlash;
		size = new System.Drawing.Size(584, 397);
		axShockwaveFlash2.Size = size;
		this.aFlash.TabIndex = 5;
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(616, 428);
		this.ClientSize = size;
		this.Controls.Add(this.GroupBox1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.Name = "frmNumbers";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Khmer Number";
		this.GroupBox1.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.aFlash).EndInit();
		this.ResumeLayout(false);
	}

	private void frmNumbers_Load(object sender, EventArgs e)
	{
		aFlash.Movie = Application.StartupPath + "\\flash\\ReadNum.swf";
	}
}
