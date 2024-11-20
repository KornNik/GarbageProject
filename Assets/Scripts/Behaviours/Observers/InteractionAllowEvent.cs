namespace Helpers
{
    struct InteractionAllowEvent
    {
        private static InteractionAllowEvent _interactionEvent;

        public static void Trigger()
        {
            EventManager.TriggerEvent(_interactionEvent);
        }
    }
}
