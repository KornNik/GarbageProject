using UnityEngine;

namespace Behaviours
{
    struct DamageableInfo
    {
        public float Damage;
        public Vector3 DamagePoint;
        public Vector3 DamageDirection;

        public DamageableInfo(float damage, Vector3 damagePoint, Vector3 damageDirection)
        {
            Damage = damage;
            DamagePoint = damagePoint;
            DamageDirection = damageDirection;
        }
    }
}
