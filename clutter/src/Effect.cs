// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public class Effect {

		[DllImport("clutter")]
		static extern IntPtr clutter_effect_move(IntPtr template_, IntPtr actor, int x, int y, ClutterSharp.EffectCompleteFuncNative func, IntPtr data);

		public static Clutter.Timeline Move(Clutter.EffectTemplate template_, Clutter.Actor actor, int x, int y, Clutter.EffectCompleteFunc func) {
			ClutterSharp.EffectCompleteFuncWrapper func_wrapper = new ClutterSharp.EffectCompleteFuncWrapper (func);
			IntPtr raw_ret = clutter_effect_move(template_ == null ? IntPtr.Zero : template_.Handle, actor == null ? IntPtr.Zero : actor.Handle, x, y, func_wrapper.NativeDelegate, IntPtr.Zero);
			Clutter.Timeline ret = GLib.Object.GetObject(raw_ret) as Clutter.Timeline;
			return ret;
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_effect_fade(IntPtr template_, IntPtr actor, byte opacity_end, ClutterSharp.EffectCompleteFuncNative func, IntPtr data);

		public static Clutter.Timeline Fade(Clutter.EffectTemplate template_, Clutter.Actor actor, byte opacity_end, Clutter.EffectCompleteFunc func) {
			ClutterSharp.EffectCompleteFuncWrapper func_wrapper = new ClutterSharp.EffectCompleteFuncWrapper (func);
			IntPtr raw_ret = clutter_effect_fade(template_ == null ? IntPtr.Zero : template_.Handle, actor == null ? IntPtr.Zero : actor.Handle, opacity_end, func_wrapper.NativeDelegate, IntPtr.Zero);
			Clutter.Timeline ret = GLib.Object.GetObject(raw_ret) as Clutter.Timeline;
			return ret;
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_effect_path(IntPtr template_, IntPtr actor, IntPtr knots, uint n_knots, ClutterSharp.EffectCompleteFuncNative func, IntPtr data);

		public static Clutter.Timeline Path(Clutter.EffectTemplate template_, Clutter.Actor actor, Clutter.Knot knots, uint n_knots, Clutter.EffectCompleteFunc func) {
			IntPtr native_knots = GLib.Marshaller.StructureToPtrAlloc (knots);
			ClutterSharp.EffectCompleteFuncWrapper func_wrapper = new ClutterSharp.EffectCompleteFuncWrapper (func);
			IntPtr raw_ret = clutter_effect_path(template_ == null ? IntPtr.Zero : template_.Handle, actor == null ? IntPtr.Zero : actor.Handle, native_knots, n_knots, func_wrapper.NativeDelegate, IntPtr.Zero);
			Clutter.Timeline ret = GLib.Object.GetObject(raw_ret) as Clutter.Timeline;
			knots = Clutter.Knot.New (native_knots);
			Marshal.FreeHGlobal (native_knots);
			return ret;
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_effect_depth(IntPtr template_, IntPtr actor, int depth_end, ClutterSharp.EffectCompleteFuncNative func, IntPtr data);

		public static Clutter.Timeline Depth(Clutter.EffectTemplate template_, Clutter.Actor actor, int depth_end, Clutter.EffectCompleteFunc func) {
			ClutterSharp.EffectCompleteFuncWrapper func_wrapper = new ClutterSharp.EffectCompleteFuncWrapper (func);
			IntPtr raw_ret = clutter_effect_depth(template_ == null ? IntPtr.Zero : template_.Handle, actor == null ? IntPtr.Zero : actor.Handle, depth_end, func_wrapper.NativeDelegate, IntPtr.Zero);
			Clutter.Timeline ret = GLib.Object.GetObject(raw_ret) as Clutter.Timeline;
			return ret;
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_effect_scale(IntPtr template_, IntPtr actor, double x_scale_end, double y_scale_end, ClutterSharp.EffectCompleteFuncNative func, IntPtr data);

		public static Clutter.Timeline Scale(Clutter.EffectTemplate template_, Clutter.Actor actor, double x_scale_end, double y_scale_end, Clutter.EffectCompleteFunc func) {
			ClutterSharp.EffectCompleteFuncWrapper func_wrapper = new ClutterSharp.EffectCompleteFuncWrapper (func);
			IntPtr raw_ret = clutter_effect_scale(template_ == null ? IntPtr.Zero : template_.Handle, actor == null ? IntPtr.Zero : actor.Handle, x_scale_end, y_scale_end, func_wrapper.NativeDelegate, IntPtr.Zero);
			Clutter.Timeline ret = GLib.Object.GetObject(raw_ret) as Clutter.Timeline;
			return ret;
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_effect_rotate(IntPtr template_, IntPtr actor, int axis, double angle, int center_x, int center_y, int center_z, int direction, ClutterSharp.EffectCompleteFuncNative func, IntPtr data);

		public static Clutter.Timeline Rotate(Clutter.EffectTemplate template_, Clutter.Actor actor, Clutter.RotateAxis axis, double angle, int center_x, int center_y, int center_z, Clutter.RotateDirection direction, Clutter.EffectCompleteFunc func) {
			ClutterSharp.EffectCompleteFuncWrapper func_wrapper = new ClutterSharp.EffectCompleteFuncWrapper (func);
			IntPtr raw_ret = clutter_effect_rotate(template_ == null ? IntPtr.Zero : template_.Handle, actor == null ? IntPtr.Zero : actor.Handle, (int) axis, angle, center_x, center_y, center_z, (int) direction, func_wrapper.NativeDelegate, IntPtr.Zero);
			Clutter.Timeline ret = GLib.Object.GetObject(raw_ret) as Clutter.Timeline;
			return ret;
		}

#endregion
	}
}
