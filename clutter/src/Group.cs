// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class Group : Clutter.Actor, Clutter.Container {

		[Obsolete]
		protected Group(GLib.GType gtype) : base(gtype) {}
		public Group(IntPtr raw) : base(raw) {}

		[DllImport("clutter")]
		static extern IntPtr clutter_group_new();

		public Group () : base (IntPtr.Zero)
		{
			if (GetType () != typeof (Group)) {
				CreateNativeObject (new string [0], new GLib.Value[0]);
				return;
			}
			Raw = clutter_group_new();
		}

		[GLib.CDeclCallback]
		delegate void AddEventSignalDelegate (IntPtr arg0, IntPtr arg1, IntPtr gch);

		static void AddEventSignalCallback (IntPtr arg0, IntPtr arg1, IntPtr gch)
		{
			Clutter.AddEventArgs args = new Clutter.AddEventArgs ();
			try {
				GLib.Signal sig = ((GCHandle) gch).Target as GLib.Signal;
				if (sig == null)
					throw new Exception("Unknown signal GC handle received " + gch);

				args.Args = new object[1];
				args.Args[0] = GLib.Object.GetObject(arg1) as Clutter.Actor;
				Clutter.AddEventHandler handler = (Clutter.AddEventHandler) sig.Handler;
				handler (GLib.Object.GetObject (arg0), args);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.CDeclCallback]
		delegate void AddEventVMDelegate (IntPtr group, IntPtr child);

		static AddEventVMDelegate AddEventVMCallback;

		static void addevent_cb (IntPtr group, IntPtr child)
		{
			try {
				Group group_managed = GLib.Object.GetObject (group, false) as Group;
				group_managed.OnAddEvent (GLib.Object.GetObject(child) as Clutter.Actor);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideAddEvent (GLib.GType gtype)
		{
			if (AddEventVMCallback == null)
				AddEventVMCallback = new AddEventVMDelegate (addevent_cb);
			OverrideVirtualMethod (gtype, "add", AddEventVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Group), ConnectionMethod="OverrideAddEvent")]
		protected virtual void OnAddEvent (Clutter.Actor child)
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (2);
			GLib.Value[] vals = new GLib.Value [2];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			vals [1] = new GLib.Value (child);
			inst_and_params.Append (vals [1]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
			foreach (GLib.Value v in vals)
				v.Dispose ();
		}

		[GLib.Signal("add")]
		public event Clutter.AddEventHandler AddEvent {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "add", new AddEventSignalDelegate(AddEventSignalCallback));
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "add", new AddEventSignalDelegate(AddEventSignalCallback));
				sig.RemoveDelegate (value);
			}
		}

		[GLib.CDeclCallback]
		delegate void RemoveEventSignalDelegate (IntPtr arg0, IntPtr arg1, IntPtr gch);

		static void RemoveEventSignalCallback (IntPtr arg0, IntPtr arg1, IntPtr gch)
		{
			Clutter.RemoveEventArgs args = new Clutter.RemoveEventArgs ();
			try {
				GLib.Signal sig = ((GCHandle) gch).Target as GLib.Signal;
				if (sig == null)
					throw new Exception("Unknown signal GC handle received " + gch);

				args.Args = new object[1];
				args.Args[0] = GLib.Object.GetObject(arg1) as Clutter.Actor;
				Clutter.RemoveEventHandler handler = (Clutter.RemoveEventHandler) sig.Handler;
				handler (GLib.Object.GetObject (arg0), args);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.CDeclCallback]
		delegate void RemoveEventVMDelegate (IntPtr group, IntPtr child);

		static RemoveEventVMDelegate RemoveEventVMCallback;

		static void removeevent_cb (IntPtr group, IntPtr child)
		{
			try {
				Group group_managed = GLib.Object.GetObject (group, false) as Group;
				group_managed.OnRemoveEvent (GLib.Object.GetObject(child) as Clutter.Actor);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideRemoveEvent (GLib.GType gtype)
		{
			if (RemoveEventVMCallback == null)
				RemoveEventVMCallback = new RemoveEventVMDelegate (removeevent_cb);
			OverrideVirtualMethod (gtype, "remove", RemoveEventVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Group), ConnectionMethod="OverrideRemoveEvent")]
		protected virtual void OnRemoveEvent (Clutter.Actor child)
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (2);
			GLib.Value[] vals = new GLib.Value [2];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			vals [1] = new GLib.Value (child);
			inst_and_params.Append (vals [1]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
			foreach (GLib.Value v in vals)
				v.Dispose ();
		}

		[GLib.Signal("remove")]
		public event Clutter.RemoveEventHandler RemoveEvent {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "remove", new RemoveEventSignalDelegate(RemoveEventSignalCallback));
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "remove", new RemoveEventSignalDelegate(RemoveEventSignalCallback));
				sig.RemoveDelegate (value);
			}
		}

		[DllImport("clutter")]
		static extern void clutter_group_add_many_valist(IntPtr raw, IntPtr first_actor, IntPtr var_args);

		[Obsolete]
		public void AddManyValist(Clutter.Actor first_actor, IntPtr var_args) {
			clutter_group_add_many_valist(Handle, first_actor == null ? IntPtr.Zero : first_actor.Handle, var_args);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_group_get_nth_child(IntPtr raw, int index_);

		public Clutter.Actor GetNthChild(int index_) {
			IntPtr raw_ret = clutter_group_get_nth_child(Handle, index_);
			Clutter.Actor ret = GLib.Object.GetObject(raw_ret) as Clutter.Actor;
			return ret;
		}

		[DllImport("clutter")]
		static extern void clutter_group_remove(IntPtr raw, IntPtr actor);

		[Obsolete]
		public void Remove(Clutter.Actor actor) {
			clutter_group_remove(Handle, actor == null ? IntPtr.Zero : actor.Handle);
		}

		[DllImport("clutter")]
		static extern void clutter_group_raise(IntPtr raw, IntPtr actor, IntPtr sibling);

		[Obsolete]
		public void Raise(Clutter.Actor actor, Clutter.Actor sibling) {
			clutter_group_raise(Handle, actor == null ? IntPtr.Zero : actor.Handle, sibling == null ? IntPtr.Zero : sibling.Handle);
		}

		[DllImport("clutter")]
		static extern void clutter_group_lower(IntPtr raw, IntPtr actor, IntPtr sibling);

		[Obsolete]
		public void Lower(Clutter.Actor actor, Clutter.Actor sibling) {
			clutter_group_lower(Handle, actor == null ? IntPtr.Zero : actor.Handle, sibling == null ? IntPtr.Zero : sibling.Handle);
		}

		[DllImport("clutter")]
		static extern void clutter_group_sort_depth_order(IntPtr raw);

		[Obsolete]
		public void SortDepthOrder() {
			clutter_group_sort_depth_order(Handle);
		}

		[DllImport("clutter")]
		static extern int clutter_group_get_n_children(IntPtr raw);

		public int NChildren { 
			get {
				int raw_ret = clutter_group_get_n_children(Handle);
				int ret = raw_ret;
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_group_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_group_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern void clutter_group_remove_all(IntPtr raw);

		public void RemoveAll() {
			clutter_group_remove_all(Handle);
		}

		[DllImport("clutter")]
		static extern void clutter_container_add_valist(IntPtr raw, IntPtr first_actor, IntPtr var_args);

		public void AddValist(Clutter.Actor first_actor, IntPtr var_args) {
			clutter_container_add_valist(Handle, first_actor == null ? IntPtr.Zero : first_actor.Handle, var_args);
		}

		[DllImport("clutter")]
		static extern void clutter_container_add_actor(IntPtr raw, IntPtr actor);

		public void AddActor(Clutter.Actor actor) {
			clutter_container_add_actor(Handle, actor == null ? IntPtr.Zero : actor.Handle);
		}

		[DllImport("clutter")]
		static extern void clutter_container_sort_depth_order(IntPtr raw);

		void Clutter.Container.SortDepthOrder() {
			clutter_container_sort_depth_order(Handle);
		}

		[DllImport("clutter")]
		static extern void clutter_container_lower_child(IntPtr raw, IntPtr actor, IntPtr sibling);

		public void LowerChild(Clutter.Actor actor, Clutter.Actor sibling) {
			clutter_container_lower_child(Handle, actor == null ? IntPtr.Zero : actor.Handle, sibling == null ? IntPtr.Zero : sibling.Handle);
		}

		[DllImport("clutter")]
		static extern void clutter_container_raise_child(IntPtr raw, IntPtr actor, IntPtr sibling);

		public void RaiseChild(Clutter.Actor actor, Clutter.Actor sibling) {
			clutter_container_raise_child(Handle, actor == null ? IntPtr.Zero : actor.Handle, sibling == null ? IntPtr.Zero : sibling.Handle);
		}

		[DllImport("clutter")]
		static extern void clutter_container_remove_valist(IntPtr raw, IntPtr first_actor, IntPtr var_args);

		public void RemoveValist(Clutter.Actor first_actor, IntPtr var_args) {
			clutter_container_remove_valist(Handle, first_actor == null ? IntPtr.Zero : first_actor.Handle, var_args);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_container_find_child_by_name(IntPtr raw, IntPtr child_name);

		public Clutter.Actor FindChildByName(string child_name) {
			IntPtr child_name_as_native = GLib.Marshaller.StringToPtrGStrdup (child_name);
			IntPtr raw_ret = clutter_container_find_child_by_name(Handle, child_name_as_native);
			Clutter.Actor ret = GLib.Object.GetObject(raw_ret) as Clutter.Actor;
			GLib.Marshaller.Free (child_name_as_native);
			return ret;
		}

		[DllImport("clutter")]
		static extern void clutter_container_remove_actor(IntPtr raw, IntPtr actor);

		public void RemoveActor(Clutter.Actor actor) {
			clutter_container_remove_actor(Handle, actor == null ? IntPtr.Zero : actor.Handle);
		}

		[DllImport("clutter")]
		static extern void clutter_container_foreach(IntPtr raw, ClutterSharp.CallbackNative cb, IntPtr user_data);

		public void Foreach(Clutter.Callback cb) {
			ClutterSharp.CallbackWrapper cb_wrapper = new ClutterSharp.CallbackWrapper (cb);
			clutter_container_foreach(Handle, cb_wrapper.NativeDelegate, IntPtr.Zero);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_container_get_children(IntPtr raw);

		public GLib.List Children { 
			get {
				IntPtr raw_ret = clutter_container_get_children(Handle);
				GLib.List ret = new GLib.List(raw_ret);
				return ret;
			}
		}

		[GLib.CDeclCallback]
		delegate void ActorRemovedSignalDelegate (IntPtr arg0, IntPtr arg1, IntPtr gch);

		static void ActorRemovedSignalCallback (IntPtr arg0, IntPtr arg1, IntPtr gch)
		{
			Clutter.ActorRemovedArgs args = new Clutter.ActorRemovedArgs ();
			try {
				GLib.Signal sig = ((GCHandle) gch).Target as GLib.Signal;
				if (sig == null)
					throw new Exception("Unknown signal GC handle received " + gch);

				args.Args = new object[1];
				args.Args[0] = GLib.Object.GetObject(arg1) as Clutter.Actor;
				Clutter.ActorRemovedHandler handler = (Clutter.ActorRemovedHandler) sig.Handler;
				handler (GLib.Object.GetObject (arg0), args);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.CDeclCallback]
		delegate void ActorRemovedVMDelegate (IntPtr container, IntPtr actor);

		static ActorRemovedVMDelegate ActorRemovedVMCallback;

		static void actorremoved_cb (IntPtr container, IntPtr actor)
		{
			try {
				Group container_managed = GLib.Object.GetObject (container, false) as Group;
				container_managed.OnActorRemoved (GLib.Object.GetObject(actor) as Clutter.Actor);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideActorRemoved (GLib.GType gtype)
		{
			if (ActorRemovedVMCallback == null)
				ActorRemovedVMCallback = new ActorRemovedVMDelegate (actorremoved_cb);
			OverrideVirtualMethod (gtype, "actor-removed", ActorRemovedVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Group), ConnectionMethod="OverrideActorRemoved")]
		protected virtual void OnActorRemoved (Clutter.Actor actor)
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (2);
			GLib.Value[] vals = new GLib.Value [2];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			vals [1] = new GLib.Value (actor);
			inst_and_params.Append (vals [1]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
			foreach (GLib.Value v in vals)
				v.Dispose ();
		}

		[GLib.Signal("actor-removed")]
		public event Clutter.ActorRemovedHandler ActorRemoved {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "actor-removed", new ActorRemovedSignalDelegate(ActorRemovedSignalCallback));
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "actor-removed", new ActorRemovedSignalDelegate(ActorRemovedSignalCallback));
				sig.RemoveDelegate (value);
			}
		}

		[GLib.CDeclCallback]
		delegate void ActorAddedSignalDelegate (IntPtr arg0, IntPtr arg1, IntPtr gch);

		static void ActorAddedSignalCallback (IntPtr arg0, IntPtr arg1, IntPtr gch)
		{
			Clutter.ActorAddedArgs args = new Clutter.ActorAddedArgs ();
			try {
				GLib.Signal sig = ((GCHandle) gch).Target as GLib.Signal;
				if (sig == null)
					throw new Exception("Unknown signal GC handle received " + gch);

				args.Args = new object[1];
				args.Args[0] = GLib.Object.GetObject(arg1) as Clutter.Actor;
				Clutter.ActorAddedHandler handler = (Clutter.ActorAddedHandler) sig.Handler;
				handler (GLib.Object.GetObject (arg0), args);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.CDeclCallback]
		delegate void ActorAddedVMDelegate (IntPtr container, IntPtr actor);

		static ActorAddedVMDelegate ActorAddedVMCallback;

		static void actoradded_cb (IntPtr container, IntPtr actor)
		{
			try {
				Group container_managed = GLib.Object.GetObject (container, false) as Group;
				container_managed.OnActorAdded (GLib.Object.GetObject(actor) as Clutter.Actor);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideActorAdded (GLib.GType gtype)
		{
			if (ActorAddedVMCallback == null)
				ActorAddedVMCallback = new ActorAddedVMDelegate (actoradded_cb);
			OverrideVirtualMethod (gtype, "actor-added", ActorAddedVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Group), ConnectionMethod="OverrideActorAdded")]
		protected virtual void OnActorAdded (Clutter.Actor actor)
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (2);
			GLib.Value[] vals = new GLib.Value [2];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			vals [1] = new GLib.Value (actor);
			inst_and_params.Append (vals [1]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
			foreach (GLib.Value v in vals)
				v.Dispose ();
		}

		[GLib.Signal("actor-added")]
		public event Clutter.ActorAddedHandler ActorAdded {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "actor-added", new ActorAddedSignalDelegate(ActorAddedSignalCallback));
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "actor-added", new ActorAddedSignalDelegate(ActorAddedSignalCallback));
				sig.RemoveDelegate (value);
			}
		}

#endregion
	}
}
