using System;
using klukule.Engine;
using System.Drawing;
using klukule.Wrappers.MathUtils;

namespace klukule.Engine
{
	public class StaticShader : ShaderProgram
	{
		private static string VERTEX_FILE = "testShader.vert";
		private static string FRAGMENT_FILE = "testShader.frag";

		private int location_transformationMatrix;
		private int location_projectionMatrix;
		private int location_viewMatrix;
		private int location_inverseViewMatrix;
		private int location_lightPosition;
		private int location_lightColor;
		private int location_shineDamper;
		private int location_reflectivity;

		public StaticShader () : base (VERTEX_FILE, FRAGMENT_FILE)
		{
				
		}

		protected override void bindAttributes ()
		{
			base.bindAttribute (0, "position");
			base.bindAttribute (1, "textureCoords");
			base.bindAttribute (2, "normals");
		}

		protected override void getAllUniformLocations ()
		{
			location_transformationMatrix = base.getUniformLocation ("transformationMatrix");
			location_projectionMatrix = base.getUniformLocation ("projectionMatrix");
			location_viewMatrix = base.getUniformLocation ("viewMatrix");
			location_inverseViewMatrix = base.getUniformLocation ("inverseViewMatrix");
			location_lightPosition = base.getUniformLocation ("lightPosition");
			location_lightColor = base.getUniformLocation ("lightColor");
			location_shineDamper = base.getUniformLocation ("shineDamper");
			location_reflectivity = base.getUniformLocation ("reflectivity");
		}

		public void loadShineValues (float shineDamper, float reflectivity)
		{
			base.loadFloat (location_shineDamper, shineDamper);
			base.loadFloat (location_reflectivity, reflectivity);
		}

		public void loadTransformationMatrix (Matrix matrix)
		{
			base.loadMatrix (location_transformationMatrix, matrix);
		}

		public void loadLight (Light light)
		{
			base.loadVector (location_lightPosition, light.getPosition ());
			base.loadVector (location_lightColor, light.getColor ());
		}

		public void loadProjectionMatrix (Matrix matrix)
		{
			base.loadMatrix (location_projectionMatrix, matrix);
		}

		public void loadViewMatrix (Camera camera)
		{
			Matrix viewMatrix = Math.createViewMatrix (camera);
			base.loadMatrix (location_viewMatrix, viewMatrix);
			viewMatrix.Invert ();
			base.loadMatrix (location_inverseViewMatrix, viewMatrix);
		}
	}
}

