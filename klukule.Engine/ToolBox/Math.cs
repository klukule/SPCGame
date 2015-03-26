using System;
using klukule.Wrappers.MathUtils;
using klukule.Wrappers.Graphics;
using klukule.Wrappers;

namespace klukule.Engine
{
	public class Math
	{
		/// <summary>
		/// Creates the transformation matrix.
		/// </summary>
		/// <returns>The transformation matrix.</returns>
		/// <param name="translation">Translation.</param>
		/// <param name="rx">Rotation x.</param>
		/// <param name="ry">Rotation y.</param>
		/// <param name="rz">Rotation z.</param>
		/// <param name="scale">Scale.</param>
		public static Matrix createTransformationMatrix (Vector3 translation, float rx, float ry, float rz, float scale)
		{
			Matrix matrix = (

			                    Matrix.CreateRotationX (ConvertToRadians (rx)) *
			                    Matrix.CreateRotationY (ConvertToRadians (ry)) *
			                    Matrix.CreateRotationZ (ConvertToRadians (rz)) *
			                    Matrix.CreateTranslation (translation) *
			                    Matrix.CreateScale (scale)
			                );
			return matrix;
		}

		/// <summary>
		/// Creates the projection matrix.
		/// </summary>
		/// <returns>The projection matrix.</returns>
		/// <param name="fov">Fov.</param>
		/// <param name="window_width">Window width.</param>
		/// <param name="window_height">Window height.</param>
		/// <param name="near_plane">Near plane.</param>
		/// <param name="far_plane">Far plane.</param>
		public static Matrix createProjectionMatrix (float fov, int window_width, int window_height, float near_plane, float far_plane)
		{
			return Matrix.CreatePerspectiveFieldOfView (ConvertToRadians (fov), (float)window_width / window_height, near_plane, far_plane);
		}

		/// <summary>
		/// Creates the view matrix.
		/// </summary>
		/// <returns>The view matrix.</returns>
		/// <param name="camera">Camera.</param>
		public static Matrix createViewMatrix (Camera camera)
		{
			Vector3 negativeCameraPos = -camera.getPosition ();
			//Matrix viewMatrix = Matrix.LookAt (negativeCameraPos, negativeCameraPos, new Vector3 (0, 1, 0));
			Matrix viewMatrix = 
				Matrix.CreateRotationX (ConvertToRadians (camera.getPitch ())) *
				Matrix.CreateRotationY (ConvertToRadians (camera.getYaw ())) *
				Matrix.CreateTranslation (negativeCameraPos.X, negativeCameraPos.Y, negativeCameraPos.Z);
			return viewMatrix;
		}

		/// <summary>
		/// Converts to radians.
		/// </summary>
		/// <returns>Radians.</returns>
		/// <param name="angle">Angle.</param>
		public static float ConvertToRadians (float angle)
		{
			return (float)((System.Math.PI / 180) * angle);
		}
	}
}

