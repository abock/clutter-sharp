// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Collections;
	using System.Runtime.InteropServices;

#region Autogenerated code
	public class IDPool : GLib.Opaque {

		[DllImport("clutter")]
		static extern void clutter_id_pool_remove(IntPtr raw, uint id);

		public void Remove(uint id) {
			clutter_id_pool_remove(Handle, id);
		}

		[DllImport("clutter")]
		static extern IntPtr clutter_id_pool_lookup(IntPtr raw, uint id);

		public IntPtr Lookup(uint id) {
			IntPtr raw_ret = clutter_id_pool_lookup(Handle, id);
			IntPtr ret = raw_ret;
			return ret;
		}

		[DllImport("clutter")]
		static extern uint clutter_id_pool_add(IntPtr raw, IntPtr ptr);

		public uint Add(IntPtr ptr) {
			uint raw_ret = clutter_id_pool_add(Handle, ptr);
			uint ret = raw_ret;
			return ret;
		}

		public IDPool(IntPtr raw) : base(raw) {}

		[DllImport("clutter")]
		static extern IntPtr clutter_id_pool_new(uint initial_size);

		public IDPool (uint initial_size) 
		{
			Raw = clutter_id_pool_new(initial_size);
		}

		[DllImport("clutter")]
		static extern void clutter_id_pool_free(IntPtr raw);

		protected override void Free (IntPtr raw)
		{
			clutter_id_pool_free (raw);
		}

#endregion
	}
}
