using System;
using UnityEngine;

namespace Utilities
{
	public static class InvokeExt 
	{
		public static void Invoke(this MonoBehaviour mb, Action action, float delayTime)
		{
			mb.Invoke(action.Method.Name, delayTime);
		}

		public static void InvokeRepeating(this MonoBehaviour mb, Action action, float delayTime, float repeatInterval)
		{
			mb.InvokeRepeating(action.Method.Name, delayTime, repeatInterval);
		}

		public static void CancelInvoke(this MonoBehaviour mb, Action action)
		{
			mb.CancelInvoke(action.Method.Name);
		}

		public static bool IsInvoking(this MonoBehaviour mb, Action action)
		{
			return mb.IsInvoking(action.Method.Name);
		}
	}
}
	
