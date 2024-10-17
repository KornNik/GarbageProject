using Helpers;
using UI;

namespace Behaviours
{
    internal class MenuState : BaseState<GameStateController>
    {
        public MenuState(GameStateController stateController) : base()
        {

        }
        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.MainMenu);
        }

        public override void ExitState()
        {
        }

        public override void LogicFixedUpdate()
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }
    }
}