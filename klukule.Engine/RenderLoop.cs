using System;
using klukule.Wrappers;
using klukule.Wrappers.Audio;
using klukule.Wrappers.Graphics;
using klukule.Wrappers.MathUtils;
using klukule.Wrappers.Scripting;
using System.Reflection;
using System.Diagnostics;

namespace klukule.Engine
{
	public class RenderLoop
	{
		public static void Loop (GlfwWindowPtr window)
		{

			Loader loader = new Loader ();
			ModelTexture texture = new ModelTexture (loader.loadTexture ("texture"));
			texture.setShineDamper (10);
			texture.setReflectivity (1);
			TexturedModel model = new TexturedModel (OBJLoader.loadObjModel ("stall", loader), texture);
			Entity entity = new Entity (model, new Vector3 (0, 0, -25), 0, 0, 0, 1);
			Entity entity2 = new Entity (model, new Vector3 (5, 0, -25), 0, 0, 0, 1);
			Light light = new Light (new Vector3 (3000, 2000, 2000), new Vector3 (1, 1, 1));

			Terrain terrain = new Terrain (0, -1, loader, texture);
			Terrain terrain2 = new Terrain (1, -1, loader, texture);

			Camera camera = new Camera (window);

			MasterRenderer renderer = new MasterRenderer ();

			while (!Glfw.WindowShouldClose (window)) {
				Glfw.PollEvents ();
				if (Glfw.GetKey (window, Key.Escape)) {
					Glfw.SetWindowShouldClose (window, true);
				}

				Glfw.PollEvents ();

				if (Glfw.GetKey (window, Key.Escape)) {
					Glfw.SetWindowShouldClose (window, true);
				}
				//entity.increasePosition (0, 0, -0.002f);
				entity.increaseRotation (0, 0.2f, 0);
				entity2.increaseRotation (0, -0.2f, 0);
				camera.move ();
				renderer.processTerrain (terrain);
				renderer.processTerrain (terrain2);
				renderer.processEntity (entity);
				renderer.processEntity (entity2);
				renderer.render (light, camera);
				Glfw.SwapBuffers (window);
			}
			renderer.cleanUp ();
			loader.cleanUp ();
		}
	}
}

