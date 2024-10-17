using UnityEngine;
using Helpers;

namespace Behaviours.States
{
    class JumpState : CharacterState
    {
        public JumpState(CharacterStateController stateController) : base(stateController)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
            MakeJump();
        }
        public override void ExitState()
        {
            base.ExitState();

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

        }

        private void MakeJump()
        {
            _stateController.StateObject.Jump.Move(Services.Instance.InputController.ServicesObject.
                InputActions.PlayerActionList[InputActionManagerPlayer.MOVEMENT].ReadValue<Vector2>());

            if (!_stateController.StateObject.Jump.IsCanJump())
            {
                _stateController.ChangeState(_stateController.IdleState);
            }
        }
    }
}
