using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ADODB;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace reankhmer;

public class frmTest : Form
{
	[AccessedThroughProperty("p7")]
	private PictureBox _p7;

	[AccessedThroughProperty("p8")]
	private PictureBox _p8;

	[AccessedThroughProperty("p9")]
	private PictureBox _p9;

	[AccessedThroughProperty("Label2")]
	private Label _Label2;

	[AccessedThroughProperty("pic1")]
	private PictureBox _pic1;

	[AccessedThroughProperty("txt3")]
	private TextBox _txt3;

	[AccessedThroughProperty("pic3")]
	private PictureBox _pic3;

	[AccessedThroughProperty("lblTest")]
	private Label _lblTest;

	[AccessedThroughProperty("txt7")]
	private TextBox _txt7;

	[AccessedThroughProperty("cmdClose")]
	private Button _cmdClose;

	[AccessedThroughProperty("txt1")]
	private TextBox _txt1;

	[AccessedThroughProperty("p11")]
	private PictureBox _p11;

	[AccessedThroughProperty("txtTime")]
	private TextBox _txtTime;

	[AccessedThroughProperty("p10")]
	private PictureBox _p10;

	[AccessedThroughProperty("p6")]
	private PictureBox _p6;

	[AccessedThroughProperty("GroupBox3")]
	private GroupBox _GroupBox3;

	[AccessedThroughProperty("p5")]
	private PictureBox _p5;

	[AccessedThroughProperty("p4")]
	private PictureBox _p4;

	[AccessedThroughProperty("p12")]
	private PictureBox _p12;

	[AccessedThroughProperty("Timer1")]
	private Timer _Timer1;

	[AccessedThroughProperty("pic2")]
	private PictureBox _pic2;

	[AccessedThroughProperty("p25")]
	private PictureBox _p25;

	[AccessedThroughProperty("p3")]
	private PictureBox _p3;

	[AccessedThroughProperty("p2")]
	private PictureBox _p2;

	[AccessedThroughProperty("p15")]
	private PictureBox _p15;

	[AccessedThroughProperty("GroupBox2")]
	private GroupBox _GroupBox2;

	[AccessedThroughProperty("p1")]
	private PictureBox _p1;

	[AccessedThroughProperty("pic4")]
	private PictureBox _pic4;

	[AccessedThroughProperty("cmdCheck")]
	private Button _cmdCheck;

	[AccessedThroughProperty("p17")]
	private PictureBox _p17;

	[AccessedThroughProperty("p32")]
	private PictureBox _p32;

	[AccessedThroughProperty("pic5")]
	private PictureBox _pic5;

	[AccessedThroughProperty("p31")]
	private PictureBox _p31;

	[AccessedThroughProperty("p18")]
	private PictureBox _p18;

	[AccessedThroughProperty("p33")]
	private PictureBox _p33;

	[AccessedThroughProperty("p26")]
	private PictureBox _p26;

	[AccessedThroughProperty("p20")]
	private PictureBox _p20;

	[AccessedThroughProperty("p16")]
	private PictureBox _p16;

	[AccessedThroughProperty("GroupBox1")]
	private GroupBox _GroupBox1;

	[AccessedThroughProperty("p27")]
	private PictureBox _p27;

	[AccessedThroughProperty("txt2")]
	private TextBox _txt2;

	[AccessedThroughProperty("Label1")]
	private Label _Label1;

	[AccessedThroughProperty("p29")]
	private PictureBox _p29;

	[AccessedThroughProperty("p14")]
	private PictureBox _p14;

	[AccessedThroughProperty("p30")]
	private PictureBox _p30;

	[AccessedThroughProperty("p28")]
	private PictureBox _p28;

	[AccessedThroughProperty("txt5")]
	private TextBox _txt5;

	[AccessedThroughProperty("txt4")]
	private TextBox _txt4;

	[AccessedThroughProperty("p13")]
	private PictureBox _p13;

	[AccessedThroughProperty("p22")]
	private PictureBox _p22;

	[AccessedThroughProperty("cmdClear")]
	private Button _cmdClear;

	[AccessedThroughProperty("p24")]
	private PictureBox _p24;

	[AccessedThroughProperty("p23")]
	private PictureBox _p23;

	[AccessedThroughProperty("txt6")]
	private TextBox _txt6;

	[AccessedThroughProperty("p21")]
	private PictureBox _p21;

	[AccessedThroughProperty("p19")]
	private PictureBox _p19;

	[AccessedThroughProperty("cmdStart")]
	private Button _cmdStart;

	private IContainer components;

	private Application app;

	private Connection cnn;

	private Recordset rst;

	private string[] getPic;

	private int[] getRand;

	private int[] getCheck;

	private string[] gP;

	private int[] gC;

	private Image[] getImg;

	private int gCh;

	private int mn;

	private int score;

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

	internal virtual GroupBox GroupBox3
	{
		get
		{
			return _GroupBox3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_GroupBox3 != null)
			{
			}
			_GroupBox3 = value;
			if (_GroupBox3 == null)
			{
			}
		}
	}

	internal virtual Button cmdClose
	{
		get
		{
			return _cmdClose;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdClose != null)
			{
				_cmdClose.Click -= cmdClose_Click;
			}
			_cmdClose = value;
			if (_cmdClose != null)
			{
				_cmdClose.Click += cmdClose_Click;
			}
		}
	}

	internal virtual PictureBox p1
	{
		get
		{
			return _p1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p1 != null)
			{
				_p1.MouseEnter -= p1_MouseEnter;
				_p1.DragEnter -= p1_DragEnter;
				_p1.MouseDown -= p1_MouseDown;
			}
			_p1 = value;
			if (_p1 != null)
			{
				_p1.MouseEnter += p1_MouseEnter;
				_p1.DragEnter += p1_DragEnter;
				_p1.MouseDown += p1_MouseDown;
			}
		}
	}

	internal virtual PictureBox p2
	{
		get
		{
			return _p2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p2 != null)
			{
				_p2.MouseEnter -= p2_MouseEnter;
				_p2.DragEnter -= p2_DragEnter;
				_p2.MouseDown -= p2_MouseDown;
			}
			_p2 = value;
			if (_p2 != null)
			{
				_p2.MouseEnter += p2_MouseEnter;
				_p2.DragEnter += p2_DragEnter;
				_p2.MouseDown += p2_MouseDown;
			}
		}
	}

	internal virtual PictureBox p3
	{
		get
		{
			return _p3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p3 != null)
			{
				_p3.MouseEnter -= p3_MouseEnter;
				_p3.DragEnter -= p3_DragEnter;
				_p3.MouseDown -= p3_MouseDown;
			}
			_p3 = value;
			if (_p3 != null)
			{
				_p3.MouseEnter += p3_MouseEnter;
				_p3.DragEnter += p3_DragEnter;
				_p3.MouseDown += p3_MouseDown;
			}
		}
	}

	internal virtual PictureBox p4
	{
		get
		{
			return _p4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p4 != null)
			{
				_p4.MouseEnter -= p4_MouseEnter;
				_p4.MouseDown -= p4_MouseDown;
			}
			_p4 = value;
			if (_p4 != null)
			{
				_p4.MouseEnter += p4_MouseEnter;
				_p4.MouseDown += p4_MouseDown;
			}
		}
	}

	internal virtual PictureBox p5
	{
		get
		{
			return _p5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p5 != null)
			{
				_p5.MouseEnter -= p5_MouseEnter;
				_p5.MouseDown -= p5_MouseDown;
			}
			_p5 = value;
			if (_p5 != null)
			{
				_p5.MouseEnter += p5_MouseEnter;
				_p5.MouseDown += p5_MouseDown;
			}
		}
	}

	internal virtual PictureBox p6
	{
		get
		{
			return _p6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p6 != null)
			{
				_p6.MouseEnter -= p6_MouseEnter;
				_p6.MouseDown -= p6_MouseDown;
			}
			_p6 = value;
			if (_p6 != null)
			{
				_p6.MouseEnter += p6_MouseEnter;
				_p6.MouseDown += p6_MouseDown;
			}
		}
	}

	internal virtual PictureBox p11
	{
		get
		{
			return _p11;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p11 != null)
			{
				_p11.MouseEnter -= p11_MouseEnter;
				_p11.DragEnter -= p11_DragEnter;
				_p11.MouseDown -= p11_MouseDown;
			}
			_p11 = value;
			if (_p11 != null)
			{
				_p11.MouseEnter += p11_MouseEnter;
				_p11.DragEnter += p11_DragEnter;
				_p11.MouseDown += p11_MouseDown;
			}
		}
	}

	internal virtual PictureBox p9
	{
		get
		{
			return _p9;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p9 != null)
			{
				_p9.MouseEnter -= p9_MouseEnter;
				_p9.MouseDown -= p9_MouseDown;
			}
			_p9 = value;
			if (_p9 != null)
			{
				_p9.MouseEnter += p9_MouseEnter;
				_p9.MouseDown += p9_MouseDown;
			}
		}
	}

	internal virtual PictureBox p7
	{
		get
		{
			return _p7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p7 != null)
			{
				_p7.MouseEnter -= p7_MouseEnter;
				_p7.MouseDown -= p7_MouseDown;
			}
			_p7 = value;
			if (_p7 != null)
			{
				_p7.MouseEnter += p7_MouseEnter;
				_p7.MouseDown += p7_MouseDown;
			}
		}
	}

	internal virtual PictureBox p8
	{
		get
		{
			return _p8;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p8 != null)
			{
				_p8.MouseEnter -= p8_MouseEnter;
				_p8.MouseDown -= p8_MouseDown;
			}
			_p8 = value;
			if (_p8 != null)
			{
				_p8.MouseEnter += p8_MouseEnter;
				_p8.MouseDown += p8_MouseDown;
			}
		}
	}

	internal virtual PictureBox p10
	{
		get
		{
			return _p10;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p10 != null)
			{
				_p10.MouseEnter -= p10_MouseEnter;
				_p10.DragEnter -= p10_DragEnter;
				_p10.MouseDown -= p10_MouseDown;
			}
			_p10 = value;
			if (_p10 != null)
			{
				_p10.MouseEnter += p10_MouseEnter;
				_p10.DragEnter += p10_DragEnter;
				_p10.MouseDown += p10_MouseDown;
			}
		}
	}

	internal virtual PictureBox p12
	{
		get
		{
			return _p12;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p12 != null)
			{
				_p12.MouseEnter -= p12_MouseEnter;
				_p12.DragEnter -= p12_DragEnter;
				_p12.MouseDown -= p12_MouseDown;
			}
			_p12 = value;
			if (_p12 != null)
			{
				_p12.MouseEnter += p12_MouseEnter;
				_p12.DragEnter += p12_DragEnter;
				_p12.MouseDown += p12_MouseDown;
			}
		}
	}

	internal virtual PictureBox p15
	{
		get
		{
			return _p15;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p15 != null)
			{
				_p15.MouseEnter -= p15_MouseEnter;
				_p15.DragEnter -= p15_DragEnter;
				_p15.MouseDown -= p15_MouseDown;
			}
			_p15 = value;
			if (_p15 != null)
			{
				_p15.MouseEnter += p15_MouseEnter;
				_p15.DragEnter += p15_DragEnter;
				_p15.MouseDown += p15_MouseDown;
			}
		}
	}

	internal virtual PictureBox p17
	{
		get
		{
			return _p17;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p17 != null)
			{
				_p17.MouseEnter -= p17_MouseEnter;
				_p17.DragEnter -= p17_DragEnter;
				_p17.MouseDown -= p17_MouseDown;
			}
			_p17 = value;
			if (_p17 != null)
			{
				_p17.MouseEnter += p17_MouseEnter;
				_p17.DragEnter += p17_DragEnter;
				_p17.MouseDown += p17_MouseDown;
			}
		}
	}

	internal virtual PictureBox p18
	{
		get
		{
			return _p18;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p18 != null)
			{
				_p18.MouseEnter -= p18_MouseEnter;
				_p18.DragEnter -= p18_DragEnter;
				_p18.MouseDown -= p18_MouseDown;
			}
			_p18 = value;
			if (_p18 != null)
			{
				_p18.MouseEnter += p18_MouseEnter;
				_p18.DragEnter += p18_DragEnter;
				_p18.MouseDown += p18_MouseDown;
			}
		}
	}

	internal virtual PictureBox p16
	{
		get
		{
			return _p16;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p16 != null)
			{
				_p16.MouseEnter -= p16_MouseEnter;
				_p16.DragEnter -= p16_DragEnter;
				_p16.MouseDown -= p16_MouseDown;
			}
			_p16 = value;
			if (_p16 != null)
			{
				_p16.MouseEnter += p16_MouseEnter;
				_p16.DragEnter += p16_DragEnter;
				_p16.MouseDown += p16_MouseDown;
			}
		}
	}

	internal virtual PictureBox p14
	{
		get
		{
			return _p14;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p14 != null)
			{
				_p14.MouseEnter -= p14_MouseEnter;
				_p14.DragEnter -= p14_DragEnter;
				_p14.MouseDown -= p14_MouseDown;
			}
			_p14 = value;
			if (_p14 != null)
			{
				_p14.MouseEnter += p14_MouseEnter;
				_p14.DragEnter += p14_DragEnter;
				_p14.MouseDown += p14_MouseDown;
			}
		}
	}

	internal virtual PictureBox p13
	{
		get
		{
			return _p13;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p13 != null)
			{
				_p13.MouseEnter -= p13_MouseEnter;
				_p13.DragEnter -= p13_DragEnter;
				_p13.MouseDown -= p13_MouseDown;
			}
			_p13 = value;
			if (_p13 != null)
			{
				_p13.MouseEnter += p13_MouseEnter;
				_p13.DragEnter += p13_DragEnter;
				_p13.MouseDown += p13_MouseDown;
			}
		}
	}

	internal virtual PictureBox p22
	{
		get
		{
			return _p22;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p22 != null)
			{
				_p22.MouseEnter -= p22_MouseEnter;
				_p22.DragEnter -= p22_DragEnter;
				_p22.MouseDown -= p22_MouseDown;
			}
			_p22 = value;
			if (_p22 != null)
			{
				_p22.MouseEnter += p22_MouseEnter;
				_p22.DragEnter += p22_DragEnter;
				_p22.MouseDown += p22_MouseDown;
			}
		}
	}

	internal virtual PictureBox p24
	{
		get
		{
			return _p24;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p24 != null)
			{
				_p24.MouseEnter -= p24_MouseEnter;
				_p24.DragEnter -= p24_DragEnter;
				_p24.MouseDown -= p24_MouseDown;
			}
			_p24 = value;
			if (_p24 != null)
			{
				_p24.MouseEnter += p24_MouseEnter;
				_p24.DragEnter += p24_DragEnter;
				_p24.MouseDown += p24_MouseDown;
			}
		}
	}

	internal virtual PictureBox p23
	{
		get
		{
			return _p23;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p23 != null)
			{
				_p23.MouseEnter -= p23_MouseEnter;
				_p23.DragEnter -= p23_DragEnter;
				_p23.MouseDown -= p23_MouseDown;
			}
			_p23 = value;
			if (_p23 != null)
			{
				_p23.MouseEnter += p23_MouseEnter;
				_p23.DragEnter += p23_DragEnter;
				_p23.MouseDown += p23_MouseDown;
			}
		}
	}

	internal virtual PictureBox p21
	{
		get
		{
			return _p21;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p21 != null)
			{
				_p21.MouseEnter -= p21_MouseEnter;
				_p21.DragEnter -= p21_DragEnter;
				_p21.MouseDown -= p21_MouseDown;
			}
			_p21 = value;
			if (_p21 != null)
			{
				_p21.MouseEnter += p21_MouseEnter;
				_p21.DragEnter += p21_DragEnter;
				_p21.MouseDown += p21_MouseDown;
			}
		}
	}

	internal virtual PictureBox p19
	{
		get
		{
			return _p19;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p19 != null)
			{
				_p19.MouseEnter -= p19_MouseEnter;
				_p19.DragEnter -= p19_DragEnter;
				_p19.MouseDown -= p19_MouseDown;
			}
			_p19 = value;
			if (_p19 != null)
			{
				_p19.MouseEnter += p19_MouseEnter;
				_p19.DragEnter += p19_DragEnter;
				_p19.MouseDown += p19_MouseDown;
			}
		}
	}

	internal virtual PictureBox p20
	{
		get
		{
			return _p20;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p20 != null)
			{
				_p20.MouseEnter -= p20_MouseEnter;
				_p20.DragEnter -= p20_DragEnter;
				_p20.MouseDown -= p20_MouseDown;
			}
			_p20 = value;
			if (_p20 != null)
			{
				_p20.MouseEnter += p20_MouseEnter;
				_p20.DragEnter += p20_DragEnter;
				_p20.MouseDown += p20_MouseDown;
			}
		}
	}

	internal virtual PictureBox p26
	{
		get
		{
			return _p26;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p26 != null)
			{
				_p26.MouseEnter -= p26_MouseEnter;
				_p26.DragEnter -= p26_DragEnter;
				_p26.MouseDown -= p26_MouseDown;
			}
			_p26 = value;
			if (_p26 != null)
			{
				_p26.MouseEnter += p26_MouseEnter;
				_p26.DragEnter += p26_DragEnter;
				_p26.MouseDown += p26_MouseDown;
			}
		}
	}

	internal virtual PictureBox p25
	{
		get
		{
			return _p25;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p25 != null)
			{
				_p25.MouseEnter -= p25_MouseEnter;
				_p25.DragEnter -= p25_DragEnter;
				_p25.MouseDown -= p25_MouseDown;
			}
			_p25 = value;
			if (_p25 != null)
			{
				_p25.MouseEnter += p25_MouseEnter;
				_p25.DragEnter += p25_DragEnter;
				_p25.MouseDown += p25_MouseDown;
			}
		}
	}

	internal virtual PictureBox p27
	{
		get
		{
			return _p27;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p27 != null)
			{
				_p27.MouseEnter -= p27_MouseEnter;
				_p27.DragEnter -= p27_DragEnter;
				_p27.MouseDown -= p27_MouseDown;
			}
			_p27 = value;
			if (_p27 != null)
			{
				_p27.MouseEnter += p27_MouseEnter;
				_p27.DragEnter += p27_DragEnter;
				_p27.MouseDown += p27_MouseDown;
			}
		}
	}

	internal virtual PictureBox p29
	{
		get
		{
			return _p29;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p29 != null)
			{
				_p29.MouseEnter -= p29_MouseEnter;
				_p29.DragEnter -= p29_DragEnter;
				_p29.MouseDown -= p29_MouseDown;
			}
			_p29 = value;
			if (_p29 != null)
			{
				_p29.MouseEnter += p29_MouseEnter;
				_p29.DragEnter += p29_DragEnter;
				_p29.MouseDown += p29_MouseDown;
			}
		}
	}

	internal virtual PictureBox p30
	{
		get
		{
			return _p30;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p30 != null)
			{
				_p30.MouseEnter -= p30_MouseEnter;
				_p30.DragEnter -= p30_DragEnter;
				_p30.MouseDown -= p30_MouseDown;
			}
			_p30 = value;
			if (_p30 != null)
			{
				_p30.MouseEnter += p30_MouseEnter;
				_p30.DragEnter += p30_DragEnter;
				_p30.MouseDown += p30_MouseDown;
			}
		}
	}

	internal virtual PictureBox p28
	{
		get
		{
			return _p28;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p28 != null)
			{
				_p28.MouseEnter -= p28_MouseEnter;
				_p28.DragEnter -= p28_DragEnter;
				_p28.MouseDown -= p28_MouseDown;
			}
			_p28 = value;
			if (_p28 != null)
			{
				_p28.MouseEnter += p28_MouseEnter;
				_p28.DragEnter += p28_DragEnter;
				_p28.MouseDown += p28_MouseDown;
			}
		}
	}

	internal virtual PictureBox p33
	{
		get
		{
			return _p33;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p33 != null)
			{
				_p33.MouseEnter -= p33_MouseEnter;
				_p33.DragEnter -= p33_DragEnter;
				_p33.MouseDown -= p33_MouseDown;
			}
			_p33 = value;
			if (_p33 != null)
			{
				_p33.MouseEnter += p33_MouseEnter;
				_p33.DragEnter += p33_DragEnter;
				_p33.MouseDown += p33_MouseDown;
			}
		}
	}

	internal virtual PictureBox p31
	{
		get
		{
			return _p31;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p31 != null)
			{
				_p31.MouseEnter -= p31_MouseEnter;
				_p31.DragEnter -= p31_DragEnter;
				_p31.MouseDown -= p31_MouseDown;
			}
			_p31 = value;
			if (_p31 != null)
			{
				_p31.MouseEnter += p31_MouseEnter;
				_p31.DragEnter += p31_DragEnter;
				_p31.MouseDown += p31_MouseDown;
			}
		}
	}

	internal virtual PictureBox p32
	{
		get
		{
			return _p32;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_p32 != null)
			{
				_p32.MouseEnter -= p32_MouseEnter;
				_p32.DragEnter -= p32_DragEnter;
				_p32.MouseDown -= p32_MouseDown;
			}
			_p32 = value;
			if (_p32 != null)
			{
				_p32.MouseEnter += p32_MouseEnter;
				_p32.DragEnter += p32_DragEnter;
				_p32.MouseDown += p32_MouseDown;
			}
		}
	}

	internal virtual PictureBox pic1
	{
		get
		{
			return _pic1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic1 != null)
			{
				_pic1.Click -= pic1_Click;
				_pic1.MouseEnter -= pic1_MouseEnter;
				_pic1.DragEnter -= pic1_DragEnter;
				_pic1.DragDrop -= pic1_DragDrop;
			}
			_pic1 = value;
			if (_pic1 != null)
			{
				_pic1.Click += pic1_Click;
				_pic1.MouseEnter += pic1_MouseEnter;
				_pic1.DragEnter += pic1_DragEnter;
				_pic1.DragDrop += pic1_DragDrop;
			}
		}
	}

	internal virtual PictureBox pic2
	{
		get
		{
			return _pic2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic2 != null)
			{
				_pic2.MouseEnter -= pic2_MouseEnter;
				_pic2.DragEnter -= pic2_DragEnter;
				_pic2.DragDrop -= pic2_DragDrop;
			}
			_pic2 = value;
			if (_pic2 != null)
			{
				_pic2.MouseEnter += pic2_MouseEnter;
				_pic2.DragEnter += pic2_DragEnter;
				_pic2.DragDrop += pic2_DragDrop;
			}
		}
	}

	internal virtual PictureBox pic3
	{
		get
		{
			return _pic3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic3 != null)
			{
				_pic3.MouseEnter -= pic3_MouseEnter;
				_pic3.DragEnter -= pic3_DragEnter;
				_pic3.DragDrop -= pic3_DragDrop;
			}
			_pic3 = value;
			if (_pic3 != null)
			{
				_pic3.MouseEnter += pic3_MouseEnter;
				_pic3.DragEnter += pic3_DragEnter;
				_pic3.DragDrop += pic3_DragDrop;
			}
		}
	}

	internal virtual PictureBox pic4
	{
		get
		{
			return _pic4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic4 != null)
			{
				_pic4.MouseEnter -= pic4_MouseEnter;
				_pic4.DragEnter -= pic4_DragEnter;
				_pic4.DragDrop -= pic4_DragDrop;
			}
			_pic4 = value;
			if (_pic4 != null)
			{
				_pic4.MouseEnter += pic4_MouseEnter;
				_pic4.DragEnter += pic4_DragEnter;
				_pic4.DragDrop += pic4_DragDrop;
			}
		}
	}

	internal virtual PictureBox pic5
	{
		get
		{
			return _pic5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_pic5 != null)
			{
				_pic5.MouseEnter -= pic5_MouseEnter;
				_pic5.DragEnter -= pic5_DragEnter;
				_pic5.DragDrop -= pic5_DragDrop;
			}
			_pic5 = value;
			if (_pic5 != null)
			{
				_pic5.MouseEnter += pic5_MouseEnter;
				_pic5.DragEnter += pic5_DragEnter;
				_pic5.DragDrop += pic5_DragDrop;
			}
		}
	}

	internal virtual Button cmdCheck
	{
		get
		{
			return _cmdCheck;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdCheck != null)
			{
				_cmdCheck.Click -= cmdCheck_Click;
			}
			_cmdCheck = value;
			if (_cmdCheck != null)
			{
				_cmdCheck.Click += cmdCheck_Click;
			}
		}
	}

	internal virtual TextBox txt1
	{
		get
		{
			return _txt1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt1 != null)
			{
			}
			_txt1 = value;
			if (_txt1 == null)
			{
			}
		}
	}

	internal virtual TextBox txt2
	{
		get
		{
			return _txt2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt2 != null)
			{
			}
			_txt2 = value;
			if (_txt2 == null)
			{
			}
		}
	}

	internal virtual TextBox txt3
	{
		get
		{
			return _txt3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt3 != null)
			{
			}
			_txt3 = value;
			if (_txt3 == null)
			{
			}
		}
	}

	internal virtual TextBox txt7
	{
		get
		{
			return _txt7;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt7 != null)
			{
			}
			_txt7 = value;
			if (_txt7 == null)
			{
			}
		}
	}

	internal virtual TextBox txt6
	{
		get
		{
			return _txt6;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt6 != null)
			{
			}
			_txt6 = value;
			if (_txt6 == null)
			{
			}
		}
	}

	internal virtual TextBox txt5
	{
		get
		{
			return _txt5;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt5 != null)
			{
			}
			_txt5 = value;
			if (_txt5 == null)
			{
			}
		}
	}

	internal virtual TextBox txt4
	{
		get
		{
			return _txt4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txt4 != null)
			{
			}
			_txt4 = value;
			if (_txt4 == null)
			{
			}
		}
	}

	internal virtual TextBox txtTime
	{
		get
		{
			return _txtTime;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_txtTime != null)
			{
			}
			_txtTime = value;
			if (_txtTime == null)
			{
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

	internal virtual Label lblTest
	{
		get
		{
			return _lblTest;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_lblTest != null)
			{
			}
			_lblTest = value;
			if (_lblTest == null)
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

	internal virtual Timer Timer1
	{
		get
		{
			return _Timer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_Timer1 != null)
			{
				_Timer1.Tick -= Timer1_Tick;
			}
			_Timer1 = value;
			if (_Timer1 != null)
			{
				_Timer1.Tick += Timer1_Tick;
			}
		}
	}

	internal virtual Button cmdStart
	{
		get
		{
			return _cmdStart;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			if (_cmdStart != null)
			{
				_cmdStart.Click -= cmdStart_Click;
			}
			_cmdStart = value;
			if (_cmdStart != null)
			{
				_cmdStart.Click += cmdStart_Click;
			}
		}
	}

	public frmTest()
	{
		base.Load += frmTest_Load;
		base.Resize += frmTest_Resize;
		cnn = new ConnectionClass();
		rst = new RecordsetClass();
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
		this.lblTest = new System.Windows.Forms.Label();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.Label2 = new System.Windows.Forms.Label();
		this.p1 = new System.Windows.Forms.PictureBox();
		this.p2 = new System.Windows.Forms.PictureBox();
		this.p3 = new System.Windows.Forms.PictureBox();
		this.p4 = new System.Windows.Forms.PictureBox();
		this.p5 = new System.Windows.Forms.PictureBox();
		this.p6 = new System.Windows.Forms.PictureBox();
		this.p12 = new System.Windows.Forms.PictureBox();
		this.p11 = new System.Windows.Forms.PictureBox();
		this.p9 = new System.Windows.Forms.PictureBox();
		this.p7 = new System.Windows.Forms.PictureBox();
		this.p8 = new System.Windows.Forms.PictureBox();
		this.p10 = new System.Windows.Forms.PictureBox();
		this.p15 = new System.Windows.Forms.PictureBox();
		this.p17 = new System.Windows.Forms.PictureBox();
		this.p18 = new System.Windows.Forms.PictureBox();
		this.p16 = new System.Windows.Forms.PictureBox();
		this.p14 = new System.Windows.Forms.PictureBox();
		this.p13 = new System.Windows.Forms.PictureBox();
		this.p22 = new System.Windows.Forms.PictureBox();
		this.p24 = new System.Windows.Forms.PictureBox();
		this.p23 = new System.Windows.Forms.PictureBox();
		this.p21 = new System.Windows.Forms.PictureBox();
		this.p19 = new System.Windows.Forms.PictureBox();
		this.p20 = new System.Windows.Forms.PictureBox();
		this.p26 = new System.Windows.Forms.PictureBox();
		this.p25 = new System.Windows.Forms.PictureBox();
		this.p27 = new System.Windows.Forms.PictureBox();
		this.p29 = new System.Windows.Forms.PictureBox();
		this.p30 = new System.Windows.Forms.PictureBox();
		this.p28 = new System.Windows.Forms.PictureBox();
		this.p33 = new System.Windows.Forms.PictureBox();
		this.p31 = new System.Windows.Forms.PictureBox();
		this.p32 = new System.Windows.Forms.PictureBox();
		this.GroupBox2 = new System.Windows.Forms.GroupBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.txtTime = new System.Windows.Forms.TextBox();
		this.cmdCheck = new System.Windows.Forms.Button();
		this.pic1 = new System.Windows.Forms.PictureBox();
		this.pic2 = new System.Windows.Forms.PictureBox();
		this.pic3 = new System.Windows.Forms.PictureBox();
		this.pic4 = new System.Windows.Forms.PictureBox();
		this.pic5 = new System.Windows.Forms.PictureBox();
		this.cmdClear = new System.Windows.Forms.Button();
		this.cmdStart = new System.Windows.Forms.Button();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.cmdClose = new System.Windows.Forms.Button();
		this.txt1 = new System.Windows.Forms.TextBox();
		this.txt2 = new System.Windows.Forms.TextBox();
		this.txt3 = new System.Windows.Forms.TextBox();
		this.txt7 = new System.Windows.Forms.TextBox();
		this.txt6 = new System.Windows.Forms.TextBox();
		this.txt5 = new System.Windows.Forms.TextBox();
		this.txt4 = new System.Windows.Forms.TextBox();
		this.Timer1 = new System.Windows.Forms.Timer(this.components);
		this.GroupBox1.SuspendLayout();
		this.GroupBox2.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.SuspendLayout();
		this.lblTest.BackColor = System.Drawing.Color.SteelBlue;
		this.lblTest.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		this.lblTest.ForeColor = System.Drawing.SystemColors.ControlLightLight;
		System.Windows.Forms.Label label = this.lblTest;
		System.Drawing.Point location = new System.Drawing.Point(0, 0);
		label.Location = location;
		this.lblTest.Name = "lblTest";
		System.Windows.Forms.Label label2 = this.lblTest;
		System.Drawing.Size size = new System.Drawing.Size(720, 40);
		label2.Size = size;
		this.lblTest.TabIndex = 28;
		this.lblTest.Text = "Test :: May be you have known that there are 33 Khmer consonants. The consonant devide into 7 parts that each part has 5 consonants and the 7th part has 3 consonants. Now you must classify them into its group.";
		this.lblTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.p1);
		this.GroupBox1.Controls.Add(this.p2);
		this.GroupBox1.Controls.Add(this.p3);
		this.GroupBox1.Controls.Add(this.p4);
		this.GroupBox1.Controls.Add(this.p5);
		this.GroupBox1.Controls.Add(this.p6);
		this.GroupBox1.Controls.Add(this.p12);
		this.GroupBox1.Controls.Add(this.p11);
		this.GroupBox1.Controls.Add(this.p9);
		this.GroupBox1.Controls.Add(this.p7);
		this.GroupBox1.Controls.Add(this.p8);
		this.GroupBox1.Controls.Add(this.p10);
		this.GroupBox1.Controls.Add(this.p15);
		this.GroupBox1.Controls.Add(this.p17);
		this.GroupBox1.Controls.Add(this.p18);
		this.GroupBox1.Controls.Add(this.p16);
		this.GroupBox1.Controls.Add(this.p14);
		this.GroupBox1.Controls.Add(this.p13);
		this.GroupBox1.Controls.Add(this.p22);
		this.GroupBox1.Controls.Add(this.p24);
		this.GroupBox1.Controls.Add(this.p23);
		this.GroupBox1.Controls.Add(this.p21);
		this.GroupBox1.Controls.Add(this.p19);
		this.GroupBox1.Controls.Add(this.p20);
		this.GroupBox1.Controls.Add(this.p26);
		this.GroupBox1.Controls.Add(this.p25);
		this.GroupBox1.Controls.Add(this.p27);
		this.GroupBox1.Controls.Add(this.p29);
		this.GroupBox1.Controls.Add(this.p30);
		this.GroupBox1.Controls.Add(this.p28);
		this.GroupBox1.Controls.Add(this.p33);
		this.GroupBox1.Controls.Add(this.p31);
		this.GroupBox1.Controls.Add(this.p32);
		this.GroupBox1.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox1.ForeColor = System.Drawing.Color.IndianRed;
		System.Windows.Forms.GroupBox groupBox = this.GroupBox1;
		location = new System.Drawing.Point(8, 48);
		groupBox.Location = location;
		this.GroupBox1.Name = "GroupBox1";
		System.Windows.Forms.GroupBox groupBox2 = this.GroupBox1;
		size = new System.Drawing.Size(488, 440);
		groupBox2.Size = size;
		this.GroupBox1.TabIndex = 30;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "1- The consonants are not in order, use your memory to classify them";
		this.Label2.BackColor = System.Drawing.SystemColors.Info;
		this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.Label label3 = this.Label2;
		location = new System.Drawing.Point(280, 376);
		label3.Location = location;
		this.Label2.Name = "Label2";
		System.Windows.Forms.Label label4 = this.Label2;
		size = new System.Drawing.Size(152, 40);
		label4.Size = size;
		this.Label2.TabIndex = 1;
		this.Label2.Text = "Drag a consonant and put to the Classify";
		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.p1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox = this.p1;
		location = new System.Drawing.Point(8, 19);
		pictureBox.Location = location;
		this.p1.Name = "p1";
		System.Windows.Forms.PictureBox pictureBox2 = this.p1;
		size = new System.Drawing.Size(72, 64);
		pictureBox2.Size = size;
		this.p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p1.TabIndex = 0;
		this.p1.TabStop = false;
		this.p2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox3 = this.p2;
		location = new System.Drawing.Point(88, 19);
		pictureBox3.Location = location;
		this.p2.Name = "p2";
		System.Windows.Forms.PictureBox pictureBox4 = this.p2;
		size = new System.Drawing.Size(72, 64);
		pictureBox4.Size = size;
		this.p2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p2.TabIndex = 0;
		this.p2.TabStop = false;
		this.p3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox5 = this.p3;
		location = new System.Drawing.Point(168, 19);
		pictureBox5.Location = location;
		this.p3.Name = "p3";
		System.Windows.Forms.PictureBox pictureBox6 = this.p3;
		size = new System.Drawing.Size(72, 64);
		pictureBox6.Size = size;
		this.p3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p3.TabIndex = 0;
		this.p3.TabStop = false;
		this.p4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox7 = this.p4;
		location = new System.Drawing.Point(248, 19);
		pictureBox7.Location = location;
		this.p4.Name = "p4";
		System.Windows.Forms.PictureBox pictureBox8 = this.p4;
		size = new System.Drawing.Size(72, 64);
		pictureBox8.Size = size;
		this.p4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p4.TabIndex = 0;
		this.p4.TabStop = false;
		this.p5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox9 = this.p5;
		location = new System.Drawing.Point(328, 19);
		pictureBox9.Location = location;
		this.p5.Name = "p5";
		System.Windows.Forms.PictureBox pictureBox10 = this.p5;
		size = new System.Drawing.Size(72, 64);
		pictureBox10.Size = size;
		this.p5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p5.TabIndex = 0;
		this.p5.TabStop = false;
		this.p6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox11 = this.p6;
		location = new System.Drawing.Point(408, 19);
		pictureBox11.Location = location;
		this.p6.Name = "p6";
		System.Windows.Forms.PictureBox pictureBox12 = this.p6;
		size = new System.Drawing.Size(72, 64);
		pictureBox12.Size = size;
		this.p6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p6.TabIndex = 0;
		this.p6.TabStop = false;
		this.p12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox13 = this.p12;
		location = new System.Drawing.Point(408, 88);
		pictureBox13.Location = location;
		this.p12.Name = "p12";
		System.Windows.Forms.PictureBox pictureBox14 = this.p12;
		size = new System.Drawing.Size(72, 64);
		pictureBox14.Size = size;
		this.p12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p12.TabIndex = 0;
		this.p12.TabStop = false;
		this.p11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox15 = this.p11;
		location = new System.Drawing.Point(328, 88);
		pictureBox15.Location = location;
		this.p11.Name = "p11";
		System.Windows.Forms.PictureBox pictureBox16 = this.p11;
		size = new System.Drawing.Size(72, 64);
		pictureBox16.Size = size;
		this.p11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p11.TabIndex = 0;
		this.p11.TabStop = false;
		this.p9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox17 = this.p9;
		location = new System.Drawing.Point(168, 88);
		pictureBox17.Location = location;
		this.p9.Name = "p9";
		System.Windows.Forms.PictureBox pictureBox18 = this.p9;
		size = new System.Drawing.Size(72, 64);
		pictureBox18.Size = size;
		this.p9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p9.TabIndex = 0;
		this.p9.TabStop = false;
		this.p7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox19 = this.p7;
		location = new System.Drawing.Point(8, 88);
		pictureBox19.Location = location;
		this.p7.Name = "p7";
		System.Windows.Forms.PictureBox pictureBox20 = this.p7;
		size = new System.Drawing.Size(72, 64);
		pictureBox20.Size = size;
		this.p7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p7.TabIndex = 0;
		this.p7.TabStop = false;
		this.p8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox21 = this.p8;
		location = new System.Drawing.Point(88, 88);
		pictureBox21.Location = location;
		this.p8.Name = "p8";
		System.Windows.Forms.PictureBox pictureBox22 = this.p8;
		size = new System.Drawing.Size(72, 64);
		pictureBox22.Size = size;
		this.p8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p8.TabIndex = 0;
		this.p8.TabStop = false;
		this.p10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox23 = this.p10;
		location = new System.Drawing.Point(248, 88);
		pictureBox23.Location = location;
		this.p10.Name = "p10";
		System.Windows.Forms.PictureBox pictureBox24 = this.p10;
		size = new System.Drawing.Size(72, 64);
		pictureBox24.Size = size;
		this.p10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p10.TabIndex = 0;
		this.p10.TabStop = false;
		this.p15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox25 = this.p15;
		location = new System.Drawing.Point(168, 156);
		pictureBox25.Location = location;
		this.p15.Name = "p15";
		System.Windows.Forms.PictureBox pictureBox26 = this.p15;
		size = new System.Drawing.Size(72, 64);
		pictureBox26.Size = size;
		this.p15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p15.TabIndex = 0;
		this.p15.TabStop = false;
		this.p17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox27 = this.p17;
		location = new System.Drawing.Point(328, 156);
		pictureBox27.Location = location;
		this.p17.Name = "p17";
		System.Windows.Forms.PictureBox pictureBox28 = this.p17;
		size = new System.Drawing.Size(72, 64);
		pictureBox28.Size = size;
		this.p17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p17.TabIndex = 0;
		this.p17.TabStop = false;
		this.p18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox29 = this.p18;
		location = new System.Drawing.Point(408, 156);
		pictureBox29.Location = location;
		this.p18.Name = "p18";
		System.Windows.Forms.PictureBox pictureBox30 = this.p18;
		size = new System.Drawing.Size(72, 64);
		pictureBox30.Size = size;
		this.p18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p18.TabIndex = 0;
		this.p18.TabStop = false;
		this.p16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox31 = this.p16;
		location = new System.Drawing.Point(248, 156);
		pictureBox31.Location = location;
		this.p16.Name = "p16";
		System.Windows.Forms.PictureBox pictureBox32 = this.p16;
		size = new System.Drawing.Size(72, 64);
		pictureBox32.Size = size;
		this.p16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p16.TabIndex = 0;
		this.p16.TabStop = false;
		this.p14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox33 = this.p14;
		location = new System.Drawing.Point(88, 156);
		pictureBox33.Location = location;
		this.p14.Name = "p14";
		System.Windows.Forms.PictureBox pictureBox34 = this.p14;
		size = new System.Drawing.Size(72, 64);
		pictureBox34.Size = size;
		this.p14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p14.TabIndex = 0;
		this.p14.TabStop = false;
		this.p13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox35 = this.p13;
		location = new System.Drawing.Point(8, 156);
		pictureBox35.Location = location;
		this.p13.Name = "p13";
		System.Windows.Forms.PictureBox pictureBox36 = this.p13;
		size = new System.Drawing.Size(72, 64);
		pictureBox36.Size = size;
		this.p13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p13.TabIndex = 0;
		this.p13.TabStop = false;
		this.p22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox37 = this.p22;
		location = new System.Drawing.Point(248, 225);
		pictureBox37.Location = location;
		this.p22.Name = "p22";
		System.Windows.Forms.PictureBox pictureBox38 = this.p22;
		size = new System.Drawing.Size(72, 64);
		pictureBox38.Size = size;
		this.p22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p22.TabIndex = 0;
		this.p22.TabStop = false;
		this.p24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox39 = this.p24;
		location = new System.Drawing.Point(408, 225);
		pictureBox39.Location = location;
		this.p24.Name = "p24";
		System.Windows.Forms.PictureBox pictureBox40 = this.p24;
		size = new System.Drawing.Size(72, 64);
		pictureBox40.Size = size;
		this.p24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p24.TabIndex = 0;
		this.p24.TabStop = false;
		this.p23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox41 = this.p23;
		location = new System.Drawing.Point(328, 225);
		pictureBox41.Location = location;
		this.p23.Name = "p23";
		System.Windows.Forms.PictureBox pictureBox42 = this.p23;
		size = new System.Drawing.Size(72, 64);
		pictureBox42.Size = size;
		this.p23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p23.TabIndex = 0;
		this.p23.TabStop = false;
		this.p21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox43 = this.p21;
		location = new System.Drawing.Point(168, 225);
		pictureBox43.Location = location;
		this.p21.Name = "p21";
		System.Windows.Forms.PictureBox pictureBox44 = this.p21;
		size = new System.Drawing.Size(72, 64);
		pictureBox44.Size = size;
		this.p21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p21.TabIndex = 0;
		this.p21.TabStop = false;
		this.p19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox45 = this.p19;
		location = new System.Drawing.Point(8, 225);
		pictureBox45.Location = location;
		this.p19.Name = "p19";
		System.Windows.Forms.PictureBox pictureBox46 = this.p19;
		size = new System.Drawing.Size(72, 64);
		pictureBox46.Size = size;
		this.p19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p19.TabIndex = 0;
		this.p19.TabStop = false;
		this.p20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox47 = this.p20;
		location = new System.Drawing.Point(88, 225);
		pictureBox47.Location = location;
		this.p20.Name = "p20";
		System.Windows.Forms.PictureBox pictureBox48 = this.p20;
		size = new System.Drawing.Size(72, 64);
		pictureBox48.Size = size;
		this.p20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p20.TabIndex = 0;
		this.p20.TabStop = false;
		this.p26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox49 = this.p26;
		location = new System.Drawing.Point(88, 295);
		pictureBox49.Location = location;
		this.p26.Name = "p26";
		System.Windows.Forms.PictureBox pictureBox50 = this.p26;
		size = new System.Drawing.Size(72, 64);
		pictureBox50.Size = size;
		this.p26.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p26.TabIndex = 0;
		this.p26.TabStop = false;
		this.p25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox51 = this.p25;
		location = new System.Drawing.Point(8, 295);
		pictureBox51.Location = location;
		this.p25.Name = "p25";
		System.Windows.Forms.PictureBox pictureBox52 = this.p25;
		size = new System.Drawing.Size(72, 64);
		pictureBox52.Size = size;
		this.p25.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p25.TabIndex = 0;
		this.p25.TabStop = false;
		this.p27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox53 = this.p27;
		location = new System.Drawing.Point(168, 295);
		pictureBox53.Location = location;
		this.p27.Name = "p27";
		System.Windows.Forms.PictureBox pictureBox54 = this.p27;
		size = new System.Drawing.Size(72, 64);
		pictureBox54.Size = size;
		this.p27.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p27.TabIndex = 0;
		this.p27.TabStop = false;
		this.p29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox55 = this.p29;
		location = new System.Drawing.Point(328, 295);
		pictureBox55.Location = location;
		this.p29.Name = "p29";
		System.Windows.Forms.PictureBox pictureBox56 = this.p29;
		size = new System.Drawing.Size(72, 64);
		pictureBox56.Size = size;
		this.p29.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p29.TabIndex = 0;
		this.p29.TabStop = false;
		this.p30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox57 = this.p30;
		location = new System.Drawing.Point(408, 295);
		pictureBox57.Location = location;
		this.p30.Name = "p30";
		System.Windows.Forms.PictureBox pictureBox58 = this.p30;
		size = new System.Drawing.Size(72, 64);
		pictureBox58.Size = size;
		this.p30.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p30.TabIndex = 0;
		this.p30.TabStop = false;
		this.p28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox59 = this.p28;
		location = new System.Drawing.Point(248, 295);
		pictureBox59.Location = location;
		this.p28.Name = "p28";
		System.Windows.Forms.PictureBox pictureBox60 = this.p28;
		size = new System.Drawing.Size(72, 64);
		pictureBox60.Size = size;
		this.p28.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p28.TabIndex = 0;
		this.p28.TabStop = false;
		this.p33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox61 = this.p33;
		location = new System.Drawing.Point(168, 365);
		pictureBox61.Location = location;
		this.p33.Name = "p33";
		System.Windows.Forms.PictureBox pictureBox62 = this.p33;
		size = new System.Drawing.Size(72, 64);
		pictureBox62.Size = size;
		this.p33.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p33.TabIndex = 0;
		this.p33.TabStop = false;
		this.p31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox63 = this.p31;
		location = new System.Drawing.Point(8, 365);
		pictureBox63.Location = location;
		this.p31.Name = "p31";
		System.Windows.Forms.PictureBox pictureBox64 = this.p31;
		size = new System.Drawing.Size(72, 64);
		pictureBox64.Size = size;
		this.p31.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p31.TabIndex = 0;
		this.p31.TabStop = false;
		this.p32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox65 = this.p32;
		location = new System.Drawing.Point(88, 365);
		pictureBox65.Location = location;
		this.p32.Name = "p32";
		System.Windows.Forms.PictureBox pictureBox66 = this.p32;
		size = new System.Drawing.Size(72, 64);
		pictureBox66.Size = size;
		this.p32.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.p32.TabIndex = 0;
		this.p32.TabStop = false;
		this.GroupBox2.Controls.Add(this.Label1);
		this.GroupBox2.Controls.Add(this.txtTime);
		this.GroupBox2.Controls.Add(this.cmdCheck);
		this.GroupBox2.Controls.Add(this.pic1);
		this.GroupBox2.Controls.Add(this.pic2);
		this.GroupBox2.Controls.Add(this.pic3);
		this.GroupBox2.Controls.Add(this.pic4);
		this.GroupBox2.Controls.Add(this.pic5);
		this.GroupBox2.Controls.Add(this.cmdClear);
		this.GroupBox2.Controls.Add(this.cmdStart);
		this.GroupBox2.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox2.ForeColor = System.Drawing.Color.ForestGreen;
		System.Windows.Forms.GroupBox groupBox3 = this.GroupBox2;
		location = new System.Drawing.Point(504, 48);
		groupBox3.Location = location;
		this.GroupBox2.Name = "GroupBox2";
		System.Windows.Forms.GroupBox groupBox4 = this.GroupBox2;
		size = new System.Drawing.Size(248, 304);
		groupBox4.Size = size;
		this.GroupBox2.TabIndex = 31;
		this.GroupBox2.TabStop = false;
		this.GroupBox2.Text = "2- Consonants  :: Put [1] first";
		this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
		System.Windows.Forms.Label label5 = this.Label1;
		location = new System.Drawing.Point(102, 99);
		label5.Location = location;
		this.Label1.Name = "Label1";
		System.Windows.Forms.Label label6 = this.Label1;
		size = new System.Drawing.Size(24, 16);
		label6.Size = size;
		this.Label1.TabIndex = 3;
		this.Label1.Text = "1";
		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.txtTime.BackColor = System.Drawing.SystemColors.Info;
		this.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txtTime.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox = this.txtTime;
		location = new System.Drawing.Point(128, 272);
		textBox.Location = location;
		this.txtTime.Multiline = true;
		this.txtTime.Name = "txtTime";
		this.txtTime.ReadOnly = true;
		System.Windows.Forms.TextBox textBox2 = this.txtTime;
		size = new System.Drawing.Size(104, 24);
		textBox2.Size = size;
		this.txtTime.TabIndex = 2;
		this.txtTime.Text = "";
		this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.cmdCheck.BackColor = System.Drawing.SystemColors.ControlDark;
		this.cmdCheck.ForeColor = System.Drawing.Color.Azure;
		System.Windows.Forms.Button button = this.cmdCheck;
		location = new System.Drawing.Point(128, 240);
		button.Location = location;
		this.cmdCheck.Name = "cmdCheck";
		System.Windows.Forms.Button button2 = this.cmdCheck;
		size = new System.Drawing.Size(104, 24);
		button2.Size = size;
		this.cmdCheck.TabIndex = 1;
		this.cmdCheck.Text = "C&heck";
		this.pic1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox67 = this.pic1;
		location = new System.Drawing.Point(16, 24);
		pictureBox67.Location = location;
		this.pic1.Name = "pic1";
		System.Windows.Forms.PictureBox pictureBox68 = this.pic1;
		size = new System.Drawing.Size(104, 88);
		pictureBox68.Size = size;
		this.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pic1.TabIndex = 0;
		this.pic1.TabStop = false;
		this.pic2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox69 = this.pic2;
		location = new System.Drawing.Point(128, 24);
		pictureBox69.Location = location;
		this.pic2.Name = "pic2";
		System.Windows.Forms.PictureBox pictureBox70 = this.pic2;
		size = new System.Drawing.Size(104, 88);
		pictureBox70.Size = size;
		this.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pic2.TabIndex = 0;
		this.pic2.TabStop = false;
		this.pic3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox71 = this.pic3;
		location = new System.Drawing.Point(16, 117);
		pictureBox71.Location = location;
		this.pic3.Name = "pic3";
		System.Windows.Forms.PictureBox pictureBox72 = this.pic3;
		size = new System.Drawing.Size(104, 88);
		pictureBox72.Size = size;
		this.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pic3.TabIndex = 0;
		this.pic3.TabStop = false;
		this.pic4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox73 = this.pic4;
		location = new System.Drawing.Point(128, 117);
		pictureBox73.Location = location;
		this.pic4.Name = "pic4";
		System.Windows.Forms.PictureBox pictureBox74 = this.pic4;
		size = new System.Drawing.Size(104, 88);
		pictureBox74.Size = size;
		this.pic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pic4.TabIndex = 0;
		this.pic4.TabStop = false;
		this.pic5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		System.Windows.Forms.PictureBox pictureBox75 = this.pic5;
		location = new System.Drawing.Point(16, 210);
		pictureBox75.Location = location;
		this.pic5.Name = "pic5";
		System.Windows.Forms.PictureBox pictureBox76 = this.pic5;
		size = new System.Drawing.Size(104, 88);
		pictureBox76.Size = size;
		this.pic5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pic5.TabIndex = 0;
		this.pic5.TabStop = false;
		this.cmdClear.BackColor = System.Drawing.SystemColors.ControlDark;
		this.cmdClear.ForeColor = System.Drawing.Color.Azure;
		System.Windows.Forms.Button button3 = this.cmdClear;
		location = new System.Drawing.Point(176, 216);
		button3.Location = location;
		this.cmdClear.Name = "cmdClear";
		System.Windows.Forms.Button button4 = this.cmdClear;
		size = new System.Drawing.Size(56, 24);
		button4.Size = size;
		this.cmdClear.TabIndex = 1;
		this.cmdClear.Text = "Cl&ear";
		this.cmdStart.BackColor = System.Drawing.SystemColors.ControlDark;
		this.cmdStart.ForeColor = System.Drawing.Color.Azure;
		System.Windows.Forms.Button button5 = this.cmdStart;
		location = new System.Drawing.Point(128, 216);
		button5.Location = location;
		this.cmdStart.Name = "cmdStart";
		System.Windows.Forms.Button button6 = this.cmdStart;
		size = new System.Drawing.Size(48, 24);
		button6.Size = size;
		this.cmdStart.TabIndex = 1;
		this.cmdStart.Text = "&Start";
		this.GroupBox3.Controls.Add(this.cmdClose);
		this.GroupBox3.Controls.Add(this.txt1);
		this.GroupBox3.Controls.Add(this.txt2);
		this.GroupBox3.Controls.Add(this.txt3);
		this.GroupBox3.Controls.Add(this.txt7);
		this.GroupBox3.Controls.Add(this.txt6);
		this.GroupBox3.Controls.Add(this.txt5);
		this.GroupBox3.Controls.Add(this.txt4);
		this.GroupBox3.Font = new System.Drawing.Font("Arial", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.GroupBox3.ForeColor = System.Drawing.Color.Crimson;
		System.Windows.Forms.GroupBox groupBox5 = this.GroupBox3;
		location = new System.Drawing.Point(504, 352);
		groupBox5.Location = location;
		this.GroupBox3.Name = "GroupBox3";
		System.Windows.Forms.GroupBox groupBox6 = this.GroupBox3;
		size = new System.Drawing.Size(248, 136);
		groupBox6.Size = size;
		this.GroupBox3.TabIndex = 32;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Result";
		this.cmdClose.BackColor = System.Drawing.SystemColors.ControlDark;
		this.cmdClose.ForeColor = System.Drawing.Color.LavenderBlush;
		System.Windows.Forms.Button button7 = this.cmdClose;
		location = new System.Drawing.Point(128, 104);
		button7.Location = location;
		this.cmdClose.Name = "cmdClose";
		System.Windows.Forms.Button button8 = this.cmdClose;
		size = new System.Drawing.Size(112, 23);
		button8.Size = size;
		this.cmdClose.TabIndex = 1;
		this.cmdClose.Text = "&Close";
		this.txt1.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt1.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox3 = this.txt1;
		location = new System.Drawing.Point(8, 16);
		textBox3.Location = location;
		this.txt1.Name = "txt1";
		this.txt1.ReadOnly = true;
		System.Windows.Forms.TextBox textBox4 = this.txt1;
		size = new System.Drawing.Size(112, 27);
		textBox4.Size = size;
		this.txt1.TabIndex = 0;
		this.txt1.Text = "";
		this.txt2.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt2.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox5 = this.txt2;
		location = new System.Drawing.Point(8, 45);
		textBox5.Location = location;
		this.txt2.Name = "txt2";
		this.txt2.ReadOnly = true;
		System.Windows.Forms.TextBox textBox6 = this.txt2;
		size = new System.Drawing.Size(112, 27);
		textBox6.Size = size;
		this.txt2.TabIndex = 0;
		this.txt2.Text = "";
		this.txt3.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt3.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox7 = this.txt3;
		location = new System.Drawing.Point(8, 75);
		textBox7.Location = location;
		this.txt3.Name = "txt3";
		this.txt3.ReadOnly = true;
		System.Windows.Forms.TextBox textBox8 = this.txt3;
		size = new System.Drawing.Size(112, 27);
		textBox8.Size = size;
		this.txt3.TabIndex = 0;
		this.txt3.Text = "";
		this.txt7.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt7.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox9 = this.txt7;
		location = new System.Drawing.Point(129, 75);
		textBox9.Location = location;
		this.txt7.Name = "txt7";
		this.txt7.ReadOnly = true;
		System.Windows.Forms.TextBox textBox10 = this.txt7;
		size = new System.Drawing.Size(112, 27);
		textBox10.Size = size;
		this.txt7.TabIndex = 0;
		this.txt7.Text = "";
		this.txt6.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt6.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox11 = this.txt6;
		location = new System.Drawing.Point(129, 45);
		textBox11.Location = location;
		this.txt6.Name = "txt6";
		this.txt6.ReadOnly = true;
		System.Windows.Forms.TextBox textBox12 = this.txt6;
		size = new System.Drawing.Size(112, 27);
		textBox12.Size = size;
		this.txt6.TabIndex = 0;
		this.txt6.Text = "";
		this.txt5.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt5.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox13 = this.txt5;
		location = new System.Drawing.Point(129, 16);
		textBox13.Location = location;
		this.txt5.Name = "txt5";
		this.txt5.ReadOnly = true;
		System.Windows.Forms.TextBox textBox14 = this.txt5;
		size = new System.Drawing.Size(112, 27);
		textBox14.Size = size;
		this.txt5.TabIndex = 0;
		this.txt5.Text = "";
		this.txt4.BackColor = System.Drawing.SystemColors.HighlightText;
		this.txt4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.txt4.Font = new System.Drawing.Font("Khmer OS System", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		System.Windows.Forms.TextBox textBox15 = this.txt4;
		location = new System.Drawing.Point(8, 104);
		textBox15.Location = location;
		this.txt4.Name = "txt4";
		this.txt4.ReadOnly = true;
		System.Windows.Forms.TextBox textBox16 = this.txt4;
		size = new System.Drawing.Size(112, 27);
		textBox16.Size = size;
		this.txt4.TabIndex = 0;
		this.txt4.Text = "";
		this.Timer1.Interval = 1000;
		size = new System.Drawing.Size(5, 13);
		this.AutoScaleBaseSize = size;
		size = new System.Drawing.Size(758, 496);
		this.ClientSize = size;
		this.Controls.Add(this.GroupBox3);
		this.Controls.Add(this.GroupBox2);
		this.Controls.Add(this.GroupBox1);
		this.Controls.Add(this.lblTest);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.Name = "frmTest";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Test :: Classify the Consonants";
		this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
		this.GroupBox1.ResumeLayout(false);
		this.GroupBox2.ResumeLayout(false);
		this.GroupBox3.ResumeLayout(false);
		this.ResumeLayout(false);
	}

	private void cmdClose_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void frmTest_Load(object sender, EventArgs e)
	{
		getImg = new Image[33];
		Recordset recordset = new RecordsetClass();
		string connectionString = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=" + Application.StartupPath + "\\reankhmer.mdb";
		cnn.ConnectionString = connectionString;
		cnn.Open();
		string source = "Select * From tblTestLevel Where type=1";
		rst.Open(source, cnn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic);
		getRandPic();
		put33con();
		AllowDropPic();
		cmdClear_Click(RuntimeHelpers.GetObjectValue(sender), e);
		GroupBox1.Enabled = false;
		txtTime.Text = "300";
		mn = 300;
	}

	private bool checkRand(int num, int[] getR)
	{
		if (!Information.IsNothing((object)getR))
		{
			int num2 = Information.UBound((Array)getR, 1);
			for (int i = 0; i <= num2; i = checked(i + 1))
			{
				if (num == getR[i])
				{
					return false;
				}
			}
		}
		return true;
	}

	private void getRandPic()
	{
		getPic = null;
		getRand = null;
		int num = 0;
		checked
		{
			int num2 = rst.RecordCount - 1;
			VBMath.Randomize();
			while (true)
			{
				int num3 = (int)Math.Round(Conversion.Int((float)(num2 - num + 1) * VBMath.Rnd() + (float)num));
				if (checkRand(num3, getRand))
				{
					if (Information.IsNothing((object)getRand))
					{
						getRand = new int[1];
					}
					else
					{
						getRand = (int[])Utils.CopyArray((Array)getRand, (Array)new int[Information.UBound((Array)getRand, 1) + 1 + 1]);
					}
					getRand[Information.UBound((Array)getRand, 1)] = num3;
					if (Information.UBound((Array)getRand, 1) == 32)
					{
						break;
					}
				}
			}
			rst.MoveFirst();
			int num4 = rst.RecordCount - 1;
			for (int i = 0; i <= num4; i++)
			{
				if (Information.IsNothing((object)gP))
				{
					gP = new string[1];
				}
				else
				{
					gP = (string[])Utils.CopyArray((Array)gP, (Array)new string[Information.UBound((Array)gP, 1) + 1 + 1]);
				}
				if (Information.IsNothing((object)gC))
				{
					gC = new int[1];
				}
				else
				{
					gC = (int[])Utils.CopyArray((Array)gC, (Array)new int[Information.UBound((Array)gC, 1) + 1 + 1]);
				}
				gP[Information.UBound((Array)gP, 1)] = StringType.FromObject(rst.Fields["t_name"].Value);
				gC[Information.UBound((Array)gC, 1)] = IntegerType.FromObject(rst.Fields["check"].Value);
				rst.MoveNext();
			}
			int num5 = Information.UBound((Array)getRand, 1);
			for (int j = 0; j <= num5; j++)
			{
				if (Information.IsNothing((object)getPic))
				{
					getPic = new string[1];
				}
				else
				{
					getPic = (string[])Utils.CopyArray((Array)getPic, (Array)new string[Information.UBound((Array)getPic, 1) + 1 + 1]);
				}
				if (Information.IsNothing((object)getCheck))
				{
					getCheck = new int[1];
				}
				else
				{
					getCheck = (int[])Utils.CopyArray((Array)getCheck, (Array)new int[Information.UBound((Array)getCheck, 1) + 1 + 1]);
				}
				getPic[Information.UBound((Array)getPic, 1)] = gP[getRand[j]];
				getCheck[Information.UBound((Array)getCheck, 1)] = gC[getRand[j]];
			}
		}
	}

	private void put33con()
	{
		int num = 0;
		do
		{
			getImg[num] = Image.FromFile(Application.StartupPath + "\\images\\test\\" + getPic[num] + ".jpg");
			num = checked(num + 1);
		}
		while (num <= 32);
		p1.Image = getImg[0];
		p2.Image = getImg[1];
		p3.Image = getImg[2];
		p4.Image = getImg[3];
		p5.Image = getImg[4];
		p6.Image = getImg[5];
		p7.Image = getImg[6];
		p8.Image = getImg[7];
		p9.Image = getImg[8];
		p10.Image = getImg[9];
		p11.Image = getImg[10];
		p12.Image = getImg[11];
		p13.Image = getImg[12];
		p14.Image = getImg[13];
		p15.Image = getImg[14];
		p16.Image = getImg[15];
		p17.Image = getImg[16];
		p18.Image = getImg[17];
		p19.Image = getImg[18];
		p20.Image = getImg[19];
		p21.Image = getImg[20];
		p22.Image = getImg[21];
		p23.Image = getImg[22];
		p24.Image = getImg[23];
		p25.Image = getImg[24];
		p26.Image = getImg[25];
		p27.Image = getImg[26];
		p28.Image = getImg[27];
		p29.Image = getImg[28];
		p30.Image = getImg[29];
		p31.Image = getImg[30];
		p32.Image = getImg[31];
		p33.Image = getImg[32];
		p1.Tag = getCheck[0];
		p2.Tag = getCheck[1];
		p3.Tag = getCheck[2];
		p4.Tag = getCheck[3];
		p5.Tag = getCheck[4];
		p6.Tag = getCheck[5];
		p7.Tag = getCheck[6];
		p8.Tag = getCheck[7];
		p9.Tag = getCheck[8];
		p10.Tag = getCheck[9];
		p11.Tag = getCheck[10];
		p12.Tag = getCheck[11];
		p13.Tag = getCheck[12];
		p14.Tag = getCheck[13];
		p15.Tag = getCheck[14];
		p16.Tag = getCheck[15];
		p17.Tag = getCheck[16];
		p18.Tag = getCheck[17];
		p19.Tag = getCheck[18];
		p20.Tag = getCheck[19];
		p21.Tag = getCheck[20];
		p22.Tag = getCheck[21];
		p23.Tag = getCheck[22];
		p24.Tag = getCheck[23];
		p25.Tag = getCheck[24];
		p26.Tag = getCheck[25];
		p27.Tag = getCheck[26];
		p28.Tag = getCheck[27];
		p29.Tag = getCheck[28];
		p30.Tag = getCheck[29];
		p31.Tag = getCheck[30];
		p32.Tag = getCheck[31];
		p33.Tag = getCheck[32];
	}

	private void AllowDropPic()
	{
		p1.AllowDrop = true;
		p2.AllowDrop = true;
		p3.AllowDrop = true;
		p4.AllowDrop = true;
		p5.AllowDrop = true;
		p6.AllowDrop = true;
		p7.AllowDrop = true;
		p8.AllowDrop = true;
		p9.AllowDrop = true;
		p10.AllowDrop = true;
		p11.AllowDrop = true;
		p12.AllowDrop = true;
		p13.AllowDrop = true;
		p14.AllowDrop = true;
		p15.AllowDrop = true;
		p16.AllowDrop = true;
		p17.AllowDrop = true;
		p18.AllowDrop = true;
		p19.AllowDrop = true;
		p20.AllowDrop = true;
		p21.AllowDrop = true;
		p22.AllowDrop = true;
		p23.AllowDrop = true;
		p24.AllowDrop = true;
		p25.AllowDrop = true;
		p26.AllowDrop = true;
		p27.AllowDrop = true;
		p28.AllowDrop = true;
		p29.AllowDrop = true;
		p30.AllowDrop = true;
		p31.AllowDrop = true;
		p32.AllowDrop = true;
		p33.AllowDrop = true;
		pic1.AllowDrop = true;
		pic2.AllowDrop = true;
		pic3.AllowDrop = true;
		pic4.AllowDrop = true;
		pic5.AllowDrop = true;
	}

	private void p1_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p1.DoDragDrop(p1.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p1.Image = getImg[0];
			ProjectData.ClearProjectError();
		}
	}

	private void p2_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p2.DoDragDrop(p2.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p2.Image = getImg[1];
			ProjectData.ClearProjectError();
		}
	}

	private void p3_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p3.DoDragDrop(p3.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p3.Image = getImg[2];
			ProjectData.ClearProjectError();
		}
	}

	private void p4_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p4.DoDragDrop(p4.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p4.Image = getImg[3];
			ProjectData.ClearProjectError();
		}
	}

	private void p5_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p5.DoDragDrop(p5.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p5.Image = getImg[4];
			ProjectData.ClearProjectError();
		}
	}

	private void p6_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p6.DoDragDrop(p6.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p6.Image = getImg[5];
			ProjectData.ClearProjectError();
		}
	}

	private void p7_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p7.DoDragDrop(p7.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p7.Image = getImg[6];
			ProjectData.ClearProjectError();
		}
	}

	private void p8_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p8.DoDragDrop(p8.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p8.Image = getImg[7];
			ProjectData.ClearProjectError();
		}
	}

	private void p9_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p9.DoDragDrop(p9.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p9.Image = getImg[8];
			ProjectData.ClearProjectError();
		}
	}

	private void p10_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p10.DoDragDrop(p10.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p10.Image = getImg[9];
			ProjectData.ClearProjectError();
		}
	}

	private void p11_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p11.DoDragDrop(p11.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p11.Image = getImg[10];
			ProjectData.ClearProjectError();
		}
	}

	private void p12_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p12.DoDragDrop(p12.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p12.Image = getImg[11];
			ProjectData.ClearProjectError();
		}
	}

	private void p13_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p13.DoDragDrop(p13.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p13.Image = getImg[12];
			ProjectData.ClearProjectError();
		}
	}

	private void p14_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p14.DoDragDrop(p14.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p14.Image = getImg[13];
			ProjectData.ClearProjectError();
		}
	}

	private void p15_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p15.DoDragDrop(p15.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p15.Image = getImg[14];
			ProjectData.ClearProjectError();
		}
	}

	private void p16_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p16.DoDragDrop(p16.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p16.Image = getImg[15];
			ProjectData.ClearProjectError();
		}
	}

	private void p17_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p17.DoDragDrop(p17.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p17.Image = getImg[16];
			ProjectData.ClearProjectError();
		}
	}

	private void p18_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p18.DoDragDrop(p18.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p18.Image = getImg[17];
			ProjectData.ClearProjectError();
		}
	}

	private void p19_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p19.DoDragDrop(p19.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p19.Image = getImg[18];
			ProjectData.ClearProjectError();
		}
	}

	private void p20_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p20.DoDragDrop(p20.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p20.Image = getImg[19];
			ProjectData.ClearProjectError();
		}
	}

	private void p21_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p21.DoDragDrop(p21.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p21.Image = getImg[20];
			ProjectData.ClearProjectError();
		}
	}

	private void p22_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p22.DoDragDrop(p22.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p22.Image = getImg[21];
			ProjectData.ClearProjectError();
		}
	}

	private void p23_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p23.DoDragDrop(p23.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p23.Image = getImg[22];
			ProjectData.ClearProjectError();
		}
	}

	private void p24_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p24.DoDragDrop(p24.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p24.Image = getImg[23];
			ProjectData.ClearProjectError();
		}
	}

	private void p25_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p25.DoDragDrop(p25.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p25.Image = getImg[24];
			ProjectData.ClearProjectError();
		}
	}

	private void p26_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p26.DoDragDrop(p26.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p26.Image = getImg[25];
			ProjectData.ClearProjectError();
		}
	}

	private void p27_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p27.DoDragDrop(p27.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p27.Image = getImg[26];
			ProjectData.ClearProjectError();
		}
	}

	private void p28_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p28.DoDragDrop(p28.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p28.Image = getImg[27];
			ProjectData.ClearProjectError();
		}
	}

	private void p29_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p29.DoDragDrop(p29.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p29.Image = getImg[28];
			ProjectData.ClearProjectError();
		}
	}

	private void p30_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p30.DoDragDrop(p30.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p30.Image = getImg[29];
			ProjectData.ClearProjectError();
		}
	}

	private void p31_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p31.DoDragDrop(p31.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p31.Image = getImg[30];
			ProjectData.ClearProjectError();
		}
	}

	private void p32_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p32.DoDragDrop(p32.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p32.Image = getImg[31];
			ProjectData.ClearProjectError();
		}
	}

	private void p33_MouseDown(object sender, MouseEventArgs e)
	{
		try
		{
			p33.DoDragDrop(p33.Image, DragDropEffects.Copy);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("It looks like no the consonant... Try again :-)", "Hey!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
			p33.Image = getImg[32];
			ProjectData.ClearProjectError();
		}
	}

	private void pic1_DragDrop(object sender, DragEventArgs e)
	{
		pic1.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
		pic1.Tag = gCh;
	}

	private void pic2_DragDrop(object sender, DragEventArgs e)
	{
		pic2.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
		pic2.Tag = gCh;
	}

	private void pic3_DragDrop(object sender, DragEventArgs e)
	{
		pic3.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
		pic3.Tag = gCh;
	}

	private void pic4_DragDrop(object sender, DragEventArgs e)
	{
		pic4.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
		pic4.Tag = gCh;
	}

	private void pic5_DragDrop(object sender, DragEventArgs e)
	{
		pic5.Image = (Image)e.Data.GetData(DataFormats.Bitmap);
		pic5.Tag = gCh;
	}

	private void p1_DragEnter(object sender, DragEventArgs e)
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

	private void p10_DragEnter(object sender, DragEventArgs e)
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

	private void p11_DragEnter(object sender, DragEventArgs e)
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

	private void p12_DragEnter(object sender, DragEventArgs e)
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

	private void p13_DragEnter(object sender, DragEventArgs e)
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

	private void p14_DragEnter(object sender, DragEventArgs e)
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

	private void p15_DragEnter(object sender, DragEventArgs e)
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

	private void p16_DragEnter(object sender, DragEventArgs e)
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

	private void p17_DragEnter(object sender, DragEventArgs e)
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

	private void p18_DragEnter(object sender, DragEventArgs e)
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

	private void p19_DragEnter(object sender, DragEventArgs e)
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

	private void p2_DragEnter(object sender, DragEventArgs e)
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

	private void p20_DragEnter(object sender, DragEventArgs e)
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

	private void p21_DragEnter(object sender, DragEventArgs e)
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

	private void p22_DragEnter(object sender, DragEventArgs e)
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

	private void p23_DragEnter(object sender, DragEventArgs e)
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

	private void p24_DragEnter(object sender, DragEventArgs e)
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

	private void p25_DragEnter(object sender, DragEventArgs e)
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

	private void p26_DragEnter(object sender, DragEventArgs e)
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

	private void p27_DragEnter(object sender, DragEventArgs e)
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

	private void p28_DragEnter(object sender, DragEventArgs e)
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

	private void p29_DragEnter(object sender, DragEventArgs e)
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

	private void p3_DragEnter(object sender, DragEventArgs e)
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

	private void p30_DragEnter(object sender, DragEventArgs e)
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

	private void p31_DragEnter(object sender, DragEventArgs e)
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

	private void p32_DragEnter(object sender, DragEventArgs e)
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

	private void p33_DragEnter(object sender, DragEventArgs e)
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

	private void pic1_DragEnter(object sender, DragEventArgs e)
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

	private void pic2_DragEnter(object sender, DragEventArgs e)
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

	private void pic3_DragEnter(object sender, DragEventArgs e)
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

	private void pic4_DragEnter(object sender, DragEventArgs e)
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

	private void pic5_DragEnter(object sender, DragEventArgs e)
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

	private void p1_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p1.Tag);
	}

	private void p2_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p2.Tag);
	}

	private void p3_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p3.Tag);
	}

	private void p10_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p10.Tag);
	}

	private void p11_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p11.Tag);
	}

	private void p12_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p12.Tag);
	}

	private void p13_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p13.Tag);
	}

	private void p14_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p14.Tag);
	}

	private void p15_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p15.Tag);
	}

	private void p16_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p16.Tag);
	}

	private void p17_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p17.Tag);
	}

	private void p18_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p18.Tag);
	}

	private void p19_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p19.Tag);
	}

	private void p20_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p20.Tag);
	}

	private void p21_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p21.Tag);
	}

	private void p22_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p22.Tag);
	}

	private void p23_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p23.Tag);
	}

	private void p24_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p24.Tag);
	}

	private void p25_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p25.Tag);
	}

	private void p26_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p26.Tag);
	}

	private void p27_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p27.Tag);
	}

	private void p28_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p28.Tag);
	}

	private void p29_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p29.Tag);
	}

	private void p30_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p30.Tag);
	}

	private void p31_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p31.Tag);
	}

	private void p32_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p32.Tag);
	}

	private void p33_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p33.Tag);
	}

	private void pic1_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(pic1.Tag);
	}

	private void pic2_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(pic2.Tag);
	}

	private void pic3_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(pic3.Tag);
	}

	private void pic4_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(pic4.Tag);
	}

	private void pic5_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(pic5.Tag);
	}

	private void cmdCheck_Click(object sender, EventArgs e)
	{
		//IL_06c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		int num = default(int);
		int num2 = default(int);
		int num3 = default(int);
		int num4 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		int num7 = 0 - ((0 - ((0 - ((0 - ((0 - ((0 - ((num == num2) ? 1 : 0) == num3) ? 1 : 0) == num4) ? 1 : 0) == num5) ? 1 : 0) == num6) ? 1 : 0) == 0) ? 1 : 0);
		int num8 = 0;
		checked
		{
			if (ObjectType.ObjTst(pic1.Tag, (object)7, false) == 0)
			{
				num8 += 7;
				if (ObjectType.ObjTst(pic2.Tag, (object)7, false) == 0)
				{
					num8 += 7;
				}
				if (ObjectType.ObjTst(pic3.Tag, (object)7, false) == 0)
				{
					num8 += 7;
				}
				if (ObjectType.ObjTst(pic4.Tag, (object)7, false) == 0)
				{
					num8 += 7;
				}
				if (ObjectType.ObjTst(pic5.Tag, (object)7, false) == 0)
				{
					num8 += 7;
				}
				num6++;
			}
			if (ObjectType.ObjTst(pic1.Tag, (object)1, false) == 0)
			{
				num8++;
				if (ObjectType.ObjTst(pic2.Tag, (object)1, false) == 0)
				{
					num8++;
				}
				if (ObjectType.ObjTst(pic3.Tag, (object)1, false) == 0)
				{
					num8++;
				}
				if (ObjectType.ObjTst(pic4.Tag, (object)1, false) == 0)
				{
					num8++;
				}
				if (ObjectType.ObjTst(pic5.Tag, (object)1, false) == 0)
				{
					num8++;
				}
				num7++;
			}
			if (ObjectType.ObjTst(pic1.Tag, (object)2, false) == 0)
			{
				num8 += 2;
				if (ObjectType.ObjTst(pic2.Tag, (object)2, false) == 0)
				{
					num8 += 2;
				}
				if (ObjectType.ObjTst(pic3.Tag, (object)7, false) == 0)
				{
					num8 += 2;
				}
				if (ObjectType.ObjTst(pic4.Tag, (object)7, false) == 0)
				{
					num8 += 2;
				}
				if (ObjectType.ObjTst(pic5.Tag, (object)7, false) == 0)
				{
					num8 += 2;
				}
				num++;
			}
			if (ObjectType.ObjTst(pic1.Tag, (object)3, false) == 0)
			{
				num8 += 3;
				if (ObjectType.ObjTst(pic2.Tag, (object)3, false) == 0)
				{
					num8 += 3;
				}
				if (ObjectType.ObjTst(pic3.Tag, (object)3, false) == 0)
				{
					num8 += 3;
				}
				if (ObjectType.ObjTst(pic4.Tag, (object)3, false) == 0)
				{
					num8 += 3;
				}
				if (ObjectType.ObjTst(pic5.Tag, (object)3, false) == 0)
				{
					num8 += 3;
				}
				num2++;
			}
			if (ObjectType.ObjTst(pic1.Tag, (object)4, false) == 0)
			{
				num8 += 4;
				if (ObjectType.ObjTst(pic2.Tag, (object)4, false) == 0)
				{
					num8 += 4;
				}
				if (ObjectType.ObjTst(pic3.Tag, (object)4, false) == 0)
				{
					num8 += 4;
				}
				if (ObjectType.ObjTst(pic4.Tag, (object)4, false) == 0)
				{
					num8 += 4;
				}
				if (ObjectType.ObjTst(pic5.Tag, (object)4, false) == 0)
				{
					num8 += 4;
				}
				num3++;
			}
			if (ObjectType.ObjTst(pic1.Tag, (object)5, false) == 0)
			{
				num8 += 5;
				if (ObjectType.ObjTst(pic2.Tag, (object)5, false) == 0)
				{
					num8 += 5;
				}
				if (ObjectType.ObjTst(pic3.Tag, (object)5, false) == 0)
				{
					num8 += 5;
				}
				if (ObjectType.ObjTst(pic4.Tag, (object)5, false) == 0)
				{
					num8 += 5;
				}
				if (ObjectType.ObjTst(pic5.Tag, (object)5, false) == 0)
				{
					num8 += 5;
				}
				num4++;
			}
			if (ObjectType.ObjTst(pic1.Tag, (object)6, false) == 0)
			{
				num8 += 6;
				if (ObjectType.ObjTst(pic2.Tag, (object)6, false) == 0)
				{
					num8 += 6;
				}
				if (ObjectType.ObjTst(pic3.Tag, (object)6, false) == 0)
				{
					num8 += 6;
				}
				if (ObjectType.ObjTst(pic4.Tag, (object)6, false) == 0)
				{
					num8 += 6;
				}
				if (ObjectType.ObjTst(pic5.Tag, (object)6, false) == 0)
				{
					num8 += 6;
				}
				num5++;
			}
			if (unchecked(((num8 != 0) & (num8 % 5 == 0)) || num8 == 21))
			{
				Interaction.MsgBox((object)"You are right! you can see the group in Result part.", (MsgBoxStyle)64, (object)"Right group");
				switch (num8)
				{
				case 5:
					txt1.Text = "Group 1: ក to ង";
					if (num7 == 1)
					{
						score += num8;
					}
					break;
				case 10:
					txt2.Text = "Group 2: ច to ញ";
					if (num == 1)
					{
						score += num8;
					}
					break;
				case 15:
					txt3.Text = "Group 3: ដ to ណ";
					if (num2 == 1)
					{
						score += num8;
					}
					break;
				case 20:
					txt4.Text = "Group 4: ត to ន";
					if (num3 == 1)
					{
						score += num8;
					}
					break;
				case 25:
					txt5.Text = "Group 5: ប to ម";
					if (num4 == 1)
					{
						score += num8;
					}
					break;
				case 30:
					txt6.Text = "Group 6: យ to ស";
					if (num5 == 1)
					{
						score += num8;
					}
					break;
				case 21:
					txt7.Text = "Group 7: ហ to អ";
					if (num6 == 1)
					{
						score += num8;
					}
					break;
				case 6:
				case 7:
				case 8:
				case 9:
				case 11:
				case 12:
				case 13:
				case 14:
				case 16:
				case 17:
				case 18:
				case 19:
				case 22:
				case 23:
				case 24:
				case 26:
				case 27:
				case 28:
				case 29:
					break;
				}
			}
			else
			{
				Interaction.MsgBox((object)"Wrong! Please try again!", (MsgBoxStyle)48, (object)"Wrong group");
			}
		}
	}

	private void cmdClear_Click(object sender, EventArgs e)
	{
		pic1.Image = null;
		pic2.Image = null;
		pic3.Image = null;
		pic4.Image = null;
		pic5.Image = null;
		pic1.Tag = 0;
		pic2.Tag = 0;
		pic3.Tag = 0;
		pic4.Tag = 0;
		pic5.Tag = 0;
	}

	private void frmTest_Resize(object sender, EventArgs e)
	{
		lblTest.Width = Width;
	}

	private void cmdStart_Click(object sender, EventArgs e)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		if (StringType.StrCmp(cmdStart.Text, "&Start", false) == 0)
		{
			Timer1.Start();
			cmdStart.Text = "&Stop";
			GroupBox1.Enabled = true;
		}
		else
		{
			Timer1.Stop();
			cmdStart.Text = "&Start";
			GroupBox1.Enabled = false;
			Interaction.MsgBox((object)getMention(score), (MsgBoxStyle)64, (object)"Result :: Time still has");
		}
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			mn--;
			txtTime.Text = StringType.FromInteger(mn);
			if ((StringType.StrCmp(txt1.Text, "", false) != 0) & (StringType.StrCmp(txt2.Text, "", false) != 0) & (StringType.StrCmp(txt3.Text, "", false) != 0) & (StringType.StrCmp(txt4.Text, "", false) != 0) & (StringType.StrCmp(txt5.Text, "", false) != 0) & (StringType.StrCmp(txt6.Text, "", false) != 0) & (StringType.StrCmp(txt7.Text, "", false) != 0))
			{
				Timer1.Stop();
				if (mn > 0)
				{
					Interaction.MsgBox((object)string.Concat(string.Concat("Excellent! You have finished grouping the consonant in " + StringType.FromInteger(300 - mn) + " seconds.\r\nYou still have time " + StringType.FromInteger(mn), " seconds. \r\nYour complete score is ", StringType.FromInteger(score)), ".\r\nYour total score is ", StringType.FromInteger(score + mn), "."), (MsgBoxStyle)64, (object)"Result :: Excellent");
					mn = 300;
					cmdStart_Click(RuntimeHelpers.GetObjectValue(sender), e);
				}
				else if (mn == 0)
				{
					Interaction.MsgBox((object)("Very Good! You have finished grouping the consonant in 300 seconds.\r\nYour complete score is " + StringType.FromInteger(score) + "."), (MsgBoxStyle)64, (object)"Result :: Very Good");
					mn = 300;
					cmdStart_Click(RuntimeHelpers.GetObjectValue(sender), e);
				}
			}
			else if (mn == 0)
			{
				Timer1.Stop();
				Interaction.MsgBox((object)getMention(score), (MsgBoxStyle)64, (object)"Result :: On Time");
				mn = 300;
				cmdStart_Click(RuntimeHelpers.GetObjectValue(sender), e);
			}
		}
	}

	public string getMention(int sc)
	{
		if (sc > 100)
		{
			return "Excellent! even you haven't finish all groups but well done. Try more to.\r\nYour score is " + StringType.FromInteger(sc);
		}
		if (sc > 90)
		{
			return "Very Good! Great! Take another time to try so can be the best.\r\nYour score is " + StringType.FromInteger(sc);
		}
		if (sc > 80)
		{
			return "Good! Be patient to study Khmer Language hard, ok?.\r\nYour score is " + StringType.FromInteger(sc);
		}
		if (sc > 65)
		{
			return "Fair Good! You need more practise should go to Chapter 1.\r\nYour score is " + StringType.FromInteger(sc);
		}
		if (sc > 50)
		{
			return "Passed! But you must try one by one with Chapter 1.\r\nYour score is " + StringType.FromInteger(sc);
		}
		if (sc < 50)
		{
			return "Failed! Try and don't be shy about that because Khmer Language is also difficult.\r\nYour score is " + StringType.FromInteger(sc);
		}
		string result = default(string);
		return result;
	}

	private void p4_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p4.Tag);
	}

	private void p5_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p5.Tag);
	}

	private void p6_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p6.Tag);
	}

	private void p7_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p7.Tag);
	}

	private void p8_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p8.Tag);
	}

	private void p9_MouseEnter(object sender, EventArgs e)
	{
		gCh = IntegerType.FromObject(p9.Tag);
	}

	private void pic1_Click(object sender, EventArgs e)
	{
	}
}
