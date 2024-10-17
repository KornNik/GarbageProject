using UnityEngine;
using Attributes;

namespace Behaviours.Items
{
    class ClipModificaction : IWeaponModification
    {
        private int _increasAmmo = 10;

        private Object _clipObject;
        private StatModifier _clipModifier;
        private WeaponEnumModifications _modificationPlace = WeaponEnumModifications.Clip;

        public int IncreasAmmo { get => _increasAmmo; }
        public WeaponEnumModifications ModificationPlace { get => _modificationPlace; }

        public ClipModificaction()
        {
            _clipModifier = new StatModifier(_increasAmmo, Attributes.StatModType.Flat);
        }

        public void AddModification(Weapon weapon)
        {
            if (weapon.ModificationsController.TryAddModification(this))
            {
                weapon.WeaponAttributes.BulletsInClip.AddModifier(_clipModifier);
                ///Add clipModifier object to weapon
            }
            else { Debug.Log($"{this.GetType()} is on weapon now"); }
        }
        public void RemoveModification(Weapon weapon)
        {
            if (weapon.ModificationsController.TryRemoveModification(this))
            {
                weapon.WeaponAttributes.BulletsInClip.RemoveModifier(_clipModifier);
                ///Remove clipModifier object to weapon
            }
            else { Debug.Log($"{this.GetType()} is remove from weapon"); }
        }
    }
}
