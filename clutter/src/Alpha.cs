// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class Alpha : GLib.InitiallyUnowned {

		[Obsolete]
		protected Alpha(GLib.GType gtype) : base(gtype) {}
		public Alpha(IntPtr raw) : base(raw) {}

		[DllImport("clutter")]
		static extern IntPtr clutter_alpha_new();

		public Alpha () : base (IntPtr.Zero)
		{
			if (GetType () != typeof (Alpha)) {
				CreateNativeObject (new string [0], new GLib.Value[0]);
				return;
			}
			Raw = clutter_alpha_new();
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_alpha_new_full(IntPtr timeline, ClutterSharp.AlphaFuncNative func, IntPtr data, GLib.DestroyNotify destroy);

		public Alpha (Clutter.Timeline timeline, Clutter.AlphaFunc func) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (Alpha)) {
				throw new InvalidOperationException ("Can't override this constructor.");
			}
			ClutterSharp.AlphaFuncWrapper func_wrapper;
			IntPtr data;
			GLib.DestroyNotify destroy;
			if (func == null) {
				func_wrapper = null;
				data = IntPtr.Zero;
				destroy = null;
			} else {
				func_wrapper = new ClutterSharp.AlphaFuncWrapper (func);
				data = (IntPtr) GCHandle.Alloc (func_wrapper);
				destroy = GLib.DestroyHelper.NotifyHandler;
			}
			Raw = clutter_alpha_new_full(timeline == null ? IntPtr.Zero : timeline.Handle, func_wrapper.NativeDelegate, data, destroy);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_alpha_get_timeline(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_alpha_set_timeline(IntPtr raw, IntPtr timeline);

		[GLib.Property ("timeline")]
		public Clutter.Timeline Timeline {
			get  {
				IntPtr raw_ret = clutter_alpha_get_timeline(Handle);
				Clutter.Timeline ret = GLib.Object.GetObject(raw_ret) as Clutter.Timeline;
				return ret;
			}
			set  {
				clutter_alpha_set_timeline(Handle, value == null ? IntPtr.Zero : value.Handle);
			}
		}

		[DllImport("clutter")]
		static extern uint clutter_alpha_get_alpha(IntPtr raw);

		[GLib.Property ("alpha")]
		public uint AlphaProp {
			get  {
				uint raw_ret = clutter_alpha_get_alpha(Handle);
				uint ret = raw_ret;
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern void clutter_alpha_set_func(IntPtr raw, ClutterSharp.AlphaFuncNative func, IntPtr data, GLib.DestroyNotify destroy);

		public Clutter.AlphaFunc Func { 
			set {
				ClutterSharp.AlphaFuncWrapper value_wrapper;
				IntPtr data;
				GLib.DestroyNotify destroy;
				if (value == null) {
					value_wrapper = null;
					data = IntPtr.Zero;
					destroy = null;
				} else {
					value_wrapper = new ClutterSharp.AlphaFuncWrapper (value);
					data = (IntPtr) GCHandle.Alloc (value_wrapper);
					destroy = GLib.DestroyHelper.NotifyHandler;
				}
				clutter_alpha_set_func(Handle, value_wrapper.NativeDelegate, data, destroy);
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_alpha_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_alpha_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern void clutter_alpha_set_closure(IntPtr raw, IntPtr closure);

		public IntPtr Closure { 
			set {
				clutter_alpha_set_closure(Handle, value);
			}
		}

#endregion
	}
}
