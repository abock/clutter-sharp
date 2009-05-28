using System;
using System.Runtime.InteropServices;

using GLib;

internal static class GTypeExtensions
{
	internal static IntPtr ValFromInstancePtr (IntPtr handle)
	{
		if (handle == IntPtr.Zero)
			return IntPtr.Zero;

		// First field of instance is a GTypeClass*.  
		IntPtr klass = Marshal.ReadIntPtr (handle);
		// First field of GTypeClass is a GType.
		return Marshal.ReadIntPtr (klass);
	}

    public static bool IsInstance (this GType type, IntPtr raw)
	{
		return Is (ValFromInstancePtr (raw), type);
	}
	
	internal static bool Is (IntPtr type, GType is_a_type)
	{
		return g_type_is_a (type, is_a_type.Val);
	}
	
	[DllImport ("libgobject-2.0-0.dll")]
	static extern bool g_type_is_a (IntPtr type, IntPtr is_a_type);
}

