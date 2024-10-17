using System;

namespace Behaviours
{
    abstract class BaseStateController
    {
        protected IState _previousState;
        protected IState _currentState;

        public BaseStateController()
        {
            InitializeStates();
        }

        protected abstract void InitializeStates();

        protected virtual void StartState(IState startingState)
        {
            _currentState = startingState;
            startingState.EnterState();
        }

        public void ChangeState(IState newState)
        {
            if (ReferenceEquals(newState, null))
            {
                throw new Exception($"{this} try to set new state that is equal null");
            }
            if (!ReferenceEquals(_currentState, null))
            {
                _currentState.ExitState();
            }
            else
            {
                throw new Exception($"{this} try to access current state that is equal null");
            }

            _previousState = _currentState;
            _currentState = newState;
            _currentState.EnterState();
        }

        public void Update()
        {
            _currentState.LogicUpdate();
        }

        public void FixedUpdate()
        {
            _currentState.LogicFixedUpdate();
        }
        public void LateUpdate()
        {
            _currentState.LogicLateUpdate();
        }

        public IState GetPreviousState()
        {
            if (!ReferenceEquals(_previousState, null))
            {
                return _previousState;
            }
            return null;
        }
    }
}