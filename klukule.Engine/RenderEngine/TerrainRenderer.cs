using System;
using klukule.Wrappers.Graphics;
using klukule.Wrappers.MathUtils;
using System.Collections.Generic;

namespace klukule.Engine
{
	public class TerrainRenderer
	{
		private TerrainShader shader;

		public TerrainRenderer (TerrainShader shader, Matrix projectionMatrix)
		{
			this.shader = shader;
			shader.start ();
			shader.loadProjectionMatrix (projectionMatrix);
			shader.stop ();
		}

		public void render (List<Terrain> terrains)
		{
			foreach (Terrain terrain in terrains) {
				prepareTerrain (terrain);
				loadModelMatrix (terrain);
				GL.DrawElements (BeginMode.Triangles, terrain.getModel ().getVertexCount (), DrawElementsType.UnsignedInt, 0);

				unbindTexturedModel ();
			}
		}

		private void prepareTerrain (Terrain terrain)
		{
			RawModel rawModel = terrain.getModel ();
			GL.BindVertexArray (rawModel.getVaoID ());

			GL.EnableVertexAttribArray (0);
			GL.EnableVertexAttribArray (1);
			GL.EnableVertexAttribArray (2);
			ModelTexture texture = terrain.getTexture ();
			shader.loadShineValues (texture.getShineDamper (), texture.getReflectivity ());

			GL.ActiveTexture (TextureUnit.Texture0);
			GL.BindTexture (TextureTarget.Texture2D, texture.getTextureID ());
		}

		private void unbindTexturedModel ()
		{
			GL.DisableVertexAttribArray (0);
			GL.DisableVertexAttribArray (1);
			GL.DisableVertexAttribArray (2);
			GL.BindVertexArray (0);
		}

		private void loadModelMatrix (Terrain terrain)
		{
			Matrix transformationMatrix = Math.createTransformationMatrix (new Vector3 (terrain.getX (), 0, terrain.getZ ()), 0, 0, 0, 1);
			shader.loadTransformationMatrix (transformationMatrix);

		}
	}
}

