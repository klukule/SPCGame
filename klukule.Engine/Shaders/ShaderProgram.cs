using System;
using klukule.Wrappers.Graphics;
using System.IO;
using klukule.Wrappers.MathUtils;

namespace klukule.Engine
{
	public abstract class ShaderProgram
	{
		private int programID;
		private int vertexShaderID;
		private int fragmentShaderID;

		/// <summary>
		/// Initializes a new instance of the <see cref="klukule.Engine.ShaderProgram"/> class.
		/// </summary>
		/// <param name="vertexFile">Vertex file.</param>
		/// <param name="fragmentFile">Fragment file.</param>
		public ShaderProgram (string vertexFile, string fragmentFile)
		{
			vertexShaderID = loadShader (vertexFile, ShaderType.VertexShader);
			fragmentShaderID = loadShader (fragmentFile, ShaderType.FragmentShader);
			programID = (int)GL.CreateProgram ();
			GL.AttachShader (programID, vertexShaderID);
			GL.AttachShader (programID, fragmentShaderID);
			bindAttributes ();
			GL.LinkProgram (programID);
			GL.ValidateProgram (programID);
			getAllUniformLocations ();
		}

		/// <summary>
		/// Start using this shader.
		/// </summary>
		public void start ()
		{
			GL.UseProgram (programID);
		}

		/// <summary>
		/// Stop using this shader.
		/// </summary>
		public void stop ()
		{
			GL.UseProgram (0);
		}

		/// <summary>
		/// Cleans up.
		/// </summary>
		public void cleanUp ()
		{
			stop ();
			GL.DetachShader (programID, vertexShaderID);
			GL.DetachShader (programID, fragmentShaderID);
			GL.DeleteShader (vertexShaderID);
			GL.DeleteShader (fragmentShaderID);
			GL.DeleteProgram (programID);
		}

		/// <summary>
		/// Binds the attributes.
		/// </summary>
		protected abstract void bindAttributes ();

		/// <summary>
		/// Gets locations of all uniforms.
		/// </summary>
		protected abstract void getAllUniformLocations ();

		/// <summary>
		/// Gets the uniform location.
		/// </summary>
		/// <returns>The uniform location.</returns>
		/// <param name="uniformName">Uniform name.</param>
		protected int getUniformLocation (string uniformName)
		{
			return GL.GetUniformLocation (programID, uniformName);
		}

		/// <summary>
		/// Loads the float.
		/// </summary>
		/// <param name="location">Location.</param>
		/// <param name="value">Value.</param>
		protected void loadFloat (int location, float value)
		{
			GL.Uniform1 (location, value);
		}

		/// <summary>
		/// Loads the boolean.
		/// </summary>
		/// <param name="location">Location.</param>
		/// <param name="value">If set to <c>true</c> value.</param>
		protected void loadBoolean (int location, bool value)
		{
			float toLoad = 0;
			if (value) {
				toLoad = 1;
			}
			GL.Uniform1 (location, toLoad);
		}

		protected void loadMatrix (int location, Matrix value)
		{
			GL.UniformMatrix4 (location, false, ref value);
		}

		/// <summary>
		/// Loads the vector.
		/// </summary>
		/// <param name="location">Location.</param>
		/// <param name="value">Value.</param>
		protected void loadVector (int location, Vector3 value)
		{
			GL.Uniform3 (location, value);
		}

		/// <summary>
		/// Binds the attribute.
		/// </summary>
		/// <param name="attribute">Attribute.</param>
		/// <param name="variableName">Variable name.</param>
		protected void bindAttribute (int attribute, string variableName)
		{
			GL.BindAttribLocation (programID, attribute, variableName);
		}

		/// <summary>
		/// Loads the shader.
		/// </summary>
		/// <returns>The shader ID.</returns>
		/// <param name="filename">Filename.</param>
		/// <param name="type">Type of shader.</param>
		private static int loadShader (string filename, ShaderType type)
		{
			string shaderSource = "";
			try {
				shaderSource = File.ReadAllText (@"shaders/" + filename);
			} catch (IOException e) {
				Console.WriteLine (e);
			}
			int shaderID = (int)GL.CreateShader (type);
			GL.ShaderSource ((uint)shaderID, shaderSource);
			GL.CompileShader (shaderID);
			int param;
			GL.GetShader (shaderID, ShaderParameter.CompileStatus, out param);
			if (param == 0) {
				Console.WriteLine (GL.GetShaderInfoLog (shaderID));
				Console.WriteLine ("Could not compile Shader.");
				//Environment.Exit (-1);
			}
			return shaderID;
		}
	}
}

