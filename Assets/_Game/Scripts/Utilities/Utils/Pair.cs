using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
	[Serializable]
	public struct MinMaxInt
	{
		[SerializeField] int min;
		[SerializeField] int max;

		public MinMaxInt(int min = 0, int max = 1)
		{
			this.min = min;
			this.max = max;
			if (max < min) max = min;
		}
		public int Min
		{
			get { return min; }
			set { min = value; }
		}
		public int Max
		{
			get { return max; }
			set {
				max = value;
				if (max < min) max = min;
			}
		}
		public int Clamp(int v)
		{
			return Mathf.Clamp(v, min, max);
		}
		public float Rnd
		{ 
			get { return UnityEngine.Random.Range(Min, Max + 1);}
		}
		public float Mid
		{ 
			get { return (Min + Max) / 2;}
		}

	}

	[Serializable]
	public struct MinMaxFloat
	{
		[SerializeField] float min;
		[SerializeField] float max;

		public MinMaxFloat(float min = 0f, float max = 1.0f)
		{
			this.min = min;
			this.max = max;
			if (max < min) max = min;
		}
		public float Min
		{
			get { return min; }
			set { min = value; }
		}
		public float Max
		{
			get { return max; }
			set
			{
				max = value;
				if (max < min) max = min;
			}
		}
		public float Clamp(float v)
		{
			return Mathf.Clamp(v, min, max);
		}
		public float Rnd
		{ 
			get { return UnityEngine.Random.Range(Min, Max);}
		}
		public float Mid
		{ 
			get { return (Min + Max) / 2;}
		}
	}
}