using System;
using Clutter;

public class ShaderTest
{
 	static int current_shader = 0;
	static string[] shader_sources = {
  	       @"uniform sampler2D tex;
		 uniform float x_step, y_step;
	         uniform float brightness, contrast;
		 void main ()
		 {
		 	vec4 color = texture2D (tex, vec2(gl_TexCoord[0]));
		 	color.rgb = (color.rgb - vec3(0.5, 0.5, 0.5)) * contrast + vec3 (brightness + 0.5, brightness + 0.5, brightness + 0.5);
		   	gl_FragColor = color;
      		   	gl_FragColor = gl_FragColor * gl_Color;
		 }", 
		@"uniform sampler2D tex;
		  uniform float x_step, y_step;
		  void main ()
		  {
		  	vec4 color = texture2D (tex, vec2(gl_TexCoord[0]));
		  	vec4 colorB = texture2D (tex, vec2(gl_TexCoord[0].ts));
		  	float avg = (color.r + color.g + color.b) / 3.0;
		  	color.r = avg;
		  	color.g = avg;
		  	color.b = avg;
		  	color = (color + colorB)/2.0;
		  	gl_FragColor = color;
      		  	gl_FragColor = gl_FragColor * gl_Color;
		  }",
		@"uniform sampler2D tex;
		  uniform float x_step, y_step;
     		  void main ()
		  {
		  	vec4 color = texture2D (tex, vec2(gl_TexCoord[0]));
     			float avg = (color.r + color.g + color.b) / 3.0;
     			color.r = avg;
     			color.g = avg;
     			color.b = avg;
		  	gl_FragColor = color;
      		  	gl_FragColor = gl_FragColor * gl_Color;
		  }"
	};

	public static void HandleActorButtonPress(object sender, ButtonPressEventArgs args)
	{
	 	int new_no;

		if (args.Event.Button == 1)
		 	new_no = current_shader + 1;
		else
		 	new_no = current_shader - 1;

		if (new_no >= 0 & new_no < shader_sources.Length)
		{
			current_shader = new_no; 

			Shader shader = new Shader ();

			shader.FragmentSource = shader_sources[current_shader];
			shader.Compile ();

			Actor actor = sender as Actor;
			actor.SetShader (shader);
			actor.SetShaderParam ("radius", 3.0f);
		}
	}

	public static void Main ()
	{
		ClutterRun.Init (); 

		Stage stage = Stage.Default;
		stage.SetSize(512, 384);

		Shader shader = new Shader ();

		shader.FragmentSource = shader_sources[current_shader];
		shader.Compile ();

		stage.Title = "Shader Test";
		stage.Color = new Clutter.Color (0x61, 0x64, 0x8c, 0xff);

		Timeline timeline = new Timeline(360, 60);
		timeline.Loop = true;

		stage.AddActor (new Label ("Mono 16", "Press the Hand"));

		Texture actor = new Texture("redhand.png");
		actor.SetShader (shader);
		actor.Reactive = true;
		actor.ButtonPressEvent += HandleActorButtonPress;
		stage.AddActor (actor);
		actor.SetShaderParam("brightness", 0.4f);
		actor.SetShaderParam("contrast", -1.9f);
		actor.SetPosition (0, 20);

		stage.ShowAll ();
		timeline.Start ();

		ClutterRun.Main ();
	} 
}

