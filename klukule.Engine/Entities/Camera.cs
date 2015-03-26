using System;
using klukule.Wrappers.MathUtils;
using klukule.Wrappers;

namespace klukule.Engine
{
	public class Camera
	{

		private Vector3 position = new Vector3 (0, 1, 0);
		private float pitch;
		private float yaw;
		private float roll;
		private GlfwWindowPtr window;

		public void move ()
		{
			if (Glfw.GetKey (window, Key.W)) {
				position.Z -= 0.02f;
			}
			if (Glfw.GetKey (window, Key.S)) {
				position.Z += 0.02f;
			}
			if (Glfw.GetKey (window, Key.A)) {
				position.X -= 0.02f;
			}
			if (Glfw.GetKey (window, Key.D)) {
				position.X += 0.02f;
			}

		}

		public GlfwWindowPtr getWindow ()
		{
			return window;
		}

		public Vector3 getPosition ()
		{
			return position;
		}

		public float getPitch ()
		{
			return pitch;
		}

		public float getYaw ()
		{
			return yaw;
		}

		public float getRoll ()
		{
			return roll;
		}

		public Camera (GlfwWindowPtr window)
		{
			this.window = window;
		}
	}
}

