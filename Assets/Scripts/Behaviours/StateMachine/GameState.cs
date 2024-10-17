using Behaviours.Units;
using Cinemachine;
using Controllers;
using Helpers;
using UI;
using UnityEngine;

namespace Behaviours
{
    sealed class GameState : BaseState<GameStateController>
    {
        PlayerLoader _playerLoader;
        LevelLoader _levelLoader;
        CinemachineVirtualCamera _camera;

        public GameState(GameStateController stateController) : base()
        {
            _playerLoader = Services.Instance.PlayerLoader.ServicesObject;
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
            _camera = Services.Instance.CameraService.ServicesObject.GetComponent<CinemachineVirtualCamera>();
        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            LoadPlayerBehaviours();
            LoadLevelBehaviours();
            Cursor.lockState = CursorLockMode.Locked;
        }

        public override void ExitState()
        {
            _playerLoader.DeletePlayer();
            _levelLoader.ClearLevelFull();
            Cursor.lockState = CursorLockMode.None;
        }

        public override void LogicFixedUpdate()
        {
        }

        public override void LogicUpdate()
        {
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
    }
}
