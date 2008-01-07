// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class Timeline : GLib.Object {

		[Obsolete]
		protected Timeline(GLib.GType gtype) : base(gtype) {}
		public Timeline(IntPtr raw) : base(raw) {}

		[DllImport("clutter")]
		static extern IntPtr clutter_timeline_new(uint n_frames, uint fps);

		public Timeline (uint n_frames, uint fps) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (Timeline)) {
				throw new InvalidOperationException ("Can't override this constructor.");
			}
			Raw = clutter_timeline_new(n_frames, fps);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_timeline_new_for_duration(uint msecs);

		public Timeline (uint msecs) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (Timeline)) {
				throw new InvalidOperationException ("Can't override this constructor.");
			}
			Raw = clutter_timeline_new_for_duration(msecs);
		}

		[DllImport("clutter")]
		static extern bool clutter_timeline_get_loop(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_timeline_set_loop(IntPtr raw, bool loop);

		[GLib.Property ("loop")]
		public bool Loop {
			get  {
				bool raw_ret = clutter_timeline_get_loop(Handle);
				bool ret = raw_ret;
				return ret;
			}
			set  {
				clutter_timeline_set_loop(Handle, value);
			}
		}

		[GLib.Property ("num-frames")]
		public uint NumFrames {
			get {
				GLib.Value val = GetProperty ("num-frames");
				uint ret = (uint) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("num-frames", val);
				val.Dispose ();
			}
		}

		[DllImport("clutter")]
		static extern int clutter_timeline_get_direction(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_timeline_set_direction(IntPtr raw, int direction);

		[GLib.Property ("direction")]
		public Clutter.TimelineDirection Direction {
			get  {
				int raw_ret = clutter_timeline_get_direction(Handle);
				Clutter.TimelineDirection ret = (Clutter.TimelineDirection) raw_ret;
				return ret;
			}
			set  {
				clutter_timeline_set_direction(Handle, (int) value);
			}
		}

		[DllImport("clutter")]
		static extern uint clutter_timeline_get_delay(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_timeline_set_delay(IntPtr raw, uint msecs);

		[GLib.Property ("delay")]
		public uint Delay {
			get  {
				uint raw_ret = clutter_timeline_get_delay(Handle);
				uint ret = raw_ret;
				return ret;
			}
			set  {
				clutter_timeline_set_delay(Handle, value);
			}
		}

		[GLib.Property ("fps")]
		public uint Fps {
			get {
				GLib.Value val = GetProperty ("fps");
				uint ret = (uint) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("fps", val);
				val.Dispose ();
			}
		}

		[DllImport("clutter")]
		static extern uint clutter_timeline_get_duration(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_timeline_set_duration(IntPtr raw, uint msecs);

		[GLib.Property ("duration")]
		public uint Duration {
			get  {
				uint raw_ret = clutter_timeline_get_duration(Handle);
				uint ret = raw_ret;
				return ret;
			}
			set  {
				clutter_timeline_set_duration(Handle, value);
			}
		}

		[GLib.CDeclCallback]
		delegate void StartedVMDelegate (IntPtr timeline);

		static StartedVMDelegate StartedVMCallback;

		static void started_cb (IntPtr timeline)
		{
			try {
				Timeline timeline_managed = GLib.Object.GetObject (timeline, false) as Timeline;
				timeline_managed.OnStarted ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideStarted (GLib.GType gtype)
		{
			if (StartedVMCallback == null)
				StartedVMCallback = new StartedVMDelegate (started_cb);
			OverrideVirtualMethod (gtype, "started", StartedVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Timeline), ConnectionMethod="OverrideStarted")]
		protected virtual void OnStarted ()
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

		[GLib.Signal("started")]
		public event System.EventHandler Started {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "started");
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "started");
				sig.RemoveDelegate (value);
			}
		}

		[GLib.CDeclCallback]
		delegate void CompletedVMDelegate (IntPtr timeline);

		static CompletedVMDelegate CompletedVMCallback;

		static void completed_cb (IntPtr timeline)
		{
			try {
				Timeline timeline_managed = GLib.Object.GetObject (timeline, false) as Timeline;
				timeline_managed.OnCompleted ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideCompleted (GLib.GType gtype)
		{
			if (CompletedVMCallback == null)
				CompletedVMCallback = new CompletedVMDelegate (completed_cb);
			OverrideVirtualMethod (gtype, "completed", CompletedVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Timeline), ConnectionMethod="OverrideCompleted")]
		protected virtual void OnCompleted ()
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

		[GLib.Signal("completed")]
		public event System.EventHandler Completed {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "completed");
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "completed");
				sig.RemoveDelegate (value);
			}
		}

		[GLib.CDeclCallback]
		delegate void PausedVMDelegate (IntPtr timeline);

		static PausedVMDelegate PausedVMCallback;

		static void paused_cb (IntPtr timeline)
		{
			try {
				Timeline timeline_managed = GLib.Object.GetObject (timeline, false) as Timeline;
				timeline_managed.OnPaused ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverridePaused (GLib.GType gtype)
		{
			if (PausedVMCallback == null)
				PausedVMCallback = new PausedVMDelegate (paused_cb);
			OverrideVirtualMethod (gtype, "paused", PausedVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Timeline), ConnectionMethod="OverridePaused")]
		protected virtual void OnPaused ()
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

		[GLib.Signal("paused")]
		public event System.EventHandler Paused {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "paused");
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "paused");
				sig.RemoveDelegate (value);
			}
		}

		[GLib.CDeclCallback]
		delegate void NewFrameSignalDelegate (IntPtr arg0, int arg1, IntPtr gch);

		static void NewFrameSignalCallback (IntPtr arg0, int arg1, IntPtr gch)
		{
			Clutter.NewFrameArgs args = new Clutter.NewFrameArgs ();
			try {
				GLib.Signal sig = ((GCHandle) gch).Target as GLib.Signal;
				if (sig == null)
					throw new Exception("Unknown signal GC handle received " + gch);

				args.Args = new object[1];
				args.Args[0] = arg1;
				Clutter.NewFrameHandler handler = (Clutter.NewFrameHandler) sig.Handler;
				handler (GLib.Object.GetObject (arg0), args);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.CDeclCallback]
		delegate void NewFrameVMDelegate (IntPtr timeline, int frame_num);

		static NewFrameVMDelegate NewFrameVMCallback;

		static void newframe_cb (IntPtr timeline, int frame_num)
		{
			try {
				Timeline timeline_managed = GLib.Object.GetObject (timeline, false) as Timeline;
				timeline_managed.OnNewFrame (frame_num);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideNewFrame (GLib.GType gtype)
		{
			if (NewFrameVMCallback == null)
				NewFrameVMCallback = new NewFrameVMDelegate (newframe_cb);
			OverrideVirtualMethod (gtype, "new-frame", NewFrameVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Timeline), ConnectionMethod="OverrideNewFrame")]
		protected virtual void OnNewFrame (int frame_num)
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (2);
			GLib.Value[] vals = new GLib.Value [2];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			vals [1] = new GLib.Value (frame_num);
			inst_and_params.Append (vals [1]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
			foreach (GLib.Value v in vals)
				v.Dispose ();
		}

		[GLib.Signal("new-frame")]
		public event Clutter.NewFrameHandler NewFrame {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "new-frame", new NewFrameSignalDelegate(NewFrameSignalCallback));
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "new-frame", new NewFrameSignalDelegate(NewFrameSignalCallback));
				sig.RemoveDelegate (value);
			}
		}

		[DllImport("clutter")]
		static extern void clutter_timeline_advance(IntPtr raw, uint frame_num);

		public void Advance(uint frame_num) {
			clutter_timeline_advance(Handle, frame_num);
		}

		[DllImport("clutter")]
		static extern uint clutter_timeline_get_delta(IntPtr raw, out uint msecs);

		public uint GetDelta(out uint msecs) {
			uint raw_ret = clutter_timeline_get_delta(Handle, out msecs);
			uint ret = raw_ret;
			return ret;
		}

		[DllImport("clutter")]
		static extern void clutter_timeline_start(IntPtr raw);

		public void Start() {
			clutter_timeline_start(Handle);
		}

		[DllImport("clutter")]
		static extern uint clutter_timeline_get_n_frames(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_timeline_set_n_frames(IntPtr raw, uint n_frames);

		public uint NFrames { 
			get {
				uint raw_ret = clutter_timeline_get_n_frames(Handle);
				uint ret = raw_ret;
				return ret;
			}
			set {
				clutter_timeline_set_n_frames(Handle, value);
			}
		}

		[DllImport("clutter")]
		static extern bool clutter_timeline_is_playing(IntPtr raw);

		public bool IsPlaying { 
			get {
				bool raw_ret = clutter_timeline_is_playing(Handle);
				bool ret = raw_ret;
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_timeline_clone(IntPtr raw);

		public Clutter.Timeline Clone() {
			IntPtr raw_ret = clutter_timeline_clone(Handle);
			Clutter.Timeline ret = GLib.Object.GetObject(raw_ret) as Clutter.Timeline;
			return ret;
		}

		[DllImport("clutter")]
		static extern void clutter_timeline_rewind(IntPtr raw);

		public void Rewind() {
			clutter_timeline_rewind(Handle);
		}

		[DllImport("clutter")]
		static extern double clutter_timeline_get_progress(IntPtr raw);

		public double Progress { 
			get {
				double raw_ret = clutter_timeline_get_progress(Handle);
				double ret = raw_ret;
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern int clutter_timeline_get_current_frame(IntPtr raw);

		public int CurrentFrame { 
			get {
				int raw_ret = clutter_timeline_get_current_frame(Handle);
				int ret = raw_ret;
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern void clutter_timeline_skip(IntPtr raw, uint n_frames);

		public void Skip(uint n_frames) {
			clutter_timeline_skip(Handle, n_frames);
		}

		[DllImport("clutter")]
		static extern void clutter_timeline_pause(IntPtr raw);

		public void Pause() {
			clutter_timeline_pause(Handle);
		}

		[DllImport("clutter")]
		static extern int clutter_timeline_get_progressx(IntPtr raw);

		public int Progressx { 
			get {
				int raw_ret = clutter_timeline_get_progressx(Handle);
				int ret = raw_ret;
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern uint clutter_timeline_get_speed(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_timeline_set_speed(IntPtr raw, uint fps);

		public uint Speed { 
			get {
				uint raw_ret = clutter_timeline_get_speed(Handle);
				uint ret = raw_ret;
				return ret;
			}
			set {
				clutter_timeline_set_speed(Handle, value);
			}
		}

		[DllImport("clutter")]
		static extern void clutter_timeline_stop(IntPtr raw);

		public void Stop() {
			clutter_timeline_stop(Handle);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_timeline_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_timeline_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

#endregion
	}
}
