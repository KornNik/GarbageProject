using Behaviours.Units;
using Cinemachine;
using Controllers;
using Helpers;
using UI;
using UnityEngine;

namespace Behaviours
{
    class GameState : BaseState<GameStateController>
    {
        private PlayerLoader _playerLoader;
        private LevelLoader _levelLoader;
        private CinemachineVirtualCamera _camera;
        private InputController _inputController;

        public GameState(GameStateController stateController) : base()
        {
            _playerLoader = Services.Instance.PlayerLoader.ServicesObject;
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
            _inputController = Services.Instance.InputController.ServicesObject;
            _camera = Services.Instance.CameraService.ServicesObject.GetComponent<CinemachineVirtualCamera>();
        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            LoadPlayerBehaviours();
            LoadLevelBehaviours();
            Services.Instance.SettingsController.ServicesObject.LockedCursor();
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
        private void LoadPlayerBehaviours()
        {
            _playerLoader.LoadPlayerClean();
            var cameraObject = (Services.Instance.PlayerGameObject.Controller.Model as PlayerModel).HeadTransform;
            _camera.Follow = cameraObject;
        }
        private void LoadLevelBehaviours()
        {
            _levelLoader.LoadLevelGame(0);
        }
        protected void DeletLevel()
        {
            _playerLoader.DeletePlayer();
            _levelLoader.ClearLevelFull();
            _camera.Follow = null;
        }
    }
}
