// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class Entry : Clutter.Actor {

		[Obsolete]
		protected Entry(GLib.GType gtype) : base(gtype) {}
		public Entry(IntPtr raw) : base(raw) {}

		[DllImport("clutter")]
		static extern IntPtr clutter_entry_new();

		public Entry () : base (IntPtr.Zero)
		{
			if (GetType () != typeof (Entry)) {
				CreateNativeObject (new string [0], new GLib.Value[0]);
				return;
			}
			Raw = clutter_entry_new();
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_entry_new_full(IntPtr font_name, IntPtr text, IntPtr color);

		public Entry (string font_name, string text, Clutter.Color color) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (Entry)) {
				ArrayList vals = new ArrayList();
				ArrayList names = new ArrayList();
				names.Add ("font_name");
				vals.Add (new GLib.Value (font_name));
				names.Add ("text");
				vals.Add (new GLib.Value (text));
				names.Add ("color");
				vals.Add (new GLib.Value (color));
				CreateNativeObject ((string[])names.ToArray (typeof (string)), (GLib.Value[])vals.ToArray (typeof (GLib.Value)));
				return;
			}
			IntPtr native_font_name = GLib.Marshaller.StringToPtrGStrdup (font_name);
			IntPtr native_text = GLib.Marshaller.StringToPtrGStrdup (text);
			IntPtr native_color = GLib.Marshaller.StructureToPtrAlloc (color);
			Raw = clutter_entry_new_full(native_font_name, native_text, native_color);
			GLib.Marshaller.Free (native_font_name);
			GLib.Marshaller.Free (native_text);
			color = Clutter.Color.New (native_color);
			Marshal.FreeHGlobal (native_color);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_entry_new_with_text(IntPtr font_name, IntPtr text);

		public Entry (string font_name, string text) : base (IntPtr.Zero)
		{
			if (GetType () != typeof (Entry)) {
				ArrayList vals = new ArrayList();
				ArrayList names = new ArrayList();
				names.Add ("font_name");
				vals.Add (new GLib.Value (font_name));
				names.Add ("text");
				vals.Add (new GLib.Value (text));
				CreateNativeObject ((string[])names.ToArray (typeof (string)), (GLib.Value[])vals.ToArray (typeof (GLib.Value)));
				return;
			}
			IntPtr native_font_name = GLib.Marshaller.StringToPtrGStrdup (font_name);
			IntPtr native_text = GLib.Marshaller.StringToPtrGStrdup (text);
			Raw = clutter_entry_new_with_text(native_font_name, native_text);
			GLib.Marshaller.Free (native_font_name);
			GLib.Marshaller.Free (native_text);
		}

		[GLib.Property ("text-visible")]
		public bool TextVisible {
			get {
				GLib.Value val = GetProperty ("text-visible");
				bool ret = (bool) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("text-visible", val);
				val.Dispose ();
			}
		}

		[DllImport("clutter")]
		static extern int clutter_entry_get_alignment(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_entry_set_alignment(IntPtr raw, int alignment);

		[GLib.Property ("alignment")]
		public Pango.Alignment Alignment {
			get  {
				int raw_ret = clutter_entry_get_alignment(Handle);
				Pango.Alignment ret = (Pango.Alignment) raw_ret;
				return ret;
			}
			set  {
				clutter_entry_set_alignment(Handle, (int) value);
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_entry_get_font_name(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_entry_set_font_name(IntPtr raw, IntPtr font_name);

		[GLib.Property ("font-name")]
		public string FontName {
			get  {
				IntPtr raw_ret = clutter_entry_get_font_name(Handle);
				string ret = GLib.Marshaller.Utf8PtrToString (raw_ret);
				return ret;
			}
			set  {
				IntPtr native_value = GLib.Marshaller.StringToPtrGStrdup (value);
				clutter_entry_set_font_name(Handle, native_value);
				GLib.Marshaller.Free (native_value);
			}
		}

		[GLib.Property ("x-align")]
		public double XAlign {
			get {
				GLib.Value val = GetProperty ("x-align");
				double ret = (double) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("x-align", val);
				val.Dispose ();
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_entry_get_text(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_entry_set_text(IntPtr raw, IntPtr text);

		[GLib.Property ("text")]
		public string Text {
			get  {
				IntPtr raw_ret = clutter_entry_get_text(Handle);
				string ret = GLib.Marshaller.Utf8PtrToString (raw_ret);
				return ret;
			}
			set  {
				IntPtr native_value = GLib.Marshaller.StringToPtrGStrdup (value);
				clutter_entry_set_text(Handle, native_value);
				GLib.Marshaller.Free (native_value);
			}
		}

		[GLib.Property ("entry-padding")]
		public uint EntryPadding {
			get {
				GLib.Value val = GetProperty ("entry-padding");
				uint ret = (uint) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("entry-padding", val);
				val.Dispose ();
			}
		}

		[GLib.Property ("position")]
		public int Position {
			get {
				GLib.Value val = GetProperty ("position");
				int ret = (int) val;
				val.Dispose ();
				return ret;
			}
			set {
				GLib.Value val = new GLib.Value(value);
				SetProperty("position", val);
				val.Dispose ();
			}
		}

		[DllImport("clutter")]
		static extern void clutter_entry_set_color(IntPtr raw, IntPtr value);

		[GLib.Property ("color")]
		public Clutter.Color Color {
			get {
				GLib.Value val = GetProperty ("color");
				Clutter.Color ret = (Clutter.Color) val;
				val.Dispose ();
				return ret;
			}
			set  {
				IntPtr native_value = GLib.Marshaller.StructureToPtrAlloc (value);
				clutter_entry_set_color(Handle, native_value);
				value = Clutter.Color.New (native_value);
				Marshal.FreeHGlobal (native_value);
			}
		}

		[DllImport("clutter")]
		static extern int clutter_entry_get_max_length(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_entry_set_max_length(IntPtr raw, int max);

		[GLib.Property ("max-length")]
		public int MaxLength {
			get  {
				int raw_ret = clutter_entry_get_max_length(Handle);
				int ret = raw_ret;
				return ret;
			}
			set  {
				clutter_entry_set_max_length(Handle, value);
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

		[GLib.CDeclCallback]
		delegate void ActivateVMDelegate (IntPtr entry);

		static ActivateVMDelegate ActivateVMCallback;

		static void activate_cb (IntPtr entry)
		{
			try {
				Entry entry_managed = GLib.Object.GetObject (entry, false) as Entry;
				entry_managed.OnActivate ();
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

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Entry), ConnectionMethod="OverrideActivate")]
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
		delegate void CursorEventSignalDelegate (IntPtr arg0, IntPtr arg1, IntPtr gch);

		static void CursorEventSignalCallback (IntPtr arg0, IntPtr arg1, IntPtr gch)
		{
			Clutter.CursorEventArgs args = new Clutter.CursorEventArgs ();
			try {
				GLib.Signal sig = ((GCHandle) gch).Target as GLib.Signal;
				if (sig == null)
					throw new Exception("Unknown signal GC handle received " + gch);

				args.Args = new object[1];
				args.Args[0] = Clutter.Geometry.New (arg1);
				Clutter.CursorEventHandler handler = (Clutter.CursorEventHandler) sig.Handler;
				handler (GLib.Object.GetObject (arg0), args);
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		[GLib.CDeclCallback]
		delegate void CursorEventVMDelegate (IntPtr entry, IntPtr geometry);

		static CursorEventVMDelegate CursorEventVMCallback;

		static void cursorevent_cb (IntPtr entry, IntPtr geometry)
		{
			try {
				Entry entry_managed = GLib.Object.GetObject (entry, false) as Entry;
				entry_managed.OnCursorEvent (Clutter.Geometry.New (geometry));
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideCursorEvent (GLib.GType gtype)
		{
			if (CursorEventVMCallback == null)
				CursorEventVMCallback = new CursorEventVMDelegate (cursorevent_cb);
			OverrideVirtualMethod (gtype, "cursor-event", CursorEventVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Entry), ConnectionMethod="OverrideCursorEvent")]
		protected virtual void OnCursorEvent (Clutter.Geometry geometry)
		{
			GLib.Value ret = GLib.Value.Empty;
			GLib.ValueArray inst_and_params = new GLib.ValueArray (2);
			GLib.Value[] vals = new GLib.Value [2];
			vals [0] = new GLib.Value (this);
			inst_and_params.Append (vals [0]);
			vals [1] = new GLib.Value (geometry);
			inst_and_params.Append (vals [1]);
			g_signal_chain_from_overridden (inst_and_params.ArrayPtr, ref ret);
			foreach (GLib.Value v in vals)
				v.Dispose ();
		}

		[GLib.Signal("cursor-event")]
		public event Clutter.CursorEventHandler CursorEvent {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "cursor-event", new CursorEventSignalDelegate(CursorEventSignalCallback));
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "cursor-event", new CursorEventSignalDelegate(CursorEventSignalCallback));
				sig.RemoveDelegate (value);
			}
		}

		[GLib.CDeclCallback]
		delegate void TextChangedVMDelegate (IntPtr entry);

		static TextChangedVMDelegate TextChangedVMCallback;

		static void textchanged_cb (IntPtr entry)
		{
			try {
				Entry entry_managed = GLib.Object.GetObject (entry, false) as Entry;
				entry_managed.OnTextChanged ();
			} catch (Exception e) {
				GLib.ExceptionManager.RaiseUnhandledException (e, false);
			}
		}

		private static void OverrideTextChanged (GLib.GType gtype)
		{
			if (TextChangedVMCallback == null)
				TextChangedVMCallback = new TextChangedVMDelegate (textchanged_cb);
			OverrideVirtualMethod (gtype, "text-changed", TextChangedVMCallback);
		}

		[GLib.DefaultSignalHandler(Type=typeof(Clutter.Entry), ConnectionMethod="OverrideTextChanged")]
		protected virtual void OnTextChanged ()
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

		[GLib.Signal("text-changed")]
		public event System.EventHandler TextChanged {
			add {
				GLib.Signal sig = GLib.Signal.Lookup (this, "text-changed");
				sig.AddDelegate (value);
			}
			remove {
				GLib.Signal sig = GLib.Signal.Lookup (this, "text-changed");
				sig.RemoveDelegate (value);
			}
		}

		[DllImport("clutter")]
		static extern void clutter_entry_delete_chars(IntPtr raw, uint len);

		public void DeleteChars(uint len) {
			clutter_entry_delete_chars(Handle, len);
		}

		[DllImport("clutter")]
		static extern uint clutter_entry_get_invisible_char(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_entry_set_invisible_char(IntPtr raw, uint wc);

		public char InvisibleChar { 
			get {
				uint raw_ret = clutter_entry_get_invisible_char(Handle);
				char ret = GLib.Marshaller.GUnicharToChar (raw_ret);
				return ret;
			}
			set {
				clutter_entry_set_invisible_char(Handle, GLib.Marshaller.CharToGUnichar (value));
			}
		}

		[DllImport("clutter")]
		static extern int clutter_entry_get_cursor_position(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_entry_set_cursor_position(IntPtr raw, int position);

		public int CursorPosition { 
			get {
				int raw_ret = clutter_entry_get_cursor_position(Handle);
				int ret = raw_ret;
				return ret;
			}
			set {
				clutter_entry_set_cursor_position(Handle, value);
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_entry_get_layout(IntPtr raw);

		public Pango.Layout Layout { 
			get {
				IntPtr raw_ret = clutter_entry_get_layout(Handle);
				Pango.Layout ret = GLib.Object.GetObject(raw_ret) as Pango.Layout;
				return ret;
			}
		}

		[DllImport("clutter")]
		static extern bool clutter_entry_get_visibility(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_entry_set_visibility(IntPtr raw, bool visible);

		public bool Visibility { 
			get {
				bool raw_ret = clutter_entry_get_visibility(Handle);
				bool ret = raw_ret;
				return ret;
			}
			set {
				clutter_entry_set_visibility(Handle, value);
			}
		}

		[DllImport("clutter")]
		static extern void clutter_entry_insert_text(IntPtr raw, IntPtr text, IntPtr position);

		public void InsertText(string text, long position) {
			IntPtr native_text = GLib.Marshaller.StringToPtrGStrdup (text);
			clutter_entry_insert_text(Handle, native_text, new IntPtr (position));
			GLib.Marshaller.Free (native_text);
		}

		[DllImport("clutter")]
		static extern void clutter_entry_delete_text(IntPtr raw, IntPtr start_pos, IntPtr end_pos);

		public void DeleteText(long start_pos, long end_pos) {
			clutter_entry_delete_text(Handle, new IntPtr (start_pos), new IntPtr (end_pos));
		}

		[DllImport("clutter")]
		static extern bool clutter_entry_handle_key_event(IntPtr raw, IntPtr kev);

		public bool HandleKeyEvent(Clutter.KeyEvent kev) {
			IntPtr native_kev = GLib.Marshaller.StructureToPtrAlloc (kev);
			bool raw_ret = clutter_entry_handle_key_event(Handle, native_kev);
			bool ret = raw_ret;
			kev = Clutter.KeyEvent.New (native_kev);
			Marshal.FreeHGlobal (native_kev);
			return ret;
		}

		[DllImport("clutter")]
		static extern void clutter_entry_insert_unichar(IntPtr raw, uint wc);

		public void InsertUnichar(char wc) {
			clutter_entry_insert_unichar(Handle, GLib.Marshaller.CharToGUnichar (wc));
		}

		[DllImport("clutter")]
		static extern bool clutter_entry_get_visible_cursor(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_entry_set_visible_cursor(IntPtr raw, bool visible);

		public bool VisibleCursor { 
			get {
				bool raw_ret = clutter_entry_get_visible_cursor(Handle);
				bool ret = raw_ret;
				return ret;
			}
			set {
				clutter_entry_set_visible_cursor(Handle, value);
			}
		}

		[DllImport("clutter")]
		static extern void clutter_entry_get_color(IntPtr raw, IntPtr color);

		public void GetColor(Clutter.Color color) {
			IntPtr native_color = GLib.Marshaller.StructureToPtrAlloc (color);
			clutter_entry_get_color(Handle, native_color);
			color = Clutter.Color.New (native_color);
			Marshal.FreeHGlobal (native_color);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_entry_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_entry_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

#endregion
	}
}
