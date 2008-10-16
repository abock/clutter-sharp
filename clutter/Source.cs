namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

	//
	// Base class for IdleProxy and TimeoutProxy
	//
	internal class SourceProxy {
		internal Delegate real_handler;
		internal Delegate proxy_handler;

		internal void Remove ()
		{
			ArrayList keys = new ArrayList ();
			lock (Source.source_handlers) {
				foreach (uint code in Source.source_handlers.Keys)
					if (Source.source_handlers [code] == this)
						keys.Add (code);
				foreach (object key in keys)
					Source.source_handlers.Remove (key);
			}
			real_handler = null;
			proxy_handler = null;
		}
	}
	
        public class Source {
		private Source () {}
		
		internal static Hashtable source_handlers = new Hashtable ();
		
		[DllImport("glib")]
		static extern bool g_source_remove (uint tag);

		public static bool Remove (uint tag)
		{
			lock (Source.source_handlers)
				source_handlers.Remove (tag);
			return g_source_remove (tag);
		}
	}
}
