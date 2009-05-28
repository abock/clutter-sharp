using System;
using System.Runtime.InteropServices;

using GLib;

internal static class GTypeExtensions
{
	public static IntPtr ValFromInstancePtr (IntPtr handle)
	{
		if (handle == IntPtr.Zero)
			return IntPtr.Zero;

		// First field of instance is a GTypeClass*.  
		IntPtr klass = Marshal.ReadIntPtr (handle);
		// First field of GTypeClass is a GType.
		return Marshal.ReadIntPtr (klass);
	}

	public static bool IsInstance (GType type, IntPtr raw)
	{
		return Is (ValFromInstancePtr (raw), type);
	}
	
	public static bool Is (IntPtr type, GType is_a_type)
	{
		return g_type_is_a (type, is_a_type.Val);
	}
	
	public static IntPtr GetClassPtr (GType type)
	{
			IntPtr klass = g_type_class_peek (type.Val);
			if (klass == IntPtr.Zero)
				klass = g_type_class_ref (type.Val);
			return klass;
	}

	public static GType GetThresholdType (GType type) 
	{
		GLib.GType curr_type = type;
		while (curr_type.ToString ().StartsWith ("__gtksharp_")) {
			curr_type = GetBaseType (curr_type);
		}
		return curr_type;
	}
	
	public static uint GetClassSize (GType type) 
	{
		GTypeQuery query;
		g_type_query (type.Val, out query);
		return query.class_size;
	}
	

	public static GType GetBaseType (GType type) 
	{
		IntPtr parent = g_type_parent (type.Val);
		if (parent == IntPtr.Zero)
			return GType.None;
		else
			return new GType (parent);
	}
	
	struct GTypeQuery {
		public IntPtr type;
		public IntPtr type_name;
		public uint class_size;
		public uint instance_size;
	}
	
	[DllImport ("libgobject-2.0-0.dll")]
	static extern bool g_type_is_a (IntPtr type, IntPtr is_a_type);
	
	[DllImport("libgobject-2.0-0.dll")]
	static extern IntPtr g_type_class_peek (IntPtr gtype);

	[DllImport("libgobject-2.0-0.dll")]
	static extern IntPtr g_type_class_ref (IntPtr gtype);

	[DllImport("libgobject-2.0-0.dll")]
	static extern IntPtr g_type_parent (IntPtr type);

	[DllImport("libgobject-2.0-0.dll")]
	static extern void g_type_query (IntPtr type, out GTypeQuery query);
}

