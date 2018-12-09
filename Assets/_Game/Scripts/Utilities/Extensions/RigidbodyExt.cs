using UnityEngine;

namespace Utilities
{
	public static class RigidbodyExt
	{ 
		public static void SetPositionX(this Rigidbody2D rb, float newX)
		{
			rb.position = new Vector2(newX, rb.position.y);
		}
		public static void SetPositionY(this Rigidbody2D rb, float newY)
		{
			rb.position = new Vector2(rb.position.x, newY);
		}

		public static void SetPositionX(this Rigidbody rb, float newX)
		{
			rb.position = new Vector3(newX, rb.position.y, rb.position.z);
		}
		public static void SetPositionY(this Rigidbody rb, float newY)
		{
			rb.position = new Vector3(rb.position.x, newY, rb.position.z);
		}
		public static void SetPositionZ(this Rigidbody rb, float newZ)
		{
			rb.position = new Vector3(rb.position.x, rb.position.y, newZ);
		}
	}
}
