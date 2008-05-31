// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public class Threads {

		[DllImport("clutter")]
		static extern void clutter_threads_enter();

		public static void Enter() {
			clutter_threads_enter();
		}

		[DllImport("clutter")]
		static extern void clutter_threads_leave();

		public static void Leave() {
			clutter_threads_leave();
		}

		[DllImport("clutter")]
		static extern uint clutter_threads_add_idle_full(int priority, GLibSharp.GSourceFuncNative func, IntPtr data, GLib.DestroyNotify notify);

		public static uint AddIdleFull(int priority, GLib.GSourceFunc func) {
			GLibSharp.GSourceFuncWrapper func_wrapper;
			IntPtr data;
			GLib.DestroyNotify notify;
			if (func == null) {
				func_wrapper = null;
				data = IntPtr.Zero;
				notify = null;
			} else {
				func_wrapper = new GLibSharp.GSourceFuncWrapper (func);
				data = (IntPtr) GCHandle.Alloc (func_wrapper);
				notify = GLib.DestroyHelper.NotifyHandler;
			}
			uint raw_ret = clutter_threads_add_idle_full(priority, func_wrapper.NativeDelegate, data, notify);
			uint ret = raw_ret;
			return ret;
		}

		[DllImport("clutter")]
		static extern void clutter_threads_init();

		public static void Init() {
			clutter_threads_init();
		}

		[DllImport("clutter")]
		static extern uint clutter_threads_add_idle(GLibSharp.GSourceFuncNative func, IntPtr data);

		public static uint AddIdle(GLib.GSourceFunc func) {
			GLibSharp.GSourceFuncWrapper func_wrapper = new GLibSharp.GSourceFuncWrapper (func);
			uint raw_ret = clutter_threads_add_idle(func_wrapper.NativeDelegate, IntPtr.Zero);
			uint ret = raw_ret;
			return ret;
		}

		[DllImport("clutter")]
		static extern uint clutter_threads_add_timeout(uint interval, GLibSharp.GSourceFuncNative func, IntPtr data);

		public static uint AddTimeout(uint interval, GLib.GSourceFunc func) {
			GLibSharp.GSourceFuncWrapper func_wrapper = new GLibSharp.GSourceFuncWrapper (func);
			uint raw_ret = clutter_threads_add_timeout(interval, func_wrapper.NativeDelegate, IntPtr.Zero);
			uint ret = raw_ret;
			return ret;
		}

		[DllImport("clutter")]
		static extern uint clutter_threads_add_timeout_full(int priority, uint interval, GLibSharp.GSourceFuncNative func, IntPtr data, GLib.DestroyNotify notify);

		public static uint AddTimeoutFull(int priority, uint interval, GLib.GSourceFunc func) {
			GLibSharp.GSourceFuncWrapper func_wrapper;
			IntPtr data;
			GLib.DestroyNotify notify;
			if (func == null) {
				func_wrapper = null;
				data = IntPtr.Zero;
				notify = null;
			} else {
				func_wrapper = new GLibSharp.GSourceFuncWrapper (func);
				data = (IntPtr) GCHandle.Alloc (func_wrapper);
				notify = GLib.DestroyHelper.NotifyHandler;
			}
			uint raw_ret = clutter_threads_add_timeout_full(priority, interval, func_wrapper.NativeDelegate, data, notify);
			uint ret = raw_ret;
			return ret;
		}

#endregion
	}
}
