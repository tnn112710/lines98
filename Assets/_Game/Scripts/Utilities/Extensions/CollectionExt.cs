using System.Collections.Generic;
using System.Linq;

namespace Utilities
{
	public static class CollectionExt
	{
		public static void Resize<T>(this List<T> list, int size, T element)
		{
			int count = list.Count;

			if (size < count)
			{
				list.RemoveRange(size, count - size);
			}
			else if (size > count)
			{
				if (size > list.Capacity) 
					list.Capacity = size;

				list.AddRange(Enumerable.Repeat(element, size - count));
			}
		}
		public static void Resize<T>(this List<T> list, int size)
		{
			int count = list.Count;

			if (size < count)
			{
				list.RemoveRange(size, count - size);
			}
			else if (size > count)
			{
				T element = list.Last();
				if (size > list.Capacity) 
					list.Capacity = size;

				list.AddRange(Enumerable.Repeat(element, size - count));
			}
		}

		public static void ResizeIfMore<T>(this List<T> list, int size)
		{
			int count = list.Count;

			if (size < count)
			{
				return;
			}
			else if (size > count)
			{
				T element = list.Last();
				if (size > list.Capacity) 
					list.Capacity = size;

				list.AddRange(Enumerable.Repeat(element, size - count));
			}
		}

		public static void Shuffle<T>(this IList<T> list)
		{
			if (list.Count == 0 || list == null)
				return;

			System.Random rand = new System.Random();
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = rand.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}

		public static T RandomItem<T>(this T[] array)
		{
			if (array.Length == 0 || array == null)
				return default(T);
			return array[UnityEngine.Random.Range(0, array.Length)];
		}

		public static T RandomItem<T>(this IList<T> list)
		{
			if (list.Count == 0 || list == null)
				return default(T);
			return list[UnityEngine.Random.Range(0, list.Count)];
		}

		public static T RemoveRandom<T>(this IList<T> list)
		{
			if (list.Count == 0 || list == null)
				return default(T);
			int index = UnityEngine.Random.Range(0, list.Count);
			T item = list[index];
			list.RemoveAt(index);
			return item;
		}

		public static bool IsEmpty<T>(this ICollection<T> collection)
		{
			return collection.Count == 0;
		}

		public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
		{
			return collection.Count == 0 || collection == null;
		}

		public static void Merge<T>(this List<T> current, List<T> another)
		{
			if (current == null || another == null || another.Count == 0)
				return;
			for (int i = 0; i < another.Count; i++)
				current.Add(another[i]);
		}
		public static void Merge<K, V>(this Dictionary<K, V> current, Dictionary<K, V> another, bool updateDuplicate = true)
		{
			if (current == null || another == null || another.Count == 0)
				return;
			foreach (var item in another)
			{
				if (!current.ContainsKey(item.Key))
					current.Add(item.Key, item.Value);
				else if (updateDuplicate)
					current[item.Key] = item.Value;
			}
		}
		public static T First<T>(this List<T> list)
		{
			if (list.Count == 0 || list == null)
				return default(T);
			return list[0];
		}
		public static T Last<T>(this List<T> list)
		{
			if (list.Count == 0 || list == null)
				return default(T);
			return list[list.Count - 1];
		}

		public static T First<T>(this T[] list)
		{
			if (list.Length == 0 || list == null)
				return default(T);
			return list[0];
		}
		public static T Last<T>(this T[] list)
		{
			if (list.Length == 0 || list == null)
				return default(T);
			return list[list.Length - 1];
		}

		public static T GetRollableElement<T>(this List<T> list, int index)
		{
			if (list.Count == 0 || list == null)
				return default(T);
			return list[index % list.Count];
		}

		public static T GetRollableElement<T>(this T[] list, int index)
		{
			if (list.Length == 0 || list == null)
				return default(T);
			return list[index % list.Length];
		}


		public static void Init<T>(this List<T> list)
		{
			list = new List<T>();
		}
		public static void Init<K, V>(this Dictionary<K, V> dict)
		{
			dict = new Dictionary<K, V>();
		}

		public static void Print<T>(this List<T> list, bool lineBreak = false)
		{
			if (list == null || list.Count == 0)
				return;
			if (!lineBreak)
			{
				string message = "List<" + typeof(T).ToString() + ">: ";
				for (int i = 0; i < list.Count; i++)
					message += list[i].ToString() + ", ";
				UnityEngine.Debug.Log(message);
			}
			else
			{
				UnityEngine.Debug.Log("List<" + typeof(T).ToString() + ">: ");
				for (int i = 0; i < list.Count; i++)
					UnityEngine.Debug.Log(list[i]);
				UnityEngine.Debug.Log("End list!");
			}
		}
		public static void Print<K, V>(this Dictionary<K, V> dict, bool lineBreak = false)
		{
			if (dict == null || dict.Count == 0)
				return;
			if (!lineBreak)
			{
				string message = "Dictionary<" + typeof(K).ToString() + "," + typeof(V).ToString() + ">: ";
				foreach (var item in dict)
					message += item.Key.ToString() + ": " + item.Value.ToString() + ";  ";
				UnityEngine.Debug.Log(message);
			}
			else
			{
				UnityEngine.Debug.Log("Dictionary<" + typeof(K).ToString() + "," + typeof(V).ToString() + ">: ");
				foreach (var item in dict)
					UnityEngine.Debug.Log(item.Key.ToString() + ": " + item.Value.ToString());
				UnityEngine.Debug.Log("End dictionary!");

			}
		}
	}
}

