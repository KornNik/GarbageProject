using System.Collections.Generic;

namespace Behaviours.Items
{
    class WeaponModificationsSlots
    {
        private List<WeaponModificationSlot> _modificationsList;

        public WeaponModificationsSlots(ModificationsPlaces[] modificationsTransforms)
        {
            _modificationsList = new List<WeaponModificationSlot>(modificationsTransforms.Length);
            for (int i = 0; i < modificationsTransforms.Length; i++)
            {
                var modification = modificationsTransforms[i];
                _modificationsList.Add(new WeaponModificationSlot(modification.ModTransform, modification.ModPlaceEnum));
            }
        }

        public bool CheckModificationSlot(IWeaponModification weaponModification)
        {
            foreach (var modification in _modificationsList)
            {
                if (modification.IsModificationFit(weaponModification.ModificationPlace))
                {
                    if (modification.TryAttachMod(weaponModification))
                    {
                        return true;
                    }
                    return false;
                }
            }

            return false;
        }
    }
}
