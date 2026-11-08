using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class frmUserGame : Form
{
	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("cmdPlay")]
	private Button _cmdPlay;

	[AccessedThroughProperty("rdoMs")]
	private RadioButton _rdoMs;

	[AccessedThroughProperty("cmdCancel")]
	private Button _cmdCancel;

	[AccessedThroughProperty("rdoMr")]
	private RadioButton _rdoMr;

	[AccessedThroughProperty("rdoPhrase")]
	private RadioButton _rdoPhrase;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("rdoWords")]
	private RadioButton _rdoWords;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("rdoMrs")]
	private RadioButton _rdoMrs;

	[AccessedThroughProperty("txtUserName")]
	private TextBox _txtUserName;

	private IContainer components;

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

	internal virtual TextBox txtUserName
	{
		get
		{
			return _txtUserName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtUserName != null)
			{
			}
			_txtUserName = value;
			if (_txtUserName == null)
			{
			}
		}
	}

	internal virtual RadioButton rdoMr
	{
		get
		{
			return _rdoMr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdoMr != null)
			{
			}
			_rdoMr = value;
			if (_rdoMr == null)
			{
			}
		}
	}

	internal virtual RadioButton rdoMs
	{
		get
		{
			return _rdoMs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdoMs != null)
			{
			}
			_rdoMs = value;
			if (_rdoMs == null)
			{
			}
		}
	}

	internal virtual RadioButton rdoMrs
	{
		get
		{
			return _rdoMrs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdoMrs != null)
			{
			}
			_rdoMrs = value;
			if (_rdoMrs == null)
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

	internal virtual Button cmdPlay
	{
		get
		{
			return _cmdPlay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdPlay != null)
			{
				_cmdPlay.Click -= cmdPlay_Click;
			}
			_cmdPlay = value;
			if (_cmdPlay != null)
			{
				_cmdPlay.Click += cmdPlay_Click;
			}
		}
	}

	internal virtual Button cmdCancel
	{
		get
		{
			return _cmdCancel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdCancel != null)
			{
				_cmdCancel.Click -= cmdCancel_Click;
			}
			_cmdCancel = value;
			if (_cmdCancel != null)
			{
				_cmdCancel.Click += cmdCancel_Click;
			}
		}
	}

	internal virtual RadioButton rdoPhrase
	{
		get
		{
			return _rdoPhrase;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdoPhrase != null)
			{
			}
			_rdoPhrase = value;
			if (_rdoPhrase == null)
			{
			}
		}
	}

	internal virtual RadioButton rdoWords
	{
		get
		{
			return _rdoWords;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_rdoWords != null)
			{
			}
			_rdoWords = value;
			if (_rdoWords == null)
			{
			}
		}
	}

	public frmUserGame()
	{
		base.Load += frmUserGame_Load;
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
		System.Configuration.AppSettingsReader appSettingsReader = new System.Configuration.AppSettingsReader();
		this.Label1 = new System.Windows.Forms.Label();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.cmdCancel = new System.Windows.Forms.Button();
		this.cmdPlay = new System.Windows.Forms.Button();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.rdoPhrase = new System.Windows.Forms.RadioButton();
		this.rdoWords = new System.Windows.Forms.RadioButton();
		this.rdoMrs = new System.Windows.Forms.RadioButton();
		this.rdoMs = new System.Windows.Forms.RadioButton();
		this.rdoMr = new System.Windows.Forms.RadioButton();
		this.txtUserName = new System.Windows.Forms.TextBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.SuspendLayout();
		this.Label1.BackColor = System.Drawing.SystemColors.Desktop;
		this.Label1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.SystemColors.HighlightText;
		System.Windows.Forms.Label label = this.Label1;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		System.Drawing.Size size = new System.Drawing.Size(400, 32);
		label2.Size = size;
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Game :: User Information";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.GroupBox1.Controls.Add(this.cmdCancel);
		this.GroupBox1.Controls.Add(this.cmdPlay);
		this.GroupBox1.Controls.Add(this.GroupBox2);
		this.GroupBox1.Controls.Add(this.rdoMrs);
		this.GroupBox1.Controls.Add(this.rdoMs);
		this.GroupBox1.Controls.Add(this.rdoMr);
		this.GroupBox1.Controls.Add(this.txtUserName);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox1.ForeColor = System.Drawing.Color.Green;
		this.GroupBox1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(8, 40);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		size = new System.Drawing.Size(376, 168);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 1;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Provide us information before playing game:";
		this.GroupBox1.Visible = BooleanType.FromObject(appSettingsReader.GetValue("tbaGrammar.Pushed", typeof(bool)));
		this.cmdCancel.BackColor = System.Drawing.Color.SlateGray;
		this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Button button = this.cmdCancel;
		location = new System.Drawing.Point(296, 136);
		button.Location = location;
		this.cmdCancel.Name = "cmdCancel";
		this.cmdCancel.TabIndex = 7;
		this.cmdCancel.Text = "&Cancel";
		this.cmdPlay.BackColor = System.Drawing.Color.SlateGray;
		this.cmdPlay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Button button2 = this.cmdPlay;
		location = new System.Drawing.Point(216, 136);
		button2.Location = location;
		this.cmdPlay.Name = "cmdPlay";
		this.cmdPlay.TabIndex = 6;
		this.cmdPlay.Text = "&Play";
		this.GroupBox2.Controls.Add(this.rdoPhrase);
		this.GroupBox2.Controls.Add(this.rdoWords);
		this.GroupBox2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox2;
		location = new System.Drawing.Point(8, 72);
		groupBox3.Location = location;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox2;
		size = new System.Drawing.Size(200, 88);
		groupBox4.Size = size;
		this.GroupBox2.TabIndex = 5;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "Choose prefered typing:";
		this.rdoPhrase.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rdoPhrase.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.RadioButton radioButton = this.rdoPhrase;
		location = new System.Drawing.Point(8, 56);
		radioButton.Location = location;
		this.rdoPhrase.Name = "rdoPhrase";
		System.Windows.Forms.RadioButton radioButton2 = this.rdoPhrase;
		size = new System.Drawing.Size(152, 24);
		radioButton2.Size = size;
		this.rdoPhrase.TabIndex = 1;
		this.rdoPhrase.Text = "Sentences/Phrases";
		this.rdoWords.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.rdoWords.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.RadioButton radioButton3 = this.rdoWords;
		location = new System.Drawing.Point(8, 27);
		radioButton3.Location = location;
		this.rdoWords.Name = "rdoWords";
		System.Windows.Forms.RadioButton radioButton4 = this.rdoWords;
		size = new System.Drawing.Size(160, 24);
		radioButton4.Size = size;
		this.rdoWords.TabIndex = 0;
		this.rdoWords.Text = "Vocabularies/Words";
		this.rdoMrs.ForeColor = System.Drawing.SystemColors.ControlText;
		System.Windows.Forms.RadioButton radioButton5 = this.rdoMrs;
		location = new System.Drawing.Point(316, 36);
		radioButton5.Location = location;
		this.rdoMrs.Name = "rdoMrs";
		System.Windows.Forms.RadioButton radioButton6 = this.rdoMrs;
		size = new System.Drawing.Size(54, 24);
		radioButton6.Size = size;
		this.rdoMrs.TabIndex = 4;
		this.rdoMrs.Text = "Mrs. ";
		this.rdoMs.ForeColor = System.Drawing.SystemColors.ControlText;
		System.Windows.Forms.RadioButton radioButton7 = this.rdoMs;
		location = new System.Drawing.Point(268, 36);
		radioButton7.Location = location;
		this.rdoMs.Name = "rdoMs";
		System.Windows.Forms.RadioButton radioButton8 = this.rdoMs;
		size = new System.Drawing.Size(48, 24);
		radioButton8.Size = size;
		this.rdoMs.TabIndex = 3;
		this.rdoMs.Text = "Ms. ";
		this.rdoMr.ForeColor = System.Drawing.SystemColors.ControlText;
		System.Windows.Forms.RadioButton radioButton9 = this.rdoMr;
		location = new System.Drawing.Point(220, 36);
		radioButton9.Location = location;
		this.rdoMr.Name = "rdoMr";
		System.Windows.Forms.RadioButton radioButton10 = this.rdoMr;
		size = new System.Drawing.Size(48, 24);
		radioButton10.Size = size;
		this.rdoMr.TabIndex = 2;
		this.rdoMr.Text = "Mr. ";
		this.txtUserName.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox = this.txtUserName;
		location = new System.Drawing.Point(88, 32);
		textBox.Location = location;
		this.txtUserName.Name = "txtUserName";
		System.Windows.Forms.TextBox textBox2 = this.txtUserName;
		size = new System.Drawing.Size(128, 31);
		textBox2.Size = size;
		this.txtUserName.TabIndex = 1;
		this.txtUserName.Text = "MLD";
		this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
		System.Windows.Forms.Label label3 = this.Label2;
		location = new System.Drawing.Point(8, 32);
		label3.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label4 = this.Label2;
		size = new System.Drawing.Size(80, 23);
		label4.Size = size;
		this.Label2.TabIndex = 0;
		this.Label2.Text = "Your name:";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.AllowDrop = true;
		size = new System.Drawing.Size(6, 24);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(394, 210);
		this.ClientSize = size;
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.Label1);
		this.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		this.Name = "frmUserGame";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Game - User Information";
		this.TransparencyKey = System.Drawing.Color.Yellow;
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.ResumeLayout(false);
	}

	private void cmdCancel_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		if ((int)Interaction.MsgBox((object)"Are you sure you want to cancel the game?", (MsgBoxStyle)4, (object)"Exit Game") == 6)
		{
			Close();
		}
	}

	private void cmdPlay_Click(object sender, EventArgs e)
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		if (StringType.StrCmp(txtUserName.Text, "", false) != 0)
		{
			string text = default(string);
			if (rdoMr.Checked)
			{
				text = rdoMr.Text;
			}
			if (rdoMs.Checked)
			{
				text = rdoMs.Text;
			}
			if (rdoMrs.Checked)
			{
				text = rdoMrs.Text;
			}
			text += txtUserName.Text;
			int num = default(int);
			if (rdoWords.Checked)
			{
				num = 1;
			}
			if (rdoPhrase.Checked)
			{
				num = 2;
			}
			Hide();
			frmGame frmGame2 = new frmGame();
			frmMain frmMain2 = new frmMain();
			frmGame2.txtName.Text = text;
			frmGame2.lblType.Text = StringType.FromInteger(num);
			frmGame2.MdiParent = MdiParent;
			frmGame2.Show();
		}
		else
		{
			Interaction.MsgBox((object)"Please provide us our name", (MsgBoxStyle)112, (object)"Need Name");
		}
	}

	private void frmUserGame_Load(object sender, EventArgs e)
	{
		rdoMr.Checked = true;
		rdoWords.Checked = true;
	}
}
