namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

	public delegate bool IdleHandler ();

	public class Idle {

		[GLib.CDeclCallback]
		delegate bool IdleHandlerInternal ();


		internal class IdleProxy : SourceProxy {
			public IdleProxy (IdleHandler real)
			{
				real_handler = real;
				proxy_handler = new IdleHandlerInternal (Handler);
			}

			public bool Handler ()
			{
				IdleHandler idle_handler = (IdleHandler) real_handler;

				bool cont = idle_handler ();
				if (!cont)
					Remove ();
				return cont;
			}
		}
		
		private Idle ()
		{
		}
		
		[DllImport("clutter")]
		static extern uint clutter_threads_add_idle (IdleHandlerInternal d, IntPtr data);

		public static uint Add (IdleHandler hndlr)
		{
			IdleProxy p = new IdleProxy (hndlr);
			uint code = clutter_threads_add_idle ((IdleHandlerInternal) p.proxy_handler, IntPtr.Zero);
			lock (Source.source_handlers)
				Source.source_handlers [code] = p;

			return code;
		}
	}
}

