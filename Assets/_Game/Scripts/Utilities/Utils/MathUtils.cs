using UnityEngine;

namespace Utilities
{
	public static class MathUtils
	{
		public static float AngleBetween(Vector2 vectorA, Vector2 vectorB)
		{
			float angle = Vector2.Angle(vectorA, vectorB);
			Vector3 cross = Vector3.Cross(vectorA, vectorB);
			if (cross.z > 0)
				angle = 360 - angle;
			return angle;
		}
		
		public static float Map01(float value, float min, float max)
		{
			return (value - min) * 1f / (max - min);
		}
		public static float MapRangeFloat(this float value, float from1, float to1, float from2, float to2)
		{
			return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
		}
		public static int MapRangeInt(this int value, int from1, int to1, int from2, int to2)
		{
			return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
		}
	}
}
