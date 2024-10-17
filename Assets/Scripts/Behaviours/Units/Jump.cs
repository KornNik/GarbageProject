﻿using Behaviours.Units;
using UnityEngine;

namespace Behaviours
{
    sealed class Jump : IMovable
    {
        private float _jumpForce = 3f;
        private int _jumpsCount;
        private CharacterController _characterController;
        private UnitAttributesContainer _unitAttributesContainer;

        private Vector2 _input;
        private Vector3 _moveVector;
        private Vector3 _gravityValue;
        private Transform _characterTransform;

        public Jump(CharacterController characterController, UnitAttributesContainer unitAttributes)
        {
            _characterController = characterController;
            _unitAttributesContainer = unitAttributes;
        }

        public void Move(Vector3 movement)
        {
            if (!IsCanJump()) return;

            _input = new Vector2(movement.x, movement.z);

            Vector3 desiredMove = _characterTransform.forward * _input.y + _characterTransform.right * _input.x + _characterTransform.up * -_jumpForce;
            _moveVector.x = desiredMove.x * _unitAttributesContainer.SpeedMovement.Attribute.CurrentValue;
            _moveVector.z = desiredMove.z * _unitAttributesContainer.SpeedMovement.Attribute.CurrentValue;
            _moveVector.y = desiredMove.y * -_unitAttributesContainer.JumpHeight.Attribute.CurrentValue;

            _characterController.Move(desiredMove);
        }
        public void StopMovement()
        {

        }
        public bool IsCanJump()
        {
            if (_characterController.isGrounded)
            {
                return true;
            }
            return false;
        }
    }
}