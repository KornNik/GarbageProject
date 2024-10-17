namespace Behaviours.Items
{
    interface IWeaponModification
    {
        void AddModification(Weapon weapon);
        void RemoveModification(Weapon weapon);
        public WeaponEnumModifications ModificationPlace { get; }
    }
}
