using System;
using System.Runtime.InteropServices;
using Clutter;

public static class TestCoglVertexBuffer
{
    // Defines the size and resolution of the quad mesh we morph:
     
    const int MESH_WIDTH  = 100;      // number of quads along x axis
    const int MESH_HEIGHT = 100;      // number of quads along y axis
    const float QUAD_WIDTH  = 5.0f;   // width in pixels of a single quad
    const float QUAD_HEIGHT = 5.0f;   // height in pixels of a single quad

    // Defines a sine wave that sweeps across the mesh:
     
    const float WAVE_DEPTH   = ((MESH_WIDTH * QUAD_WIDTH) / 16.0f); // peak amplitude 
    const float WAVE_PERIODS = 4.0f;
    const float WAVE_SPEED   = 10.0f;

    // Defines a rippling sine wave emitted from a point:
     
    const float RIPPLE_CENTER_X = ((MESH_WIDTH / 2.0f) * QUAD_WIDTH);
    const float RIPPLE_CENTER_Y = ((MESH_HEIGHT / 2.0f) * QUAD_HEIGHT);
    const float RIPPLE_RADIUS   = (MESH_WIDTH * QUAD_WIDTH);
    const float RIPPLE_DEPTH    = ((MESH_WIDTH * QUAD_WIDTH) / 16.0f); // peak amplitude 
    const float RIPPLE_PERIODS  = 4.0f;
    const float RIPPLE_SPEED    = -10.0f;

    // Defines the width of the gaussian bell used to fade out the alpha
    // towards the edges of the mesh (starting from the ripple center):
     
    const float GAUSSIAN_RADIUS = ((MESH_WIDTH * QUAD_WIDTH) / 6.0f);

    // Our hues lie in the range [0, 1], and this defines how we map amplitude
    // to hues (before scaling by {WAVE,RIPPLE}_DEPTH)
    // As we are interferring two sine waves together; amplitudes lie in the
    // range [-2, 2]
     
    const float HSL_OFFSET = 0.5f; // the hue that we map an amplitude of 0 too 
    const float HSL_SCALE  = 0.25f;
    
    static Actor dummy;
    static Timeline timeline;
    static IntPtr buffer;
    
    static unsafe float *quad_mesh_verts;
    static unsafe byte  *quad_mesh_colors;
    static unsafe ushort *static_indices;
    static uint n_static_indices;

    public static unsafe void Main ()
    {
        Application.Init ();
    
        var stage = Stage.Default;
        var stage_geom = stage.Geometry;
        
        var dummy_width = (int)(MESH_WIDTH * QUAD_WIDTH);
        var dummy_height = (int)(MESH_HEIGHT * QUAD_HEIGHT);
        dummy = CreateDummyActor (dummy_width, dummy_height);
        dummy.SetPosition (
            (int)((stage_geom.Width / 2.0) - (dummy_width / 2.0)),
            (int)((stage_geom.Height / 2.0) - (dummy_height / 2.0)));

        dummy.Painted += (o, e) => {
            Cogl.General.SetSourceColor4ub (0xff, 0x00, 0x00, 0xff);
            Cogl.VertexBuffer.DrawElements (buffer,
                Cogl.GL.GL_TRIANGLE_STRIP,
                0,
                (MESH_WIDTH + 1) * (MESH_HEIGHT + 1),
                (int)n_static_indices,
                Cogl.GL.GL_UNSIGNED_SHORT,
                new IntPtr (static_indices));
        };
        
        timeline = new Timeline () {
            FrameCount = 360,
            Speed = 60,
            Loop = true
        };
        
        timeline.NewFrame += OnNewFrame;
        
        GLib.Idle.Add (() => { stage.QueueRedraw (); return true; });
        
        InitQuadMesh ();
        
        stage.Color = new Color (0, 0, 0, 0xff);
        stage.Add (dummy);
        stage.ShowAll ();
        
        timeline.Start ();
        
        Application.Run ();
    }
    
    static Actor CreateDummyActor (int width, int height)
    {
        var rect = new Rectangle (new Color (0, 0, 0, 0));
        rect.SetSize (width, height);
        return rect;
    }
    
    static float Gaussian (float x, float y)
    {
        // Bell width
        float c = GAUSSIAN_RADIUS;

        // Peak amplitude
        float a = 1.0f;
        // float a = 1.0 / (c * sqrtf (2.0 * G_PI));

        // Center offset
        float b = 0.0f;

        x = x - RIPPLE_CENTER_X;
        y = y - RIPPLE_CENTER_Y;
        float dist = (float)Math.Sqrt (x*x + y*y);

        return a * (float)Math.Exp ((- ((dist - b) * (dist - b))) / (2.0f * c * c));
    }
    
    static unsafe void InitQuadMesh ()
    {
        // Note: we maintain the minimum number of vertices possible. This minimizes
        // the work required when we come to morph the geometry.
        //
        // We use static indices into our mesh so that we can treat the data like a
        // single triangle list and drawing can be done in one operation (Note: We
        // are using degenerate triangles at the edges to link to the next row)
        
        quad_mesh_verts = (float *)Marshal.AllocHGlobal (sizeof (float) * 3 * (MESH_WIDTH + 1) * (MESH_HEIGHT + 1));
        quad_mesh_colors = (byte *)Marshal.AllocHGlobal (sizeof (byte) * 4 * (MESH_WIDTH + 1) * (MESH_HEIGHT + 1));
        
        float *vert = quad_mesh_verts;
        byte *color = quad_mesh_colors;
        
        for (int y = 0; y <= MESH_HEIGHT; y++) {
            for (int x = 0; x <= MESH_WIDTH; x++) {
                vert[0] = x * QUAD_WIDTH;
                vert[1] = y * QUAD_HEIGHT;
                vert += 3;

                color[3] = (byte)(Gaussian (x * QUAD_WIDTH, y * QUAD_HEIGHT) * 255.0);
                color += 4;
            }
        }
        
        buffer = Cogl.VertexBuffer.New ((MESH_WIDTH + 1) * (MESH_HEIGHT + 1));
        Cogl.VertexBuffer.Add (buffer, 
            "gl_Vertex",
            3, // n components
            Cogl.GL.GL_FLOAT,
            false, // normalized
            0, // stride
            new IntPtr (quad_mesh_verts));

        Cogl.VertexBuffer.Add (buffer,
            "gl_Color",
            4, //n components
            Cogl.GL.GL_UNSIGNED_BYTE,
            false, // normalized
            0, // stride
            new IntPtr (quad_mesh_colors));

        Cogl.VertexBuffer.Submit (buffer);
        InitStaticIndexArrays ();
    }
    
    static ushort MeshIndex (int x, int y)
    {
        return (ushort)(y * (MESH_WIDTH + 1) + x);
    }
    
    static unsafe void InitStaticIndexArrays ()
    {
        // - Each row takes (2 + 2 * MESH_WIDTH indices)
        //   - Thats 2 to start the triangle strip then 2 indices to add 2 triangles
        //     per mesh quad.
        // - We have MESH_HEIGHT rows
        // - It takes one extra index for linking between rows (MESH_HEIGHT - 1)
        // - A 2 x 3 mesh == 20 indices...
        
        n_static_indices = (uint)((2 + 2 * MESH_WIDTH) * MESH_HEIGHT + (MESH_HEIGHT - 1));
        static_indices = (ushort *)Marshal.AllocHGlobal ((int)(sizeof (ushort) * n_static_indices));
        ushort *i = static_indices;

        // NB: front facing == anti-clockwise winding
        i[0] = MeshIndex (0, 0);
        i[1] = MeshIndex (0, 1);
        i += 2;

        bool right_dir = true;

        for (int y = 0; y < MESH_HEIGHT; y++) {
            for (int x = 0; x < MESH_WIDTH; x++) {
                // Add 2 triangles per mesh quad...
                if (right_dir) {
                    i[0] = MeshIndex (x + 1, y);
                    i[1] = MeshIndex (x + 1, y + 1);
                } else {
                    i[0] = MeshIndex (MESH_WIDTH - x - 1, y);
                    i[1] = MeshIndex (MESH_WIDTH - x - 1, y + 1);
                }
                i += 2;
            }

            // Link rows...
            if (y == (MESH_HEIGHT - 1)) {
                break;
            }

            if (right_dir) {
                i[0] = MeshIndex (MESH_WIDTH, y + 1);
                i[1] = MeshIndex (MESH_WIDTH, y + 1);
                i[2] = MeshIndex (MESH_WIDTH, y + 2);
            } else {
                i[0] = MeshIndex (0, y + 1);
                i[1] = MeshIndex (0, y + 1);
                i[2] = MeshIndex (0, y + 2);
            }
            
            i += 3;
            right_dir = !right_dir;
        }
    }
    
    static unsafe void OnNewFrame (object o, NewFrameArgs args)
    {
        Color color = Color.Zero;
        uint n_frames = timeline.FrameCount;
        int frame_num = args.FrameNum;
        float period_progress = ((float)frame_num / (float)n_frames) * 2.0f * (float)Math.PI;
        float period_progress_sin = (float)Math.Sin (period_progress);
        float wave_shift = period_progress * WAVE_SPEED;
        float ripple_shift = period_progress * RIPPLE_SPEED;

        for (uint y = 0; y <= MESH_HEIGHT; y++) {
            for (uint x = 0; x <= MESH_WIDTH; x++) {
                uint vert_index = (MESH_WIDTH + 1) * y + x;
                float *vert = &quad_mesh_verts[3 * vert_index];

                float real_x = x * QUAD_WIDTH;
                float real_y = y * QUAD_HEIGHT;

                float wave_offset = (float)x / (MESH_WIDTH + 1);
                float wave_angle = (WAVE_PERIODS * 2 * (float)Math.PI * wave_offset) + wave_shift;
                float wave_sin = (float)Math.Sin (wave_angle);

                float a_sqr = (RIPPLE_CENTER_X - real_x) * (RIPPLE_CENTER_X - real_x);
                float b_sqr = (RIPPLE_CENTER_Y - real_y) * (RIPPLE_CENTER_Y - real_y);
                float ripple_offset = (float)Math.Sqrt (a_sqr + b_sqr) / RIPPLE_RADIUS;
                float ripple_angle = (RIPPLE_PERIODS * 2 * (float)Math.PI * ripple_offset) + ripple_shift;
                float ripple_sin = (float)Math.Sin (ripple_angle);

                vert[2] = (wave_sin * WAVE_DEPTH) + (ripple_sin * RIPPLE_DEPTH);

                // Burn some CPU time picking a pretty color...
                float h = (HSL_OFFSET
                    + wave_sin
                    + ripple_sin
                    + period_progress_sin) * HSL_SCALE;
                float s = 0.5f;
                float l = 0.25f + (period_progress_sin + 1.0f) / 4.0f;
                
                color.FromHls (h * 360.0f, l, s);

                byte *c = &quad_mesh_colors[4 * vert_index];
                c[0] = color.R;
                c[1] = color.G;
                c[2] = color.B;
            }
        }
        
        Cogl.VertexBuffer.Add (buffer,
            "gl_Vertex",
            3, // n components
            Cogl.GL.GL_FLOAT,
            false, // normalized
            0, // stride
            new IntPtr (quad_mesh_verts));
        
        Cogl.VertexBuffer.Add (buffer,
            "gl_Color",
            4, // n components
            Cogl.GL.GL_UNSIGNED_BYTE,
            false, // normalized
            0, // stride
            new IntPtr (quad_mesh_colors));

        Cogl.VertexBuffer.Submit (buffer);

        dummy.SetRotation (RotateAxis.Z, 
            frame_num,
            (int)((MESH_WIDTH * QUAD_WIDTH) / 2),
            (int)((MESH_HEIGHT * QUAD_HEIGHT) / 2),
            0);

        dummy.SetRotation (RotateAxis.X,
            frame_num,
            (int)((MESH_WIDTH * QUAD_WIDTH) / 2),
            (int)((MESH_HEIGHT * QUAD_HEIGHT) / 2),
            0);
    }
}
