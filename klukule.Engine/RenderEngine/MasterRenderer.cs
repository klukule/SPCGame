using System;
using klukule.Wrappers.Graphics;
using System.Collections.Generic;
using klukule.Wrappers.MathUtils;
using System.Runtime.Remoting.Messaging;

namespace klukule.Engine
{
	public class MasterRenderer
	{
		private static float FOV = 70f;
		private static float NEAR_PLANE = 0.1f;
		private static float FAR_PLANE = 1000.0f;

		private static StaticShader entityShader = new StaticShader ();
		private static TerrainShader terrainShader = new TerrainShader ();

		private static EntityRenderer entityRenderer;
		private static TerrainRenderer terrainRenderer;

		private Matrix projectionMatrix;

		private Dictionary<TexturedModel,List<Entity>> entities = new Dictionary<TexturedModel, List<Entity>>{ };
		private List<Terrain> terrains = new List<Terrain>{ };

		public MasterRenderer ()
		{
			//GL.Enable (EnableCap.CullFace);
			//GL.CullFace (CullFaceMode.Front);
			projectionMatrix = createProjectionMatrix ();
			entityRenderer = new EntityRenderer (entityShader, projectionMatrix);
			terrainRenderer = new TerrainRenderer (terrainShader, projectionMatrix);
		}

		public void render (Light sun, Camera camera)
		{
			prepare ();
			entityShader.start ();
			entityShader.loadLight (sun);
			entityShader.loadViewMatrix (camera);
			entityRenderer.render (entities);
			entityShader.stop ();

			terrainShader.start ();
			terrainShader.loadLight (sun);
			terrainShader.loadViewMatrix (camera);
			terrainRenderer.render (terrains);
			terrainShader.stop ();

			terrains.Clear ();
			entities.Clear ();
		}

		public void processTerrain (Terrain terrain)
		{
			terrains.Add (terrain);
		}

		public void processEntity (Entity entity)
		{
			TexturedModel entityModel = entity.getModel ();
			List<Entity> batch;
			entities.TryGetValue (entityModel, out batch);
			if (batch != null) {
				batch.Add (entity);
			} else {
				List<Entity> newBatch = new List<Entity>{ };
				newBatch.Add (entity);
				entities.Add (entityModel, newBatch);
			}
		}

		public void prepare ()
		{
			GL.Enable (EnableCap.DepthTest);
			GL.ClearColor (Color4.Black);
			GL.Clear (ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
		}

		public void cleanUp ()
		{
			terrainShader.cleanUp ();
			entityShader.cleanUp ();
		}

		public Matrix createProjectionMatrix ()
		{
			return Math.createProjectionMatrix (FOV, GLFW_Backend.getWindowWidth (), GLFW_Backend.getWindowHeight (), NEAR_PLANE, FAR_PLANE);
		}
	}
}

