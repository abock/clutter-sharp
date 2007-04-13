
using System;
using System.Runtime.InteropServices;

namespace Clutter {
	public class ClutterRun {
			[DllImport("clutter")]
			static extern void clutter_main();

			public static void Main() {
				clutter_main();
			}

			[DllImport("clutter")]
			static extern void clutter_init (int argc, IntPtr argv);

			public static void Init( ) {
				clutter_init (0, IntPtr.Zero);
			}

		}
}
