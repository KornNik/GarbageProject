using Helpers;
using UnityEngine;

namespace Behaviours.States
{
    class MovementState : CharacterState
    {
        public MovementState(CharacterStateController characterStateController) : 
            base(characterStateController)
        {

        }

        public override void EnterState()
        {
            base.EnterState();
            _stateController.StateObject.UnitEvents.IsMoving?.Invoke(true);
        }
        public override void ExitState()
        {
            base.ExitState();

            _stateController.StateObject.UnitEvents.IsMoving?.Invoke(false);
            _stateController.StateObject.UnitEvents.HorizontalMoving?.Invoke(0);
            _stateController.StateObject.UnitEvents.VerticalMoving?.Invoke(0);
        }
        public override void LogicFixedUpdate()
        {
            base.LogicFixedUpdate();
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }
        public override void LogicLateUpdate()
        {
            base.LogicLateUpdate();
        }

        protected override void InputHandle()
        {
            base.InputHandle();
            var isMoving = _inputController.InputActions.
                PlayerActionList[InputActionManagerPlayer.MOVEMENT].IsPressed();
            var isJumping = _inputController.InputActions.
                PlayerActionList[InputActionManagerPlayer.JUMP].IsPressed();
            var isRuning = _inputController.InputActions.
                PlayerActionList[InputActionManagerPlayer.RUN].IsPressed();
            if (!isMoving)
            {
                _stateController.ChangeState(_stateController.IdleState);
            }
            if (isJumping)
            {
                _stateController.ChangeState(_stateController.JumpState);
            }
            if(isRuning)
            {
                _stateController.ChangeState(_stateController.RunState);
            }

            var movementInputs = _inputController.InputActions.PlayerActionList
                [InputActionManagerPlayer.MOVEMENT].ReadValue<Vector2>();
            _stateController.StateObject.Movement.MoveHorizontal(new Vector3(movementInputs.x, 0.0f, movementInputs.y),
            _stateController.StateObject.PlayerData.WalkSpeed);

            _stateController.StateObject.UnitEvents.HorizontalMoving?.Invoke(movementInputs.x);
            _stateController.StateObject.UnitEvents.VerticalMoving?.Invoke(movementInputs.y);
        }
    }
}
