using UnityEngine;

namespace Behaviours.Units
{
    [RequireComponent(typeof(CharacterController))]
    sealed class PlayerModel : UnitModel
    {
        [SerializeField] private Transform _headTransform;
        [SerializeField] private CharacterController _characterController;

        private Inventory _inventory;

        public Transform HeadTransform => _headTransform;
        public CharacterController CharacterController => _characterController;
        public Inventory Inventory => _inventory;

        protected override void InitializeComponents()
        {
            base.InitializeComponents();
            _movement = new PlayerMovement(_characterController, UnitAttributes, Gravity, PlayerData);
            _jump = new Jump(_characterController, UnitAttributes);
            _rotation = new Rotation(_characterController);
            _combat = new Combat(Equipment, CoreAnimComponent);
            _crouch = new Crouch(_characterController);
            _inventory = new Inventory();
        }
    }
}
