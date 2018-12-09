using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : Component
{
	private static T inst;
	public static T Inst
	{ 
		get
		{
			if ( inst == null )
			{
				inst = FindObjectOfType<T> ();
				if (inst == null)
					Debug.LogError("Cannot find " + typeof(T).Name);
			}
			return inst;
		}
	}
}