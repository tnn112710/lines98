using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
	public static class GameObjectExt
	{
		public static bool IsNull(this UnityEngine.Object obj)
		{
			return obj == null;
		}
		public static bool IsNull(this System.Object obj)
		{
			return obj == null;
		}

		public static T GetComponentInParents<T>(this GameObject gameObject) where T : Component
		{
			if (gameObject == null)
				return null;
			for (Transform t = gameObject.transform; t != null; t = t.parent)
			{
				T result = t.GetComponent<T>();
				if (result != null)
					return result;
			}
			return null;
		}
		public static T[] GetComponentsInParents<T>(this GameObject gameObject) where T : Component
		{
			if (gameObject == null)
				return null;
			List<T> results = new List<T>();
			for (Transform t = gameObject.transform; t != null; t = t.parent)
			{
				T result = t.GetComponent<T>();
				if (result != null)
					results.Add(result);
			}
			return results.ToArray();
		}
		public static GameObject FindChildInChildRecursively(this Transform trans, string name)
		{
			Transform temp = trans.Find("name");
			if (temp != null)
				return temp.gameObject;
			else
			{
				foreach (Transform child in trans)
					child.FindChildInChildRecursively(name);
			}
			return null;
		}

		public static void AddChild(this GameObject obj, Transform child)
		{
			if (child == null || child == obj)
				return;
			child.parent = obj.transform;
		}
		public static void AddChild(this GameObject obj, GameObject child)
		{
			if (child == null || child == obj)
				return;
			child.transform.parent = obj.transform;
		}

		public static void DetachChild(this GameObject obj, string name)
		{
			Transform child = obj.transform.Find(name);
			if (child != null && child != obj)
				child.parent = null;
		}
		public static void DetachParent(this GameObject obj)
		{
			obj.transform.parent = null;
		}

		public static void Destroy(this GameObject obj)
		{
			Destroy(obj);
		}
		public static void Activate(this GameObject obj)
		{
			obj.SetActive(true);
		}
		public static void Deactivate(this GameObject obj)
		{
			obj.SetActive(false);
		}

		public static void ActivateChildren(this GameObject obj)
		{
			if (obj.transform.childCount == 0)
				return;
			foreach (Transform child in obj.transform)
				child.gameObject.SetActive(true);
		}
		public static void DeactivateChildren(this GameObject obj)
		{
			if (obj.transform.childCount == 0)
				return;
			foreach (Transform child in obj.transform)
				child.gameObject.SetActive(false);
		}

		public static void ActivateChild(this GameObject obj, string childName)
		{
			if (obj.transform.childCount == 0 || string.IsNullOrEmpty(childName))
				return;
			Transform child = obj.transform.Find(childName);
			if (child != null)
			{
				child.gameObject.SetActive(true);
			}
		}
		public static void DeactivateChild(this GameObject obj, string childName)
		{
			if (obj.transform.childCount == 0 || string.IsNullOrEmpty(childName))
				return;
			Transform child = obj.transform.Find(childName);
			if (child != null)
			{
				child.gameObject.SetActive(false);
			}
		}

		public static void StripCloneFromName(this GameObject gameObject)
		{
			gameObject.name = gameObject.GetNameWithoutClone();
		}

		public static string GetNameWithoutClone(this GameObject gameObject)
		{
			var gameObjectName = gameObject.name;

			var clonePartIndex = gameObjectName.IndexOf("(Clone)", StringComparison.Ordinal);
			if (clonePartIndex == -1)
				return gameObjectName;

			return gameObjectName.Substring(0, clonePartIndex);
		}
	}
}

