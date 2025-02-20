using System.Collections.Generic;

namespace Behaviours.Items
{
    class DamageModifiers
    {
        private List<DamageModifier> _modifiers;

        public DamageModifiers()
        {
            _modifiers = new List<DamageModifier>();
        }

        public void AddModifier(DamageModifier newModifier)
        {
            _modifiers.Add(newModifier);
        }
        public void RemoveModifier(DamageModifier newModifier)
        {
            if (_modifiers.Contains(newModifier))
            {
                _modifiers.Remove(newModifier);
            }
        }

        public float CalculateModifiersDamage()
        {
            float calculatedDamage = default;
            foreach (var item in _modifiers)
            {
                calculatedDamage = item.ReturnCalculationValue();
            }
            return calculatedDamage;
        }
    }
}
