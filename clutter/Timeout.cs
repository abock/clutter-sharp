namespace Clutter {

	using System;
	using System.Runtime.InteropServices;

	public delegate bool TimeoutHandler ();

	public class Timeout {

		[GLib.CDeclCallback]
		delegate bool TimeoutHandlerInternal ();

		internal class TimeoutProxy : SourceProxy {
			public TimeoutProxy (TimeoutHandler real)
			{
				real_handler = real;
				proxy_handler = new TimeoutHandlerInternal (Handler);
			}

			public bool Handler ()
			{
				TimeoutHandler timeout_handler = (TimeoutHandler) real_handler;

				bool cont = timeout_handler ();
				if (!cont)
					Remove ();
				return cont;
			}
		}
		
		private Timeout () {} 
		[DllImport("clutter")]
		static extern uint clutter_threads_add_timeout (uint interval, TimeoutHandlerInternal d, IntPtr data);

		public static uint Add (uint interval, TimeoutHandler hndlr)
		{
			TimeoutProxy p = new TimeoutProxy (hndlr);

			uint code = clutter_threads_add_timeout (interval, (TimeoutHandlerInternal) p.proxy_handler, IntPtr.Zero);
			lock (Source.source_handlers)
				Source.source_handlers [code] = p;

			return code;
		}
	}
}

