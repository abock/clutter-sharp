// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class VBox : Clutter.Box, Clutter.Layout {

		~VBox()
		{
			Dispose();
		}

		[Obsolete]
		protected VBox(GLib.GType gtype) : base(gtype) {}
		public VBox(IntPtr raw) : base(raw) {}

		[DllImport("clutter")]
		static extern IntPtr clutter_vbox_new();

		public VBox () : base (IntPtr.Zero)
		{
			if (GetType () != typeof (VBox)) {
				CreateNativeObject (new string [0], new GLib.Value[0]);
				return;
			}
			Raw = clutter_vbox_new();
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_vbox_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_vbox_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern void clutter_layout_natural_request(IntPtr raw, out int width, out int height);

		public void NaturalRequest(out int width, out int height) {
			clutter_layout_natural_request(Handle, out width, out height);
		}

		[DllImport("clutter")]
		static extern void clutter_layout_height_for_width(IntPtr raw, int width, out int height);

		public int HeightForWidth(int width) {
			int height;
			clutter_layout_height_for_width(Handle, width, out height);
			return height;
		}

		[DllImport("clutter")]
		static extern void clutter_layout_width_for_height(IntPtr raw, out int width, int height);

		public int WidthForHeight(int height) {
			int width;
			clutter_layout_width_for_height(Handle, out width, height);
			return width;
		}

		[DllImport("clutter")]
		static extern void clutter_layout_tune_request(IntPtr raw, int given_width, int given_height, out int width, out int height);

		public void TuneRequest(int given_width, int given_height, out int width, out int height) {
			clutter_layout_tune_request(Handle, given_width, given_height, out width, out height);
		}

		[DllImport("clutter")]
		static extern int clutter_layout_get_layout_flags(IntPtr raw);

		[GLib.Property ("layout-flags")]
		public Clutter.LayoutFlags LayoutFlags {
			get  {
				int raw_ret = clutter_layout_get_layout_flags(Handle);
				Clutter.LayoutFlags ret = (Clutter.LayoutFlags) raw_ret;
				return ret;
			}
		}

#endregion
	}
}
