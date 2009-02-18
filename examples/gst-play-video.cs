using System;
using Clutter;

public class VideoApp 
{
	const int SEEK_H = 20;
	const int SEEK_W = 690;

	#region Fields
	GstVideoTexture vtexture;

	Group control;
	Texture control_bg;
	Texture control_play;
	Texture control_pause;
	Rectangle control_seek1;
	Rectangle control_seek2;
	Actor control_seekbar;
	Label control_label;

	bool controls_showing;
	bool paused;

	uint controls_timeout;

	Timeline controls_tl;
	Timeline effect1_tl;
	#endregion

	void HandleControlTlNewFrame (object o, NewFrameArgs args)
	{
		control.ShowAll ();
		
		if (paused) {
		 	control_pause.Hide ();
			control_play.Show ();
		}
		else {
			control_play.Hide ();
		 	control_pause.Show ();
		}

		uint opacity = (uint)((args.FrameNum * 0xde) / controls_tl.NumFrames);

		if (!controls_showing)
		 	opacity = 0xde - opacity;

		control.Opacity = (byte)opacity;
	}

	void HandleControlTimelineCompleted (object o, System.EventArgs args)
	{
		if (!controls_showing)
		 	control.HideAll (); 

		controls_timeout = 0;
	}

	void HandleEffect1TlNewFrame (object o, NewFrameArgs args)
	{
		vtexture.SetRotation (RotateAxis.YAxis,
				      (float)args.FrameNum * 12,
				      (int)Stage.Default.Width / 2,
				      0,
				      0); 
	}

	bool HandleControlsTimeout ()
	{
		ShowControls (false);
		return false; 
	}

	void ShowControls (bool vis)
	{
		if (controls_tl.IsPlaying)
		 	return;
			
		if (vis && !controls_showing) {
			controls_showing = true;
			
			controls_tl.Start ();
			
			controls_timeout = GLib.Timeout.Add (5000, new GLib.TimeoutHandler (HandleControlsTimeout));
			return;
		}

		if (vis && controls_showing) {
		 	if (controls_timeout != 0) {
				GLib.Source.Remove (controls_timeout); 
				controls_timeout = GLib.Timeout.Add (5000, new GLib.TimeoutHandler (HandleControlsTimeout));
			}
			return;
		}

		if (!vis && controls_showing) {
			controls_showing = false;
			controls_tl.Start (); 
		}
	}

	void TogglePauseState ()
	{
		if (paused) {
			vtexture.Playing = true;
			paused = false;
			
			control_play.Hide ();
			control_pause.Show (); 
		} 
		else {
			vtexture.Playing = false;
			paused = true;

			control_pause.Hide ();
			control_play.Show ();
		}
	}

	void HandleSizeChange (object o, SizeChangeArgs args)
	{
		Stage stage = Stage.Default;
		int new_x = 0;
		int new_y = 0;

		int new_width = 0;
		int new_height = (args.Height * (int)stage.Width) / args.Width;

		if (new_height <= stage.Height) {
			new_width = (int)stage.Width;

			new_x = 0;
			new_y = ((int)stage.Height - new_height) / 2;		 
		}
		else {
			new_width = (args.Width * (int)stage.Height) / args.Height;
			
			new_x = ((int)stage.Width - new_width) / 2;
			new_y = 0;
		}

		vtexture.SetPosition (new_x, new_y);
		vtexture.SetSize (new_width, new_height);
	}

	bool Tick ()
	{
		int position = vtexture.Position;
		int duration = vtexture.Duration;

		if (position == 0 || duration == 0)
		 	return true;
			
		control_seekbar.SetSize ((position * SEEK_W) / duration, SEEK_H);

		return true;
	}

	void HandleButtonPressEvent (object o, ButtonPressEventArgs args) 
	{
		if (!controls_showing)
		 	return;
			
		Actor actor = Stage.Default.GetActorAtPos (args.Event.X, args.Event.Y);

		if (actor == control_pause || actor == control_play) {
			TogglePauseState ();
			return; 
		}

		if (actor == control_seek1 
		 	|| actor == control_seek2
			|| actor == control_seekbar) {
		 	int x;
			int y;

		 	control_seekbar.GetTransformedPosition (out x, out y);

			int dist = args.Event.X - x;

			dist = Math.Max (dist, 0);
			dist = Math.Min (dist, SEEK_W);

			int pos = (dist * vtexture.Duration) / SEEK_W;

			vtexture.Position = pos;
		}
	}

	void HandleKeyReleaseEvent (object o, KeyReleaseEventArgs args)
	{
		uint symbol = args.Event.Symbol;

		Gdk.Key key = (Gdk.Key) Enum.Parse (typeof(Gdk.Key), symbol.ToString ());

		switch (key) {
			case Gdk.Key.q:
			case Gdk.Key.Escape:
				Clutter.Main.Quit ();
				break;
			case Gdk.Key.e:
				if (!effect1_tl.IsPlaying)
				 	effect1_tl.Start ();
				break;
			default:
				TogglePauseState ();
				break;
		}
	}

	public VideoApp (string filename)
	{
		Stage stage = Stage.Default;
		stage.Color = new Color (0x00, 0x00, 0x00, 0x00);
		stage.SetSize (1200, 1024);

		vtexture = new GstVideoTexture ();
		vtexture.SyncSize = false;

		// add size changed call back here
		vtexture.SizeChange += HandleSizeChange;

		vtexture.Filename = filename;
		control = new Group ();

		// panel
		control_bg = new Texture ("vid-panel.png");

		// play button
		control_play = new Texture ("media-actions-start.png");

		// pause button
		control_pause = new Texture ("media-actions-pause.png");

		control_seek1 = new Rectangle (new Color (73, 74, 77, 0xee));
		control_seek2 = new Rectangle (new Color (0xcc, 0xcc, 0xcc, 0xff));
		control_seekbar = new Rectangle (new Color (73, 74, 77, 0xee));
		control_seekbar.Opacity = 0x99;

		// label with name
		string text = System.IO.Path.GetFileName (filename);
		control_label = new Label ("Sans Bold 24", text);
		control_label.Color = new Color (73, 74, 77, 0xee);

		control.AddActor (control_bg);
		control.AddActor (control_play);
 
		control.AddActor (control_pause);
		control.AddActor (control_seek1);
		control.AddActor (control_seek2);
		control.AddActor (control_seekbar);
		control.AddActor (control_label);

		control.Opacity = 0xee;
		control_play.SetPosition (30, 30);
		control_pause.SetPosition (30, 30);

		control_seek1.SetSize (SEEK_W + 10, SEEK_H + 10);
		control_seek1.SetPosition (200, 100);

		control_seek2.SetSize (SEEK_W, SEEK_H);
		control_seek2.SetPosition (205, 105);

		control_seekbar.SetSize (0, SEEK_H);
		control_seekbar.SetPosition (205, 105);

		control_label.SetPosition (200, 40);

		stage.AddActor (vtexture);
		stage.AddActor (control);

		int x = (int)((stage.Width - control.Width) / 2);
		int y = (int)(stage.Height - (stage.Height / 3));

		control.SetPosition (x, y);

		controls_tl = new Timeline (10, 30);
		controls_tl.NewFrame += HandleControlTlNewFrame;
		controls_tl.Completed += HandleControlTimelineCompleted;

		effect1_tl = new Timeline (30, 90);
		effect1_tl.NewFrame += HandleEffect1TlNewFrame;

		GLib.Timeout.Add (1000, new GLib.TimeoutHandler (Tick));
		stage.MotionEvent += delegate { ShowControls (true); };
		stage.ButtonPressEvent += HandleButtonPressEvent;
		stage.KeyReleaseEvent += HandleKeyReleaseEvent;

		vtexture.Playing = true;
		stage.ShowAll ();
		control_play.Hide ();
	}

	public static void Main (string[] args)
	{
		int arg;
			
		Clutter.GstGlobal.GstInit (out arg, string.Empty);

		VideoApp app = new VideoApp (args[0]);
	
		ClutterRun.Main ();
	}
}
