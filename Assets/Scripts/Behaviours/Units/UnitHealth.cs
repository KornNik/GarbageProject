using Data;

namespace Behaviours.Units
{
    sealed class UnitHealth : Health
    {
        private UnitAttributesContainer _unitAttributes;
        public UnitHealth(UnitAttributesContainer unitAttributes, HealthAttribute healthAttributes) : base(healthAttributes)
        {
            _unitAttributes = unitAttributes;
        }
        protected override float DamageReductionCalculation(float damage)
        {
            var reductedDamage = (damage - _unitAttributes.Armor.Attribute.CurrentValue);
            if (reductedDamage < 0)
            {
                reductedDamage = MINIMUM_DAMAGE;
            }
            return reductedDamage;
        }
    }
}
