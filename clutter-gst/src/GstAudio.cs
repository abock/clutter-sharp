// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public  class GstAudio : GLib.Object, Media {

		~GstAudio()
		{
			Dispose();
		}

		[Obsolete]
		protected GstAudio(GLib.GType gtype) : base(gtype) {}
		public GstAudio(IntPtr raw) : base(raw) {}

		[DllImport("clutter-gst")]
		static extern IntPtr clutter_gst_audio_new();

		public GstAudio () : base (IntPtr.Zero)
		{
			if (GetType () != typeof (GstAudio)) {
				CreateNativeObject (new string [0], new GLib.Value[0]);
				return;
			}
			Raw = clutter_gst_audio_new();
		}

		[DllImport("clutter-gst")]
		static extern IntPtr clutter_gst_audio_get_type();

		public static new GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_gst_audio_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

#endregion
#region Customized extensions
#line 1 "GstAudio.custom"
		// FIXME: not implemented correctly now
		public event Clutter.ErrorHandler Error;
		public event System.EventHandler Eos;


		#region Interface implementation
		//[DllImport("clutter")]
		//static extern IntPtr clutter_media_get_name(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_media_set_filename (IntPtr raw, IntPtr name);

		public string Filename {
			set {
				 IntPtr name_as_native = GLib.Marshaller.StringToPtrGStrdup (value);
				 clutter_media_set_filename (Handle, name_as_native);
				 GLib.Marshaller.Free (name_as_native);
			} 
		}

		[DllImport("clutter")]
		static extern int clutter_media_get_buffer_percent (IntPtr raw);

		public int BufferPercent {
			get {
			 	return clutter_media_get_buffer_percent (Handle);
			} 
		}

		[DllImport("clutter")]
		static extern bool clutter_media_get_can_seek (IntPtr raw);

		public bool CanSeek {
			get {
				return clutter_media_get_can_seek (Handle); 
			} 
		}

		[DllImport("clutter")]
		static extern bool clutter_media_get_playing (IntPtr raw);

		[DllImport("clutter")]
		static extern bool clutter_media_set_playing (IntPtr raw, bool playing);

		public bool Playing {
			get {
				return clutter_media_get_playing (Handle); 
			}
			set {
				clutter_media_set_playing (Handle, value); 
			}
		}

		[DllImport("clutter")]
		static extern int clutter_media_get_duration (IntPtr raw);

		public int Duration {
			get {
				return clutter_media_get_duration (Handle);
			} 
		}


		[DllImport("clutter")]
		static extern double clutter_media_get_volume (IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_media_set_volume (IntPtr raw, double volume);

		public double Volume {
			get {
				return clutter_media_get_volume (Handle); 
			}
			set {
				clutter_media_set_volume (Handle, value); 
			}
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_media_get_uri(IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_media_set_uri (IntPtr raw, IntPtr name);

		public string Uri {
			get {
				IntPtr raw_ret = clutter_media_get_uri (Handle);
				string ret = GLib.Marshaller.Utf8PtrToString (raw_ret);
				return ret; 
			}
			set {
				 IntPtr uri_as_native = GLib.Marshaller.StringToPtrGStrdup (value);
				 clutter_media_set_uri (Handle, uri_as_native);
				 GLib.Marshaller.Free (uri_as_native);
			}
		}

		[DllImport("clutter")]
		static extern int clutter_media_get_position (IntPtr raw);

		[DllImport("clutter")]
		static extern void clutter_media_set_position (IntPtr raw, int position);

		public int Position {
			get {
			 	return clutter_media_get_position (Handle);
			} 
			set {
			 	clutter_media_set_position (Handle, value);
			}
		}
		#endregion


#endregion
	}
}