// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[StructLayout(LayoutKind.Sequential)]
	public struct BoxChild {

		private IntPtr _actor;
		public Clutter.Actor Actor {
			get {
				return GLib.Object.GetObject(_actor) as Clutter.Actor;
			}
			set {
				_actor = value == null ? IntPtr.Zero : value.Handle;
			}
		}
		public Clutter.ActorBox ChildCoords;
		public Clutter.PackType PackType;
		private Clutter.Padding padding;

		public static Clutter.BoxChild Zero = new Clutter.BoxChild ();

		public static Clutter.BoxChild New(IntPtr raw) {
			if (raw == IntPtr.Zero)
				return Clutter.BoxChild.Zero;
			return (Clutter.BoxChild) Marshal.PtrToStructure (raw, typeof (Clutter.BoxChild));
		}

		private static GLib.GType GType {
			get { return GLib.GType.Pointer; }
		}
#endregion
	}
}
