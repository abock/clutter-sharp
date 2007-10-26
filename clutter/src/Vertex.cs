// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[StructLayout(LayoutKind.Sequential)]
	public struct Vertex {

		public int X;
		public int Y;
		public int Z;

		public static Clutter.Vertex Zero = new Clutter.Vertex ();

		public static Clutter.Vertex New(IntPtr raw) {
			if (raw == IntPtr.Zero)
				return Clutter.Vertex.Zero;
			return (Clutter.Vertex) Marshal.PtrToStructure (raw, typeof (Clutter.Vertex));
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_vertex_get_type();

		public static GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_vertex_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("glibsharpglue-2")]
		static extern IntPtr glibsharp_value_get_boxed (ref GLib.Value val);

		[DllImport("glibsharpglue-2")]
		static extern void glibsharp_value_set_boxed (ref GLib.Value val, ref Clutter.Vertex boxed);

		public static explicit operator GLib.Value (Clutter.Vertex boxed)
		{
			GLib.Value val = GLib.Value.Empty;
			val.Init (Clutter.Vertex.GType);
			glibsharp_value_set_boxed (ref val, ref boxed);
			return val;
		}

		public static explicit operator Clutter.Vertex (GLib.Value val)
		{
			IntPtr boxed_ptr = glibsharp_value_get_boxed (ref val);
			return New (boxed_ptr);
		}
#endregion
	}
}
