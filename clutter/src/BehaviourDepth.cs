// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class BehaviourDepth : Clutter.Behaviour {

		~BehaviourDepth()
		{
			Dispose();
		}

		[Obsolete]
		protected BehaviourDepth(GLib.GType gtype) : base(gtype) {}
		public BehaviourDepth(IntPtr raw) : base(raw) {}

		[DllImport("clutter")]
		static extern IntPtr clutter_behaviour_depth_new(IntPtr alpha, int start_depth, int end_depth);

		public BehaviourDepth (Clutter.Alpha alpha, int start_depth, int end_depth) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (BehaviourDepth)) {
				ArrayList vals = new ArrayList();
				ArrayList names = new ArrayList();
				if (alpha != null) {
					names.Add ("alpha");
					vals.Add (new GLib.Value (alpha));
				}
				names.Add ("start_depth");
				vals.Add (new GLib.Value (start_depth));
				names.Add ("end_depth");
				vals.Add (new GLib.Value (end_depth));
				CreateNativeObject ((string[])names.ToArray (typeof (string)), (GLib.Value[])vals.ToArray (typeof (GLib.Value)));
				return;
			}
			Raw = clutter_behaviour_depth_new(alpha == null ? IntPtr.Zero : alpha.Handle, start_depth, end_depth);
		}

		[GLib.Property ("end-depth")]
		public int EndDepth {
			get {
				GLib.Value val = GetProperty ("end-depth");
				int ret = (int) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("end-depth", val);
				val.Dispose ();
			}
		}

		[GLib.Property ("start-depth")]
		public int StartDepth {
			get {
				GLib.Value val = GetProperty ("start-depth");
				int ret = (int) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("start-depth", val);
				val.Dispose ();
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_behaviour_depth_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_behaviour_depth_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

#endregion
	}
}
