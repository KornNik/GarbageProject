using Controllers;
using Helpers;


namespace Behaviours.States
{
    abstract class CharacterState : BaseState<CharacterStateController>
    {
        protected InputController _inputController;
        protected CharacterState(CharacterStateController stateController) : base()
        {
            _stateController = stateController;
            _inputController = Services.Instance.InputController.ServicesObject;
        }
        public override void EnterState()
        {
            base.EnterState();
        }
        public override void ExitState()
        {
            base.ExitState();
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            MakeRotation();
            InputHandle();
            _stateController.StateObject.Movement.MoveUpdate();
        }
        public override void LogicLateUpdate()
        {
            base.LogicLateUpdate();
        }
        protected virtual void InputHandle()
        {
            var isInteracting = _inputController.InputActions.
                PlayerActionList[InputActionManagerPlayer.INTERACT].IsPressed();
            if (isInteracting)
            {
                _stateController.StateObject.Interacter.CheckInteraction();
            }
        }
        private void MakeRotation()
        {
            _stateController.StateObject.Rotation.RotateTowardCamera();
        }
    }
}