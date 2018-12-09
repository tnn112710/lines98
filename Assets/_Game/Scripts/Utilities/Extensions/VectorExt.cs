using UnityEngine;

namespace Utilities
{
	public static class VectorExt
	{
		public static Vector2 CreateVector2AngleRad(float angleRad)
		{
			return new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
		}
		public static Vector2 CreateVector2AngleDeg(float angleDeg)
		{
			return CreateVector2AngleRad(angleDeg * Mathf.Deg2Rad);
		}
		public static float GetAngleRad(this Vector2 vector)
		{
			return Mathf.Atan2(vector.y, vector.x);
		}
		public static float GetAngleDeg(this Vector2 vector)
		{
			return vector.GetAngleRad() * Mathf.Rad2Deg;
		}

		public static Vector2 NormalVector(this Vector2 v)
		{
			Vector2 nor = v.normalized;
			return new Vector2(-nor.y, nor.x);
		}

		public static float VectorToDegree(this Vector2 v)
		{
			if (v.x < 0)
				return 360 - (Mathf.Atan2(v.x, v.y) * Mathf.Rad2Deg * -1);
			else
				return Mathf.Atan2(v.x, v.y) * Mathf.Rad2Deg;
		}
		public static float VectorToRadian(this Vector2 v)
		{
			return VectorToDegree(v) * Mathf.Deg2Rad;
		}

		public static Vector2 DegreeToVector2(this float degree)
		{
			return RadianToVector2(degree * Mathf.Deg2Rad);
		}
		public static Vector2 RadianToVector2(this float radian)
		{
			return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
		}

		public static Vector3 ToVector3(this Vector2 v, float newZ = 0)
		{
			return new Vector3(v.x, v.y, newZ);
		}


		public static Vector2 Shift(this Vector2 v, float offsetX, float offsetY)
		{
			return new Vector2(v.x + offsetX, v.y + offsetY);
		}

		public static Vector2 ClampX(this Vector2 v, float min, float max)
		{
			return new Vector2(v.x.Clamp(min, max), v.y);
		}
		public static Vector2 ClampY(this Vector2 v, float min, float max)
		{
			return new Vector2(v.x, v.y.Clamp(min, max));
		}
		public static Vector2 Clamp(this Vector2 v, float minX, float maxX, float minY, float maxY)
		{
			return new Vector2(v.x.Clamp(minX, maxX), v.y.Clamp(minY, maxY));
		}

		public static Vector2 RotateRad(this Vector2 vec, float angleRad)
		{
			Vector2 v = vec;
			var sin = Mathf.Sin(angleRad);
			var cos = Mathf.Cos(angleRad);
			var tx = v.x;
			var ty = v.y;
			v.x = (cos * tx) - (sin * ty);
			v.y = (sin * tx) + (cos * ty);
			return v;
		}
		public static Vector2 RotateDeg(this Vector2 vec, float angleDeg)
		{
			return vec.RotateRad(angleDeg * Mathf.Deg2Rad);
		}
		public static float AngleBetween(this Vector2 vectorA, Vector2 vectorB)
		{
			float angle = Vector2.Angle(vectorA, vectorB);
			Vector3 cross = Vector3.Cross(vectorA, vectorB);
			if (cross.z > 0)
				angle = 360 - angle;
			return angle;
		}
		/***************************************************************************/
		public static Vector2 ToVector2(this Vector3 v)
		{
			return new Vector2(v.x, v.y);
		}
		public static Vector3 ClampX(this Vector3 v, float min, float max)
		{
			return new Vector3(v.x.Clamp(min, max), v.y, v.z);
		}
		public static Vector3 ClampY(this Vector3 v, float min, float max)
		{
			return new Vector3(v.x, v.y.Clamp(min, max), v.z);
		}
		public static Vector3 ClampZ(this Vector3 v, float min, float max)
		{
			return new Vector3(v.x, v.y, v.z.Clamp(min, max));
		}
		public static Vector3 Clamp(this Vector3 v, float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
		{
			return new Vector3(v.x.Clamp(minX, maxX), v.y.Clamp(minY, maxY), v.z.Clamp(minZ, maxZ));
		}
		/***************************************************************************/
		public static float Dot(this Vector2 vector1, Vector2 vector2)
		{
			return vector1.x * vector2.x + vector1.y * vector2.y;
		}
		public static float Dot(this Vector3 vector1, Vector3 vector2)
		{
			return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
		}
	}
}
