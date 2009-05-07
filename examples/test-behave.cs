using System;

using Clutter;

namespace ClutterTest
{
	public class Behave
	{
		static Knot[] knots = {new Knot (0, 0), new Knot (0, 300), new Knot (300, 300),
					new Knot (300, 0), new Knot (0, 0) };

		public static void Main(string[] args)
		{
			Application.Init ();

			Stage stage = Stage.Default as Stage;
			(stage as Stage).KeyPressEvent += delegate { 
				Clutter.Main.Quit(); 
			};

			// fixme: add constructor
			Clutter.Color stage_color = new Clutter.Color (0xcc, 0xcc, 0xcc, 0xff);
			stage.SetColor (stage_color);

			Clutter.Group group = new Group();
			stage.Add (group);
			group.Show ();

			// Make a hand
			Clutter.Actor hand = new Texture ("redhand.png");
			hand.SetPosition (0,0);
			hand.Show ();

			// Make a rect
			Clutter.Rectangle rect = new Clutter.Rectangle();
			rect.SetPosition (0,0);
			rect.SetSize ((int)hand.Width, (int)hand.Height);

			Clutter.Color rect_bg_color = new Clutter.Color (0x33, 0x22, 0x22, 0xff);
			rect.SetColor (rect_bg_color);
			rect.BorderWidth = 10;
			rect.Show ();

			group.Add (rect);
			group.Add (hand);

			// Make a timeline
			Timeline timeline = new Timeline (100, 26);
			timeline.Loop = true;

			Alpha alpha = new Alpha (timeline, (a) => a.Value);

			Behaviour o_behave = new BehaviourOpacity (alpha, 0x33, 0xff); 
			o_behave.Apply (group);

			// Make a path behaviour and apply that too
			Behaviour p_behave = new BehaviourPath(alpha, knots); // fixme: add custom constructor?
			p_behave.Apply (group);

			// start timeline
			timeline.Start ();

			stage.ShowAll();

			// launch
			Application.Run ();
		}
	}
}
