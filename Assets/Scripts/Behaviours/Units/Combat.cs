using System;

namespace Behaviours.Units
{
    sealed class Combat : IDisposable
    {
        private Equipment _equipment;

        public Combat(Equipment equipment)
        {
            _equipment = equipment;
            _equipment.WeaponEquiped += OnWeaponEquiped;
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
        }

        private void OnWeaponEquiped(bool status)
        {

        }
    }
}
