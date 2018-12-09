using UnityEngine;

namespace Utilities
{
	public static class RandomUtils
	{
		public static bool Chance(int percent)
		{
			return Random.Range(0, 100) <= percent;
		}
		public static float RandomDegree()
		{
			return Random.Range(0f, 360f);
		}
		public static int RandomSign(float negProb = 0.5f)
		{
			return UnityEngine.Random.value < negProb ? -1 : 1;
		}
		public static bool RandomBool(float falseProb = 0.5f)
		{
			return UnityEngine.Random.value < falseProb ? false : true;
		}
		public static int RandomTwoRanges(int min1, int max1, int min2, int max2)
		{
			return RandomBool() ? Random.Range(min1, max1 + 1) : Random.Range(min2, max2 + 1);
		}
		public static Vector2 RandomVector2(Vector2 min, Vector2 max)
		{
			return new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
		}
		public static Vector3 RandomVector3(Vector3 min, Vector3 max)
		{
			return new Vector3(Random.Range(min.x, max.x), Random.Range(min.y, max.y), Random.Range(min.z, max.z));
		}
		public static Vector2 RandomVector2(float minX, float maxX, float minY, float maxY)
		{
			return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
		}
		public static Vector3 RandomVector3(float minX, float maxX, float minY, float maxY, float minZ, float maxZ)
		{
			return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
		}
	}
}

