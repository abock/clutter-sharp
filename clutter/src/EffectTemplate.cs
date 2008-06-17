// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class EffectTemplate : GLib.Object {

		[Obsolete]
		protected EffectTemplate(GLib.GType gtype) : base(gtype) {}
		public EffectTemplate(IntPtr raw) : base(raw) {}

		[DllImport("clutter")]
		static extern IntPtr clutter_effect_template_new(IntPtr timeline, ClutterSharp.AlphaFuncNative alpha_func);

		public EffectTemplate (Clutter.Timeline timeline, Clutter.AlphaFunc alpha_func) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (EffectTemplate)) {
				throw new InvalidOperationException ("Can't override this constructor.");
			}
			ClutterSharp.AlphaFuncWrapper alpha_func_wrapper = new ClutterSharp.AlphaFuncWrapper (alpha_func);
			Raw = clutter_effect_template_new(timeline == null ? IntPtr.Zero : timeline.Handle, alpha_func_wrapper.NativeDelegate);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_effect_template_new_for_duration(uint msecs, ClutterSharp.AlphaFuncNative alpha_func);

		public EffectTemplate (uint msecs, Clutter.AlphaFunc alpha_func) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (EffectTemplate)) {
				throw new InvalidOperationException ("Can't override this constructor.");
			}
			ClutterSharp.AlphaFuncWrapper alpha_func_wrapper = new ClutterSharp.AlphaFuncWrapper (alpha_func);
			Raw = clutter_effect_template_new_for_duration(msecs, alpha_func_wrapper.NativeDelegate);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_effect_template_new_full(IntPtr timeline, ClutterSharp.AlphaFuncNative alpha_func, IntPtr user_data, GLib.DestroyNotify notify);

		public static EffectTemplate NewFull(Clutter.Timeline timeline, Clutter.AlphaFunc alpha_func)
		{
			ClutterSharp.AlphaFuncWrapper alpha_func_wrapper;
			IntPtr user_data;
			GLib.DestroyNotify notify;
			if (alpha_func == null) {
				alpha_func_wrapper = null;
				user_data = IntPtr.Zero;
				notify = null;
			} else {
				alpha_func_wrapper = new ClutterSharp.AlphaFuncWrapper (alpha_func);
				user_data = (IntPtr) GCHandle.Alloc (alpha_func_wrapper);
				notify = GLib.DestroyHelper.NotifyHandler;
			}
			EffectTemplate result = new EffectTemplate (clutter_effect_template_new_full(timeline == null ? IntPtr.Zero : timeline.Handle, alpha_func_wrapper.NativeDelegate, user_data, notify));
			return result;
		}

		[GLib.Property ("timeline")]
		public Clutter.Timeline Timeline {
			get {
				GLib.Value val = GetProperty ("timeline");
				Clutter.Timeline ret = (Clutter.Timeline) val;
				val.Dispose ();
				return ret;
			}
		}

		[GLib.Property ("clone")]
		public bool Clone {
			get {
				GLib.Value val = GetProperty ("clone");
				bool ret = (bool) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("clone", val);
				val.Dispose ();
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_effect_template_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_effect_template_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern bool clutter_effect_template_get_timeline_clone(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_effect_template_set_timeline_clone(IntPtr raw, bool setting);

		public bool TimelineClone { 
			get {
				bool raw_ret = clutter_effect_template_get_timeline_clone(Handle);
				bool ret = raw_ret;
				return ret;
			}
			set {
				clutter_effect_template_set_timeline_clone(Handle, value);
			}
		}

		[DllImport("clutter")]
		static extern void clutter_effect_template_construct(IntPtr raw, IntPtr timeline, ClutterSharp.AlphaFuncNative alpha_func, IntPtr user_data, GLib.DestroyNotify notify);

		public void Construct(Clutter.Timeline timeline, Clutter.AlphaFunc alpha_func) {
			ClutterSharp.AlphaFuncWrapper alpha_func_wrapper;
			IntPtr user_data;
			GLib.DestroyNotify notify;
			if (alpha_func == null) {
				alpha_func_wrapper = null;
				user_data = IntPtr.Zero;
				notify = null;
			} else {
				alpha_func_wrapper = new ClutterSharp.AlphaFuncWrapper (alpha_func);
				user_data = (IntPtr) GCHandle.Alloc (alpha_func_wrapper);
				notify = GLib.DestroyHelper.NotifyHandler;
			}
			clutter_effect_template_construct(Handle, timeline == null ? IntPtr.Zero : timeline.Handle, alpha_func_wrapper.NativeDelegate, user_data, notify);
		}

#endregion
	}
}