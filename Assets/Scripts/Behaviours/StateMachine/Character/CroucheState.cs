using Helpers;
using UnityEngine;

namespace Behaviours.States
{
    sealed class CrouchState : CharacterState
    {
        public CrouchState(CharacterStateController characterStateController) : base(characterStateController)
        {

        }
        public override void EnterState()
        {
            _stateController.StateObject.Crouch.GetDown();
        }

        public override void ExitState()
        {
            _stateController.StateObject.Crouch.StandUp();
        }

        public override void LogicFixedUpdate()
        {
            var movementInputs = _inputController.InputActions.PlayerActionList
                [InputActionManagerPlayer.MOVEMENT].ReadValue<Vector2>();
            _stateController.StateObject.Movement.Move(movementInputs);

            _stateController.StateObject.UnitEvents.HorizontalMoving?.Invoke(movementInputs.x);
            _stateController.StateObject.UnitEvents.VerticalMoving?.Invoke(movementInputs.y);
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
            if (!isCrouching)
            {
                _stateController.ChangeState(_stateController.IdleState);
            }
        }
    }
}
