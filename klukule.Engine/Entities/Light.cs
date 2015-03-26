using System;
using klukule.Wrappers.MathUtils;
using klukule.Wrappers.Graphics;

namespace klukule.Engine
{
	public class Light
	{
		private Vector3 position;
		private Vector3 color;

		public Light (Vector3 position, Vector3 color)
		{
			this.position = position;
			this.color = color;
		}

		public Vector3 getPosition ()
		{
			return position;
		}

		public Vector3 getColor ()
		{
			return color;
		}

		public void setPosition (Vector3 position)
		{
			this.position = position;
		}

		public void setColor (Vector3 color)
		{
			this.color = color;
		}
	}
}

