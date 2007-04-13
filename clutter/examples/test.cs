using System;
using Clutter;

public class ColoredLabel : Clutter.Group
{
	Label label;
	Rectangle rect;

 	public ColoredLabel (string text, Color back_color) 
		: base ()
	{
	 	this.rect = new Rectangle (back_color);
		this.label = new Label ("Sans 24", text);

		this.Add (rect);
		this.Add (label);

		this.ShowAll ();
	}
}

public class Test
{
	private const string PARA_TEXT = "This is a paragraph of text to check both word wrapping and basic clipping";

 	Texture texture;
	Label label;
	Rectangle rect;
	int direction = -1;

	public void TextCallBack (object o, NewFrameArgs args)
	{
		int frame_num = args.FrameNum;

		string text = string.Format ("--> {0} <--", frame_num / 10);

		this.label.Text = text;
		this.label.SetSize (170, 0);
		this.label.Ellipsize = Pango.EllipsizeMode.End;
		this.label.Opacity = (byte)(frame_num / 2);

		this.label.RotateZ (frame_num, (int)label.Width / 2, (int)label.Height / 2);
	}

	public void RectCallBack (object o, NewFrameArgs args)
	{
		int x = rect.X;
		int y = rect.Y; 

		if (x > Stage.Default.Width - 200)
		 	direction = -1;

		if (x < 100)
		 	direction = 1;

		x += direction;

		rect.SetPosition (x, y);
	}

	public Test ()
	{
		Stage stage = Stage.Default;
		stage.ButtonPressEvent += delegate { Clutter.Main.Quit (); };
		// add  quitter

		Gdk.Pixbuf pixbuf = new Gdk.Pixbuf ("clutter-logo-800x600.png");

		this.texture = new Texture (pixbuf);

		this.label = new Label ("Sans Bold 32", "hello");
		this.label.Opacity = 0x99;
		this.label.SetPosition (550, 100);
		this.label.SetSize (400, 0);

		this.rect = new Rectangle (new Color (0xff, 0x0, 0x0, 0x99));
		this.rect.SetSize (100, 100);
		this.rect.SetPosition (100, 100);

		Label para = new Label ("Sans 24", PARA_TEXT);
		para.SetPosition (10, 10);
		para.SetSize (200, 0);

		stage.Add (texture);
		stage.Add (label);
		stage.Add (rect);
		stage.Add (para);

		stage.SetSize (800, 600);
		stage.ShowAll ();

		Timeline timeline = new Timeline (360, 200);
		timeline.Loop = true;
		timeline.NewFrame += TextCallBack;
		timeline.Start ();

		Timeline rect_timeline = new Timeline (1, 30);
		rect_timeline.Loop = true;
		rect_timeline.NewFrame += RectCallBack;
		rect_timeline.Start ();

		ClutterRun.Main (); 
	}

	public static void Main ()
	{
		ClutterRun.Init (); 
		new Test ();
	} 
}
