using Behaviours.Units;
using UnityEngine;

namespace Behaviours
{
    sealed class PlayerMovement : Movement
    {
        private CharacterController _characterController;
        private UnitAttributesContainer _unitAttributes;

        public PlayerMovement(CharacterController characterController, UnitAttributesContainer unitAttributes)
        {
            _unitAttributes = unitAttributes;
            _characterController = characterController;
        }

        public override void Move(Vector3 movement)
        {
            var normalizedMovement = Vector3.Normalize(movement);
            var movementVector = new Vector3(normalizedMovement.x, 0, normalizedMovement.y);
            var localMovement = _characterController.transform.right * normalizedMovement.x +
                _characterController.transform.forward * normalizedMovement.y;
            var finalMovement = localMovement * _unitAttributes.SpeedMovement.Attribute.CurrentValue *
                Time.fixedDeltaTime;
            _characterController.Move(finalMovement);
        }

        public override void StopMovement()
        {
            _characterController.Move(Vector3.zero);
        }
    }
}
