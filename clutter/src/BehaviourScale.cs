// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class BehaviourScale : Clutter.Behaviour {

		~BehaviourScale()
		{
			Dispose();
		}

		[Obsolete]
		protected BehaviourScale(GLib.GType gtype) : base(gtype) {}
		public BehaviourScale(IntPtr raw) : base(raw) {}

		[DllImport("clutter")]
		static extern IntPtr clutter_behaviour_scale_new(IntPtr alpha, double scale_begin, double scale_end, int gravity);

		public BehaviourScale (Clutter.Alpha alpha, double scale_begin, double scale_end, Clutter.Gravity gravity) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (BehaviourScale)) {
				throw new InvalidOperationException ("Can't override this constructor.");
			}
			Raw = clutter_behaviour_scale_new(alpha == null ? IntPtr.Zero : alpha.Handle, scale_begin, scale_end, (int) gravity);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_behaviour_scale_newx(IntPtr alpha, int scale_begin, int scale_end, int gravity);

		public BehaviourScale (Clutter.Alpha alpha, int scale_begin, int scale_end, Clutter.Gravity gravity) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (BehaviourScale)) {
				throw new InvalidOperationException ("Can't override this constructor.");
			}
			Raw = clutter_behaviour_scale_newx(alpha == null ? IntPtr.Zero : alpha.Handle, scale_begin, scale_end, (int) gravity);
		}

		[GLib.Property ("scale-gravity")]
		public Clutter.Gravity ScaleGravity {
			get {
				GLib.Value val = GetProperty ("scale-gravity");
				Clutter.Gravity ret = (Clutter.Gravity) (Enum) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value((Enum) value);
				SetProperty("scale-gravity", val);
				val.Dispose ();
			}
		}

		[GLib.Property ("scale-begin")]
		public double ScaleBegin {
			get {
				GLib.Value val = GetProperty ("scale-begin");
				double ret = (double) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("scale-begin", val);
				val.Dispose ();
			}
		}

		[GLib.Property ("scale-end")]
		public double ScaleEnd {
			get {
				GLib.Value val = GetProperty ("scale-end");
				double ret = (double) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("scale-end", val);
				val.Dispose ();
			}
		}

		[DllImport("clutter")]
		static extern int clutter_behaviour_scale_get_gravity(IntPtr raw);

		public Clutter.Gravity Gravity { 
			get {
				int raw_ret = clutter_behaviour_scale_get_gravity(Handle);
				Clutter.Gravity ret = (Clutter.Gravity) raw_ret;
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern void clutter_behaviour_scale_get_boundsx(IntPtr raw, out int scale_begin, out int scale_end);

		public void GetBoundsx(out int scale_begin, out int scale_end) {
			clutter_behaviour_scale_get_boundsx(Handle, out scale_begin, out scale_end);
		}

		[DllImport("clutter")]
		static extern void clutter_behaviour_scale_get_bounds(IntPtr raw, out double scale_begin, out double scale_end);

		public void GetBounds(out double scale_begin, out double scale_end) {
			clutter_behaviour_scale_get_bounds(Handle, out scale_begin, out scale_end);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_behaviour_scale_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_behaviour_scale_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

#endregion
	}
}
