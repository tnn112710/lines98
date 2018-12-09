using UnityEngine;

namespace Utilities
{
	public static class AudioExt
	{
		public static void PlayOneShot(this AudioClip clip, Vector3 pos)
		{
			if (clip != null)
				AudioSource.PlayClipAtPoint(clip, pos);
		}
		public static void PlayOneShot(this AudioClip clip)
		{
			if (clip != null)
				AudioSource.PlayClipAtPoint(clip, Vector3.zero);
		}
	}
}

