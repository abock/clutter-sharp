using System;
using Clutter;

public class ShaderTest
{
	static string test_behaviour = "[" + 
		"{"									 + 
		"    \"id\" : \"main-timeline\","                                        + 
		"    \"type\" : \"ClutterTimeline\","                                    + 
		"    \"duration\" : 5000,"                                               + 
		"    \"loop\" : true"                                                    + 
		"  },"                                                                   + 
		"  {"                                                                    + 
		"    \"id\"          : \"path-behaviour\","                              + 
		"    \"type\"        : \"ClutterBehaviourPath\","                        + 
		"    \"knots\"       : [ [ 50, 50 ], { \"x\" : 100, \"y\" : 100 } ],"    + 
		"    \"alpha\"       : {"                                                + 
		"      \"timeline\" : \"main-timeline\","                                + 
		"      \"function\" : \"ramp\""                                          + 
		"    }"                                                                  + 
		"  },"                                                                   + 
		"  {"                                                                    + 
		"    \"id\"          : \"rotate-behaviour\","                            + 
		"    \"type\"        : \"ClutterBehaviourRotate\","                      + 
		"    \"angle-start\" : 0.0,"                                             + 
		"    \"angle-end\"   : 360.0,"                                           + 
		"    \"axis\"        : \"y-axis\","                                      + 
		"    \"alpha\"       : {"                                                + 
		"      \"timeline\" : \"main-timeline\","                                + 
		"      \"function\" : \"sine\""                                          + 
		"    }"                                                                  + 
		"  },"                                                                   + 
		"  {"                                                                    + 
		"    \"id\"            : \"fade-behaviour\","                            + 
		"    \"type\"          : \"ClutterBehaviourOpacity\","                   + 
		"    \"opacity-start\" : 255,"                                           + 
		"    \"opacity-end\"   : 0,"                                             + 
		"    \"alpha\"         : {"                                              + 
		"      \"timeline\" : \"main-timeline\","                                + 
		"      \"function\" : \"ramp-inc\""                                      + 
		"    }"                                                                  + 
		"  }"                                                                    + 
		"]";

	static string test_unmerge = 
	        "{"                                  +  
		"   \"id\" : \"blue-button\",       "+ 
		"   \"type\" : \"ClutterRectangle\","+ 
		"   \"color\" : \"#0000ffff\",      "+ 
		"   \"x\" : 350,                    "+ 
		"   \"y\" : 50,                     "+ 
		"   \"width\" : 100,                "+ 
		"   \"height\" : 100,               "+ 
		"   \"visible\" : true,             "+ 
		"   \"reactive\" : true             "+ 
		" }";

	static Script script;
	static uint merge_id = 0;

	public static void Main ()
	{
		ClutterRun.Init (); 

		script = new Script ();
		script.LoadFromData (test_behaviour);
		script.LoadFromFile ("test-script.json");
		merge_id = script.LoadFromData (test_unmerge);

		Stage stage = script.GetObject<Stage>("main-stage");
		Actor blue_button = script.GetObject<Actor>("blue-button");
		Actor red_button = script.GetObject<Actor>("red-button");

		blue_button.ButtonPressEvent += delegate
		{
	 		Console.WriteLine("Unmerging");
			script.UnmergeObjects(merge_id);
		};

		red_button.ButtonPressEvent += delegate
		{
		 	Console.WriteLine ("Changing timeline state");
			Timeline timeline = script.GetObject<Timeline> ("main-timeline");

			if (!timeline.IsPlaying)
			 	timeline.Start ();
			else
			 	timeline.Pause ();
		};

		stage.Unrealized += delegate  { Clutter.Main.Quit (); };
		stage.KeyPressEvent += delegate { Clutter.Main.Quit ();	};

		stage.ShowAll ();

		ClutterRun.Main ();
	} 
}

