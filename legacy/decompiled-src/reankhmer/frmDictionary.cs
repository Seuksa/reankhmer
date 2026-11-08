using System;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class frmDictionary : Form
{
	[AccessedThroughProperty("txtSearch")]
	private TextBox _txtSearch;

	[AccessedThroughProperty("PrintDocument1")]
	private PrintDocument _PrintDocument1;

	[AccessedThroughProperty("cmdPrint")]
	private Button _cmdPrint;

	[AccessedThroughProperty("lblMeaning")]
	private TextBox _lblMeaning;

	[AccessedThroughProperty("lstWord")]
	private ListBox _lstWord;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	private int meW;

	private int meH;

	private int mW;

	private int mH;

	private int wW;

	private int wH;

	private IContainer components;

	private OleDbConnection cnn;

	private Application app;

	private OleDbDataAdapter da;

	private DataSet ds;

	[SpecialName]
	private int _0024STATIC_0024PrintDocument1_PrintPage_002420211C126D_0024currentChar;

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
				_txtSearch.TextChanged -= txtSearch_TextChanged;
			}
			_txtSearch = value;
			if (_txtSearch != null)
			{
				_txtSearch.TextChanged += txtSearch_TextChanged;
			}
		}
	}

	internal virtual ListBox lstWord
	{
		get
		{
			return _lstWord;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lstWord != null)
			{
				_lstWord.SelectedIndexChanged -= lstWord_SelectedIndexChanged;
			}
			_lstWord = value;
			if (_lstWord != null)
			{
				_lstWord.SelectedIndexChanged += lstWord_SelectedIndexChanged;
			}
		}
	}

	internal virtual TextBox lblMeaning
	{
		get
		{
			return _lblMeaning;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblMeaning != null)
			{
				_lblMeaning.TextChanged -= lblMeaning_TextChanged;
			}
			_lblMeaning = value;
			if (_lblMeaning != null)
			{
				_lblMeaning.TextChanged += lblMeaning_TextChanged;
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

	public frmDictionary()
	{
		base.Load += frmDictionary_Load;
		base.Resize += frmDictionary_Resize;
		cnn = new OleDbConnection();
		da = new OleDbDataAdapter();
		ds = new DataSet();
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
		this.txtSearch = new System.Windows.Forms.TextBox();
		this.lstWord = new System.Windows.Forms.ListBox();
		this.lblMeaning = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.cmdPrint = new System.Windows.Forms.Button();
		this.PrintDocument1 = new System.Drawing.Printing.PrintDocument();
		this.SuspendLayout();
		this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtSearch.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox = this.txtSearch;
		System.Drawing.Point location = new System.Drawing.Point(8, 16);
		textBox.Location = location;
		this.txtSearch.Name = "txtSearch";
		System.Windows.Forms.TextBox textBox2 = this.txtSearch;
		System.Drawing.Size size = new System.Drawing.Size(152, 31);
		textBox2.Size = size;
		this.txtSearch.TabIndex = 0;
		this.txtSearch.Text = "";
		this.lstWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lstWord.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lstWord.ForeColor = System.Drawing.Color.Blue;
		this.lstWord.ItemHeight = 24;
		System.Windows.Forms.ListBox listBox = this.lstWord;
		location = new System.Drawing.Point(8, 48);
		listBox.Location = location;
		this.lstWord.Name = "lstWord";
		System.Windows.Forms.ListBox listBox2 = this.lstWord;
		size = new System.Drawing.Size(152, 290);
		listBox2.Size = size;
		this.lstWord.TabIndex = 1;
		this.lblMeaning.BackColor = System.Drawing.SystemColors.ControlLightLight;
		this.lblMeaning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lblMeaning.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblMeaning.ForeColor = System.Drawing.Color.Green;
		System.Windows.Forms.TextBox textBox3 = this.lblMeaning;
		location = new System.Drawing.Point(168, 48);
		textBox3.Location = location;
		this.lblMeaning.Multiline = true;
		this.lblMeaning.Name = "lblMeaning";
		this.lblMeaning.ReadOnly = true;
		this.lblMeaning.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		System.Windows.Forms.TextBox textBox4 = this.lblMeaning;
		size = new System.Drawing.Size(352, 296);
		textBox4.Size = size;
		this.lblMeaning.TabIndex = 2;
		this.lblMeaning.Text = "";
		this.Label1.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Label1.ForeColor = System.Drawing.SystemColors.Control;
		System.Windows.Forms.Label label = this.Label1;
		location = new System.Drawing.Point(488, 16);
		label.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label2 = this.Label1;
		size = new System.Drawing.Size(32, 24);
		label2.Size = size;
		this.Label1.TabIndex = 4;
		this.Label1.Text = "Label1";
		this.cmdPrint.BackColor = System.Drawing.Color.SlateGray;
		this.cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		this.cmdPrint.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.cmdPrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		System.Windows.Forms.Button button = this.cmdPrint;
		location = new System.Drawing.Point(168, 16);
		button.Location = location;
		this.cmdPrint.Name = "cmdPrint";
		this.cmdPrint.TabIndex = 5;
		this.cmdPrint.Text = "&Print";
		size = new System.Drawing.Size(6, 24);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(712, 354);
		this.ClientSize = size;
		this.Controls.Add(this.cmdPrint);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.lblMeaning);
		this.Controls.Add(this.lstWord);
		this.Controls.Add(this.txtSearch);
		this.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.Name = "frmDictionary";
		this.Text = "frmDictionary";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.ResumeLayout(false);
	}

	private void frmDictionary_Load(object sender, EventArgs e)
	{
		cnn.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Application.StartupPath + "\\reankhmer.mdb";
		cnn.Open();
		OleDbCommand oleDbCommand = new OleDbCommand("Select * From tblDictionary", cnn);
		OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
		while (oleDbDataReader.Read())
		{
			lstWord.Items.Add(oleDbDataReader.GetString(1));
		}
		oleDbDataReader.Close();
		cnn.Close();
		OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);
		oleDbDataAdapter.Fill(ds, "dictionary");
		meW = Width;
		meH = Height;
		mW = lblMeaning.Width;
		mH = lblMeaning.Height;
		wW = lstWord.Width;
		wH = lstWord.Height;
		lstWord.Height = 415;
		lblMeaning.Height = 410;
		lblMeaning.Width = 500;
	}

	private void lstWord_SelectedIndexChanged(object sender, EventArgs e)
	{
		cnn.Open();
		OleDbCommand oleDbCommand = new OleDbCommand("Select * From tblDictionary ", cnn);
		lblMeaning.Text = "";
		OleDbDataReader oleDbDataReader = oleDbCommand.ExecuteReader();
		while (oleDbDataReader.Read())
		{
			if (ObjectType.ObjTst((object)oleDbDataReader.GetString(1), lstWord.Items[lstWord.SelectedIndex], false) == 0)
			{
				lblMeaning.Text = oleDbDataReader.GetString(2);
			}
		}
		lstWord.TopIndex = lstWord.SelectedIndex;
		cnn.Close();
	}

	private void txtSearch_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			int num = lstWord.Items.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				Label1.Text = StringType.FromObject(lstWord.Items[i]);
				string text = Label1.Text;
				if (Strings.Len(txtSearch.Text) <= Strings.Len(text) && StringType.StrCmp(text.Substring(0, Strings.Len(txtSearch.Text)), txtSearch.Text, false) == 0)
				{
					lstWord.TopIndex = i;
					lstWord.SelectedIndex = i;
					break;
				}
			}
		}
	}

	private void frmDictionary_Resize(object sender, EventArgs e)
	{
	}

	private void Button1_Click(object sender, EventArgs e)
	{
		int num = lstWord.FindStringExact(txtSearch.Text);
		if (num >= 0)
		{
			lstWord.TopIndex = num;
			lstWord.SelectedIndex = num;
			return;
		}
		num = lstWord.FindString(txtSearch.Text);
		if (num >= 0)
		{
			lstWord.TopIndex = num;
			lstWord.SelectedIndex = num;
		}
	}

	private void cmdPrint_Click(object sender, EventArgs e)
	{
		PrintDocument1.Print();
	}

	private void PrintDocument1_PrintPage(object sender, PrintPageEventArgs e)
	{
		Font font = new Font("Khmer OS System", 12f);
		string text = StringType.FromObject(ObjectType.StrCatObj(ObjectType.StrCatObj(lstWord.SelectedItem, (object)"\t : "), (object)lblMeaning.Text));
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

	private void lblMeaning_TextChanged(object sender, EventArgs e)
	{
	}
}
