// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[GLib.GType (typeof (Clutter.TextureErrorGType))]
	public enum TextureError {

		OutOfMemory,
		NoYuv,
		BadFormat,
	}

	internal class TextureErrorGType {
		[DllImport ("clutter")]
		static extern IntPtr clutter_texture_error_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (clutter_texture_error_get_type ());
			}
		}
	}
#endregion
}
