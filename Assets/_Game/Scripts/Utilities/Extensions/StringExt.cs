using System;

namespace Utilities
{
	public static class StringExt
	{
		private const string SPACE = " ";
		private const string COLON = ":";
		private const string EMPTY = "";
		private const string ZERO = "";


		public static bool IsNullOrEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}
		public static string Reversed(this string value)
		{
			if (!value.IsNullOrEmpty())
			{
				char[] chars = value.ToCharArray();
				Array.Reverse(chars);
				return new String(chars);
			}
			return value;
		}

		public static string RemoveSpaces(this string value)
		{
			if (!value.IsNullOrEmpty())
			{
				return value.Replace(" ", "");
			}
			return value;
		}
		public static string FirstLetter(this string value, int length = 1)
		{
			if (!value.IsNullOrEmpty())
			{
				return value.Substring(0, length);
			}
			return value;
		}

		public static string UppercaseFirstLetter(this string value)
		{
			if (!value.IsNullOrEmpty())
			{
				char[] array = value.ToCharArray();
				array[0] = char.ToUpper(array[0]);
				return new string(array);
			}
			return value;
		}

		public static int ToInt(this string value)
		{
			if (!value.IsNullOrEmpty())
			{
				int result;
				var valid = int.TryParse(value, out result);
				if (!valid)
					throw new FormatException(string.Format("'{0}' cannot be converted as int", value));
				return result;
			}
			return 0;
		}
	}
}

