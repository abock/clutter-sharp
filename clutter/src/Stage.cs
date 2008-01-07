// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class Stage : Clutter.Group {

		[Obsolete]
		protected Stage(GLib.GType gtype) : base(gtype) {}
		public Stage(IntPtr raw) : base(raw) {}

		protected Stage() : base(IntPtr.Zero)
		{
			CreateNativeObject (new string [0], new GLib.Value [0]);
		}

		[DllImport("clutter")]
		static extern bool clutter_stage_get_use_fog(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_stage_set_use_fog(IntPtr raw, bool fog);

		[GLib.Property ("use-fog")]
		public bool UseFog {
			get  {
				bool raw_ret = clutter_stage_get_use_fog(Handle);
				bool ret = raw_ret;
				return ret;
			}
			set  {
				clutter_stage_set_use_fog(Handle, value);
			}
		}

		[DllImport("clutter")]
		static extern void clutter_stage_set_color(IntPtr raw, ref Clutter.Color color);

		[GLib.Property ("color")]
		public Clutter.Color Color {
			get {
				GLib.Value val = GetProperty ("color");
				Clutter.Color ret = (Clutter.Color) val;
				val.Dispose ();
				return ret;
			}
			set  {
				clutter_stage_set_color(Handle, ref value);
			}
		}

		[GLib.Property ("cursor-visible")]
		public bool CursorVisible {
			get {
				GLib.Value val = GetProperty ("cursor-visible");
				bool ret = (bool) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("cursor-visible", val);
				val.Dispose ();
			}
		}

		[DllImport("clutter")]
		static extern bool clutter_stage_get_user_resizable(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_stage_set_user_resizable(IntPtr raw, bool resizable);

		[GLib.Property ("user-resizable")]
		public bool UserResizable {
			get  {
				bool raw_ret = clutter_stage_get_user_resizable(Handle);
				bool ret = raw_ret;
				return ret;
			}
			set  {
				clutter_stage_set_user_resizable(Handle, value);
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_stage_get_title(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_stage_set_title(IntPtr raw, IntPtr title);

		[GLib.Property ("title")]
		public string Title {
			get  {
				IntPtr raw_ret = clutter_stage_get_title(Handle);
				string ret = GLib.Marshaller.Utf8PtrToString (raw_ret);
				return ret;
			}
			set  {
				IntPtr value_as_native = GLib.Marshaller.StringToPtrGStrdup (value);
				clutter_stage_set_title(Handle, value_as_native);
				GLib.Marshaller.Free (value_as_native);
			}
		}

		[GLib.Property ("fullscreen")]
		public bool Fullscreen {
			get {
				GLib.Value val = GetProperty ("fullscreen");
				bool ret = (bool) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("fullscreen", val);
				val.Dispose ();
			}
		}

		[GLib.Property ("offscreen")]
		public bool Offscreen {
			get {
				GLib.Value val = GetProperty ("offscreen");
				bool ret = (bool) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("offscreen", val);
				val.Dispose ();
			}
		}

		[GLib.CDeclCallback]
		delegate void UnfullscreenEventVMDelegate (IntPtr stage);

		static UnfullscreenEventVMDelegate UnfullscreenEventVMCallback;

		static void unfullscreenevent_cb (IntPtr stage)
		{
			try {
				Stage stage_managed = GLib.Object.GetObject (stage, false) as Stage;
				stage_managed.OnUnfullscreenEvent ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideUnfullscreenEvent (GLib.GType gtype)
		{
			if (UnfullscreenEventVMCallback == null)
				UnfullscreenEventVMCallback = new UnfullscreenEventVMDelegate (unfullscreenevent_cb);
			OverrideVirtualMethod (gtype, "unfullscreen", UnfullscreenEventVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Stage), ConnectionMethod="OverrideUnfullscreenEvent")]
		protected virtual void OnUnfullscreenEvent ()
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (1);
			GLib.Value[] vals = new GLib.Value [1];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
			foreach (GLib.Value v in vals)
				v.Dispose ();
		}

		[GLib.Signal("unfullscreen")]
		public event System.EventHandler UnfullscreenEvent {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "unfullscreen");
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "unfullscreen");
				sig.RemoveDelegate (value);
			}
		}

		[GLib.CDeclCallback]
		delegate void ActivateVMDelegate (IntPtr stage);

		static ActivateVMDelegate ActivateVMCallback;

		static void activate_cb (IntPtr stage)
		{
			try {
				Stage stage_managed = GLib.Object.GetObject (stage, false) as Stage;
				stage_managed.OnActivate ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideActivate (GLib.GType gtype)
		{
			if (ActivateVMCallback == null)
				ActivateVMCallback = new ActivateVMDelegate (activate_cb);
			OverrideVirtualMethod (gtype, "activate", ActivateVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Stage), ConnectionMethod="OverrideActivate")]
		protected virtual void OnActivate ()
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (1);
			GLib.Value[] vals = new GLib.Value [1];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
			foreach (GLib.Value v in vals)
				v.Dispose ();
		}

		[GLib.Signal("activate")]
		public event System.EventHandler Activate {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "activate");
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "activate");
				sig.RemoveDelegate (value);
			}
		}

		[GLib.CDeclCallback]
		delegate void FullscreenEventVMDelegate (IntPtr stage);

		static FullscreenEventVMDelegate FullscreenEventVMCallback;

		static void fullscreenevent_cb (IntPtr stage)
		{
			try {
				Stage stage_managed = GLib.Object.GetObject (stage, false) as Stage;
				stage_managed.OnFullscreenEvent ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideFullscreenEvent (GLib.GType gtype)
		{
			if (FullscreenEventVMCallback == null)
				FullscreenEventVMCallback = new FullscreenEventVMDelegate (fullscreenevent_cb);
			OverrideVirtualMethod (gtype, "fullscreen", FullscreenEventVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Stage), ConnectionMethod="OverrideFullscreenEvent")]
		protected virtual void OnFullscreenEvent ()
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (1);
			GLib.Value[] vals = new GLib.Value [1];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
			foreach (GLib.Value v in vals)
				v.Dispose ();
		}

		[GLib.Signal("fullscreen")]
		public event System.EventHandler FullscreenEvent {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "fullscreen");
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "fullscreen");
				sig.RemoveDelegate (value);
			}
		}

		[GLib.CDeclCallback]
		delegate void DeactivateVMDelegate (IntPtr stage);

		static DeactivateVMDelegate DeactivateVMCallback;

		static void deactivate_cb (IntPtr stage)
		{
			try {
				Stage stage_managed = GLib.Object.GetObject (stage, false) as Stage;
				stage_managed.OnDeactivate ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideDeactivate (GLib.GType gtype)
		{
			if (DeactivateVMCallback == null)
				DeactivateVMCallback = new DeactivateVMDelegate (deactivate_cb);
			OverrideVirtualMethod (gtype, "deactivate", DeactivateVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Stage), ConnectionMethod="OverrideDeactivate")]
		protected virtual void OnDeactivate ()
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (1);
			GLib.Value[] vals = new GLib.Value [1];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
			foreach (GLib.Value v in vals)
				v.Dispose ();
		}

		[GLib.Signal("deactivate")]
		public event System.EventHandler Deactivate {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "deactivate");
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "deactivate");
				sig.RemoveDelegate (value);
			}
		}

		[DllImport("clutter")]
		static extern void clutter_stage_show_cursor(IntPtr raw);

		public void ShowCursor() {
			clutter_stage_show_cursor(Handle);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_stage_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_stage_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_stage_get_default();

		public static Clutter.Stage Default { 
			get {
				IntPtr raw_ret = clutter_stage_get_default();
				Clutter.Stage ret = GLib.Object.GetObject(raw_ret) as Clutter.Stage;
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern void clutter_stage_get_fogx(IntPtr raw, ref Clutter.Fog fog);

		public void GetFogx(Clutter.Fog fog) {
			clutter_stage_get_fogx(Handle, ref fog);
		}

		[DllImport("clutter")]
		static extern void clutter_stage_set_perspectivex(IntPtr raw, ref Clutter.Perspective perspective);

		public void SetPerspectivex(Clutter.Perspective perspective) {
			clutter_stage_set_perspectivex(Handle, ref perspective);
		}

		[DllImport("clutter")]
		static extern void clutter_stage_set_fogx(IntPtr raw, ref Clutter.Fog fog);

		public void SetFogx(Clutter.Fog fog) {
			clutter_stage_set_fogx(Handle, ref fog);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_stage_get_actor_at_pos(IntPtr raw, int x, int y);

		public Clutter.Actor GetActorAtPos(int x, int y) {
			IntPtr raw_ret = clutter_stage_get_actor_at_pos(Handle, x, y);
			Clutter.Actor ret = GLib.Object.GetObject(raw_ret) as Clutter.Actor;
			return ret;
		}

		[DllImport("clutter")]
		static extern double clutter_stage_get_resolution(IntPtr raw);

		public double Resolution { 
			get {
				double raw_ret = clutter_stage_get_resolution(Handle);
				double ret = raw_ret;
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_stage_get_key_focus(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_stage_set_key_focus(IntPtr raw, IntPtr actor);

		public Clutter.Actor KeyFocus { 
			get {
				IntPtr raw_ret = clutter_stage_get_key_focus(Handle);
				Clutter.Actor ret = GLib.Object.GetObject(raw_ret) as Clutter.Actor;
				return ret;
			}
			set {
				clutter_stage_set_key_focus(Handle, value == null ? IntPtr.Zero : value.Handle);
			}
		}

		[DllImport("clutter")]
		static extern void clutter_stage_fullscreen(IntPtr raw);

		public void SetFullscreen() {
			clutter_stage_fullscreen(Handle);
		}

		[DllImport("clutter")]
		static extern void clutter_stage_hide_cursor(IntPtr raw);

		public void HideCursor() {
			clutter_stage_hide_cursor(Handle);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_stage_snapshot(IntPtr raw, int x, int y, int width, int height);

		public Gdk.Pixbuf Snapshot(int x, int y, int width, int height) {
			IntPtr raw_ret = clutter_stage_snapshot(Handle, x, y, width, height);
			Gdk.Pixbuf ret = GLib.Object.GetObject(raw_ret) as Gdk.Pixbuf;
			return ret;
		}

		[DllImport("clutter")]
		static extern void clutter_stage_get_fog(IntPtr raw, out double density, out double z_near, out double z_far);

		public void GetFog(out double density, out double z_near, out double z_far) {
			clutter_stage_get_fog(Handle, out density, out z_near, out z_far);
		}

		[DllImport("clutter")]
		static extern void clutter_stage_get_perspective(IntPtr raw, out float fovy, out float aspect, out float z_near, out float z_far);

		public void GetPerspective(out float fovy, out float aspect, out float z_near, out float z_far) {
			clutter_stage_get_perspective(Handle, out fovy, out aspect, out z_near, out z_far);
		}

		[DllImport("clutter")]
		static extern void clutter_stage_get_perspectivex(IntPtr raw, ref Clutter.Perspective perspective);

		public void GetPerspectivex(Clutter.Perspective perspective) {
			clutter_stage_get_perspectivex(Handle, ref perspective);
		}

		[DllImport("clutter")]
		static extern void clutter_stage_set_fog(IntPtr raw, double density, double z_near, double z_far);

		public void SetFog(double density, double z_near, double z_far) {
			clutter_stage_set_fog(Handle, density, z_near, z_far);
		}

		[DllImport("clutter")]
		static extern void clutter_stage_unfullscreen(IntPtr raw);

		public void Unfullscreen() {
			clutter_stage_unfullscreen(Handle);
		}

		[DllImport("clutter")]
		static extern void clutter_stage_get_color(IntPtr raw, ref Clutter.Color color);

		public void GetColor(Clutter.Color color) {
			clutter_stage_get_color(Handle, ref color);
		}

		[DllImport("clutter")]
		static extern int clutter_stage_get_resolutionx(IntPtr raw);

		public int Resolutionx { 
			get {
				int raw_ret = clutter_stage_get_resolutionx(Handle);
				int ret = raw_ret;
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern void clutter_stage_set_perspective(IntPtr raw, float fovy, float aspect, float z_near, float z_far);

		public void SetPerspective(float fovy, float aspect, float z_near, float z_far) {
			clutter_stage_set_perspective(Handle, fovy, aspect, z_near, z_far);
		}

#endregion
	}
}
