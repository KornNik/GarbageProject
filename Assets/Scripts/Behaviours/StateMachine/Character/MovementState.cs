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
            _stateController.StateObject.Movement.StopMovement();

            _stateController.StateObject.UnitEvents.IsMoving?.Invoke(false);
            _stateController.StateObject.UnitEvents.HorizontalMoving?.Invoke(0);
            _stateController.StateObject.UnitEvents.VerticalMoving?.Invoke(0);
        }
        public override void LogicFixedUpdate()
        {
            base.LogicFixedUpdate();
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
            base.LogicLateUpdate();
        }

        protected override void InputHandle()
        {
            var isMoving = _inputController.InputActions.PlayerActionList
                [InputActionManagerPlayer.MOVEMENT].IsPressed();
            if(!isMoving)
            {
                _stateController.ChangeState(_stateController.GetPreviousState());
            }
        }
    }
}
