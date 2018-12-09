using UnityEngine;

namespace Utilities
{
	public class DelayUtils
	{
		public static class Scaled
		{
			public static readonly WaitForSeconds WAIT_ONE_TENTH_SEC = new WaitForSeconds(0.1f); 
			public static readonly WaitForSeconds WAIT_ONE_FIFTH_SEC = new WaitForSeconds(0.2f); 
			public static readonly WaitForSeconds WAIT_ONE_FOURTH_SEC = new WaitForSeconds(0.25f); 
			public static readonly WaitForSeconds WAIT_ONE_THIRD_SEC = new WaitForSeconds(0.3333f); 
			public static readonly WaitForSeconds WAIT_HALF_SEC = new WaitForSeconds(0.5f); 
			public static readonly WaitForSeconds WAIT_A_SEC = new WaitForSeconds(1f); 
			public static readonly WaitForSeconds WAIT_TWO_SEC = new WaitForSeconds(2f); 
			public static readonly WaitForSeconds WAIT_THREE_SEC = new WaitForSeconds(3f); 
			public static readonly WaitForSeconds WAIT_FOUR_SEC = new WaitForSeconds(4f);
			public static readonly WaitForSeconds WAIT_FIVE_SEC = new WaitForSeconds(5f); 
			public static readonly WaitForSeconds WAIT_TEN_SEC = new WaitForSeconds(10f); 
	
		}

		public static class UnScaled
		{
			public static readonly WaitForSecondsRealtime WAIT_ONE_TENTH_SEC = new WaitForSecondsRealtime(0.1f); 
			public static readonly WaitForSecondsRealtime WAIT_ONE_FIFTH_SEC = new WaitForSecondsRealtime(0.2f); 
			public static readonly WaitForSecondsRealtime WAIT_ONE_FOURTH_SEC = new WaitForSecondsRealtime(0.25f); 
			public static readonly WaitForSecondsRealtime WAIT_ONE_THIRD_SEC = new WaitForSecondsRealtime(0.3333f); 
			public static readonly WaitForSecondsRealtime WAIT_HALF_SEC = new WaitForSecondsRealtime(0.5f); 
			public static readonly WaitForSecondsRealtime WAIT_A_SEC = new WaitForSecondsRealtime(1f); 
			public static readonly WaitForSecondsRealtime WAIT_TWO_SEC = new WaitForSecondsRealtime(2f); 
			public static readonly WaitForSecondsRealtime WAIT_THREE_SEC = new WaitForSecondsRealtime(3f); 
			public static readonly WaitForSecondsRealtime WAIT_FOUR_SEC = new WaitForSecondsRealtime(4f); 
			public static readonly WaitForSecondsRealtime WAIT_FIVE_SEC = new WaitForSecondsRealtime(5f); 
			public static readonly WaitForSecondsRealtime WAIT_TEN_SEC = new WaitForSecondsRealtime(10f); 
		}
	
		public static readonly WaitForEndOfFrame WAIT_END_OF_FRAME = new WaitForEndOfFrame(); 
		public static readonly WaitForFixedUpdate WAIT_FIXED_UPDATE = new WaitForFixedUpdate(); 
	
		/**************************************************/
	}
}
