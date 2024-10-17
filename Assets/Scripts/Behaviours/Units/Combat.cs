namespace Behaviours.Units
{
    sealed class Combat
    {
        private Equipment _equipment;

        public Combat(Equipment equipment)
        {
            _equipment = equipment;
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
    }
}
