// 
// Matrix.cs
//  
// Author:
//   Aaron Bockover <abockover@novell.com>
// 
// Copyright 2009 Novell, Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Runtime.InteropServices;

namespace Cogl
{
    [StructLayout (LayoutKind.Sequential)]
    public struct Matrix
    {
        // column 0
        public float XX { get; set; }
        public float YX { get; set; }
        public float ZX { get; set; }
        public float WX { get; set; }

        // column 1
        public float XY { get; set; }
        public float YY { get; set; }
        public float ZY { get; set; }
        public float WY { get; set; }

        // column 2
        public float XZ { get; set; }
        public float YZ { get; set; }
        public float ZZ { get; set; }
        public float WZ { get; set; }

        // column 3
        public float XW { get; set; }
        public float YW { get; set; }
        public float ZW { get; set; }
        public float WW { get; set; }
        
        public float [] GetArray ()
        {
            throw new NotImplementedException ();
        }

        [DllImport ("clutter")]
        private static extern void cogl_matrix_init_identity (ref Matrix matrix);

        public void InitIdentity ()
        {
            cogl_matrix_init_identity (ref this);
        }
        
        [DllImport ("clutter")]
        private static extern void cogl_matrix_init_from_array (ref Matrix matrix, float [] array);

        public void InitFromArray (float [] array)
        {
            cogl_matrix_init_from_array (ref this, array);
        }

        [DllImport ("clutter")]
        private static extern void cogl_matrix_rotate (ref Matrix matrix, float angle, float x, float y, float z);

        public void Rotate (float angle, float x, float y, float z) 
        {
            cogl_matrix_rotate (ref this, angle, x, y, z);
        }

        [DllImport ("clutter")]
        private static extern void cogl_matrix_frustum (ref Matrix matrix, float left, float right, float bottom, 
            float top, float z_near, float z_far);

        public void Frustum (float left, float right, float bottom, float top, float z_near, float z_far)
        {
            cogl_matrix_frustum (ref this, left, right, bottom, top, z_near, z_far);
        }

        [DllImport ("clutter")]
        private static extern void cogl_matrix_transform_point (ref Matrix matrix, out float x, out float y, out float z, out float w);

        public void TransformPoint (out float x, out float y, out float z, out float w)
        {
            cogl_matrix_transform_point (ref this, out x, out y, out z, out w);
        }

        [DllImport ("clutter")]
        private static extern void cogl_matrix_multiply (ref Matrix matrix, ref Matrix a, ref Matrix b);

        public void Multiply (Matrix a, Matrix b)
        {
            cogl_matrix_multiply (ref this, ref a, ref b);
        }

        [DllImport ("clutter")]
        private static extern void cogl_matrix_translate (ref Matrix matrix, float x, float y, float z);

        public void Translate (float x, float y, float z)
        {
            cogl_matrix_translate (ref this, x, y, z);
        }

        [DllImport ("clutter")]
        private static extern void cogl_matrix_scale (ref Matrix matrix, float sx, float sy, float sz);

        public void Scale (float sx, float sy, float sz)
        {
            cogl_matrix_scale (ref this, sx, sy, sz);
        }
    }
}
