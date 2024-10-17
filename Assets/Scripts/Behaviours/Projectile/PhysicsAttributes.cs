using System;
using UnityEngine;
using Attributes;

namespace Behaviours.Items
{
    [Serializable]
    struct PhysicsAttributes
    {
        [SerializeField] private ObjectAttributeFloat _bulletForce;

        public ObjectAttributeFloat BulletForce => _bulletForce;
    }
}