namespace Behaviours
{
    sealed class ExitGameState : GameState
    {
        public ExitGameState(GameStateController stateController) : base(stateController)
        {
        }

        public override void EnterState()
        {
            DeletLevel();
            ChangeGameStateEvent.Trigger(GameStateType.ManuState);
        }

        public override void ExitState()
        {

        }

        public override void LogicFixedUpdate()
        {
        }

        public override void LogicUpdate()
        {
        }
    }
}
