using UnityEngine;


namespace Behaviours
{
    struct DamagerInfo
    {
        public IDamageable Damageable;
        public Vector3 DamagePoint;
        public Vector3 DamageDirection;

        public DamagerInfo(IDamageable damageable, Vector3 damagePoint, Vector3 damageDirection)
        {
            Damageable = damageable;
            DamagePoint = damagePoint;
            DamageDirection = damageDirection;
        }
    }
}
