// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;

	public delegate void StageRemovedHandler(object o, StageRemovedArgs args);

	public class StageRemovedArgs : GLib.SignalArgs {
		public Clutter.Stage Stage{
			get {
				return (Clutter.Stage) Args[0];
			}
		}

	}
}
