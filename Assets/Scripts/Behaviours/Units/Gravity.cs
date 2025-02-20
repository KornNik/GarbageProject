using UnityEngine;

namespace Behaviours.Units
{
    sealed class Gravity
    {
        private const float GRAVITY_FORCE = -9.81f;
        private float _gravityForce;
        private CharacterController _characterController;
        private Vector3 _gravityVector;

        public Gravity(CharacterController characterController = null)
        {
            _gravityForce = GRAVITY_FORCE * Time.deltaTime;
            _characterController = characterController;
        }

        public void ChangeGravityValue(float newGravityValue = GRAVITY_FORCE)
        {
            _gravityForce = newGravityValue * Time.deltaTime;
        }
        public void ApplyGravity()
        {
            _gravityVector.y = _gravityForce;
            _characterController.Move(_gravityVector);
        }
        public float GetGravityValue()
        {
            return _gravityForce;
        }
    }
}
