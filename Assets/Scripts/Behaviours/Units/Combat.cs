using Kinemation.SightsAligner;
using System;

namespace Behaviours.Units
{
    sealed class Combat : IDisposable
    {
        private Equipment _equipment;
        private CoreAnimComponent _animComponent;

        public Combat(Equipment equipment, CoreAnimComponent animComponent)
        {
            _equipment = equipment;
            _animComponent = animComponent;
            _equipment.WeaponEquiped += OnWeaponEquiped;

            if (!_equipment.IsWeaponEquiped())
            {
                _animComponent.aiming = false;
            }
        }
        public void Dispose()
        {
            _equipment.WeaponEquiped -= OnWeaponEquiped;
        }
        public void Attack()
        {
            _equipment.Weapon.Attack();
        }
        public void Reload()
        {
            _equipment.Weapon.Reload();
        }
        public void Aim()
        {
            _equipment.Weapon.Aim();
            _animComponent.aiming = !_animComponent.aiming;
        }

        private void OnWeaponEquiped(bool status)
        {
            if (status)
            {
                _equipment.Weapon.Equiped();
                _animComponent.Init(_equipment.Weapon.GunAimData, _equipment.Weapon.AimPoint);
            }
            else
            {
                _animComponent.aiming = false;
                _equipment.Weapon.UnEquiped();
            }
        }
    }
}
