using Helpers;

namespace Behaviours
{
    enum EndGameType
    {
        None,
        Winning,
        Defeated
    }
    struct EndGameEvent
    {
        private static EndGameEvent _endGameEvent;

        private EndGameType _endGameType;

        public EndGameType EndGameType => _endGameType;

        public static void Trigger(EndGameType endGameType)
        {
            _endGameEvent._endGameType = endGameType;
            EventManager.TriggerEvent(_endGameEvent);
        }
    }
}
