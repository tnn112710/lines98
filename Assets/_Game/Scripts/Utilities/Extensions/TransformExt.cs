using UnityEngine;

namespace Utilities
{
	public static class TransformExt
	{
		public static void SetPositionX(this Transform trans, float newX)
		{
			trans.position = new Vector3(newX, trans.position.y, trans.position.z);
		}
		public static void SetPositionY(this Transform trans, float newY)
		{
			trans.position = new Vector3(trans.position.x, newY, trans.position.z);
		}
		public static void SetPositionZ(this Transform trans, float newZ)
		{
			trans.position = new Vector3(trans.position.x, trans.position.y, newZ);
		}
		public static void SetPosition(this Transform trans, float newX, float newY, float newZ)
		{
			trans.position = new Vector3(newX, newY, newZ);
		}

		public static void TranslateX(this Transform trans, float offsetX, bool useDeltaTime = false)
		{
			trans.Translate(offsetX, 0f, 0f, useDeltaTime);
		}
		public static void TranslateY(this Transform trans, float offsetY, bool useDeltaTime = false)
		{
			trans.Translate(0f, offsetY, 0f, useDeltaTime);
		}
		public static void TranslateZ(this Transform trans, float offsetZ, bool useDeltaTime = false)
		{
			trans.Translate(0f, 0f, offsetZ, useDeltaTime);
		}
		public static void Translate(this Transform trans, float offsetX, float offsetY, float offsetZ, bool useDeltaTime = false)
		{
			if (!useDeltaTime)
				trans.position = new Vector3(trans.position.x + offsetX, trans.position.y + offsetY, trans.position.z + offsetZ);
			else
				trans.position = new Vector3(
					trans.position.x + offsetX * Time.deltaTime,
					trans.position.y + offsetY * Time.deltaTime,
					trans.position.z + offsetZ * Time.deltaTime);
		}

		public static void Rotating(this Transform trans, float rateX, float rateY, float rateZ, bool useDeltaTime = false)
		{
			if (!useDeltaTime)
				trans.Rotate(rateX, rateY, rateZ);
			else
				trans.Rotate(rateX * Time.deltaTime, rateY * Time.deltaTime, rateZ * Time.deltaTime);
		}
		public static void RotatingX(this Transform trans, float rate, bool useDeltaTime = false)
		{
			trans.Rotating(rate, 0f, 0f, useDeltaTime);
		}
		public static void RotatingY(this Transform trans, float rate, bool useDeltaTime = false)
		{
			trans.Rotating(0f, rate, 0f, useDeltaTime);
		}
		public static void RotatingZ(this Transform trans, float rate, bool useDeltaTime = false)
		{
			trans.Rotating(0f, 0f, rate, useDeltaTime);
		}

		public static void SetLocalRotationX(this Transform trans, float angle)
		{
			trans.localRotation = Quaternion.Euler(new Vector3(angle, 0, 0));
		}
		public static void SetLocalRotationY(this Transform trans, float angle)
		{
			trans.localRotation = Quaternion.Euler(new Vector3(0, angle, 0));
		}
		public static void SetLocalRotationZ(this Transform trans, float angle)
		{
			trans.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
		}
		public static void SetLocalRotation(this Transform trans, float x, float y, float z)
		{
			trans.localRotation = Quaternion.Euler(new Vector3(x, y, z));
		}

		public static void SetRotationX(this Transform trans, float angle)
		{
			trans.rotation = Quaternion.Euler(new Vector3(angle, 0, 0));
		}
		public static void SetRotationY(this Transform trans, float angle)
		{
			trans.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
		}
		public static void SetRotationZ(this Transform trans, float angle)
		{
			trans.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		}
		public static void SetRotation(this Transform trans, float x, float y, float z)
		{
			trans.rotation = Quaternion.Euler(new Vector3(x, y, z));
		}

		public static void SetScaleX(this Transform trans, float newScale)
		{
			trans.SetScale(newScale, trans.localScale.y, trans.localScale.z);
		}
		public static void SetScaleY(this Transform trans, float newScale)
		{
			trans.SetScale(trans.localScale.x, newScale, trans.localScale.z);
		}
		public static void SetScaleZ(this Transform trans, float newScale)
		{
			trans.SetScale(trans.localScale.x, trans.localScale.y, newScale);
		}
		public static void SetScale(this Transform trans, float x, float y, float z)
		{
			trans.localScale = new Vector3(x, y, z);
		}

		public static void ScaleByX(this Transform trans, float value)
		{
			trans.ScaleBy(value, 1, 1);
		}
		public static void ScaleByY(this Transform trans, float value)
		{
			trans.ScaleBy(1, value, 1);
		}
		public static void ScaleByZ(this Transform trans, float value)
		{
			trans.ScaleBy(1, 1, value);
		}
		public static void ScaleBy(this Transform trans, float x, float y, float z)
		{
			trans.localScale = new Vector3(trans.localScale.x * x, trans.localScale.y * y, trans.localScale.z * z);
		}

		public static void ResetLocalPosition(this Transform trans)
		{
			if (trans.parent != null)
				trans.localPosition = Vector3.zero;
			else
				trans.position = Vector3.zero;
		}
		public static void ResetPosition(this Transform trans)
		{
			trans.localPosition = Vector3.zero;
		}

		public static void ResetScale(this Transform trans)
		{
			trans.localScale = Vector3.one;
		}

		public static void ResetRotation(this Transform trans)
		{
			trans.rotation = Quaternion.identity;
		}
		public static void ResetLocalRotation(this Transform trans)
		{
			trans.localRotation = Quaternion.identity;
		}

		public static void Reset(this Transform trans, bool position = true, bool rotation = true, bool scale = true)
		{
			if (position)
				trans.ResetPosition();
			if (rotation)
				trans.ResetRotation();
			if (scale)
				trans.ResetScale();
		}
		public static void ResetLocal(this Transform trans, bool position = true, bool rotation = true, bool scale = true)
		{
			if (position)
				trans.ResetLocalPosition();
			if (rotation)
				trans.ResetLocalRotation();
			if (scale)
				trans.ResetScale();
		}

		public static void AddChild(this Transform trans, Transform child)
		{
			if (child == null || child == trans)
				return;
			child.parent = trans;
		}
		public static void AddChild(this Transform trans, GameObject child)
		{
			if (child == null || child == trans)
				return;
			child.transform.parent = trans;
		}

		public static void DetachChild(this Transform trans, string name)
		{
			Transform child = trans.Find(name);
			if (child != null && child != trans)
				child.parent = null;
		}
		public static void DetachParent(this Transform trans)
		{
			trans.parent = null;
		}

		public static void DestroyChildren(this Transform trans)
		{
			if (trans.childCount == 0)
				return;
			foreach (Transform child in trans)
			{
				GameObject.Destroy(trans.gameObject);
			}
		}

		public static void ActivateChildren(this Transform trans)
		{
			if (trans.childCount == 0)
				return;
			foreach (Transform child in trans)
				child.gameObject.SetActive(true);
		}
		public static void DeactivateChildren(this Transform trans)
		{
			if (trans.childCount == 0)
				return;
			foreach (Transform child in trans)
				child.gameObject.SetActive(false);
		}

		public static void ActivateChild(this Transform trans, string childName)
		{
			if (trans.childCount == 0 || string.IsNullOrEmpty(childName))
				return;
			Transform child = trans.Find(childName);
			if (child != null)
			{
				child.gameObject.SetActive(true);
			}
		}
		public static void DeactivateChild(this Transform trans, string childName)
		{
			if (trans.childCount == 0 || string.IsNullOrEmpty(childName))
				return;
			Transform child = trans.Find(childName);
			if (child != null)
			{
				child.gameObject.SetActive(false);
			}
		}
	}
}
