using UnityEngine;
using Data;

namespace Behaviours.Units
{
    sealed class UnitAttributesContainer
    {
        private Health _health;
        private UnitAttributeFloat _armor;
        private UnitAttributeFloat _attack;
        private UnitAttributeFloat _jumpHeight;
        private UnitAttributeFloat _speedMovement;

        public UnitAttributesContainer(UnitModel unitModel)
        {
            _health = new UnitHealth(this, unitModel.UnitData.GetHealthAttributes());
            _armor = new UnitAttributeFloat(unitModel.UnitData.GetArmorAttributes());
            _speedMovement = new UnitAttributeFloat(unitModel.UnitData.GetMovementAttributes());

        }

        public Health Health => _health;
        public UnitAttributeFloat Armor => _armor;
        public UnitAttributeFloat Attack => _attack;
        public UnitAttributeFloat JumpHeight => _jumpHeight;
        public UnitAttributeFloat SpeedMovement => _speedMovement;
    }
}
