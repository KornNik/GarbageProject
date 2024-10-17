using UnityEngine;

namespace Behaviours.Items
{
    class WeaponModificationSlot
    {
        private Transform _positionToPlace;
        private IWeaponModification _modification;
        private WeaponEnumModifications _modificationPlace;

        public WeaponModificationSlot(Transform positionToPlace, WeaponEnumModifications modificationPlace)
        {
            _positionToPlace = positionToPlace;
            _modificationPlace = modificationPlace;
        }

        public bool TryAttachMod(IWeaponModification modification)
        {
            if (_modification == null)
            {
                AttachMod(modification);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsModificationFit(WeaponEnumModifications modificationPlace)
        {
            if (_modificationPlace == modificationPlace)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Transform GetModificationPosition()
        {
            return _positionToPlace;
        }

        private void AttachMod(IWeaponModification modification)
        {
            _modification = modification;
        }
    }
}
