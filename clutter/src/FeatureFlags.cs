// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Clutter {

	using System;
	using System.Runtime.InteropServices;

#region Autogenerated code
	[Flags]
	[GLib.GType (typeof (Clutter.FeatureFlagsGType))]
	public enum FeatureFlags {

		TextureRectangle = 1 << 1,
		SyncToVblank = 1 << 2,
		TextureYuv = 1 << 3,
		TextureReadPixels = 1 << 4,
		StageStatic = 1 << 5,
		StageUserResize = 1 << 6,
		StageCursor = 1 << 7,
		ShadersGlsl = 1 << 8,
		Offscreen = 1 << 9,
	}

	internal class FeatureFlagsGType {
		[DllImport ("clutter")]
		static extern IntPtr clutter_feature_flags_get_type ();

		public static GLib.GType GType {
			get {
				return new GLib.GType (clutter_feature_flags_get_type ());
			}
		}
	}
#endregion
}
