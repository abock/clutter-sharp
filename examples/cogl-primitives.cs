using Clutter.Cogl;

public static class CoglPrimitives
{
    public static void PaintLine ()
    {
        Path.Line (-50, -25, 50, 25);
    }

    public static void PaintRect ()
    {
        Path.Rectangle (-50, -25, 50, 25);
    }

    public static void PaintRoundRect ()
    {
        Path.RoundRectangle (-50, -25, 50, 25, 10, 5);
    }

    public static void PaintPolyLine ()
    {
        float [] poly_coords = new float [] {
            -50, -50,
            +50, -30,
            +30, +30,
            -30, +40
        };
    }

    public static void PaintPolygon ()
    {
        float [] poly_coords = new float [] {
            -50, -50,
            +50, -30,
            +30, +30,
            -30, +40
        };
    }

    public static void PaintEllipse ()
    {
        Path.Ellipse (0, 0, 60, 40);
    }

    public static void PaintCurve ()
    {
        Path.MoveTo (-50, +50);
        Path.CurveTo (
            +100, -50,
            -100, -50,
            +50,  +50);
    }

    public static void PaintCb ()
    {
        Push.Matrix ();
        PaintRoundRect ();


    }

    public static void Main ()
    {
        Clutter.Application.Init ();


    }
}
