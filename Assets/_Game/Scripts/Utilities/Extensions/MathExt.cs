using UnityEngine;

namespace Utilities
{
	public static class MathExt
	{
		public static int Square(this int value)
		{
			return value * value;
		}
		public static float Square(this float value)
		{
			return value * value;
		}

		public static float SqrRoot(this int value)
		{
			return Mathf.Sqrt(value);
		}
		public static float SqrRoot(this float value)
		{
			return Mathf.Sqrt(value);
		}

		public static int Power(this int value, int power)
		{
			return (int)Mathf.Pow(value, power);
		}
		public static float Power(this float value, float power)
		{
			return Mathf.Pow(value, power);
		}

		public static int PercentOf(this int value, int max)
		{
			if (max <= 0 || value <= 0)
				return 0;
			if (value >= max)
				return 100;
			return (100 * value / max);
		}
		public static float PercentOf(this float value, float max)
		{
			if (max <= 0 || value <= 0)
				return 0;
			if (value >= max)
				return 100;
			return (100 * value / max);
		}
		/**************************************************/
		public static int ClampMin(this int value, int min)
		{
			if (value <= min)
				return min;
			return value;
		}
		public static int ClampMax(this int value, int max)
		{
			if (value >= max)
				return max;
			return value;
		}
		public static int Clamp(this int value, int min, int max)
		{
			if (value <= min)
				return min;
			if (value >= max)
				return max;
			return value;
		}

		public static float ClampMin(this float value, float min)
		{
			if (value <= min)
				return min;
			return value;
		}
		public static float ClampMax(this float value, float max)
		{
			if (value >= max)
				return max;
			return value;
		}
		public static float Clamp(this float value, float min, float max)
		{
			if (value <= min)
				return min;
			if (value >= max)
				return max;
			return value;
		}
		/**************************************************/
		public static float Sign(this float value)
		{
			return Mathf.Sign(value);
		}
		public static float Sign(this int value)
		{
			return Mathf.Sign(value);
		}

		public static int SignInt(this float value)
		{
			return (int)Mathf.Sign(value);
		}
		public static int SignInt(this int value)
		{
			return (int)Mathf.Sign(value);
		}

		public static int RandomSign(this int value, float negProb = 0.5f)
		{
			return UnityEngine.Random.value < negProb ? -value : value;
		}
		public static float RandomSign(this float value, float negProb = 0.5f)
		{
			return UnityEngine.Random.value < negProb ? -value : value;
		}

		public static bool IsPowerOfTwo(this int value)
		{
			return Mathf.IsPowerOfTwo(value);
		}
		/**************************************************/
		public static float Ceil(this float value)
		{
			return Mathf.Ceil(value);
		}
		public static int CeilToInt(this float value)
		{
			return Mathf.CeilToInt(value);
		}

		public static float Floor(this float value)
		{
			return Mathf.Floor(value);
		}
		public static int FloorToInt(this float value)
		{
			return Mathf.FloorToInt(value);
		}

		public static float Round(this float value)
		{
			return Mathf.Round(value);
		}
		public static int RoundToInt(this float value)
		{
			return Mathf.RoundToInt(value);
		}
		/**************************************************/
		public static int AddVariant(this int value, int variant)
		{
			return value + UnityEngine.Random.Range(-variant, variant + 1);
		}
		public static float AddVariant(this float value, float variant)
		{
			return value + UnityEngine.Random.Range(-variant, variant);
		}

		public static int AddNegativeVariant(this int value, int variant)
		{
			return value + UnityEngine.Random.Range(-variant, 1);
		}
		public static float AddNegativeVariant(this float value, float variant)
		{
			return value + UnityEngine.Random.Range(-variant, 0);
		}

		public static int AddPositiveVariant(this int value, int variant)
		{
			return value + UnityEngine.Random.Range(0, variant + 1);
		}
		public static float AddPositiveVariant(this float value, float variant)
		{
			return value + UnityEngine.Random.Range(0, variant);
		}

		public static float AddVariantInRange(this float value, float min, float max, bool randomSign = false)
		{
			if (randomSign)
				return value + UnityEngine.Random.Range(min, max).RandomSign();
			else
				return value + UnityEngine.Random.Range(min, max);
		}
	}
}

