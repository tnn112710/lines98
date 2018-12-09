
namespace Utilities
{
	public static class Debugger
	{ 
		public static void Log(object message)
		{
#if ENABLE_LOGGING
			UnityEngine.Debug.Log(message);
#endif
		}
		public static void LogError(object message)
		{
#if ENABLE_LOGGING
			UnityEngine.Debug.LogError(message);
#endif
		}
		public static void LogWarning(object message)
		{
#if ENABLE_LOGGING
			UnityEngine.Debug.LogWarning(message);
#endif
		}
		public static void LogAssertion(object message)
		{
#if ENABLE_LOGGING
			UnityEngine.Debug.LogAssertion(message);
#endif
		}
	}
}

