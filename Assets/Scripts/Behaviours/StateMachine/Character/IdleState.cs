using Behaviours.Units;
using Helpers;

namespace Behaviours.States
{
    class IdleState : CharacterState
    {
        private PlayerModel _playerModel;
        public IdleState(CharacterStateController characterStateController) : base(characterStateController)
        {
            _playerModel = _stateController.StateObject as PlayerModel;
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
            _playerModel.CharacterController.Move(new UnityEngine.Vector3(0, _stateController.StateObject.Gravity.GetGravityValue(), 0));
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
