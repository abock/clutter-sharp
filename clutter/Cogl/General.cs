using System;
using System.Runtime.InteropServices;

namespace Cogl
{
    public static class General
    {
        [DllImport ("clutter")]
        private static extern void cogl_create_context ();

        public static void CreateContext ()
        {
            cogl_create_context ();
        }

        [DllImport ("clutter")]
        private static extern void cogl_destroy_context ();

        public static void DestroyContext ()
        {
            cogl_destroy_context ();
        }



        [DllImport ("clutter")]
        private static extern FeatureFlags cogl_get_features ();

        public static FeatureFlags AvailableFeatures {
            get { return cogl_get_features (); }
        }

        [DllImport ("clutter")]
        private static extern bool cogl_features_available (FeatureFlags features);

        public static bool AreFeaturesAvailable (FeatureFlags features)
        {
            return cogl_features_available (features);
        }

        [DllImport ("clutter")]
        private static extern bool cogl_check_extension (IntPtr name, IntPtr ext);

        public static bool CheckExtension (string name, string extension)
        {
            IntPtr name_ptr = GLib.Marshaller.StringToPtrGStrdup (name);
            IntPtr extension_ptr = GLib.Marshaller.StringToPtrGStrdup (extension);
            try {
                return cogl_check_extension (name_ptr, extension_ptr);
            } finally {
                GLib.Marshaller.Free (name_ptr);
                GLib.Marshaller.Free (extension_ptr);
            }
        }

        [DllImport ("clutter")]
        private static extern CoglSharp.FuncPtrNative cogl_get_proc_address (IntPtr name);

        public static FuncPtr GetProcAddress (string name)
        {
            IntPtr ptr = GLib.Marshaller.StringToPtrGStrdup (name);
            try {
                return CoglSharp.FuncPtrWrapper.GetManagedDelegate (cogl_get_proc_address (ptr));
            } finally {
                GLib.Marshaller.Free (ptr);
            }
        }

        [DllImport ("clutter")]
        private static extern void cogl_perspective (float fovy, float aspect, float z_near, float z_far);

        public static void Perspective (float fovy, float aspect, float zNear, float zFar)
        {
            cogl_perspective (fovy, aspect, zNear, zFar);
        }

        [DllImport ("clutter")]
        private static extern void cogl_frustum (float left, float right, float bottom, float top, float z_near, float z_far);

        public static void Frustum (float left, float right, float bottom, float top, float zNear, float zFar)
        {
            cogl_frustum (left, right, bottom, top, zNear, zFar);
        }

        [DllImport ("clutter")]
        private static extern void cogl_setup_viewport (uint width, uint height, float fovy, float aspect, float z_near, float z_far);

        public static void SetupViewport (uint width, uint height, float fovy, float aspect, float zNear, float zFar)
        {
            cogl_setup_viewport (width, height, fovy, aspect, zNear, zFar);
        }

        [DllImport ("clutter")]
        private static extern void cogl_viewport (uint width, uint height);

        public static void SetupViewport (uint width, uint height)
        {
            cogl_viewport (width, height);
        }

        [DllImport ("clutter")]
        private static extern void cogl_get_modelview_matrix (out IntPtr matrix);

        public static Matrix ModelViewMatrix {
            get { 
                IntPtr matrix;
                cogl_get_modelview_matrix (out matrix);
                return (Matrix)Marshal.PtrToStructure (matrix, typeof (Matrix));
            }
        }

        [DllImport ("clutter")]
        private static extern void cogl_get_projection_matrix (out IntPtr matrix);

        public static Matrix ProjectionMatrix {
            get { 
                IntPtr matrix;
                cogl_get_projection_matrix (out matrix);
                return (Matrix)Marshal.PtrToStructure (matrix, typeof (Matrix));
            }
        }

        [DllImport ("clutter")]
        private static extern void cogl_get_viewport (ref float [] v);

        public static float [] Viewport {
            get {
                float [] v = new float[4];
                cogl_get_viewport (ref v);
                return v;
            }
        }

        [DllImport ("clutter")]
        private static extern void cogl_push_matrix ();

        public static void PushMatrix ()
        {
            cogl_push_matrix ();
        }

        [DllImport ("clutter")]
        private static extern void cogl_pop_matrix ();

        public static void PopMatrix ()
        {
            cogl_pop_matrix ();
        }

        [DllImport ("clutter")]
        private static extern void cogl_scale (float x, float y, float z);

        public static void Scale (float x, float y, float z)
        {
            cogl_scale (x, y, z);
        }

        [DllImport ("clutter")]
        private static extern void cogl_translate (float x, float y, float z);

        public static void Translate (float x, float y, float z)
        {
            cogl_translate (x, y, z);
        }

        [DllImport ("clutter")]
        private static extern void cogl_rotate (float angle, float x, float y, float z);

        public static void Rotate (float angle, float x, float y, float z)
        {
            cogl_rotate (angle, x, y, z);
        }

        [DllImport ("clutter")]
        private static extern void cogl_clear (IntPtr color, ulong buffers);

        public static void Clear (Color color, ulong buffers)
        {
            cogl_clear (color == null ? IntPtr.Zero : color.Handle, buffers);
        }

        [DllImport ("clutter")]
        private static extern void cogl_get_bitmasks (out int red, out int green, out int blue, out int alpha);

        public static void GetBitmasks (out int red, out int green, out int blue, out int alpha)
        {
            cogl_get_bitmasks (out red, out green, out blue, out alpha);
        }

        [DllImport ("clutter")]
        private static extern void cogl_enable_depth_test (bool setting);

        public static void EnableDepthTest (bool setting)
        {
            cogl_enable_depth_test (setting);
        }

        [DllImport ("clutter")]
        private static extern void cogl_enable_backface_culling (bool setting);

        public static void EnableBackfaceCulling (bool setting)
        {
            cogl_enable_backface_culling (setting);
        }

        [DllImport ("clutter")]
        private static extern void cogl_set_fog (IntPtr color, FogMode mode, float density, float z_near, float z_far);

        public static void SetFog (Color color, FogMode mode, float density, float zNear, float zFar)
        {
            cogl_set_fog (color == null ? IntPtr.Zero : color.Handle, mode, density, zNear, zFar);
        }

        [DllImport ("clutter")]
        private static extern void cogl_disable_fog ();

        public static void DisableFog ()
        {
            cogl_disable_fog ();
        }

        [DllImport ("clutter")]
        private static extern void cogl_set_source (IntPtr material);

        public static void SetSource (IntPtr coglMaterial)
        {
            cogl_set_source (coglMaterial);
        }

        [DllImport ("clutter")]
        private static extern void cogl_set_source_texture (IntPtr texture);

        public static void SetSourceTexture (IntPtr coglTexture)
        {
            cogl_set_source_texture (coglTexture);
        }

        [DllImport ("clutter")]
        private static extern void cogl_set_source_color (IntPtr color);

        public static void SetSourceColor (Color color)
        {
            cogl_set_source_color (color == null ? IntPtr.Zero : color.Handle);
        }

        [DllImport ("clutter")]
        private static extern void cogl_set_source_color4ub (byte red, byte green, byte blue, byte alpha);

        public static void SetSourceColor4ub (byte red, byte green, byte blue, byte alpha)
        {
            cogl_set_source_color4ub (red, green, blue, alpha);
        }

        [DllImport ("clutter")]
        private static extern void cogl_set_source_color4f (float red, float green, float blue, float alpha);

        public static void SetSourceColor4f (float red, float green, float blue, float alpha)
        {
            cogl_set_source_color4f (red, green, blue, alpha);
        }

        public static void SetSourceColor4f (double red, double green, double blue, double alpha)
        {
            cogl_set_source_color4f ((float)red, (float)green, (float)blue, (float)alpha);
        }

        [DllImport ("clutter")]
        private static extern void cogl_flush_gl_state (int flags);

        public static void FlushGlState (int flags)
        {
            cogl_flush_gl_state (flags);
        }
    }
}

