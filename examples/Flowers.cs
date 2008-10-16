using System;
using Clutter;
using Cairo;

public class Flower
{
	const int PETAL_MIN = 20;
	const int PETAL_VAR = 40;
	const int N_FLOWERS = 40;
	
	static Random random;

	static Flower[] flowers;
	
 	CairoTexture ctex;
	int x;
	int y;
	int rot;
	int v;
	int rv;

	static double[] colors = { 0.71, 0.81, 0.83, 
				   1.0,  0.78, 0.57,
				   0.64, 0.30, 0.35,
				   0.73, 0.40, 0.39, 
				   0.91, 0.56, 0.64, 
				   0.70, 0.47, 0.45,  
				   0.92, 0.75, 0.60,  
				   0.82, 0.86, 0.85,  
				   0.51, 0.56, 0.67, 
				   1.0, 0.79, 0.58  };

	public Flower ( )
	{
		int idx = -1;
		int last_idx = -1;

		int petal_size = PETAL_MIN + rand () % PETAL_VAR;
		int size = petal_size * 8;

		int n_groups = rand () % 3 + 1;

		this.ctex = new CairoTexture ((uint)size, (uint)size);

		// the using statement make sure the cr is disposed at the end,
		// otherwise we get no bling
		using (Cairo.Context cr = this.ctex.Create ())
		{
			cr.Tolerance = 0.1;

			// Clear
			cr.Operator = Operator.Clear;
			cr.Paint ();
			cr.Operator = Operator.Over;

			cr.Translate (size/2, size/2);

			// petals
			for (int i = 0; i < n_groups; i++)
			{
			 	int n_petals = rand () % 5 + 4;
				cr.Save ();

				cr.Rotate (rand () % 6);

				do {
					idx = (rand () % (colors.Length / 3)) * 3; 
				} while (idx == last_idx);

				cr.SetSourceRGBA (colors[idx], colors[idx+1], colors[idx+2], 0.5);

				int pm1 = rand () % 20;
				int pm2 = rand () % 4;

				for (int j = 0; j < n_petals; j++)
				{
				 	cr.Save ();

					cr.Rotate (((2 * Math.PI) / n_petals) * j);

					cr.NewPath ();
					cr.MoveTo (0, 0);

					cr.RelCurveTo (petal_size, petal_size, (pm2 + 2) * petal_size, 
						petal_size, (2 * petal_size) + pm1, 0);

					cr.RelCurveTo (0 + (pm2 * petal_size), -petal_size, - petal_size,
						-petal_size, -((2 * petal_size) + pm1), 0);

					cr.ClosePath ();
					cr.Fill ();
					cr.Restore ();
				}

				petal_size -= rand () % (size / 8);

				cr.Restore ();
			}

			// flower center
			do {
				idx = (rand () % (colors.Length / 4 / 3)) * 3; 
			} while (idx == last_idx);

			if (petal_size < 0)
			 	petal_size = rand () % 10;

			cr.SetSourceRGBA (colors[idx], colors[idx+1], colors[idx+2], 0.5);

			cr.Arc (0, 0, petal_size, 0, Math.PI * 2);
			cr.Fill ();
		}
	}

	static bool Tick ()
	{
		for (int i = 0; i < N_FLOWERS; i++)
		{
		 	flowers[i].y += flowers[i].v;
			flowers[i].rot += flowers[i].rv;

			if (flowers[i].y > Stage.Default.Height)
				flowers[i].y = (int)-flowers[i].ctex.Height;

			Actor current_flower = flowers[i].ctex;

			current_flower.SetPosition (flowers[i].x, flowers[i].y);
			current_flower.SetRotation(RotateAxis.ZAxis,
					           flowers[i].rot, 
						   (int)current_flower.Width / 2, 
						   (int)current_flower.Height /2,
						   0);
		}

		return true;
	}

	static int rand ()
	{
		return random.Next ();
	}

	static void HandleKeyPress (object o, KeyPressEventArgs args)
	{
		Clutter.Main.Quit (); 
	}
 
	public static void Main ()
	{
		random = new Random ();
	
	 	ClutterRun.Init ();

		Stage stage = Stage.Default;
		stage.Fullscreen = true;

		stage.Color = new Clutter.Color (0x10, 0x10, 0x10, 0xff);
		flowers = new Flower[N_FLOWERS];


		for (int i = 0; i < N_FLOWERS; i++)
		{
			flowers[i] = new Flower ();
			flowers[i].x = (int)(rand () % stage.Width - (PETAL_MIN + PETAL_VAR)*2);
			flowers[i].y = (int)(rand () % stage.Height);
			flowers[i].rv = rand () % 5 + 1;
			flowers[i].v = rand () % 10 + 2;

			stage.AddActor (flowers[i].ctex);
			flowers[i].ctex.SetPosition (flowers[i].x, flowers[i].y);
		}

		GLib.Timeout.Add (50, new GLib.TimeoutHandler (Tick));

		stage.ShowAll ();
		stage.KeyPressEvent += HandleKeyPress;

		ClutterRun.Main ();
	 
	} 
}
