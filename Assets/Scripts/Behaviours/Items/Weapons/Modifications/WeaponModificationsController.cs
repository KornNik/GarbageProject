using Attributes;

namespace Behaviours.Items
{
    sealed class WeaponModificationsController
    {
        private WeaponModificationsSlots _modificationsSlots;

        public WeaponModificationsController(ModificationsPlaces[] modificationsTransforms)
        {
            _modificationsSlots = new WeaponModificationsSlots(modificationsTransforms);
        }
        public bool TryAddModification(IWeaponModification newModification)
        {
            if (_modificationsSlots.CheckModificationSlot(newModification))
            {
                return true;
            }
            return false;
        }
        public bool TryRemoveModification(IWeaponModification modification)
        {
            return false;
        }
        private void AddModification(IWeaponModification newModification)
        {

        }
        private void RemoveModification(IWeaponModification modification)
        {

        }
    }
}