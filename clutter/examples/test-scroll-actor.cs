using System;
using Clutter;

namespace ClutterTest
{
	public class ScrollActor : Clutter.Rectangle
	{
		private int scroll_offset;

		public ScrollActor (Clutter.Color color)
			: this (color, 20)
		{  }

		public ScrollActor (Clutter.Color color, int scroll_offset)
			: base (color)
		{
			this.scroll_offset = scroll_offset;
			Reactive = true; 
		}

		protected override bool OnScrollEvent (Clutter.ScrollEvent evnt) 
		{
		 	switch (evnt.Direction)
			{
				case ScrollDirection.Up:
					base.Depth += scroll_offset; 
					break;
				case ScrollDirection.Down:
					base.Depth -= scroll_offset;
					break;
				default:
					break;
			}
		 	
			return base.OnScrollEvent (evnt);
		}
	}

	public class Test
	{
		static Color stage_color = new Color (0x00, 0x00, 0x00, 0xff);
		static Color actor_color = new Color (0x33, 0xdd, 0xff, 0xff);
		static Rectangle actor;
 
	 	public static void Main ()
		{
		 	ClutterRun.Init ();

			Stage stage = Stage.Default;
			stage.SetSize (200, 200);
			stage.Color = stage_color;
			stage.Title = "Override Test";

			actor = new ScrollActor (actor_color, 20);
			actor.SetSize (100, 100);
			actor.AnchorPointFromGravity = Gravity.Center;
			actor.SetPosition (100, 100);
			stage.AddActor (actor);

			stage.ShowAll ();
			ClutterRun.Main ();
		}
	} 
}
