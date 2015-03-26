using System;

namespace klukule.Engine
{
	public class TexturedModel
	{
		private RawModel rawModel;
		private ModelTexture texture;

		/// <summary>
		/// Initializes a new instance of the <see cref="klukule.Engine.TexturedModel"/> class.
		/// </summary>
		/// <param name="model">Model.</param>
		/// <param name="texture">Texture.</param>
		public TexturedModel (RawModel model, ModelTexture texture)
		{
			this.rawModel = model;
			this.texture = texture;
		}

		/// <summary>
		/// Gets the raw model.
		/// </summary>
		/// <returns>The raw model.</returns>
		public RawModel getRawModel ()
		{
			return rawModel;
		}

		/// <summary>
		/// Gets the texture.
		/// </summary>
		/// <returns>The texture.</returns>
		public ModelTexture getTexture ()
		{
			return texture;
		}
	}
}

