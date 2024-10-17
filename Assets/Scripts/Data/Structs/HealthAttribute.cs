using Attributes;
using System.Collections.Generic;

namespace Data
{
    struct HealthAttribute
    {
        private float _health;
        private ObjectAttributeFloat _maxHealth;

        private List<StatModifier> _healthStatModifiers;

        public HealthAttribute(AttributeDataFloat healthData)
        {
            _health = healthData.MaxValue;
            _maxHealth = new ObjectAttributeFloat(healthData);
            _healthStatModifiers = new List<StatModifier>();
        }

        public float Health => _health;
        public ObjectAttributeFloat MaxHealth => _maxHealth;

        public void SetHealth(float health)
        {
            _health = health;
        }
    }
}
