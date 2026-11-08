using System;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class frmMain : Form
{
	[AccessedThroughProperty("mnuWindowCascade")]
	private MenuItem _mnuWindowCascade;

	[AccessedThroughProperty("mnuWindowTileV")]
	private MenuItem _mnuWindowTileV;

	[AccessedThroughProperty("mnuWindowTileH")]
	private MenuItem _mnuWindowTileH;

	[AccessedThroughProperty("mnuWindow")]
	private MenuItem _mnuWindow;

	[AccessedThroughProperty("mnuToolKhmer")]
	private MenuItem _mnuToolKhmer;

	[AccessedThroughProperty("btnDrawing")]
	private Button _btnDrawing;

	[AccessedThroughProperty("MenuItem2")]
	private MenuItem _MenuItem2;

	[AccessedThroughProperty("mnuToolGrammar")]
	private MenuItem _mnuToolGrammar;

	[AccessedThroughProperty("mnuWindowArrange")]
	private MenuItem _mnuWindowArrange;

	[AccessedThroughProperty("bntConversation")]
	private Button _bntConversation;

	[AccessedThroughProperty("mnuToolConversation")]
	private MenuItem _mnuToolConversation;

	[AccessedThroughProperty("btnHelp")]
	private Button _btnHelp;

	[AccessedThroughProperty("btnGrammar")]
	private Button _btnGrammar;

	[AccessedThroughProperty("mnuToolDictionary")]
	private MenuItem _mnuToolDictionary;

	[AccessedThroughProperty("ImageList1")]
	private ImageList _ImageList1;

	[AccessedThroughProperty("mnuHelpReanKhmer")]
	private MenuItem _mnuHelpReanKhmer;

	[AccessedThroughProperty("mnuHelpApp")]
	private MenuItem _mnuHelpApp;

	[AccessedThroughProperty("mnuHelpUs")]
	private MenuItem _mnuHelpUs;

	[AccessedThroughProperty("btnGame")]
	private Button _btnGame;

	[AccessedThroughProperty("mnuHelp")]
	private MenuItem _mnuHelp;

	[AccessedThroughProperty("mnuPractiseTest")]
	private MenuItem _mnuPractiseTest;

	[AccessedThroughProperty("mnuPractiseGame")]
	private MenuItem _mnuPractiseGame;

	[AccessedThroughProperty("ToolBar2")]
	private ToolBar _ToolBar2;

	[AccessedThroughProperty("mnuPractise")]
	private MenuItem _mnuPractise;

	[AccessedThroughProperty("mnuTool")]
	private MenuItem _mnuTool;

	[AccessedThroughProperty("lblClue")]
	private Label _lblClue;

	[AccessedThroughProperty("mnuLCh1")]
	private MenuItem _mnuLCh1;

	[AccessedThroughProperty("mnuLesson")]
	private MenuItem _mnuLesson;

	[AccessedThroughProperty("mnuFileExit")]
	private MenuItem _mnuFileExit;

	[AccessedThroughProperty("mnuFile")]
	private MenuItem _mnuFile;

	[AccessedThroughProperty("mnuSupport")]
	private MenuItem _mnuSupport;

	[AccessedThroughProperty("btnDictionary")]
	private Button _btnDictionary;

	[AccessedThroughProperty("MenuItem31")]
	private MenuItem _MenuItem31;

	[AccessedThroughProperty("MainMenu1")]
	private MainMenu _MainMenu1;

	[AccessedThroughProperty("mnuDraw")]
	private MenuItem _mnuDraw;

	[AccessedThroughProperty("mnuCh5")]
	private MenuItem _mnuCh5;

	[AccessedThroughProperty("mnuCh4")]
	private MenuItem _mnuCh4;

	[AccessedThroughProperty("mnuCh3")]
	private MenuItem _mnuCh3;

	[AccessedThroughProperty("mnuCh2")]
	private MenuItem _mnuCh2;

	private IContainer components;

	private int nChLesson;

	private const int SND_LOOP = 8;

	private const int SND_ASYNC = 1;

	internal virtual MainMenu MainMenu1
	{
		get
		{
			return _MainMenu1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_MainMenu1 != null)
			{
			}
			_MainMenu1 = value;
			if (_MainMenu1 == null)
			{
			}
		}
	}

	internal virtual MenuItem MenuItem31
	{
		get
		{
			return _MenuItem31;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_MenuItem31 != null)
			{
			}
			_MenuItem31 = value;
			if (_MenuItem31 == null)
			{
			}
		}
	}

	internal virtual MenuItem mnuFile
	{
		get
		{
			return _mnuFile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuFile != null)
			{
			}
			_mnuFile = value;
			if (_mnuFile == null)
			{
			}
		}
	}

	internal virtual MenuItem mnuFileExit
	{
		get
		{
			return _mnuFileExit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuFileExit != null)
			{
				_mnuFileExit.Click -= mnuFileExit_Click;
			}
			_mnuFileExit = value;
			if (_mnuFileExit != null)
			{
				_mnuFileExit.Click += mnuFileExit_Click;
			}
		}
	}

	internal virtual MenuItem mnuLesson
	{
		get
		{
			return _mnuLesson;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuLesson != null)
			{
			}
			_mnuLesson = value;
			if (_mnuLesson == null)
			{
			}
		}
	}

	internal virtual MenuItem mnuLCh1
	{
		get
		{
			return _mnuLCh1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuLCh1 != null)
			{
				_mnuLCh1.Click -= mnuLCh1_Click;
			}
			_mnuLCh1 = value;
			if (_mnuLCh1 != null)
			{
				_mnuLCh1.Click += mnuLCh1_Click;
			}
		}
	}

	internal virtual MenuItem mnuTool
	{
		get
		{
			return _mnuTool;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuTool != null)
			{
			}
			_mnuTool = value;
			if (_mnuTool == null)
			{
			}
		}
	}

	internal virtual MenuItem mnuPractise
	{
		get
		{
			return _mnuPractise;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuPractise != null)
			{
			}
			_mnuPractise = value;
			if (_mnuPractise == null)
			{
			}
		}
	}

	internal virtual MenuItem mnuPractiseGame
	{
		get
		{
			return _mnuPractiseGame;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuPractiseGame != null)
			{
				_mnuPractiseGame.Click -= mnuPractiseGame_Click;
			}
			_mnuPractiseGame = value;
			if (_mnuPractiseGame != null)
			{
				_mnuPractiseGame.Click += mnuPractiseGame_Click;
			}
		}
	}

	internal virtual MenuItem mnuPractiseTest
	{
		get
		{
			return _mnuPractiseTest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuPractiseTest != null)
			{
				_mnuPractiseTest.Click -= mnuPractiseTest_Click;
			}
			_mnuPractiseTest = value;
			if (_mnuPractiseTest != null)
			{
				_mnuPractiseTest.Click += mnuPractiseTest_Click;
			}
		}
	}

	internal virtual MenuItem mnuHelp
	{
		get
		{
			return _mnuHelp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuHelp != null)
			{
			}
			_mnuHelp = value;
			if (_mnuHelp == null)
			{
			}
		}
	}

	internal virtual MenuItem mnuHelpUs
	{
		get
		{
			return _mnuHelpUs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuHelpUs != null)
			{
				_mnuHelpUs.Click -= mnuHelpUs_Click;
			}
			_mnuHelpUs = value;
			if (_mnuHelpUs != null)
			{
				_mnuHelpUs.Click += mnuHelpUs_Click;
			}
		}
	}

	internal virtual MenuItem mnuHelpApp
	{
		get
		{
			return _mnuHelpApp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuHelpApp != null)
			{
				_mnuHelpApp.Click -= mnuHelpApp_Click;
			}
			_mnuHelpApp = value;
			if (_mnuHelpApp != null)
			{
				_mnuHelpApp.Click += mnuHelpApp_Click;
			}
		}
	}

	internal virtual MenuItem mnuHelpReanKhmer
	{
		get
		{
			return _mnuHelpReanKhmer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuHelpReanKhmer != null)
			{
				_mnuHelpReanKhmer.Click -= mnuHelpReanKhmer_Click;
			}
			_mnuHelpReanKhmer = value;
			if (_mnuHelpReanKhmer != null)
			{
				_mnuHelpReanKhmer.Click += mnuHelpReanKhmer_Click;
			}
		}
	}

	internal virtual ImageList ImageList1
	{
		get
		{
			return _ImageList1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_ImageList1 != null)
			{
			}
			_ImageList1 = value;
			if (_ImageList1 == null)
			{
			}
		}
	}

	internal virtual MenuItem mnuToolDictionary
	{
		get
		{
			return _mnuToolDictionary;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuToolDictionary != null)
			{
				_mnuToolDictionary.Click -= mnuToolDictionary_Click;
			}
			_mnuToolDictionary = value;
			if (_mnuToolDictionary != null)
			{
				_mnuToolDictionary.Click += mnuToolDictionary_Click;
			}
		}
	}

	internal virtual MenuItem mnuToolConversation
	{
		get
		{
			return _mnuToolConversation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuToolConversation != null)
			{
				_mnuToolConversation.Click -= mnuToolConversation_Click;
			}
			_mnuToolConversation = value;
			if (_mnuToolConversation != null)
			{
				_mnuToolConversation.Click += mnuToolConversation_Click;
			}
		}
	}

	internal virtual MenuItem mnuToolGrammar
	{
		get
		{
			return _mnuToolGrammar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuToolGrammar != null)
			{
				_mnuToolGrammar.Click -= mnuToolGrammar_Click;
			}
			_mnuToolGrammar = value;
			if (_mnuToolGrammar != null)
			{
				_mnuToolGrammar.Click += mnuToolGrammar_Click;
			}
		}
	}

	internal virtual MenuItem MenuItem2
	{
		get
		{
			return _MenuItem2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_MenuItem2 != null)
			{
			}
			_MenuItem2 = value;
			if (_MenuItem2 == null)
			{
			}
		}
	}

	internal virtual MenuItem mnuToolKhmer
	{
		get
		{
			return _mnuToolKhmer;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuToolKhmer != null)
			{
				_mnuToolKhmer.Click -= mnuToolKhmer_Click;
			}
			_mnuToolKhmer = value;
			if (_mnuToolKhmer != null)
			{
				_mnuToolKhmer.Click += mnuToolKhmer_Click;
			}
		}
	}

	internal virtual MenuItem mnuWindow
	{
		get
		{
			return _mnuWindow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuWindow != null)
			{
			}
			_mnuWindow = value;
			if (_mnuWindow == null)
			{
			}
		}
	}

	internal virtual MenuItem mnuWindowTileH
	{
		get
		{
			return _mnuWindowTileH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuWindowTileH != null)
			{
				_mnuWindowTileH.Click -= mnuWindowTileH_Click;
			}
			_mnuWindowTileH = value;
			if (_mnuWindowTileH != null)
			{
				_mnuWindowTileH.Click += mnuWindowTileH_Click;
			}
		}
	}

	internal virtual MenuItem mnuWindowTileV
	{
		get
		{
			return _mnuWindowTileV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuWindowTileV != null)
			{
				_mnuWindowTileV.Click -= mnuWindowTileV_Click;
			}
			_mnuWindowTileV = value;
			if (_mnuWindowTileV != null)
			{
				_mnuWindowTileV.Click += mnuWindowTileV_Click;
			}
		}
	}

	internal virtual MenuItem mnuWindowCascade
	{
		get
		{
			return _mnuWindowCascade;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuWindowCascade != null)
			{
				_mnuWindowCascade.Click -= mnuWindowCascade_Click;
			}
			_mnuWindowCascade = value;
			if (_mnuWindowCascade != null)
			{
				_mnuWindowCascade.Click += mnuWindowCascade_Click;
			}
		}
	}

	internal virtual MenuItem mnuWindowArrange
	{
		get
		{
			return _mnuWindowArrange;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuWindowArrange != null)
			{
				_mnuWindowArrange.Click -= mnuWindowArrange_Click;
			}
			_mnuWindowArrange = value;
			if (_mnuWindowArrange != null)
			{
				_mnuWindowArrange.Click += mnuWindowArrange_Click;
			}
		}
	}

	internal virtual ToolBar ToolBar2
	{
		get
		{
			return _ToolBar2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_ToolBar2 != null)
			{
			}
			_ToolBar2 = value;
			if (_ToolBar2 == null)
			{
			}
		}
	}

	internal virtual Button btnGrammar
	{
		get
		{
			return _btnGrammar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_btnGrammar != null)
			{
				_btnGrammar.MouseLeave -= btnGrammar_MouseLeave;
				_btnGrammar.MouseHover -= btnGrammar_MouseHover;
				_btnGrammar.Click -= btnGrammar_Click;
			}
			_btnGrammar = value;
			if (_btnGrammar != null)
			{
				_btnGrammar.MouseLeave += btnGrammar_MouseLeave;
				_btnGrammar.MouseHover += btnGrammar_MouseHover;
				_btnGrammar.Click += btnGrammar_Click;
			}
		}
	}

	internal virtual Button bntConversation
	{
		get
		{
			return _bntConversation;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_bntConversation != null)
			{
				_bntConversation.MouseLeave -= bntConversation_MouseLeave;
				_bntConversation.MouseHover -= bntConversation_MouseHover;
				_bntConversation.Click -= bntConversation_Click;
			}
			_bntConversation = value;
			if (_bntConversation != null)
			{
				_bntConversation.MouseLeave += bntConversation_MouseLeave;
				_bntConversation.MouseHover += bntConversation_MouseHover;
				_bntConversation.Click += bntConversation_Click;
			}
		}
	}

	internal virtual Button btnDictionary
	{
		get
		{
			return _btnDictionary;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_btnDictionary != null)
			{
				_btnDictionary.MouseLeave -= btnDictionary_MouseLeave;
				_btnDictionary.MouseHover -= btnDictionary_MouseHover;
				_btnDictionary.Click -= btnDictionary_Click;
			}
			_btnDictionary = value;
			if (_btnDictionary != null)
			{
				_btnDictionary.MouseLeave += btnDictionary_MouseLeave;
				_btnDictionary.MouseHover += btnDictionary_MouseHover;
				_btnDictionary.Click += btnDictionary_Click;
			}
		}
	}

	internal virtual Button btnGame
	{
		get
		{
			return _btnGame;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_btnGame != null)
			{
				_btnGame.MouseLeave -= btnGame_MouseLeave;
				_btnGame.MouseHover -= btnGame_MouseHover;
				_btnGame.Click -= btnGame_Click;
			}
			_btnGame = value;
			if (_btnGame != null)
			{
				_btnGame.MouseLeave += btnGame_MouseLeave;
				_btnGame.MouseHover += btnGame_MouseHover;
				_btnGame.Click += btnGame_Click;
			}
		}
	}

	internal virtual Button btnDrawing
	{
		get
		{
			return _btnDrawing;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_btnDrawing != null)
			{
				_btnDrawing.MouseLeave -= btnDrawing_MouseLeave;
				_btnDrawing.MouseHover -= btnDrawing_MouseHover;
				_btnDrawing.Click -= btnDrawing_Click;
			}
			_btnDrawing = value;
			if (_btnDrawing != null)
			{
				_btnDrawing.MouseLeave += btnDrawing_MouseLeave;
				_btnDrawing.MouseHover += btnDrawing_MouseHover;
				_btnDrawing.Click += btnDrawing_Click;
			}
		}
	}

	internal virtual Button btnHelp
	{
		get
		{
			return _btnHelp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_btnHelp != null)
			{
				_btnHelp.MouseLeave -= btnHelp_MouseLeave;
				_btnHelp.MouseHover -= btnHelp_MouseHover;
				_btnHelp.Click -= btnHelp_Click;
			}
			_btnHelp = value;
			if (_btnHelp != null)
			{
				_btnHelp.MouseLeave += btnHelp_MouseLeave;
				_btnHelp.MouseHover += btnHelp_MouseHover;
				_btnHelp.Click += btnHelp_Click;
			}
		}
	}

	internal virtual Label lblClue
	{
		get
		{
			return _lblClue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblClue != null)
			{
			}
			_lblClue = value;
			if (_lblClue == null)
			{
			}
		}
	}

	internal virtual MenuItem mnuSupport
	{
		get
		{
			return _mnuSupport;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuSupport != null)
			{
				_mnuSupport.Click -= mnuSupport_Click;
			}
			_mnuSupport = value;
			if (_mnuSupport != null)
			{
				_mnuSupport.Click += mnuSupport_Click;
			}
		}
	}

	internal virtual MenuItem mnuCh2
	{
		get
		{
			return _mnuCh2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuCh2 != null)
			{
				_mnuCh2.Click -= mnuCh2_Click;
			}
			_mnuCh2 = value;
			if (_mnuCh2 != null)
			{
				_mnuCh2.Click += mnuCh2_Click;
			}
		}
	}

	internal virtual MenuItem mnuCh3
	{
		get
		{
			return _mnuCh3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuCh3 != null)
			{
				_mnuCh3.Click -= mnuCh3_Click;
			}
			_mnuCh3 = value;
			if (_mnuCh3 != null)
			{
				_mnuCh3.Click += mnuCh3_Click;
			}
		}
	}

	internal virtual MenuItem mnuCh4
	{
		get
		{
			return _mnuCh4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuCh4 != null)
			{
				_mnuCh4.Click -= mnuCh4_Click;
			}
			_mnuCh4 = value;
			if (_mnuCh4 != null)
			{
				_mnuCh4.Click += mnuCh4_Click;
			}
		}
	}

	internal virtual MenuItem mnuCh5
	{
		get
		{
			return _mnuCh5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuCh5 != null)
			{
				_mnuCh5.Click -= mnuCh5_Click;
			}
			_mnuCh5 = value;
			if (_mnuCh5 != null)
			{
				_mnuCh5.Click += mnuCh5_Click;
			}
		}
	}

	internal virtual MenuItem mnuDraw
	{
		get
		{
			return _mnuDraw;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_mnuDraw != null)
			{
				_mnuDraw.Click -= mnuDraw_Click;
			}
			_mnuDraw = value;
			if (_mnuDraw != null)
			{
				_mnuDraw.Click += mnuDraw_Click;
			}
		}
	}

	public frmMain()
	{
		base.Load += frmMain_Load;
		base.Resize += frmMain_Resize;
		base.Disposed += frmMain_Disposed;
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
		this.components = new System.ComponentModel.Container();
		System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager(typeof(reankhmer.frmMain));
		this.MainMenu1 = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuFileExit = new System.Windows.Forms.MenuItem();
		this.mnuLesson = new System.Windows.Forms.MenuItem();
		this.mnuLCh1 = new System.Windows.Forms.MenuItem();
		this.mnuCh2 = new System.Windows.Forms.MenuItem();
		this.mnuCh3 = new System.Windows.Forms.MenuItem();
		this.mnuCh4 = new System.Windows.Forms.MenuItem();
		this.mnuCh5 = new System.Windows.Forms.MenuItem();
		this.mnuTool = new System.Windows.Forms.MenuItem();
		this.mnuToolDictionary = new System.Windows.Forms.MenuItem();
		this.mnuToolGrammar = new System.Windows.Forms.MenuItem();
		this.mnuToolConversation = new System.Windows.Forms.MenuItem();
		this.mnuDraw = new System.Windows.Forms.MenuItem();
		this.MenuItem2 = new System.Windows.Forms.MenuItem();
		this.mnuToolKhmer = new System.Windows.Forms.MenuItem();
		this.mnuPractise = new System.Windows.Forms.MenuItem();
		this.mnuPractiseGame = new System.Windows.Forms.MenuItem();
		this.mnuPractiseTest = new System.Windows.Forms.MenuItem();
		this.mnuWindow = new System.Windows.Forms.MenuItem();
		this.mnuWindowTileH = new System.Windows.Forms.MenuItem();
		this.mnuWindowTileV = new System.Windows.Forms.MenuItem();
		this.mnuWindowCascade = new System.Windows.Forms.MenuItem();
		this.mnuWindowArrange = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuHelpUs = new System.Windows.Forms.MenuItem();
		this.mnuHelpApp = new System.Windows.Forms.MenuItem();
		this.mnuSupport = new System.Windows.Forms.MenuItem();
		this.MenuItem31 = new System.Windows.Forms.MenuItem();
		this.mnuHelpReanKhmer = new System.Windows.Forms.MenuItem();
		this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
		this.ToolBar2 = new System.Windows.Forms.ToolBar();
		this.btnGrammar = new System.Windows.Forms.Button();
		this.bntConversation = new System.Windows.Forms.Button();
		this.btnDictionary = new System.Windows.Forms.Button();
		this.btnGame = new System.Windows.Forms.Button();
		this.btnDrawing = new System.Windows.Forms.Button();
		this.btnHelp = new System.Windows.Forms.Button();
		this.lblClue = new System.Windows.Forms.Label();
		this.SuspendLayout();
		this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[6] { this.mnuFile, this.mnuLesson, this.mnuTool, this.mnuPractise, this.mnuWindow, this.mnuHelp });
		this.mnuFile.Index = 0;
		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[1] { this.mnuFileExit });
		this.mnuFile.Text = "&File";
		this.mnuFileExit.Index = 0;
		this.mnuFileExit.Text = "E&xit";
		this.mnuLesson.Index = 1;
		this.mnuLesson.MenuItems.AddRange(new System.Windows.Forms.MenuItem[5] { this.mnuLCh1, this.mnuCh2, this.mnuCh3, this.mnuCh4, this.mnuCh5 });
		this.mnuLesson.Text = "&Chapters";
		this.mnuLCh1.Index = 0;
		this.mnuLCh1.Text = "Chapter &1";
		this.mnuCh2.Index = 1;
		this.mnuCh2.Text = "Chapter &2";
		this.mnuCh3.Index = 2;
		this.mnuCh3.Text = "Chapter &3";
		this.mnuCh4.Index = 3;
		this.mnuCh4.Text = "Chapter &4";
		this.mnuCh5.Index = 4;
		this.mnuCh5.Text = "Chapter &5";
		this.mnuTool.Index = 2;
		this.mnuTool.MenuItems.AddRange(new System.Windows.Forms.MenuItem[6] { this.mnuToolDictionary, this.mnuToolGrammar, this.mnuToolConversation, this.mnuDraw, this.MenuItem2, this.mnuToolKhmer });
		this.mnuTool.Text = "&Tools";
		this.mnuToolDictionary.Index = 0;
		this.mnuToolDictionary.Text = "&Dictionary";
		this.mnuToolGrammar.Index = 1;
		this.mnuToolGrammar.Text = "&Grammars";
		this.mnuToolConversation.Index = 2;
		this.mnuToolConversation.Text = "&Conversations";
		this.mnuDraw.Index = 3;
		this.mnuDraw.Text = "Writing &Board";
		this.MenuItem2.Index = 4;
		this.MenuItem2.Text = "-";
		this.mnuToolKhmer.Index = 5;
		this.mnuToolKhmer.Text = "&Khmer Language";
		this.mnuPractise.Index = 3;
		this.mnuPractise.MenuItems.AddRange(new System.Windows.Forms.MenuItem[2] { this.mnuPractiseGame, this.mnuPractiseTest });
		this.mnuPractise.Text = "&Practices";
		this.mnuPractiseGame.Index = 0;
		this.mnuPractiseGame.Text = "G&ames";
		this.mnuPractiseTest.Index = 1;
		this.mnuPractiseTest.Text = "Te&st";
		this.mnuWindow.Index = 4;
		this.mnuWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[4] { this.mnuWindowTileH, this.mnuWindowTileV, this.mnuWindowCascade, this.mnuWindowArrange });
		this.mnuWindow.Text = "&Window";
		this.mnuWindowTileH.Index = 0;
		this.mnuWindowTileH.Text = "Tile &Horizontally";
		this.mnuWindowTileV.Index = 1;
		this.mnuWindowTileV.Text = "Tile Vertically";
		this.mnuWindowCascade.Index = 2;
		this.mnuWindowCascade.Text = "Cascade";
		this.mnuWindowArrange.Index = 3;
		this.mnuWindowArrange.Text = "Arrange Icons";
		this.mnuHelp.Index = 5;
		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[5] { this.mnuHelpUs, this.mnuHelpApp, this.mnuSupport, this.MenuItem31, this.mnuHelpReanKhmer });
		this.mnuHelp.Text = "&Help";
		this.mnuHelpUs.Index = 0;
		this.mnuHelpUs.Text = "About &Us";
		this.mnuHelpApp.Index = 1;
		this.mnuHelpApp.Text = "&Application Help";
		this.mnuSupport.Index = 2;
		this.mnuSupport.Text = "&Supports";
		this.MenuItem31.Index = 3;
		this.MenuItem31.Text = "-";
		this.mnuHelpReanKhmer.Index = 4;
		this.mnuHelpReanKhmer.Text = "About &ReanKhmer";
		System.Windows.Forms.ImageList imageList = this.ImageList1;
		System.Drawing.Size imageSize = new System.Drawing.Size(48, 35);
		imageList.ImageSize = imageSize;
		this.ImageList1.ImageStream = (System.Windows.Forms.ImageListStreamer)resourceManager.GetObject("ImageList1.ImageStream");
		this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
		this.ToolBar2.DropDownArrows = true;
		System.Windows.Forms.ToolBar toolBar = this.ToolBar2;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		toolBar.Location = location;
		this.ToolBar2.Name = "ToolBar2";
		this.ToolBar2.ShowToolTips = true;
		System.Windows.Forms.ToolBar toolBar2 = this.ToolBar2;
		imageSize = new System.Drawing.Size(664, 42);
		toolBar2.Size = imageSize;
		this.ToolBar2.TabIndex = 5;
		this.btnGrammar.Image = (System.Drawing.Image)resourceManager.GetObject("btnGrammar.Image");
		System.Windows.Forms.Button button = this.btnGrammar;
		location = new System.Drawing.Point(5, 5);
		button.Location = location;
		this.btnGrammar.Name = "btnGrammar";
		System.Windows.Forms.Button button2 = this.btnGrammar;
		imageSize = new System.Drawing.Size(48, 35);
		button2.Size = imageSize;
		this.btnGrammar.TabIndex = 6;
		this.bntConversation.Image = (System.Drawing.Image)resourceManager.GetObject("bntConversation.Image");
		System.Windows.Forms.Button button3 = this.bntConversation;
		location = new System.Drawing.Point(54, 5);
		button3.Location = location;
		this.bntConversation.Name = "bntConversation";
		System.Windows.Forms.Button button4 = this.bntConversation;
		imageSize = new System.Drawing.Size(48, 35);
		button4.Size = imageSize;
		this.bntConversation.TabIndex = 7;
		this.btnDictionary.Image = (System.Drawing.Image)resourceManager.GetObject("btnDictionary.Image");
		System.Windows.Forms.Button button5 = this.btnDictionary;
		location = new System.Drawing.Point(102, 5);
		button5.Location = location;
		this.btnDictionary.Name = "btnDictionary";
		System.Windows.Forms.Button button6 = this.btnDictionary;
		imageSize = new System.Drawing.Size(48, 35);
		button6.Size = imageSize;
		this.btnDictionary.TabIndex = 8;
		this.btnGame.Image = (System.Drawing.Image)resourceManager.GetObject("btnGame.Image");
		System.Windows.Forms.Button button7 = this.btnGame;
		location = new System.Drawing.Point(151, 5);
		button7.Location = location;
		this.btnGame.Name = "btnGame";
		System.Windows.Forms.Button button8 = this.btnGame;
		imageSize = new System.Drawing.Size(48, 35);
		button8.Size = imageSize;
		this.btnGame.TabIndex = 9;
		this.btnDrawing.Image = (System.Drawing.Image)resourceManager.GetObject("btnDrawing.Image");
		System.Windows.Forms.Button button9 = this.btnDrawing;
		location = new System.Drawing.Point(200, 5);
		button9.Location = location;
		this.btnDrawing.Name = "btnDrawing";
		System.Windows.Forms.Button button10 = this.btnDrawing;
		imageSize = new System.Drawing.Size(48, 35);
		button10.Size = imageSize;
		this.btnDrawing.TabIndex = 10;
		this.btnHelp.Image = (System.Drawing.Image)resourceManager.GetObject("btnHelp.Image");
		System.Windows.Forms.Button button11 = this.btnHelp;
		location = new System.Drawing.Point(249, 5);
		button11.Location = location;
		this.btnHelp.Name = "btnHelp";
		System.Windows.Forms.Button button12 = this.btnHelp;
		imageSize = new System.Drawing.Size(48, 35);
		button12.Size = imageSize;
		this.btnHelp.TabIndex = 11;
		this.lblClue.Font = new System.Drawing.Font("Khmer OS System", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.lblClue.ForeColor = System.Drawing.Color.SteelBlue;
		System.Windows.Forms.Label label = this.lblClue;
		location = new System.Drawing.Point(312, 16);
		label.Location = location;
		this.lblClue.Name = "lblClue";
		System.Windows.Forms.Label label2 = this.lblClue;
		imageSize = new System.Drawing.Size(168, 24);
		label2.Size = imageSize;
		this.lblClue.TabIndex = 12;
		this.lblClue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		imageSize = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = imageSize;
		imageSize = new System.Drawing.Size(664, 390);
		this.ClientSize = imageSize;
		this.Controls.Add(this.lblClue);
		this.Controls.Add(this.btnHelp);
		this.Controls.Add(this.btnDrawing);
		this.Controls.Add(this.btnGame);
		this.Controls.Add(this.btnDictionary);
		this.Controls.Add(this.bntConversation);
		this.Controls.Add(this.btnGrammar);
		this.Controls.Add(this.ToolBar2);
		this.Icon = (System.Drawing.Icon)resourceManager.GetObject("$this.Icon");
		this.IsMdiContainer = true;
		this.Menu = this.MainMenu1;
		this.Name = "frmMain";
		this.Text = "រ\u17c0នខ\u17d2ម\u17c2រ-Rean Khmer";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.ResumeLayout(false);
	}

	private void mnuWindowTileH_Click(object sender, EventArgs e)
	{
		LayoutMdi(MdiLayout.TileHorizontal);
	}

	private void mnuWindowTileV_Click(object sender, EventArgs e)
	{
		LayoutMdi(MdiLayout.TileVertical);
	}

	private void mnuWindowCascade_Click(object sender, EventArgs e)
	{
		LayoutMdi(MdiLayout.Cascade);
	}

	private void mnuWindowArrange_Click(object sender, EventArgs e)
	{
		LayoutMdi(MdiLayout.ArrangeIcons);
	}

	private void mnuLCh1Les1_Click(object sender, EventArgs e)
	{
		callForm(1);
	}

	private void frmMain_Load(object sender, EventArgs e)
	{
		OleDbConnection oleDbConnection = new OleDbConnection();
		oleDbConnection.ConnectionString = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + Application.StartupPath + "\\reankhmer.mdb";
	}

	private void callForm(int nW)
	{
		frmChapter1 frmChapter6 = new frmChapter1();
		frmChapter6.MdiParent = this;
		frmChapter6.Text = Text + " - Chapter " + nW;
		frmChapter6.Show();
	}

	private void callForm_2(int nW)
	{
		frmChapter2 frmChapter6 = new frmChapter2();
		frmChapter6.MdiParent = this;
		frmChapter6.Text = Text + " - Chapter " + nW;
		frmChapter6.lblNum.Text = nW.ToString();
		frmChapter6.Show();
	}

	private void mnuToolDictionary_Click(object sender, EventArgs e)
	{
		frmDictionary frmDictionary2 = new frmDictionary();
		frmDictionary2.MdiParent = this;
		frmDictionary2.Text = Text + " - Khmer-English Dictionary";
		frmDictionary2.Show();
	}

	private void mnuFileExit_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		if ((int)Interaction.MsgBox((object)"Are you sure you want to exit?", (MsgBoxStyle)4, (object)"Exit Window") == 6)
		{
			ProjectData.EndApp();
		}
	}

	private void tbaDictionary_Disposed(object sender, EventArgs e)
	{
		frmDictionary frmDictionary2 = new frmDictionary();
		frmDictionary2.MdiParent = this;
		frmDictionary2.Text = Text + " - Khmer-English Dictionary";
		frmDictionary2.Show();
	}

	private void mnuLCh1_Click(object sender, EventArgs e)
	{
		callForm(1);
	}

	private void mnuPractiseGame_Click(object sender, EventArgs e)
	{
		frmUserGame frmUserGame2 = new frmUserGame();
		frmUserGame2.MdiParent = this;
		frmUserGame2.Show();
	}

	private void ToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
	{
	}

	[DllImport("winmm.dll", CharSet = CharSet.Ansi, EntryPoint = "sndPlaySoundA", ExactSpelling = true, SetLastError = true)]
	private static extern long sndPlaySound([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpszSoundName, long uFlags);

	private void playSound(string filename)
	{
		long num = sndPlaySound(ref filename, 1L);
	}

	private void mnuToolGrammar_Click(object sender, EventArgs e)
	{
		frmGrammar frmGrammar2 = new frmGrammar();
		frmGrammar2.MdiParent = this;
		frmGrammar2.Show();
	}

	private void btnGrammar_Click(object sender, EventArgs e)
	{
		mnuToolGrammar_Click(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void btnGrammar_MouseHover(object sender, EventArgs e)
	{
		lblClue.Text = "Grammar!";
	}

	private void btnGrammar_MouseLeave(object sender, EventArgs e)
	{
		lblClue.Text = "";
	}

	private void btnGame_Click(object sender, EventArgs e)
	{
		mnuPractiseGame_Click(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void btnGame_MouseHover(object sender, EventArgs e)
	{
		lblClue.Text = "Play a Game!!";
	}

	private void btnGame_MouseLeave(object sender, EventArgs e)
	{
		lblClue.Text = "";
	}

	private void bntConversation_Click(object sender, EventArgs e)
	{
		mnuCh5_Click(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void bntConversation_MouseHover(object sender, EventArgs e)
	{
		lblClue.Text = "Khmer Conversation!";
	}

	private void bntConversation_MouseLeave(object sender, EventArgs e)
	{
		lblClue.Text = "";
	}

	private void btnDictionary_Click(object sender, EventArgs e)
	{
		mnuToolDictionary_Click(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void btnDictionary_MouseHover(object sender, EventArgs e)
	{
		lblClue.Text = "Check Dictionary!!";
	}

	private void btnDictionary_MouseLeave(object sender, EventArgs e)
	{
		lblClue.Text = "";
	}

	private void btnDrawing_Click(object sender, EventArgs e)
	{
		mnuDraw_Click(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void btnDrawing_MouseHover(object sender, EventArgs e)
	{
		lblClue.Text = "Writing Board!";
	}

	private void btnDrawing_MouseLeave(object sender, EventArgs e)
	{
		lblClue.Text = "";
	}

	private void btnHelp_Click(object sender, EventArgs e)
	{
		mnuHelpApp_Click(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void btnHelp_MouseHover(object sender, EventArgs e)
	{
		lblClue.Text = "Application Help!";
	}

	private void btnHelp_MouseLeave(object sender, EventArgs e)
	{
		lblClue.Text = "";
	}

	private void frmMain_Resize(object sender, EventArgs e)
	{
		if (!((Width == 800) & (Height == 600)))
		{
		}
	}

	private void mnuCh2_Click(object sender, EventArgs e)
	{
		callForm_2(2);
	}

	private void mnuCh3_Click(object sender, EventArgs e)
	{
		callForm_2(3);
	}

	private void mnuCh4_Click(object sender, EventArgs e)
	{
		frmChapter4 frmChapter6 = new frmChapter4();
		frmChapter6.MdiParent = this;
		frmChapter6.Show();
	}

	private void mnuSupport_Click(object sender, EventArgs e)
	{
		frmSupport frmSupport2 = new frmSupport();
		frmSupport2.MdiParent = this;
		frmSupport2.Show();
	}

	private void mnuDraw_Click(object sender, EventArgs e)
	{
		frmFreeDrawing frmFreeDrawing2 = new frmFreeDrawing();
		frmFreeDrawing2.MdiParent = this;
		frmFreeDrawing2.Show();
	}

	private void mnuToolKhmer_Click(object sender, EventArgs e)
	{
		frmKhmerLanguage frmKhmerLanguage2 = new frmKhmerLanguage();
		frmKhmerLanguage2.MdiParent = this;
		frmKhmerLanguage2.Show();
	}

	private void mnuHelpUs_Click(object sender, EventArgs e)
	{
		frmAboutUs frmAboutUs2 = new frmAboutUs();
		frmAboutUs2.MdiParent = this;
		frmAboutUs2.Show();
	}

	private void frmMain_Disposed(object sender, EventArgs e)
	{
		ProjectData.EndApp();
	}

	private void mnuCh5_Click(object sender, EventArgs e)
	{
		frmChapter5 frmChapter6 = new frmChapter5();
		frmChapter6.MdiParent = this;
		frmChapter6.Show();
	}

	private void mnuToolConversation_Click(object sender, EventArgs e)
	{
		mnuCh5_Click(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void mnuHelpReanKhmer_Click(object sender, EventArgs e)
	{
		frmFirst frmFirst2 = new frmFirst();
		frmFirst2.MdiParent = this;
		frmFirst2.lblFirst.Text = "1";
		frmFirst2.Show();
	}

	private void mnuHelpApp_Click(object sender, EventArgs e)
	{
		frmHelp frmHelp2 = new frmHelp();
		frmHelp2.MdiParent = this;
		frmHelp2.Show();
	}

	private void mnuPractiseTest_Click(object sender, EventArgs e)
	{
		frmTest frmTest2 = new frmTest();
		frmTest2.MdiParent = this;
		frmTest2.Show();
	}
}
