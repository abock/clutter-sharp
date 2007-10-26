// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace ClutterSharp {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[GLib.CDeclCallback]
	internal delegate void EffectCompleteFuncNative(IntPtr actor, IntPtr user_data);

	internal class EffectCompleteFuncWrapper {

		public void NativeCallback (IntPtr actor, IntPtr user_data)
		{
			try {
				Clutter.Actor _arg0 = GLib.Object.GetObject(actor) as Clutter.Actor;
				managed ( _arg0);
				if (release_on_call)
					gch.Free ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		bool release_on_call = false;
		GCHandle gch;

		public void PersistUntilCalled ()
		{
			release_on_call = true;
			gch = GCHandle.Alloc (this);
		}

		internal EffectCompleteFuncNative NativeDelegate;
		Clutter.EffectCompleteFunc managed;

		public EffectCompleteFuncWrapper (Clutter.EffectCompleteFunc managed)
		{
			this.managed = managed;
			if (managed != null)
				NativeDelegate = new EffectCompleteFuncNative (NativeCallback);
		}

		public static Clutter.EffectCompleteFunc GetManagedDelegate (EffectCompleteFuncNative native)
		{
			if (native == null)
				return null;
			EffectCompleteFuncWrapper wrapper = (EffectCompleteFuncWrapper) native.Target;
			if (wrapper == null)
				return null;
			return wrapper.managed;
		}
	}
#endregion
}
