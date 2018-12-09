using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T : Component
{
	public static T Inst { get; private set; }

	protected virtual void Awake()
	{
		if (Inst == null)
		{
			Inst = this as T;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			if (this != Inst)
				Destroy(this.gameObject);
		}
	}
}

