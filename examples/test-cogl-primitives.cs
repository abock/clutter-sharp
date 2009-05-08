using System;
using Clutter;

public static class TestCoglPrimitives
{
    public static void Main ()
    {
        var painters = new Action [] {
            () => Cogl.Path.Line (-50, -25, 50, 25),
            () => Cogl.Path.Rectangle (-50, -25, 50, 25),
            () => Cogl.Path.RoundRectangle (-50, -25, 50, 25, 10, 5),
            () => Cogl.Path.Ellipse (0, 0, 60, 40),
            () => Cogl.Path.Polygon (new float [] {
                    -50, -50,
                    +50, -30,
                    +30, +30,
                    -30, +40}),
            () => Cogl.Path.Polyline (new float [] {
                    -50, -50,
                    +50, -30,
                    +30, +30,
                    -30, +40}),
            () => {
                Cogl.Path.MoveTo (-50, +50);
                Cogl.Path.CurveTo (
                    +100, -50,
                    -100, -50,
                    +50,  +50);
            }
        };

        Application.Init ();

        var timeline = new Timeline () {
            FrameCount = (uint)painters.Length, 
            Speed = 1,
            Loop = true
        };

        var box = new Group ();
        box.Painted += (o, e) => {
            Cogl.General.PushMatrix ();

            painters[timeline.CurrentFrame % painters.Length] ();

            Cogl.General.Translate (100, 100, 0);
            Cogl.General.SetSourceColor4ub (0, 160, 0, 255);
            Cogl.Path.StrokePreserve ();

            Cogl.General.Translate (150, 0, 0);
            Cogl.General.SetSourceColor4ub (200, 0, 0, 255);
            Cogl.Path.Fill ();

            Cogl.General.PopMatrix ();
        };

        box.SetRotation (RotateAxis.X, -30, 200, 0, 0);
        box.SetPosition (0, 100);

        var stage = Stage.Default;
        stage.SetSize (400, 400);
        stage.Title = "Cogl Primitives Test";
        stage.Add (box);
        stage.Show ();

        timeline.NewFrame += (o, e) => box.QueueRedraw ();
        timeline.Start ();

        Application.Run ();
    }
}
