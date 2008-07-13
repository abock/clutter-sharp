// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class CloneTexture : Clutter.Actor {

		[Obsolete]
		protected CloneTexture(GLib.GType gtype) : base(gtype) {}
		public CloneTexture(IntPtr raw) : base(raw) {}

		[DllImport("clutter")]
		static extern IntPtr clutter_clone_texture_new(IntPtr texture);

		public CloneTexture (Clutter.Texture texture) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (CloneTexture)) {
				throw new InvalidOperationException ("Can't override this constructor.");
			}
			Raw = clutter_clone_texture_new(texture == null ? IntPtr.Zero : texture.Handle);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_clone_texture_get_parent_texture(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_clone_texture_set_parent_texture(IntPtr raw, IntPtr texture);

		[GLib.Property ("parent-texture")]
		public Clutter.Texture ParentTexture {
			get  {
				IntPtr raw_ret = clutter_clone_texture_get_parent_texture(Handle);
				Clutter.Texture ret = GLib.Object.GetObject(raw_ret) as Clutter.Texture;
				return ret;
			}
			set  {
				clutter_clone_texture_set_parent_texture(Handle, value == null ? IntPtr.Zero : value.Handle);
			}
		}

		[GLib.Property ("repeat-x")]
		public bool RepeatX {
			get {
				GLib.Value val = GetProperty ("repeat-x");
				bool ret = (bool) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("repeat-x", val);
				val.Dispose ();
			}
		}

		[GLib.Property ("repeat-y")]
		public bool RepeatY {
			get {
				GLib.Value val = GetProperty ("repeat-y");
				bool ret = (bool) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("repeat-y", val);
				val.Dispose ();
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_clone_texture_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_clone_texture_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

#endregion
	}
}
