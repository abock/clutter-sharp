using System;
using System.Threading;

using Clutter;

namespace ClutterTest 
{
	class TestThreadData {
		// Stage stage;
		Label label;

		public Label Label {
			get { return label; } 
		}

		Timeline timeline;

		bool cancelled;

		public bool Cancelled {
			get { return cancelled; } 
		}

		public TestThreadData (Label label, Timeline timeline) {
			this.label = label;
			this.timeline = timeline; 
		}

		public bool HandleIdle () {
			Console.WriteLine ("Thread completed");

			label.Text = "Completed";
			timeline.Stop ();

			return false;
		}
	} 

	class TestUpdate {
		TestThreadData data;
		int count; 

		public TestUpdate (int count, TestThreadData data) {
			this.count = count;
			this.data = data; 
		}

		public bool HandleIdle () {
			string text = string.Format ("Count to {0}", count);
			data.Label.Text = text;

			return false;
		}
	}

	class ThreadWrapper {
		TestThreadData data;
		
		public ThreadWrapper (TestThreadData data) {
			this.data = data; 
		}

		void DoSomethingVerySlow () {
			if (data.Cancelled)
			 	return; 

			for (int i = 0; i < 100; i++) {
			 	System.Threading.Thread.Sleep (100);
				
				if (i % 10 != 0)
				 	continue;

				Idle.Add (new TestUpdate (i, data).HandleIdle);
			}
		} 

		public void ThreadMethod () {
			DoSomethingVerySlow ();
			
			Idle.Add (data.HandleIdle); 
		}
	}

	class Program {
	 	static Color stage_color = new Color (0xcc, 0xcc, 0xcc, 0xff);
		static Color rect_color = new Color (0xee, 0x55, 0x55, 0x99);

		// FIXME: it looks like with threading we need to keep reference to all
		// these items :-(
		static Label count_label;
		static Label label;
		static Rectangle rect;
		static Timeline timeline; 
		static Behaviour behaviour;

		static Stage stage;

		static void HandleKeyPress (object sender, KeyPressEventArgs args) {
			uint symbol = args.Event.Symbol ();
			Gdk.Key key = (Gdk.Key) Enum.Parse (typeof(Gdk.Key), symbol.ToString ()); 

			switch (key) {
				case Gdk.Key.s:
					timeline.Start ();

					TestThreadData data = new TestThreadData (count_label, timeline);
					ThreadWrapper wrapper = new ThreadWrapper (data);

					Thread thread = new Thread (wrapper.ThreadMethod);
					thread.Start ();
					break;
			 	case Gdk.Key.q:
					Clutter.Main.Quit ();
					break;
			}
		 
		}

		static void Main () {
			// GLib.Thread.Init ();
			
			ClutterRun.Init ();

			Clutter.Threads.Init ();
			Clutter.Threads.Enter ();  

			stage = Stage.Default;
			stage.Color = stage_color;
			stage.SetSize (800, 600);

			count_label = new Label ("Mono 16", "Counter");
			count_label.SetPosition (350, 50);
			count_label.Show ();

			label = new Label ("Mono 16", "Press 's' to start");
			label.SetPosition (50, 50);
			label.Show ();

			rect = new Rectangle (rect_color);
			rect.SetPosition (150, 150);
			rect.SetSize (25, 25);
			rect.Show ();
			
			stage.Add (rect);

			timeline = new Timeline (150, 50);
			timeline.Loop = true;

			behaviour = new BehaviourRotate  (new Alpha (timeline, Sine.Func), 
									RotateAxis.ZAxis, 
									RotateDirection.Cw,
									0.0,
									360.0);
			behaviour.Apply (rect);

			stage.Add (count_label);
			stage.Add (label);

			stage.ButtonPressEvent += delegate { Clutter.Main.Quit(); };
			stage.KeyPressEvent += HandleKeyPress;

			stage.ShowAll ();

			ClutterRun.Main ();
			Clutter.Threads.Leave ();
		}
	}
}
