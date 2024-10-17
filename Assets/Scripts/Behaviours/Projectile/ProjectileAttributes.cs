using System;
using UnityEngine;

namespace Attributes
{
    [Serializable]
    struct ProjectileAttributes
    {
        [SerializeField] private ObjectAttributeFloat _startSpeed;
        [SerializeField] private ObjectAttributeFloat _finalDamageInPercent;
        [SerializeField] private ObjectAttributeFloat _startPointOfDamageReduction;

        [SerializeField] private float _timeToDestruct;

        public ObjectAttributeFloat StartSpeed => _startSpeed;
        public ObjectAttributeFloat FinalDamageInPercent => _finalDamageInPercent;
        public ObjectAttributeFloat StartPointOfDamageReduction => _startPointOfDamageReduction;

        public float TimeToDestruct => _timeToDestruct;
    }
}
