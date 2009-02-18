using Gtk;
using System;
using Clutter;

public class EventApp
{
	public Gtk.Window window;
	public Gtk.Widget popup;
	public Gtk.Entry gtk_entry; 

	public Gtk.SpinButton x_button;
	public Gtk.SpinButton y_button;
	public Gtk.SpinButton z_button;
	public Gtk.SpinButton op_button;

	public Clutter.Stage stage;
	public Clutter.Actor hand;
	public Clutter.Entry clutter_entry;
}

public class TestEvents
{
	static EventApp app; 
 
	public static void HandleDelete (object o, System.EventArgs args)
	{
		Gtk.Application.Quit (); 
	}
 
 	public static void Main ()
	{
		app = new EventApp (); 

		ClutterRun.Init ();
		Gtk.Application.Init ();

		Gtk.Window window = new Gtk.Window (WindowType.Toplevel);
		window.Title = "Gtk-Clutter Interaction Demo";
		window.Resizable = true;
		window.BorderWidth = 12;
		window.DeleteEvent += HandleDelete;
		app.window = window;

		Gtk.VBox vbox = new Gtk.VBox (false, 12);
		window.Add (vbox);

		Gtk.Entry gtk_entry = new Gtk.Entry ();
		app.gtk_entry = gtk_entry;
		gtk_entry.Text = "Enter some text";
		gtk_entry.Changed += delegate { app.clutter_entry.Text = app.gtk_entry.Text; };
		vbox.PackStart (gtk_entry, false, false, 0);

		Gtk.HBox hbox = new Gtk.HBox(false, 12);
		vbox.PackStart (hbox, true, true, 0);

		/* Clutter stage */
		Embed widget = new Embed ();
		hbox.PackStart (widget, true, true, 0);
		app.stage = widget.Stage as Stage;
		app.stage.Color = new Clutter.Color (125, 125, 125, 255);

		/* Main texture*/
		Texture texture = new Texture ("redhand.png");
		app.hand = texture;
		app.stage.AddActor (texture);
		uint width, height;
		texture.GetSize (out width, out height);
		texture.SetPosition ((int)((app.stage.Width / 2) - (width/2)), (int)((app.stage.Height / 2) - (height/2)));

		/* Clutter entry */
		app.clutter_entry = new Clutter.Entry ("Sans 10", "", new Clutter.Color (255, 255, 255, 255));
		app.stage.AddActor (app.clutter_entry);
		app.clutter_entry.SetPosition (0, 0);
		app.clutter_entry.SetSize (500, 20);

		/* Adjustment widgets */
		vbox = new Gtk.VBox (false, 6);
		hbox.PackStart (vbox, false, false, 0);

		Gtk.VBox box = new Gtk.VBox (true, 6);
		vbox.PackStart (box, false, true, 0);

		Gtk.Label x_label = new Gtk.Label ("Rotate x-axis");
		box.PackStart (x_label, true, true, 0);
		Gtk.SpinButton x_button = new Gtk.SpinButton (0, 360, 1);
		box.PackStart (x_button, true , true, 0);
		x_button.ValueChanged += delegate { app.hand.SetRotation (RotateAxis.XAxis,
									  (float)app.x_button.Value, 
									  (int)app.hand.Height, 0, 0); 
						  };
		app.x_button = x_button;

		Gtk.Label y_label = new Gtk.Label ("Rotate y-axis");
		box.PackStart (y_label, true, true, 0);
		Gtk.SpinButton y_button = new Gtk.SpinButton (0, 360, 1);
		box.PackStart (y_button, true , true, 0);
		y_button.ValueChanged += delegate { app.hand.SetRotation (RotateAxis.YAxis,
									  (float)app.y_button.Value, 
									  0, (int)app.hand.Width/2, 0); 
						  };
		app.y_button = y_button;

		Gtk.Label z_label = new Gtk.Label ("Rotate z-axis");
		box.PackStart (z_label, true, true, 0);
		Gtk.SpinButton z_button = new Gtk.SpinButton (0, 360, 1);
		box.PackStart (z_button, true , true, 0);
		z_button.ValueChanged += delegate { app.hand.SetRotation(RotateAxis.ZAxis,
								         (float)app.z_button.Value, 
									 (int)app.hand.Width/2, (int)app.hand.Height/2, 0); 
						  };
		app.z_button = z_button;

		Gtk.Label op_label = new Gtk.Label ("Adjust opacity");
		box.PackStart (op_label, true, true, 0);
		Gtk.SpinButton op_button = new Gtk.SpinButton (0, 255, 1);
		op_button.Value = 255;
		box.PackStart (op_button, true , true, 0);
		op_button.ValueChanged += delegate { app.hand.Opacity = (byte)app.op_button.Value; };
		app.op_button = op_button;

		app.stage.ShowAll ();
		app.window.SetDefaultSize (800, 600);
		app.window.ShowAll ();

		Gtk.Application.Run ();
	}
}
