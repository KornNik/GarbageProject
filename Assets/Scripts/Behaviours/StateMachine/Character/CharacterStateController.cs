using Behaviours.Units;

namespace Behaviours.States
{
    sealed class CharacterStateController : BaseStateController
    {
        private IState _idleState;
        private IState _jumpState;
        private IState _crouchState;
        private IState _movementState;
        private IState _runState;

        private UnitModel _stateObject;

        public IState IdleState => _idleState;
        public IState JumpState => _jumpState;
        public IState CrouchState => _crouchState;
        public IState MovementState => _movementState;
        public IState RunState => _runState;

        public UnitModel StateObject => _stateObject;

        public CharacterStateController(UnitModel unitModel) : base()
        {
            _stateObject = unitModel;
            InitializeStates();
            StartState(_idleState);
        }

        protected override void InitializeStates()
        {
            _idleState = new IdleState(this);
            _jumpState = new JumpState(this);
            _movementState = new MovementState(this);
            _crouchState = new CrouchState(this);
            _runState = new RunState(this);
        }
    }
}