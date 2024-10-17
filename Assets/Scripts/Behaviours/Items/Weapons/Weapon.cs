using UnityEngine;
using Attributes;
using Behaviours.States;

namespace Behaviours.Items
{
    abstract class Weapon : Item, IWeapon
    {
        [SerializeField] private WeaponAttributes _weaponAttrubutes;
        [SerializeField] private ModificationsPlaces[] _modificationsTransforms;

        private WeaponModificationsController _modificationsController;
        private WeaponStateController _stateController;

        public WeaponAttributes WeaponAttributes => _weaponAttrubutes;
        public WeaponModificationsController ModificationsController => _modificationsController;

        protected override void Awake()
        {
            base.Awake();
            _stateController = new WeaponStateController(this);
            _modificationsController = new WeaponModificationsController(_modificationsTransforms);
        }
        protected virtual void Update()
        {
            _stateController.Update();
        }
        protected virtual void FixedUpdate()
        {
            _stateController.FixedUpdate();
        }
        public virtual void Attack()
        {

        }

        public virtual void Recharge()
        {

        }

        public virtual void Reload()
        {
        }

        public virtual void Aim()
        {

        }
    }
}
