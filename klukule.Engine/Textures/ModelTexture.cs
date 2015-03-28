using System;

namespace klukule.Engine
{
	public class ModelTexture
	{
		private int textureID;

		private float shineDamper = 1;
		private float reflectivity = 0;

		private bool hasTransparency = false;
		private bool useFakeLighting = false;

		/// <summary>
		/// Initializes a new instance of the <see cref="klukule.Engine.ModelTexture"/> class.
		/// </summary>
		/// <param name="id">texture ID.</param>
		public ModelTexture (int id)
		{
			textureID = id;
		}

		/// <summary>
		/// Sets the use fake lighting.
		/// </summary>
		/// <param name="useFakeLighting">If set to <c>true</c> use fake lighting.</param>
		public void setUseFakeLighting (bool useFakeLighting)
		{
			this.useFakeLighting = useFakeLighting;
		}

		/// <summary>
		/// Ises the use fake lightig.
		/// </summary>
		/// <returns><c>true</c>, if use fake lightig was ised, <c>false</c> otherwise.</returns>
		public bool isUseFakeLightig ()
		{
			return useFakeLighting;
		}

		/// <summary>
		/// Ises the has transparency.
		/// </summary>
		/// <returns><c>true</c>, if has transparency was ised, <c>false</c> otherwise.</returns>
		public bool isHasTransparency ()
		{
			return hasTransparency;
		}

		/// <summary>
		/// Sets the has transparency.
		/// </summary>
		/// <returns><c>true</c>, if has transparency was set, <c>false</c> otherwise.</returns>
		/// <param name="transparency">If set to <c>true</c> transparency.</param>
		public void setHasTransparency (bool transparency)
		{
			this.hasTransparency = transparency;
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

