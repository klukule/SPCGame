using System;
using klukule.Wrappers;
using klukule.Wrappers.Graphics;
using System.Collections.Generic;

namespace klukule.Engine
{
	public class Loader
	{
		private List<int> vaos = new List<int>{ };
		private List<int> vbos = new List<int>{ };
		private List<int> textures = new List<int>{ };

		/// <summary>
		/// Loads Raw Model to VAO.
		/// </summary>
		/// <returns>The Raw Model.</returns>
		/// <param name="positions">Positions.</param>
		/// <param name="textureCoords">Texture coords.</param>
		/// <param name="indices">Indices.</param>
		public RawModel loadToVAO (float[] positions, float[] textureCoords, float[] normals, int[] indices)
		{
			int vaoID = createVAO ();
			//Console.WriteLine (vaoID);
			bindIndicesBuffer (indices);
			storeDataInAttributeList (0, 3, positions);
			storeDataInAttributeList (1, 2, textureCoords);
			storeDataInAttributeList (2, 3, normals);
			unbindVAO ();
			return new RawModel (vaoID, indices.Length);
		}

		/// <summary>
		/// Loads the texture.
		/// </summary>
		/// <returns>The texture ID.</returns>
		/// <param name="textureName">Texture name.</param>
		public int loadTexture (string textureName)
		{
			int textureID = GL.Utils.LoadImage ("Textures/" + textureName + ".png");
			textures.Add (textureID);
			return textureID;
		}

		/// <summary>
		/// Creates the VAO.
		/// </summary>
		/// <returns>The VAO ID.</returns>
		private int createVAO ()
		{
			int vaoID = GL.GenVertexArray ();
			vaos.Add (vaoID);
			GL.BindVertexArray (vaoID);
			return vaoID;
		}

		/// <summary>
		/// Stores the data in attribute list.
		/// </summary>
		/// <param name="attributeNumber">Attribute number.</param>
		/// <param name="data">Data.</param>
		private void storeDataInAttributeList (int attributeNumber, int size, float[] data)
		{

			int vboID = GL.GenBuffer ();
			vbos.Add (vboID);
			GL.BindBuffer (BufferTarget.ArrayBuffer, vboID);
			GL.BufferData (BufferTarget.ArrayBuffer, new IntPtr (data.Length * sizeof(float)), data, BufferUsageHint.StaticDraw);
			GL.VertexAttribPointer (attributeNumber, size, VertexAttribPointerType.Float);
			GL.BindBuffer (BufferTarget.ArrayBuffer, 0);
		}

		/// <summary>
		/// Unbinds the VAO.
		/// </summary>
		private void unbindVAO ()
		{
			GL.BindVertexArray (0);
		}

		/// <summary>
		/// Binds the indices buffer.
		/// </summary>
		/// <param name="indices">Indices.</param>
		private void bindIndicesBuffer (int[] indices)
		{

			int vboID = GL.GenBuffer ();
			vbos.Add (vboID);
			GL.BindBuffer (BufferTarget.ElementArrayBuffer, vboID);
			GL.BufferData (BufferTarget.ElementArrayBuffer, new IntPtr (indices.Length * sizeof(int)), indices, BufferUsageHint.StaticDraw);
		}

		public void cleanUp ()
		{
			int[] vao = vaos.ToArray ();
			int[] vbo = vbos.ToArray ();
			int[] texture = textures.ToArray ();

			GL.DeleteVertexArrays (vao.Length, vao);
			GL.DeleteBuffers (vbo.Length, vbo);
			GL.DeleteTextures (texture.Length, texture);
		}
	}
}