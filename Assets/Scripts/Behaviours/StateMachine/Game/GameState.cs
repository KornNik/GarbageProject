using Behaviours.Units;
using Cinemachine;
using Controllers;
using Helpers;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState<GameStateController>
    {
        private InputController _inputController;
        private CinemachineVirtualCamera _camera;

        public GameState(GameStateController stateController) : base()
        {
            _inputController = Services.Instance.InputController.ServicesObject;
            _camera = Services.Instance.CameraService.ServicesObject.GetComponent<CinemachineVirtualCamera>();
        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            Services.Instance.SettingsController.ServicesObject.LockedCursor();
            SetCamera();
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
                ChangeGameStateEvent.Trigger(GameStateType.InventoryState);
            }
        }

        private void SetCamera()
        {
            var cameraObject = (Services.Instance.PlayerGameObject.Controller.Model as PlayerModel).HeadTransform;
            _camera.Follow = cameraObject;
        }
    }
}
