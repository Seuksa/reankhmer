using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class Form3 : Form
{
	[AccessedThroughProperty("Button4")]
	private Button _Button4;

	[AccessedThroughProperty("Button1")]
	private Button _Button1;

	[AccessedThroughProperty("Button3")]
	private Button _Button3;

	[AccessedThroughProperty("Button2")]
	private Button _Button2;

	private IContainer components;

	internal virtual Button Button1
	{
		get
		{
			return _Button1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Button1 != null)
			{
				_Button1.Click -= Button1_Click;
			}
			_Button1 = value;
			if (_Button1 != null)
			{
				_Button1.Click += Button1_Click;
			}
		}
	}

	internal virtual Button Button2
	{
		get
		{
			return _Button2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Button2 != null)
			{
				_Button2.Click -= Button2_Click;
			}
			_Button2 = value;
			if (_Button2 != null)
			{
				_Button2.Click += Button2_Click;
			}
		}
	}

	internal virtual Button Button3
	{
		get
		{
			return _Button3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Button3 != null)
			{
				_Button3.Click -= Button3_Click;
			}
			_Button3 = value;
			if (_Button3 != null)
			{
				_Button3.Click += Button3_Click;
			}
		}
	}

	internal virtual Button Button4
	{
		get
		{
			return _Button4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Button4 != null)
			{
				_Button4.Click -= Button4_Click;
			}
			_Button4 = value;
			if (_Button4 != null)
			{
				_Button4.Click += Button4_Click;
			}
		}
	}

	public Form3()
	{
		base.Load += Form3_Load;
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
		this.Button1 = new System.Windows.Forms.Button();
		this.Button2 = new System.Windows.Forms.Button();
		this.Button3 = new System.Windows.Forms.Button();
		this.Button4 = new System.Windows.Forms.Button();
		this.SuspendLayout();
		System.Windows.Forms.Button button = this.Button1;
		System.Drawing.Point location = new System.Drawing.Point(72, 64);
		button.Location = location;
		this.Button1.Name = "Button1";
		this.Button1.TabIndex = 0;
		this.Button1.Text = "Button1";
		System.Windows.Forms.Button button2 = this.Button2;
		location = new System.Drawing.Point(208, 104);
		button2.Location = location;
		this.Button2.Name = "Button2";
		this.Button2.TabIndex = 1;
		this.Button2.Text = "Button2";
		System.Windows.Forms.Button button3 = this.Button3;
		location = new System.Drawing.Point(208, 152);
		button3.Location = location;
		this.Button3.Name = "Button3";
		this.Button3.TabIndex = 1;
		this.Button3.Text = "Stop";
		System.Windows.Forms.Button button4 = this.Button4;
		location = new System.Drawing.Point(160, 64);
		button4.Location = location;
		this.Button4.Name = "Button4";
		this.Button4.TabIndex = 1;
		this.Button4.Text = "Stop";
		System.Drawing.Size size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(292, 270);
		this.ClientSize = size;
		this.Controls.Add(this.Button2);
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.Button3);
		this.Controls.Add(this.Button4);
		this.Name = "Form3";
		this.Text = "Form3";
		this.ResumeLayout(false);
	}

	[DllImport("winmm.dll", CharSet = CharSet.Ansi, EntryPoint = "mciSendStringA", ExactSpelling = true, SetLastError = true)]
	private static extern long mciSendString([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpstrCommand, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpstrReturnString, long uReturnLength, long hwndCallback);

	private void Form3_Load(object sender, EventArgs e)
	{
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		string lpstrCommand = "PLAY c:\\04.mp3";
		string lpstrReturnString = StringType.FromInteger(0);
		long num = mciSendString(ref lpstrCommand, ref lpstrReturnString, 0L, 0L);
	}

	private void Button2_Click(object sender, EventArgs e)
	{
		string lpstrCommand = "PLAY c:\\dor.mp3";
		string lpstrReturnString = StringType.FromInteger(0);
		long num = mciSendString(ref lpstrCommand, ref lpstrReturnString, 0L, 0L);
	}

	private void Button3_Click(object sender, EventArgs e)
	{
		string lpstrCommand = "STOP c:\\dor.mp3";
		string lpstrReturnString = StringType.FromInteger(0);
		long num = mciSendString(ref lpstrCommand, ref lpstrReturnString, 0L, 0L);
	}

	private void Button4_Click(object sender, EventArgs e)
	{
		string lpstrCommand = "STOP c:\\04.mp3";
		string lpstrReturnString = StringType.FromInteger(0);
		long num = mciSendString(ref lpstrCommand, ref lpstrReturnString, 0L, 0L);
	}
}
