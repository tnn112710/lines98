using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
	public static class LayerExt
	{
		public static bool ContainsLayer(this LayerMask mask, int layer)
		{
			return (mask.value & (1 << layer)) != 0;
		}

		public static List<int> GetLayers(this LayerMask layerMask)
		{
			var layers = new List<int>();
			for (int mask = layerMask.value, layer = 0; mask != 0; mask = mask >> 1, layer++)
			{
				if ((mask & 1) != 0)
					layers.Add(layer);
			}
			return layers;
		}
	}
}
