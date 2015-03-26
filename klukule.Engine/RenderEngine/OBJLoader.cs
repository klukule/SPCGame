using System;
using klukule.Wrappers.Graphics;
using klukule.Wrappers.MathUtils;

namespace klukule.Engine
{
	public class OBJLoader
	{
		public static RawModel loadObjModel (string filename, Loader loader)
		{
			Vector4[] vertices;
			Vector3[] normals;
			Vector2[] tCoords;
			int[] indices;
			GL.Utils.LoadModel ("models/" + filename + ".obj", out vertices, out normals, out tCoords, out indices);
			float[] vertArray = new float[vertices.Length * 3];
			float[] normArray = new float[normals.Length * 3];
			float[] textArray = new float[tCoords.Length * 2];
			int vertPointer = 0;
			foreach (Vector4 vert in vertices) {
				vertArray [vertPointer++] = vert.X;
				vertArray [vertPointer++] = vert.Y;
				vertArray [vertPointer++] = vert.Z;
			}
			int normPointer = 0;
			foreach (Vector3 norm in normals) {
				normArray [normPointer++] = norm.X;
				normArray [normPointer++] = norm.Y;
				normArray [normPointer++] = norm.Z;
			}
			int textPointer = 0;
			foreach (Vector2 text in tCoords) {
				textArray [textPointer++] = text.X;
				textArray [textPointer++] = 1 - text.Y;
			}

			return loader.loadToVAO (vertArray, textArray, normArray, indices);
		}
	}
}

