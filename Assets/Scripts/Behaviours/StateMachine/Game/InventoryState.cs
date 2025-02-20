using Helpers;
using UI;
using Controllers;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Behaviours
{
    sealed class InventoryState : BaseState<GameStateController>
    {
        private InputController _inputController;
        private CinemachineInputProvider _cameraInputs;

        private InputActionReference _defaultInputAction;

        public InventoryState(GameStateController stateController) : base()
        {
            _inputController = Services.Instance.InputController.ServicesObject;
            _cameraInputs = Services.Instance.CameraService.ServicesObject.GetComponent<CinemachineInputProvider>();
            _defaultInputAction = _cameraInputs.XYAxis;
        }
        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.InventoryScreen);
            Services.Instance.SettingsController.ServicesObject.UnLockedCursor();
            DisableCameraInputs();
        }

        public override void ExitState()
        {
            EnableCameraInputs();
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

        private void DisableCameraInputs()
        {
            _cameraInputs.XYAxis.action.Disable();
        }
        private void EnableCameraInputs()
        {
            _cameraInputs.XYAxis.action.Enable();
        }
    }
}
