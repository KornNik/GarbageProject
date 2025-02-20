using Controllers;
using Helpers;
using System;
using System.Threading.Tasks;

namespace Behaviours
{
    sealed class LoadGameState : BaseState<GameStateController>
    {
        private PlayerLoader _playerLoader;
        private LevelLoader _levelLoader;

        public LoadGameState(GameStateController stateController) : base()
        {
            _playerLoader = Services.Instance.PlayerLoader.ServicesObject;
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
        }
        public override void EnterState()
        {
            base.EnterState();
            LoadAll();
        }
        private async void LoadAll()
        {
            await LoadTask(LoadLevelBehaviours);
            await LoadTask(LoadPlayerBehaviours);
            await LoadTask(StartGameState);
        }

        private async Task LoadTask(Action loadingAction)
        {
            loadingAction?.Invoke();
            await Task.Yield();
        }
        private void LoadLevelBehaviours()
        {
            _levelLoader.LoadLevelGame(0);
        }
        private void LoadPlayerBehaviours()
        {
            _playerLoader.LoadPlayerClean();
        }
        private void StartGameState()
        {
            ChangeGameStateEvent.Trigger(GameStateType.GameState);
        }
    }
}
