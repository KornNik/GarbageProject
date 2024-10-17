using System.Collections.Generic;

namespace Behaviours.Items
{
    class InterfacesDamageModifiers
    {
        private List<InterfaceDamageModifier> _interfacesDamageModifiers;

        public void AddModifier(InterfaceDamageModifier modifier)
        {
            _interfacesDamageModifiers.Add(modifier);
        }
        public void RemoveModifier(InterfaceDamageModifier modifier)
        {
            if (!_interfacesDamageModifiers.Contains(modifier)) return;

            _interfacesDamageModifiers.Remove(modifier);
        }
        public void InflictDamage(DamagerInfo damagerInfo)
        {
            if (_interfacesDamageModifiers.Count < 0) return;

            foreach (var item in _interfacesDamageModifiers)
            {
                item.InflictDamage(damagerInfo);
            }
        }
    }
}
