using System;

using Clutter;

namespace ClutterTest
{
	public class TestEntry
	{
		static Color stage_color = new Color (0x00, 0x00, 0x00, 0xff);
		static Color entry_color = new Color (0x33, 0xdd, 0xff, 0xff);
		static Entry entry;

	 	public static void Main ()
		{
		 	ClutterRun.Init ();

			Stage stage = Stage.Default;
			stage.SetSize (800, 600);
			stage.Color = stage_color;
			stage.Title = "ClutterEntry Test";

			entry = new Entry ("Sans 14", 
	                	"Type something, be sure to use the " +
	   	        	"left/right arrow keys to move the "  +
	            	        "cursor position.");

			entry.Color = entry_color;
			entry.SetSize (600, 50);
			entry.SetPosition (100, 100);

			stage.KeyFocus = entry;
			stage.AddActor (entry);
			stage.ShowAll ();

			ClutterRun.Main ();
		}
	} 
}
