// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;

	public delegate void CursorEventHandler(object o, CursorEventArgs args);

	public class CursorEventArgs : GLib.SignalArgs {
		public Clutter.Geometry Geometry{
			get {
				return (Clutter.Geometry) Args[0];
			}
		}

	}
}