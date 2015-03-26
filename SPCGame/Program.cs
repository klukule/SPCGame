using System;
using klukule.Engine;

namespace SPCGame
{
	class MainClass
	{
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main (string[] args)
		{
			Game game = new Game ();
			game.Init (800, 600, "Hello");
			game.Render ();
			game.Terminate ();
		}
	}
}
