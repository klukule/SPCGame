using System;

namespace klukule.Engine
{
	public class Terrain
	{
		private static float SIZE = 800;
		private static int VERTEX_COUNT = 128;

		private float x;
		private float z;
		private RawModel model;
		private ModelTexture texture;

		public Terrain (int gridX, int gridZ, Loader loader, ModelTexture texture)
		{
			this.texture = texture;
			this.x = gridX * SIZE;
			this.z = gridZ * SIZE;
			this.model = generateTerrain (loader);
		}

		public float getX ()
		{
			return x;
		}

		public float getZ ()
		{
			return z;
		}

		public RawModel getModel ()
		{
			return model;
		}

		public ModelTexture getTexture ()
		{
			return texture;
		}

		private RawModel generateTerrain (Loader loader)
		{
			int count = VERTEX_COUNT * VERTEX_COUNT;
			float[] vertices = new float[count * 3];
			float[] normals = new float[count * 3];
			float[] textureCoords = new float[count * 2];
			int[] indices = new int[6 * (VERTEX_COUNT - 1) * (VERTEX_COUNT * 1)];
			int vertexPointer = 0;
			for (int i = 0; i < VERTEX_COUNT; i++) {
				for (int j = 0; j < VERTEX_COUNT; j++) {
					vertices [vertexPointer * 3] = (float)j / ((float)VERTEX_COUNT - 1) * SIZE;
					vertices [vertexPointer * 3 + 1] = 0;
					vertices [vertexPointer * 3 + 2] = (float)i / ((float)VERTEX_COUNT - 1) * SIZE;
					normals [vertexPointer * 3] = 0;
					normals [vertexPointer * 3 + 1] = 1;
					normals [vertexPointer * 3 + 2] = 0;
					textureCoords [vertexPointer * 2] = (float)j / ((float)VERTEX_COUNT - 1);
					textureCoords [vertexPointer * 2 + 1] = (float)i / ((float)VERTEX_COUNT - 1);
					vertexPointer++;
				}
			}
			int pointer = 0;
			for (int gz = 0; gz < VERTEX_COUNT - 1; gz++) {
				for (int gx = 0; gx < VERTEX_COUNT - 1; gx++) {
					int topLeft = (gz * VERTEX_COUNT) + gx;
					int topRight = topLeft + 1;
					int bottomLeft = ((gz + 1) * VERTEX_COUNT) + gx;
					int bottomRight = bottomLeft + 1;
					indices [pointer++] = topLeft;
					indices [pointer++] = bottomLeft;
					indices [pointer++] = topRight;
					indices [pointer++] = topRight;
					indices [pointer++] = bottomLeft;
					indices [pointer++] = bottomRight;
				}
			}
			/*float[] vertices = {
				-0.5000f, -0.5000f,  0.5000f,
				0.5000f, -0.5000f,  0.5000f,
				-0.5000f,  0.5000f,  0.5000f,
				-0.5000f,  0.5000f,  0.5000f,
				0.5000f, -0.5000f,  0.5000f,
				0.5000f,  0.5000f,  0.5000f, 

				-0.5000f, -0.5000f, -0.5000f,
				-0.5000f,  0.5000f, -0.5000f,
				0.5000f, -0.5000f, -0.5000f,
				0.5000f, -0.5000f, -0.5000f,
				-0.5000f,  0.5000f, -0.5000f,
				0.5000f,  0.5000f, -0.5000f,

				0.5000f, -0.5000f, -0.5000f, 
				0.5000f,  0.5000f, -0.5000f, 
				0.5000f, -0.5000f,  0.5000f, 
				0.5000f, -0.5000f,  0.5000f, 
				0.5000f,  0.5000f, -0.5000f, 
				0.5000f,  0.5000f,  0.5000f, 

				-0.5000f, -0.5000f, -0.5000f, 
				-0.5000f, -0.5000f,  0.5000f, 
				-0.5000f,  0.5000f, -0.5000f, 
				-0.5000f,  0.5000f, -0.5000f, 
				-0.5000f, -0.5000f,  0.5000f, 
				-0.5000f,  0.5000f,  0.5000f, 

				-0.5000f, -0.5000f, -0.5000f,
				0.5000f, -0.5000f, -0.5000f,
				-0.5000f, -0.5000f,  0.5000f,
				-0.5000f, -0.5000f,  0.5000f,
				0.5000f, -0.5000f, -0.5000f,
				0.5000f, -0.5000f,  0.5000f,

				-0.5000f,  0.5000f, -0.5000f,
				-0.5000f,  0.5000f,  0.5000f,
				0.5000f,  0.5000f, -0.5000f,
				0.5000f,  0.5000f, -0.5000f,
				-0.5000f,  0.5000f,  0.5000f,
				0.5000f,  0.5000f,  0.5000f,

			};

			int[] indices = {
				0,  1,  2, 
				3,  4,  5,

				18, 19, 20,
				21, 22, 23,

				12, 13, 14,
				15, 16, 17,

				6,  7,  8,
				9, 10, 11,

				30, 31, 32,
				33, 34, 35,

				24, 25, 26,
				27, 28, 29
			};
			float[] normals = {
				-1.0000f, -1.0000f,  1.0000f,
				1.0000f, -1.0000f,  1.0000f,
				-1.0000f,  1.0000f,  1.0000f,
				-1.0000f,  1.0000f,  1.0000f,
				1.0000f, -1.0000f,  1.0000f,
				1.0000f,  1.0000f,  1.0000f, 
			};

			float[] textureCoords =
			{
				1.0000f, 0.0000f, 0.0000f,
				1.0000f, 1.0000f, 0.0000f,
				0.0000f, 1.0000f, 0.0000f,
				0.0000f, 0.0000f, 0.0000f
			};*/
			return loader.loadToVAO (vertices, textureCoords, normals, indices);
		}
	}
}

