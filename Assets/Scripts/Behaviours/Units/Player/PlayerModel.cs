using UnityEngine;

namespace Behaviours.Units
{
    [RequireComponent(typeof(CharacterController))]
    sealed class PlayerModel : UnitModel
    {
        [SerializeField] private Transform _headTransform;
        [SerializeField] private CharacterController _characterController;

        public Transform HeadTransform => _headTransform;

        protected override void InitializeComponents()
        {
            base.InitializeComponents();
            _movement = new PlayerMovement(_characterController, UnitAttributes);
            _jump = new Jump(_characterController, UnitAttributes);
            _rotation = new Rotation(_characterController);
            _combat = new Combat(Equipment);
        }
    }
}
