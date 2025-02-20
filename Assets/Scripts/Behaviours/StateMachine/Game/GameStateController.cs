using Helpers;

namespace Behaviours
{
    internal class GameStateController : BaseStateController, IEventListener<ChangeGameStateEvent>, IEventSubscription
    {
        private IState _menuState;
        private IState _pauseState;
        private IState _gameState;
        private IState _exitGameState;
        private IState _inverntoryState;
        private IState _loadGameState;

        public GameStateController()
        {
            InitializeStates();
            StartState(MenuState);
        }

        public IState MenuState => _menuState;
        public IState PauseState => _pauseState;
        public IState GameState => _gameState;
        public IState ExitGameState  => _exitGameState; 
        public IState InverntoryState => _inverntoryState; 

        protected override void InitializeStates()
        {
            _menuState = new MenuState(this);
            _pauseState = new PauseState(this);
            _gameState = new GameState(this);
            _exitGameState = new ExitGameState(this);
            _inverntoryState = new InventoryState(this);
            _loadGameState = new LoadGameState(this);
        }

        public void OnEventTrigger(ChangeGameStateEvent eventType)
        {
            switch (eventType.NextGameState)
            {
                case GameStateType.None:
                    throw new System.Exception("State is unknown");
                case GameStateType.ManuState:
                    ChangeState(_menuState);
                    break;
                case GameStateType.GameState:
                    ChangeState(_gameState);
                    break;
                case GameStateType.PauseState:
                    ChangeState(_pauseState);
                    break;
                case GameStateType.InventoryState:
                    ChangeState(_inverntoryState);
                    break;
                case GameStateType.ExitState:
                    ChangeState(_exitGameState);
                    break;
                case GameStateType.LoadGameState:
                        ChangeState(_loadGameState);
                    break;
            }
        }

        public void Subscribe()
        {
            this.EventStartListening<ChangeGameStateEvent>();
        }

        public void Unsubscribe()
        {
            this.EventStopListening<ChangeGameStateEvent>();
        }
    }
}