using UnityEngine;
using MFPC.Utils;
using Behaviours.Units;

namespace Behaviours.States
{
    class JumpState : CharacterState
    {
        private float _oldPlayerPositionY;
        private bool _playerFall;

        public JumpState(CharacterStateController stateController) : base(stateController)
        {
        }

        public override void EnterState()
        {
            base.EnterState();
            _oldPlayerPositionY = -_stateController.StateObject.transform.position.y;
            _playerFall = false;

            Jump();
        }
        public override void ExitState()
        {
            base.ExitState();
            _stateController.StateObject.Gravity.ChangeGravityValue();
        }
        public override void LogicFixedUpdate()
        {
            base.LogicFixedUpdate();
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_stateController.StateObject.transform.position.y == _oldPlayerPositionY)
            {
                _stateController.StateObject.Movement.MoveVertical(Vector3.zero);
            }
            if (_stateController.StateObject.Jump.IsCanJump() && _playerFall)
            {
                _stateController.ChangeState(_stateController.MovementState);
            }
            if (!_stateController.StateObject.Jump.IsCanJump()) { _playerFall = true; }

            _oldPlayerPositionY = _stateController.StateObject.transform.position.y;
        }
        public override void LogicLateUpdate()
        {
            base.LogicLateUpdate();
        }
        protected override void InputHandle()
        {
            base.InputHandle();
        }
        private void Jump()
        {
            if (IsGround())
            {
                _stateController.StateObject.Movement.MoveVertical(Vector3.up, _stateController.StateObject.PlayerData.JumpForce);
            }
        }

        private bool IsGround()
        {
            var playerModel = _stateController.StateObject as PlayerModel;
            Ray ray = new Ray(playerModel.CharacterController.GetUnderPosition(), Vector3.down);
            return Physics.Raycast(ray, out RaycastHit raycastHit, playerModel.PlayerData.UnderRayDistance);
        }
    }
}
