namespace Helpers
{
    static class EventRegister
    {
		public delegate void Delegate<T>(T eventType);

		public static void EventStartListening<TEventType>(this IEventListener<TEventType> caller) where TEventType : struct
		{
			EventManager.AddListener(caller);
		}

		public static void EventStopListening<TEventType>(this IEventListener<TEventType> caller) where TEventType : struct
		{
			EventManager.RemoveListener(caller);
		}
	}
}
