using System;
using klukule.Wrappers;
using klukule.Wrappers.Audio;
using klukule.Wrappers.Graphics;
using klukule.Wrappers.MathUtils;
using klukule.Wrappers.Scripting;

namespace klukule.Engine
{
	public class GLFW_Backend
	{
		GlfwWindowPtr window;
		private static int winW, winH;

		/// <summary>
		/// Gets the height of the window.
		/// </summary>
		/// <returns>The window height.</returns>
		public static int getWindowHeight ()
		{
			return winH;
		}

		/// <summary>
		/// Gets the width of the window.
		/// </summary>
		/// <returns>The window width.</returns>
		public static int getWindowWidth ()
		{
			return winW;
		}

		/// <summary>
		/// Init GLFW window with specified width, height and title.
		/// </summary>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="title">Title.</param>
		public void Init (int width, int height, string title)
		{
			Glfw.Init ();
			window = Glfw.CreateWindow (width, height, title, GlfwMonitorPtr.Null, GlfwWindowPtr.Null);
			Glfw.MakeContextCurrent (window);
			winH = height;
			winW = width;
		}

		/// <summary>
		/// Render the specified renderLoop.
		/// </summary>
		/// <param name="renderLoop">Render loop.</param>
		public void Render ()
		{
			RenderLoop.Loop (window);
		}

		/// <summary>
		/// Terminate this instance.
		/// </summary>
		public void Terminate ()
		{
			Glfw.Terminate ();
		}
	}
}

