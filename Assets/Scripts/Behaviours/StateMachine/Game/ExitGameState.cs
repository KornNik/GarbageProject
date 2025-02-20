using Cinemachine;
using Controllers;
using Helpers;

namespace Behaviours
{
    sealed class ExitGameState : BaseState<GameStateController>
    {
        private PlayerLoader _playerLoader;
        private LevelLoader _levelLoader;
        private CinemachineVirtualCamera _camera;
        public ExitGameState(GameStateController stateController) : base()
        {
            _playerLoader = Services.Instance.PlayerLoader.ServicesObject;
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
            _camera = Services.Instance.CameraService.ServicesObject.GetComponent<CinemachineVirtualCamera>();
        }

        public override void EnterState()
        {
            DeletLevel();
            ChangeGameStateEvent.Trigger(GameStateType.ManuState);
        }

        public override void ExitState()
        {

        }

        private void DeletLevel()
        {
            _playerLoader.DeletePlayer();
            _levelLoader.ClearLevelFull();
            _camera.Follow = null;
        }
    }
}
