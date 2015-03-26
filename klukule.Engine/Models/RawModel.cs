using System;

namespace klukule.Engine
{
	public class RawModel
	{
		private int vaoID;
		private int vertexCount;
		/// <summary>
		/// Initializes a new instance of the <see cref="klukule.Engine.RawModel"/> class.
		/// </summary>
		/// <param name="vaoID">Vao ID.</param>
		/// <param name="vertexCount">Vertex count.</param>
		public RawModel (int vaoID, int vertexCount)
		{
			this.vaoID = vaoID;
			this.vertexCount = vertexCount;
		}
		/// <summary>
		/// Gets the vao ID.
		/// </summary>
		/// <returns>The vao ID.</returns>
		public int getVaoID(){
			return this.vaoID;
		}
		/// <summary>
		/// Gets the vertex count.
		/// </summary>
		/// <returns>The vertex count.</returns>
		public int getVertexCount(){
			return this.vertexCount;
		}
	}
}

