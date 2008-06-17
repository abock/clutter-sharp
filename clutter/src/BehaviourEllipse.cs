// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class BehaviourEllipse : Clutter.Behaviour {

		[Obsolete]
		protected BehaviourEllipse(GLib.GType gtype) : base(gtype) {}
		public BehaviourEllipse(IntPtr raw) : base(raw) {}

		[DllImport("clutter")]
		static extern IntPtr clutter_behaviour_ellipse_new(IntPtr alpha, int x, int y, int width, int height, int direction, double start, double end);

		public BehaviourEllipse (Clutter.Alpha alpha, int x, int y, int width, int height, Clutter.RotateDirection direction, double start, double end) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (BehaviourEllipse)) {
				throw new InvalidOperationException ("Can't override this constructor.");
			}
			Raw = clutter_behaviour_ellipse_new(alpha == null ? IntPtr.Zero : alpha.Handle, x, y, width, height, (int) direction, start, end);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_behaviour_ellipse_newx(IntPtr alpha, int x, int y, int width, int height, int direction, int start, int end);

		public BehaviourEllipse (Clutter.Alpha alpha, int x, int y, int width, int height, Clutter.RotateDirection direction, int start, int end) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (BehaviourEllipse)) {
				throw new InvalidOperationException ("Can't override this constructor.");
			}
			Raw = clutter_behaviour_ellipse_newx(alpha == null ? IntPtr.Zero : alpha.Handle, x, y, width, height, (int) direction, start, end);
		}

		[DllImport("clutter")]
		static extern double clutter_behaviour_ellipse_get_angle_start(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_set_angle_start(IntPtr raw, double angle_start);

		[GLib.Property ("angle-start")]
		public double AngleStart {
			get  {
				double raw_ret = clutter_behaviour_ellipse_get_angle_start(Handle);
				double ret = raw_ret;
				return ret;
			}
			set  {
				clutter_behaviour_ellipse_set_angle_start(Handle, value);
			}
		}

		[GLib.Property ("angle-tilt-z")]
		public double AngleTiltZ {
			get {
				GLib.Value val = GetProperty ("angle-tilt-z");
				double ret = (double) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("angle-tilt-z", val);
				val.Dispose ();
			}
		}

		[GLib.Property ("center")]
		public Clutter.Knot Center {
			get {
				GLib.Value val = GetProperty ("center");
				Clutter.Knot ret = (Clutter.Knot) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = (GLib.Value) value;
				SetProperty("center", val);
				val.Dispose ();
			}
		}

		[DllImport("clutter")]
		static extern double clutter_behaviour_ellipse_get_angle_end(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_set_angle_end(IntPtr raw, double angle_end);

		[GLib.Property ("angle-end")]
		public double AngleEnd {
			get  {
				double raw_ret = clutter_behaviour_ellipse_get_angle_end(Handle);
				double ret = raw_ret;
				return ret;
			}
			set  {
				clutter_behaviour_ellipse_set_angle_end(Handle, value);
			}
		}

		[DllImport("clutter")]
		static extern int clutter_behaviour_ellipse_get_direction(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_set_direction(IntPtr raw, int direction);

		[GLib.Property ("direction")]
		public Clutter.RotateDirection Direction {
			get  {
				int raw_ret = clutter_behaviour_ellipse_get_direction(Handle);
				Clutter.RotateDirection ret = (Clutter.RotateDirection) raw_ret;
				return ret;
			}
			set  {
				clutter_behaviour_ellipse_set_direction(Handle, (int) value);
			}
		}

		[DllImport("clutter")]
		static extern int clutter_behaviour_ellipse_get_width(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_set_width(IntPtr raw, int width);

		[GLib.Property ("width")]
		public int Width {
			get  {
				int raw_ret = clutter_behaviour_ellipse_get_width(Handle);
				int ret = raw_ret;
				return ret;
			}
			set  {
				clutter_behaviour_ellipse_set_width(Handle, value);
			}
		}

		[GLib.Property ("angle-tilt-x")]
		public double AngleTiltX {
			get {
				GLib.Value val = GetProperty ("angle-tilt-x");
				double ret = (double) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("angle-tilt-x", val);
				val.Dispose ();
			}
		}

		[GLib.Property ("angle-tilt-y")]
		public double AngleTiltY {
			get {
				GLib.Value val = GetProperty ("angle-tilt-y");
				double ret = (double) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("angle-tilt-y", val);
				val.Dispose ();
			}
		}

		[DllImport("clutter")]
		static extern int clutter_behaviour_ellipse_get_height(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_set_height(IntPtr raw, int height);

		[GLib.Property ("height")]
		public int Height {
			get  {
				int raw_ret = clutter_behaviour_ellipse_get_height(Handle);
				int ret = raw_ret;
				return ret;
			}
			set  {
				clutter_behaviour_ellipse_set_height(Handle, value);
			}
		}

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_set_tilt(IntPtr raw, double angle_tilt_x, double angle_tilt_y, double angle_tilt_z);

		public void SetTilt(double angle_tilt_x, double angle_tilt_y, double angle_tilt_z) {
			clutter_behaviour_ellipse_set_tilt(Handle, angle_tilt_x, angle_tilt_y, angle_tilt_z);
		}

		[DllImport("clutter")]
		static extern double clutter_behaviour_ellipse_get_angle_tilt(IntPtr raw, int axis);

		public double GetAngleTilt(Clutter.RotateAxis axis) {
			double raw_ret = clutter_behaviour_ellipse_get_angle_tilt(Handle, (int) axis);
			double ret = raw_ret;
			return ret;
		}

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_set_angle_tilt(IntPtr raw, int axis, double angle_tilt);

		public void SetAngleTilt(Clutter.RotateAxis axis, double angle_tilt) {
			clutter_behaviour_ellipse_set_angle_tilt(Handle, (int) axis, angle_tilt);
		}

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_set_tiltx(IntPtr raw, int angle_tilt_x, int angle_tilt_y, int angle_tilt_z);

		public void SetTiltx(int angle_tilt_x, int angle_tilt_y, int angle_tilt_z) {
			clutter_behaviour_ellipse_set_tiltx(Handle, angle_tilt_x, angle_tilt_y, angle_tilt_z);
		}

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_get_tilt(IntPtr raw, out double angle_tilt_x, out double angle_tilt_y, out double angle_tilt_z);

		public void GetTilt(out double angle_tilt_x, out double angle_tilt_y, out double angle_tilt_z) {
			clutter_behaviour_ellipse_get_tilt(Handle, out angle_tilt_x, out angle_tilt_y, out angle_tilt_z);
		}

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_get_center(IntPtr raw, out int x, out int y);

		public void GetCenter(out int x, out int y) {
			clutter_behaviour_ellipse_get_center(Handle, out x, out y);
		}

		[DllImport("clutter")]
		static extern int clutter_behaviour_ellipse_get_angle_startx(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_set_angle_startx(IntPtr raw, int angle_start);

		public int AngleStartx { 
			get {
				int raw_ret = clutter_behaviour_ellipse_get_angle_startx(Handle);
				int ret = raw_ret;
				return ret;
			}
			set {
				clutter_behaviour_ellipse_set_angle_startx(Handle, value);
			}
		}

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_set_center(IntPtr raw, int x, int y);

		public void SetCenter(int x, int y) {
			clutter_behaviour_ellipse_set_center(Handle, x, y);
		}

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_get_tiltx(IntPtr raw, out int angle_tilt_x, out int angle_tilt_y, out int angle_tilt_z);

		public void GetTiltx(out int angle_tilt_x, out int angle_tilt_y, out int angle_tilt_z) {
			clutter_behaviour_ellipse_get_tiltx(Handle, out angle_tilt_x, out angle_tilt_y, out angle_tilt_z);
		}

		[DllImport("clutter")]
		static extern int clutter_behaviour_ellipse_get_angle_tiltx(IntPtr raw, int axis);

		public int GetAngleTiltx(Clutter.RotateAxis axis) {
			int raw_ret = clutter_behaviour_ellipse_get_angle_tiltx(Handle, (int) axis);
			int ret = raw_ret;
			return ret;
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_behaviour_ellipse_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_behaviour_ellipse_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_set_angle_tiltx(IntPtr raw, int axis, int angle_tilt);

		public void SetAngleTiltx(Clutter.RotateAxis axis, int angle_tilt) {
			clutter_behaviour_ellipse_set_angle_tiltx(Handle, (int) axis, angle_tilt);
		}

		[DllImport("clutter")]
		static extern int clutter_behaviour_ellipse_get_angle_endx(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_behaviour_ellipse_set_angle_endx(IntPtr raw, int angle_end);

		public int AngleEndx { 
			get {
				int raw_ret = clutter_behaviour_ellipse_get_angle_endx(Handle);
				int ret = raw_ret;
				return ret;
			}
			set {
				clutter_behaviour_ellipse_set_angle_endx(Handle, value);
			}
		}

#endregion
	}
}