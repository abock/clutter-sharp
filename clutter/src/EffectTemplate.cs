// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class EffectTemplate : GLib.Object {

		~EffectTemplate()
		{
			Dispose();
		}

		[Obsolete]
		protected EffectTemplate(GLib.GType gtype) : base(gtype) {}
		public EffectTemplate(IntPtr raw) : base(raw) {}

		[DllImport("clutter")]
		static extern IntPtr clutter_effect_template_new(IntPtr timeline, ClutterSharp.AlphaFuncNative alpha_func);

		public EffectTemplate (Clutter.Timeline timeline, Clutter.AlphaFunc alpha_func) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (EffectTemplate)) {
				ArrayList vals = new ArrayList();
				ArrayList names = new ArrayList();
				if (timeline != null) {
					names.Add ("timeline");
					vals.Add (new GLib.Value (timeline));
				}
				names.Add ("alpha_func");
				vals.Add (new GLib.Value (alpha_func));
				CreateNativeObject ((string[])names.ToArray (typeof (string)), (GLib.Value[])vals.ToArray (typeof (GLib.Value)));
				return;
			}
			ClutterSharp.AlphaFuncWrapper alpha_func_wrapper = new ClutterSharp.AlphaFuncWrapper (alpha_func);
			Raw = clutter_effect_template_new(timeline == null ? IntPtr.Zero : timeline.Handle, alpha_func_wrapper.NativeDelegate);
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

		[GLib.Property ("alpha-func")]
		public IntPtr AlphaFunc {
			get {
				GLib.Value val = GetProperty ("alpha-func");
				IntPtr ret = (IntPtr) val;
				val.Dispose ();
				return ret;
			}
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

		[DllImport("clutter")]
		static extern IntPtr clutter_effect_template_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_effect_template_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

#endregion
	}
}
