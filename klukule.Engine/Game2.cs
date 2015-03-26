using System;
using klukule.Wrappers;
using klukule.Wrappers.Audio;
using klukule.Wrappers.Graphics;
using klukule.Wrappers.MathUtils;
using klukule.Wrappers.Scripting;

namespace klukule.Engine
{
	public class Game2
	{
		public Game2 ()
		{
			float[] points = {
				0.0f,  0.5f,  0.0f,
				0.5f, -0.5f,  0.0f,
				-0.5f, -0.5f,  0.0f
			};
			Glfw.Init ();

			GlfwWindowPtr window = Glfw.CreateWindow (800, 600, "", GlfwMonitorPtr.Null, GlfwWindowPtr.Null);

			Glfw.MakeContextCurrent (window);

			Renderer renderer = new Renderer ();
			Loader loader = new Loader ();
			RawModel model = loader.loadToVAO (points);

			while (!Glfw.WindowShouldClose (window)) {
				Glfw.PollEvents ();

				if (Glfw.GetKey (window, Key.Escape)) {
					Glfw.SetWindowShouldClose (window, true);
				}

				renderer.prepare ();
				renderer.render (model);

				Glfw.SwapBuffers (window);
			}

			Glfw.Terminate ();
		}
	}
}

