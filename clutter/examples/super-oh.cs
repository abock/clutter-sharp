using System;
using Clutter;
using Gdk;


public class SuperOH
{
	public static uint n_hands = 6;
	static SuperOH CurrentOH;

	Actor[] Hands;
	//public Actor bgtex;
	Group Group;
	Gdk.Pixbuf BgPixbuf;

	static uint GetRadius ()
	{
		return (Stage.Default.Width + Stage.Default.Height) / n_hands;
	}

	static Clutter.Color StageColor {
		get {
		 	Clutter.Color c = new Clutter.Color ();
			c.FromHls (0x61, 0x64, 0x8c);
			return c;
		} 
	}

	static void HandleNewFrame (object o, NewFrameArgs args) 
	{
 		CurrentOH.Group.RotateZ  (args.FrameNum, 
 					  (int)Stage.Default.Width / 2, 
 					  (int)Stage.Default.Height / 2);


		foreach (Actor hand in CurrentOH.Hands) {
		 	hand.RotateZ (-6.0F * args.FrameNum,
				      (int)hand.Width / 2,
				      (int)hand.Height / 2);
		}
	}

	static void HandleButtonPress (object o, ButtonPressEventArgs args)
	{
	 	Actor c = (Stage.Default as Stage).GetActorAtPos (args.Event.XPosition, args.Event.YPosition);

	 	if (c != null)
	 	 	c.Hide ();

	}

	static void HandleKeyPress (object o, KeyPressEventArgs args)
	{
		 Clutter.Main.Quit ();
	}

	static void Main ()
	{
		ClutterRun.Init (); 

		Stage stage = Stage.Default as Stage;	 
		stage.Color = StageColor;
		Gdk.Pixbuf hand_pixbuf = new Gdk.Pixbuf ("redhand.png");

		SuperOH oh = new SuperOH();
		CurrentOH = oh;
		oh.Group = new Group ();
		oh.Hands = new Actor[n_hands];


		for (int i = 0; i < n_hands; i++) {
			Texture hand_text = new Texture (hand_pixbuf);
			uint w = hand_text.Width;
			uint h = hand_text.Height;

		 	uint radius = GetRadius (); 

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

		stage.Add (oh.Group);
		stage.ButtonPressEvent += HandleButtonPress;
		stage.KeyPressEvent += HandleKeyPress;

		stage.ShowAll ();

		Timeline timeline = new Timeline (360, 90);
		timeline.Loop = true;

		timeline.NewFrame += HandleNewFrame;

		timeline.Start ();

		ClutterRun.Main ();
	} 

}
