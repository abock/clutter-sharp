// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;

	public delegate void TimelineCompletedHandler(object o, TimelineCompletedArgs args);

	public class TimelineCompletedArgs : GLib.SignalArgs {
		public Clutter.Timeline Timeline{
			get {
				return (Clutter.Timeline) Args[0];
			}
		}

	}
}