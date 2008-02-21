using System;
using Clutter;

class Program 
{
	static Rectangle rect;
	static EffectTemplate template;

	static void ScaleRect () {
		Effect.Scale (template, rect, 2.0, 2.0, null);
	}

	static void Main () {
	 	ClutterRun.Init ();
	 	Stage stage = Stage.Default;
		stage.SetSize (200, 200);

		template = new EffectTemplate (new Timeline (90, 120), Sine.Func);

		rect = new Rectangle ();	
		Clutter.Color rect_bg_color = new Clutter.Color (0x33, 0x22, 0x22, 0xff);
		rect.Color = rect_bg_color;
		rect.BorderWidth = 10;

		rect.Reactive = true;
		rect.SetSize (100, 100);
		rect.AnchorPointFromGravity = Gravity.Center;
		rect.SetPosition (100, 100);
		rect.ButtonPressEvent += delegate { ScaleRect (); };

		stage.AddActor (rect);
		stage.ShowAll ();

		ClutterRun.Main ();
	} 
}
