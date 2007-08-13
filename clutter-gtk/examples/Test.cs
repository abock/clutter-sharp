using System;

using Clutter;
using Gtk;

public class SuperOH
{
	public Actor[] Hands;
	public Group Group;
	public Gdk.Pixbuf BgPixbuf; 
}

public class Test
{
 	#region Constants
	public const int n_hands = 2;
	#endregion

	#region Fields
	public static Gtk.Window Toplevel;
	public static SuperOH CurrentOH;
	public static Timeline timeline;
	public static bool fade = false;
	#endregion

	static void HandleNewFrame (object o, NewFrameArgs args) 
	{
 		CurrentOH.Group.RotateZ  (args.FrameNum, 
 					  (int)Stage.Default.Width / 2, 
 					  (int)Stage.Default.Height / 2);


		foreach (Actor hand in CurrentOH.Hands) {
		 	hand.RotateZ (-6.0F * args.FrameNum,
				      (int)hand.Width / 2,
				      (int)hand.Height / 2);

			if (fade)
			 	hand.Opacity = (byte)(255 - (args.FrameNum % 255));
		}
	}

	static void HandleButtonPress (object o, Clutter.ButtonPressEventArgs args)
	{
	 	Actor c = (Stage.Default as Stage).GetActorAtPos (args.Event.X, args.Event.Y);

	 	if (c != null)
	 	 	c.Hide ();

	}

	static void HandleKeyPress (object o, Clutter.KeyPressEventArgs args)
	{
		 Clutter.Main.Quit ();
	}

	public static void HandleDelete (object o, EventArgs args)
	{
		Gtk.Application.Quit (); 
	}

	public static void HandleClickity (object o, EventArgs args)
	{
		fade = !fade; 
	}

	public static void Main ()
	{
	 	Gtk.Application.Init ();
		ClutterRun.Init ();

		Gdk.Pixbuf hand_pixbuf = new Gdk.Pixbuf ("redhand.png");

		Gtk.Window window = new Gtk.Window (WindowType.Toplevel);
		window.DeleteEvent += HandleDelete;
		Toplevel = window;

		Gtk.VBox vbox = new Gtk.VBox (false, 6);
		window.Add (vbox);

		GtkClutter clutter = new GtkClutter ();
		vbox.Add (clutter);

		Stage stage = Stage.Default;
		Gtk.Label label = new Gtk.Label ("This is a label");
		vbox.PackStart (label, false, false, 0);

		Gtk.Button button = Gtk.Button.NewWithLabel ("This is a button...clicky");
		button.Clicked += HandleClickity;
		vbox.PackStart (button, false, false, 0);

		button = new Gtk.Button (Gtk.Stock.Quit);
		button.Clicked += delegate { Gtk.Application.Quit (); };

		vbox.PackEnd (button, false, false, 0);

		stage.Color = new Clutter.Color (0x61, 0x64, 0x8c, 0xff);

		uint radius = stage.Width / n_hands / 2;

		SuperOH oh = new SuperOH();
		CurrentOH = oh;
		oh.Group = new Group ();
		oh.Hands = new Actor[n_hands];


		for (int i = 0; i < n_hands; i++) {
			Texture hand_text = new Texture (hand_pixbuf);
			uint w = hand_text.Width;
			uint h = hand_text.Height;

		 	oh.Hands[i] = hand_text;

			int x = (int) (stage.Width / 2
				 + radius
				 * Math.Cos (i * Math.PI / ( n_hands / 2 ))
				 - w / 2);
			int y = (int)(stage.Height / 2
				 + radius
				 * Math.Sin (i * Math.PI / ( n_hands / 2))
				 - h / 2);

			oh.Hands[i].SetPosition (x, y);

			oh.Group.Add (oh.Hands[i]);
		}

		oh.Group.ShowAll ();

		stage.Add (oh.Group);
		stage.ButtonPressEvent += HandleButtonPress;
		stage.KeyPressEvent += HandleKeyPress;

		stage.ShowAll ();

		timeline = new Timeline (360, 90);
		timeline.Loop = true;

		timeline.NewFrame += HandleNewFrame;

		window.ExposeEvent += delegate { timeline.Start (); };

		window.ShowAll ();

		Gtk.Application.Run ();
	}
}
