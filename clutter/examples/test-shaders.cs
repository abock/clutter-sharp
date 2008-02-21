using System;
using Clutter;
using Gdk;

public class ShaderTest
{
 	static int current_shader = 0;
	static string[] shader_sources = {
	      @"uniform float brightness; 
		uniform float contrast;
		uniform sampler2DRect pend_s3_tex;
		void main()
		{
		    vec4 pend_s4_result;
		    pend_s4_result = texture2DRect(pend_s3_tex, gl_TexCoord[0].xy);
		    pend_s4_result.x = (pend_s4_result.x - 0.5)*contrast + brightness + 0.5;
		    pend_s4_result.y = (pend_s4_result.y - 0.5)*contrast + brightness + 0.5;
		    pend_s4_result.z = (pend_s4_result.z - 0.5)*contrast + brightness + 0.5;
		    gl_FragColor = pend_s4_result;
		}",
	       @"uniform float radius ;
		 uniform sampler2DRect rectTexture;
		 void main()
		 {
		     vec4 color = texture2DRect(rectTexture, gl_TexCoord[0].st);
		     float u;
		     float v;
		     int count = 1;
		     for (u=-radius;u<radius;u++)
		       for (v=-radius;v<radius;v++)
		         {
		           color += texture2DRect(rectTexture, vec2(gl_TexCoord[0].s + u * 2, gl_TexCoord[0].t +v * 2));
		           count ++;
		         }
		     gl_FragColor = color / count;
		 }",
		@"uniform sampler2DRect tex;
		  void main ()
		  {
		    vec4 color = texture2DRect (tex, vec2(gl_TexCoord[0].st));
		    vec4 colorB = texture2DRect (tex, vec2(gl_TexCoord[0].ts));
		    float avg = (color.r + color.g + color.b) / 3;
		    color.r = avg;
		    color.g = avg;
		    color.b = avg;
		    color = (color + colorB)/2;
		    gl_FragColor = color;
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
			shader.Bind ();

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
		shader.Bind ();

		Gdk.Pixbuf pixbuf = new Gdk.Pixbuf("redhand.png");

		stage.Title = "Shader Test";
		stage.Color = new Clutter.Color (0x61, 0x64, 0x8c, 0xff);

		Timeline timeline = new Timeline(360, 60);
		timeline.Loop = true;

		stage.AddActor (new Label ("Mono 16", "Press the Hand"));

		Texture actor = new Texture(pixbuf);
		actor.SetShader (shader);
		actor.SetShaderParam("brightness", 0.4f);
		actor.SetShaderParam("contrast", -1.9f);
		actor.Reactive = true;
		actor.ButtonPressEvent += HandleActorButtonPress;
		stage.AddActor (actor);
		actor.SetPosition (0, 20);

		stage.ShowAll ();
		timeline.Start ();

		ClutterRun.Main ();
	} 
}

