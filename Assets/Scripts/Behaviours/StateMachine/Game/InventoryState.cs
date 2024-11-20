using Helpers;
using UI;
using Controllers;

namespace Behaviours
{
    sealed class InventoryState : BaseState<GameStateController>
    {
        private InputController _inputController;
        public InventoryState(GameStateController stateController) : base()
        {
            _inputController = Services.Instance.InputController.ServicesObject;
        }
        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.InventoryScreen);
            Services.Instance.SettingsController.ServicesObject.UnLockedCursor();
        }

        public override void ExitState()
        {

        }

        public override void LogicFixedUpdate()
        {

        }

        public override void LogicUpdate()
        {
            var isInventory = _inputController.InputActions.
                PlayerActionList[InputActionManagerPlayer.INVENTORY].triggered;

            if (isInventory)
            {
                ChangeGameStateEvent.Trigger(GameStateType.GameState);
            }
        }
    }
}
