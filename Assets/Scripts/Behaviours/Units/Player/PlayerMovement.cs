using Behaviours.Units;
using MFPC;
using UnityEngine;

namespace Behaviours
{
    sealed class PlayerMovement : Movement
    {
        private CharacterController _characterController;
        private UnitAttributesContainer _unitAttributes;
        private Gravity _gravity;

        private Transform _player;
        private Vector3 _moveDirection;
        private PlayerData _playerData;
        private bool _isGrounded;
        private float _verticalDirection;

        private Vector3 _lastDirection;
        private float _lastSpeed;
        private float _lastPlayerPositionY;

        public PlayerMovement(CharacterController characterController, UnitAttributesContainer unitAttributes,Gravity gravity, PlayerData playerData)
        {
            _unitAttributes = unitAttributes;
            _characterController = characterController;
            _gravity = gravity;
            _playerData = playerData;
            _player = _characterController.transform;
        }
        public override void MoveHorizontal(Vector3 direction, float speed = 1f)
        {
            if (_characterController.isGrounded || IsLockGravity)
            {
                direction.Normalize();
                _lastDirection = direction;
                _lastSpeed = speed;

                //Direction of movement
                _moveDirection = _player.transform.TransformDirection(new Vector3(direction.x, 0.0f, direction.z)) *
                                 speed;
            }
        }

        public override void MoveVertical(Vector3 direction, float speed = 1f)
        {
            direction.Normalize();

            _verticalDirection = direction.y * speed;
        }

        public override void MoveUpdate()
        {
            Gravity();
            _characterController.Move(GetPlayerDirection());
        }

        private void Gravity()
        {
            if (IsLockGravity) return;

            if (_characterController.isGrounded)
            {
                if (!_isGrounded) _verticalDirection = -0.01f;

                _isGrounded = true;
            }
            else
            {
                _verticalDirection -= _playerData.Gravity * Time.deltaTime;

                _isGrounded = false;
            }
        }

        private Vector3 GetPlayerDirection()
        {
            Vector3 inAirDirection;

            if (!_characterController.isGrounded && _playerData.AirControl && !IsLockGravity)
            {
                inAirDirection = _player.transform.TransformDirection(_lastDirection) * _lastSpeed;
                return new Vector3(inAirDirection.x, _verticalDirection, inAirDirection.z) *
                       Time.deltaTime;
            }
            else
            {
                return new Vector3(_moveDirection.x, _verticalDirection, _moveDirection.z) *
                       Time.deltaTime;
            }
        }
    }
}
