using Helpers;

namespace Behaviours.States
{
    class IdleState : CharacterState
    {
        public IdleState(CharacterStateController characterStateController) : base(characterStateController)
        {

        }
        public override void EnterState()
        {
        }

        public override void ExitState()
        {
        }

        public override void LogicFixedUpdate()
        {
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }
        public override void LogicLateUpdate()
        {

        }
        protected override void InputHandle()
        {
            base.InputHandle();
            var isMoving = _inputController.InputActions.
                PlayerActionList[InputActionManagerPlayer.MOVEMENT].IsPressed();
            var isJumping = _inputController.InputActions.
                PlayerActionList[InputActionManagerPlayer.JUMP].IsPressed();
            var isCrouching = _inputController.InputActions.
                PlayerActionList[InputActionManagerPlayer.CROUCH].IsPressed();

            if (isMoving)
            {
                _stateController.ChangeState(_stateController.MovementState);
            }
            if (isJumping)
            {
                _stateController.ChangeState(_stateController.JumpState);
            }
            if (isCrouching)
            {
                _stateController.ChangeState(_stateController.CrouchState);
            }
        }
    }
}
