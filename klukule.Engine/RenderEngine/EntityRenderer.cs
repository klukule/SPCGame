using System;
using klukule.Wrappers.Graphics;
using klukule.Wrappers.MathUtils;
using klukule.Wrappers;
using System.Collections.Generic;

namespace klukule.Engine
{
	public class EntityRenderer
	{
		private StaticShader shader;

		public EntityRenderer (StaticShader shader, Matrix projectionMatrix)
		{
			this.shader = shader;

			shader.start ();
			shader.loadProjectionMatrix (projectionMatrix);
			shader.stop ();
		
		}

		public void render (Dictionary<TexturedModel,List<Entity>> entities)
		{
			foreach (TexturedModel model in entities.Keys) {
				prepareTexturedModel (model);
				List<Entity> batch;
				entities.TryGetValue (model, out batch);
				foreach (Entity entity in batch) {
					prepareInstance (entity);
					GL.DrawElements (BeginMode.Triangles, model.getRawModel ().getVertexCount (), DrawElementsType.UnsignedInt, 0);
				}
				unbindTexturedModel ();
			}
		}

		private void prepareTexturedModel (TexturedModel model)
		{
			RawModel rawModel = model.getRawModel ();
			GL.BindVertexArray (rawModel.getVaoID ());

			GL.EnableVertexAttribArray (0);
			GL.EnableVertexAttribArray (1);
			GL.EnableVertexAttribArray (2);
			ModelTexture texture = model.getTexture ();
			if (texture.isHasTransparency ()) {
				MasterRenderer.disableCulling ();
			}
			shader.loadFakeLightingVariable (texture.isUseFakeLightig ());
			shader.loadShineValues (texture.getShineDamper (), texture.getReflectivity ());

			GL.ActiveTexture (TextureUnit.Texture0);
			GL.BindTexture (TextureTarget.Texture2D, model.getTexture ().getTextureID ());
		}

		private void unbindTexturedModel ()
		{
			MasterRenderer.enableCulling ();
			GL.DisableVertexAttribArray (0);
			GL.DisableVertexAttribArray (1);
			GL.DisableVertexAttribArray (2);
			GL.BindVertexArray (0);
		}

		private void prepareInstance (Entity entity)
		{
			Matrix transformationMatrix = Math.createTransformationMatrix (entity.getPosition (), entity.getRotX (), entity.getRotY (), entity.getRotZ (), entity.getScale ());
			shader.loadTransformationMatrix (transformationMatrix);

		}
	}
}

