using System;

namespace klukule.Engine
{
	public class Game
	{
		GLFW_Backend backend;

		/// <summary>
		/// Initializes a new instance of the <see cref="klukule.Engine.Game"/> class.
		/// </summary>
		public Game ()
		{
			backend = new GLFW_Backend ();
		}

		/// <summary>
		/// Init game with the specified width, height and title.
		/// </summary>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="title">Title.</param>
		public void Init (int width, int height, string title)
		{
			backend.Init (width, height, title);

		}

		/// <summary>
		/// Init RenderLoop.
		/// </summary>
		public void Render ()
		{
			backend.Render ();
		}

		/// <summary>
		/// Terminate the game.
		/// </summary>
		public void Terminate ()
		{
			backend.Terminate ();
		}
	}
}

