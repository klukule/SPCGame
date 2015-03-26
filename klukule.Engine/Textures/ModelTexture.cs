using System;

namespace klukule.Engine
{
	public class ModelTexture
	{
		private int textureID;

		private float shineDamper = 1;
		private float reflectivity = 0;

		/// <summary>
		/// Initializes a new instance of the <see cref="klukule.Engine.ModelTexture"/> class.
		/// </summary>
		/// <param name="id">texture ID.</param>
		public ModelTexture (int id)
		{
			textureID = id;
		}

		/// <summary>
		/// Gets the ID.
		/// </summary>
		/// <returns>The ID.</returns>
		public int getTextureID ()
		{
			return textureID;
		}

		/// <summary>
		/// Gets the shine damper.
		/// </summary>
		/// <returns>The shine damper.</returns>
		public float getShineDamper ()
		{
			return shineDamper;
		}

		/// <summary>
		/// Gets the reflectivity.
		/// </summary>
		/// <returns>The reflectivity.</returns>
		public float getReflectivity ()
		{
			return reflectivity;
		}

		/// <summary>
		/// Sets the shine damper.
		/// </summary>
		/// <param name="shineDamper">Shine damper.</param>
		public void setShineDamper (float shineDamper)
		{
			this.shineDamper = shineDamper;
		}

		/// <summary>
		/// Sets the reflectivity.
		/// </summary>
		/// <param name="reflectivity">Reflectivity.</param>
		public void setReflectivity (float reflectivity)
		{
			this.reflectivity = reflectivity;
		}
	}
}

