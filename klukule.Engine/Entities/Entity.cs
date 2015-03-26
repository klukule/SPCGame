using System;
using klukule.Wrappers.MathUtils;

namespace klukule.Engine
{
	public class Entity
	{
		private TexturedModel model;
		private Vector3 position;
		private float rotX, rotY, rotZ;
		private float scale;

		/// <summary>
		/// Initializes a new instance of the <see cref="klukule.Engine.Entity"/> class.
		/// </summary>
		/// <param name="model">Model.</param>
		/// <param name="position">Position.</param>
		/// <param name="rotX">Rotation x.</param>
		/// <param name="rotY">Rotation y.</param>
		/// <param name="rotZ">Rotation z.</param>
		/// <param name="scale">Scale.</param>
		public Entity (TexturedModel model, Vector3 position, float rotX, float rotY, float rotZ, float scale)
		{
			this.model = model;
			this.position = position;
			this.rotX = rotX;
			this.rotY = rotY;
			this.rotZ = rotZ;
			this.scale = scale;
		}

		/// <summary>
		/// Increases the position.
		/// </summary>
		/// <param name="dx">distance x.</param>
		/// <param name="dy">distance y.</param>
		/// <param name="dz">distance z.</param>
		public void increasePosition (float dx, float dy, float dz)
		{
			this.position.X += dx;
			this.position.Y += dy;
			this.position.Z += dz;
		}

		public void increaseRotation (float rx, float ry, float rz)
		{
			this.rotX += rx;
			this.rotY += ry;
			this.rotZ += rz;
		}

		/// <summary>
		/// Gets the model.
		/// </summary>
		/// <returns>The model.</returns>
		public TexturedModel getModel ()
		{
			return model;
		}

		/// <summary>
		/// Gets the position.
		/// </summary>
		/// <returns>The position.</returns>
		public Vector3 getPosition ()
		{
			return position;
		}

		/// <summary>
		/// Gets the rot x.
		/// </summary>
		/// <returns>The rot x.</returns>
		public float getRotX ()
		{
			return rotX;
		}

		/// <summary>
		/// Gets the rot y.
		/// </summary>
		/// <returns>The rot y.</returns>
		public float getRotY ()
		{
			return rotY;
		}

		/// <summary>
		/// Gets the rot z.
		/// </summary>
		/// <returns>The rot z.</returns>
		public float getRotZ ()
		{
			return rotZ;
		}

		/// <summary>
		/// Gets the scale.
		/// </summary>
		/// <returns>The scale.</returns>
		public float getScale ()
		{
			return scale;
		}

		/// <summary>
		/// Sets the model.
		/// </summary>
		/// <param name="model">Model.</param>
		public void setModel (TexturedModel model)
		{
			this.model = model;
		}

		/// <summary>
		/// Sets the position.
		/// </summary>
		/// <param name="position">Position.</param>
		public void setPosition (Vector3 position)
		{
			this.position = position;
		}

		/// <summary>
		/// Sets the rot x.
		/// </summary>
		/// <param name="rotX">Rot x.</param>
		public void setRotX (float rotX)
		{
			this.rotX = rotX;
		}

		/// <summary>
		/// Sets the rot y.
		/// </summary>
		/// <param name="rotY">Rot y.</param>
		public void setRotY (float rotY)
		{
			this.rotY = rotY;
		}

		/// <summary>
		/// Sets the rot z.
		/// </summary>
		/// <param name="rotZ">Rot z.</param>
		public void setRotZ (float rotZ)
		{
			this.rotZ = rotZ;
		}

		/// <summary>
		/// Sets the scale.
		/// </summary>
		/// <param name="scale">Scale.</param>
		public void setScale (float scale)
		{
			this.scale = scale;
		}
	}
}

