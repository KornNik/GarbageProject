using UnityEngine;
using Attributes;

namespace Behaviours.Items
{
    [System.Serializable]
    struct DamagerAttributes
    {
        [SerializeField] private ObjectAttributeFloat _damage;
        [SerializeField] private ObjectAttributeFloat _damageReduction;
        [SerializeField] private ObjectAttributeFloat _randomDamageRange;

        [SerializeField] private bool _isDamageRandom;
        [SerializeField] private bool _isDamageReduction;
        [SerializeField] private LayerMask _collisionLayer;

        public ObjectAttributeFloat Damage => _damage;
        public ObjectAttributeFloat DamageReduction => _damageReduction;
        public ObjectAttributeFloat RandomDamageRange => _randomDamageRange;

        public bool IsDamageRandom => _isDamageRandom;
        public bool IsDamageReduction => _isDamageReduction;
        public LayerMask CollisionLayer => _collisionLayer;
    }
}