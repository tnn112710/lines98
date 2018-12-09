using UnityEngine;

namespace Utilities
{
	public static class ColorExt
	{
		public static Color32 SetRed(this Color32 color, byte newRed)
		{
			return new Color32(newRed, color.g, color.b, color.a);
		}
		public static Color32 SetGreen(this Color32 color, byte newGreen)
		{
			return new Color32(color.r, newGreen, color.b, color.a);
		}
		public static Color32 SetBlue(this Color32 color, byte newBlue)
		{
			return new Color32(color.r, color.g, newBlue, color.a);
		}
		public static Color32 SetAlpha(this Color32 color, byte newAlpha)
		{
			return new Color32(color.r, color.g, color.b, newAlpha);
		}
		public static Color32 SetRBG(this Color32 color, byte newRed, byte newGreen, byte newBlue)
		{
			return new Color32(newRed, newGreen, newBlue, color.a);
		}

		public static Color32 Inverse(this Color32 color)
		{
			return new Color32((byte)(255 - color.r), (byte)(255 - color.g), (byte)(255 - color.b), (byte)(255 - color.a));
		}
	}
}

