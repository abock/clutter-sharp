// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[StructLayout(LayoutKind.Sequential)]
	public struct Color {

		public byte Red;
		public byte Green;
		public byte Blue;
		public byte Alpha;

		public static Clutter.Color Zero = new Clutter.Color ();

		public static Clutter.Color New(IntPtr raw) {
			if (raw == IntPtr.Zero)
				return Clutter.Color.Zero;
			return (Clutter.Color) Marshal.PtrToStructure (raw, typeof (Clutter.Color));
		}

		[DllImport("clutter")]
		static extern void clutter_color_lighten(IntPtr raw, IntPtr dest);

		public void Lighten(Clutter.Color dest) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr native_dest = GLib.Marshaller.StructureToPtrAlloc (dest);
			clutter_color_lighten(this_as_native, native_dest);
			dest = Clutter.Color.New (native_dest);
			Marshal.FreeHGlobal (native_dest);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("clutter")]
		static extern void clutter_color_from_hls(IntPtr raw, byte hue, byte luminance, byte saturation);

		public void FromHls(byte hue, byte luminance, byte saturation) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			clutter_color_from_hls(this_as_native, hue, luminance, saturation);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("clutter")]
		static extern void clutter_color_to_hlsx(IntPtr raw, out int hue, out int luminance, out int saturation);

		public void ToHlsx(out int hue, out int luminance, out int saturation) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			clutter_color_to_hlsx(this_as_native, out hue, out luminance, out saturation);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_color_to_string(IntPtr raw);

		public override string ToString() {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr raw_ret = clutter_color_to_string(this_as_native);
			string ret = GLib.Marshaller.PtrToStringGFree(raw_ret);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
			return ret;
		}

		[DllImport("clutter")]
		static extern bool clutter_color_equal(IntPtr raw, IntPtr b);

		public bool Equal(Clutter.Color b) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr native_b = GLib.Marshaller.StructureToPtrAlloc (b);
			bool raw_ret = clutter_color_equal(this_as_native, native_b);
			bool ret = raw_ret;
			b = Clutter.Color.New (native_b);
			Marshal.FreeHGlobal (native_b);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
			return ret;
		}

		[DllImport("clutter")]
		static extern uint clutter_color_to_pixel(IntPtr raw);

		public uint ToPixel() {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			uint raw_ret = clutter_color_to_pixel(this_as_native);
			uint ret = raw_ret;
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
			return ret;
		}

		[DllImport("clutter")]
		static extern void clutter_color_to_hls(IntPtr raw, out byte hue, out byte luminance, out byte saturation);

		public void ToHls(out byte hue, out byte luminance, out byte saturation) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			clutter_color_to_hls(this_as_native, out hue, out luminance, out saturation);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("clutter")]
		static extern void clutter_color_shade(IntPtr raw, IntPtr dest, double shade);

		public void Shade(Clutter.Color dest, double shade) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr native_dest = GLib.Marshaller.StructureToPtrAlloc (dest);
			clutter_color_shade(this_as_native, native_dest, shade);
			dest = Clutter.Color.New (native_dest);
			Marshal.FreeHGlobal (native_dest);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("clutter")]
		static extern void clutter_color_shadex(IntPtr raw, IntPtr dest, int shade);

		public void Shadex(Clutter.Color dest, int shade) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr native_dest = GLib.Marshaller.StructureToPtrAlloc (dest);
			clutter_color_shadex(this_as_native, native_dest, shade);
			dest = Clutter.Color.New (native_dest);
			Marshal.FreeHGlobal (native_dest);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("clutter")]
		static extern void clutter_color_from_hlsx(IntPtr raw, int hue, int luminance, int saturation);

		public void FromHlsx(int hue, int luminance, int saturation) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			clutter_color_from_hlsx(this_as_native, hue, luminance, saturation);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("clutter")]
		static extern void clutter_color_subtract(IntPtr raw, IntPtr src2, IntPtr dest);

		public void Subtract(Clutter.Color src2, Clutter.Color dest) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr native_src2 = GLib.Marshaller.StructureToPtrAlloc (src2);
			IntPtr native_dest = GLib.Marshaller.StructureToPtrAlloc (dest);
			clutter_color_subtract(this_as_native, native_src2, native_dest);
			src2 = Clutter.Color.New (native_src2);
			Marshal.FreeHGlobal (native_src2);
			dest = Clutter.Color.New (native_dest);
			Marshal.FreeHGlobal (native_dest);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("clutter")]
		static extern void clutter_color_add(IntPtr raw, IntPtr src2, IntPtr dest);

		public void Add(Clutter.Color src2, Clutter.Color dest) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr native_src2 = GLib.Marshaller.StructureToPtrAlloc (src2);
			IntPtr native_dest = GLib.Marshaller.StructureToPtrAlloc (dest);
			clutter_color_add(this_as_native, native_src2, native_dest);
			src2 = Clutter.Color.New (native_src2);
			Marshal.FreeHGlobal (native_src2);
			dest = Clutter.Color.New (native_dest);
			Marshal.FreeHGlobal (native_dest);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("clutter")]
		static extern void clutter_color_darken(IntPtr raw, IntPtr dest);

		public void Darken(Clutter.Color dest) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			IntPtr native_dest = GLib.Marshaller.StructureToPtrAlloc (dest);
			clutter_color_darken(this_as_native, native_dest);
			dest = Clutter.Color.New (native_dest);
			Marshal.FreeHGlobal (native_dest);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("clutter")]
		static extern void clutter_color_from_pixel(IntPtr raw, uint pixel);

		public void FromPixel(uint pixel) {
			IntPtr this_as_native = System.Runtime.InteropServices.Marshal.AllocHGlobal (System.Runtime.InteropServices.Marshal.SizeOf (this));
			System.Runtime.InteropServices.Marshal.StructureToPtr (this, this_as_native, false);
			clutter_color_from_pixel(this_as_native, pixel);
			ReadNative (this_as_native, ref this);
			System.Runtime.InteropServices.Marshal.FreeHGlobal (this_as_native);
		}

		[DllImport("clutter")]
		static extern bool clutter_color_parse(IntPtr color, IntPtr dest);

		public static bool Parse(string color, Clutter.Color dest) {
			IntPtr native_color = GLib.Marshaller.StringToPtrGStrdup (color);
			IntPtr native_dest = GLib.Marshaller.StructureToPtrAlloc (dest);
			bool raw_ret = clutter_color_parse(native_color, native_dest);
			bool ret = raw_ret;
			GLib.Marshaller.Free (native_color);
			dest = Clutter.Color.New (native_dest);
			Marshal.FreeHGlobal (native_dest);
			return ret;
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_color_get_type();

		public static GLib.GType GType { 
			get {
				IntPtr raw_ret = clutter_color_get_type();
				GLib.GType ret = new GLib.GType(raw_ret);
				return ret;
			}
		}

		static void ReadNative (IntPtr native, ref Clutter.Color target)
		{
			target = New (native);
		}

		[DllImport("glibsharpglue-2")]
		static extern IntPtr glibsharp_value_get_boxed (ref GLib.Value val);

		[DllImport("glibsharpglue-2")]
		static extern void glibsharp_value_set_boxed (ref GLib.Value val, ref Clutter.Color boxed);

		public static explicit operator GLib.Value (Clutter.Color boxed)
		{
			GLib.Value val = GLib.Value.Empty;
			val.Init (Clutter.Color.GType);
			glibsharp_value_set_boxed (ref val, ref boxed);
			return val;
		}

		public static explicit operator Clutter.Color (GLib.Value val)
		{
			IntPtr boxed_ptr = glibsharp_value_get_boxed (ref val);
			return New (boxed_ptr);
		}
#endregion
#region Customized extensions
#line 1 "Color.custom"
		public Color (byte red, byte green, byte blue, byte alpha) {
			this.Red = red;
			this.Green = green;
			this.Blue = blue;
			this.Alpha = alpha;	
		}

#endregion
	}
}
