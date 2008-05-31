// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;

#region Autogenerated code
	public interface Media : GLib.IWrapper {

		event Clutter.ErrorHandler Error;
		event System.EventHandler Eos;
		string Filename { 
			set;
		}
		int BufferPercent {
			get; 
		}
		bool CanSeek {
			get; 
		}
		bool Playing {
			get; set;
		}
		int Duration {
			get; 
		}
		double Volume {
			get; set;
		}
		string Uri {
			get; set;
		}
		int Position {
			get; set;
		}
	}

	[GLib.GInterface (typeof (MediaAdapter))]
	public interface MediaImplementor : GLib.IWrapper {

		string Uri { set; }
		bool Playing { get; set; }
		int Position { get; set; }
		double Volume { get; set; }
		bool CanSeek ();
		int BufferPercent { get; }
		int Duration { get; }
	}
#endregion
}
