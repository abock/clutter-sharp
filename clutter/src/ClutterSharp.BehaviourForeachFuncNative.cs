// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace ClutterSharp {

	using System;

#region Autogenerated code
	[GLib.CDeclCallback]
	internal delegate void BehaviourForeachFuncNative(IntPtr behaviour, IntPtr actor, IntPtr data);

	internal class BehaviourForeachFuncWrapper {

		public void NativeCallback (IntPtr behaviour, IntPtr actor, IntPtr data)
		{
			Clutter.Behaviour _arg0 = GLib.Object.GetObject(behaviour) as Clutter.Behaviour;
			Clutter.Actor _arg1 = GLib.Object.GetObject(actor) as Clutter.Actor;
			managed ( _arg0,  _arg1);
		}

		internal BehaviourForeachFuncNative NativeDelegate;
		Clutter.BehaviourForeachFunc managed;

		public BehaviourForeachFuncWrapper (Clutter.BehaviourForeachFunc managed)
		{
			this.managed = managed;
			if (managed != null)
				NativeDelegate = new BehaviourForeachFuncNative (NativeCallback);
		}

		public static Clutter.BehaviourForeachFunc GetManagedDelegate (BehaviourForeachFuncNative native)
		{
			if (native == null)
				return null;
			BehaviourForeachFuncWrapper wrapper = (BehaviourForeachFuncWrapper) native.Target;
			if (wrapper == null)
				return null;
			return wrapper.managed;
		}
	}
#endregion
}
