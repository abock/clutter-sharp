// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public class Ramp {

		[DllImport("clutter")]
		static extern uint clutter_ramp_dec_func(IntPtr alpha, IntPtr dummy);

		public static uint DecFunc(Clutter.Alpha alpha, IntPtr dummy) {
			uint raw_ret = clutter_ramp_dec_func(alpha == null ? IntPtr.Zero : alpha.Handle, dummy);
			uint ret = raw_ret;
			return ret;
		}

		[DllImport("clutter")]
		static extern uint clutter_ramp_func(IntPtr alpha, IntPtr dummy);

		public static uint Func(Clutter.Alpha alpha, IntPtr dummy) {
			uint raw_ret = clutter_ramp_func(alpha == null ? IntPtr.Zero : alpha.Handle, dummy);
			uint ret = raw_ret;
			return ret;
		}

		[DllImport("clutter")]
		static extern uint clutter_ramp_inc_func(IntPtr alpha, IntPtr dummy);

		public static uint IncFunc(Clutter.Alpha alpha, IntPtr dummy) {
			uint raw_ret = clutter_ramp_inc_func(alpha == null ? IntPtr.Zero : alpha.Handle, dummy);
			uint ret = raw_ret;
			return ret;
		}

#endregion
#region Customized extensions
#line 1 "Ramp.custom"
		public static uint DecFunc(Clutter.Alpha alpha) {
			return DecFunc (alpha, IntPtr.Zero);
		}

		public static uint Func(Clutter.Alpha alpha) {
		 	return Func (alpha, IntPtr.Zero);
		}

		public static uint IncFunc(Clutter.Alpha alpha) {
			return IncFunc (alpha, IntPtr.Zero); 
		}
		

#endregion
	}
}
