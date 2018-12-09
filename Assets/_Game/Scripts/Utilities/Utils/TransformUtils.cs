using UnityEngine;

namespace Utilities
{
	public static class TransformUtils 
	{
		public static Vector3 CanvasToWorldPoint(Transform tr)
		{
			Vector3 zero = Vector3.zero;
			Canvas componentInParent = tr.GetComponentInParent<Canvas>();
			bool flag = componentInParent == null;
			Vector3 result;
			if (flag)
			{
				result = Vector3.zero;
			}
			else
			{
				RectTransform component = componentInParent.GetComponent<RectTransform>();
				Vector2 vector = RectTransformUtility.PixelAdjustPoint(tr.position, tr, componentInParent);
				RectTransformUtility.ScreenPointToWorldPointInRectangle(component, vector, Camera.main, out zero);
				result = zero;
			}
			return result;
		}
	}
}
