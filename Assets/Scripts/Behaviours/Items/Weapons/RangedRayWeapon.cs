using UnityEngine;

namespace Behaviours.Items
{
    sealed class RangedRayWeapon : Weapon
    {
        [SerializeField] private Transform _barrelTransform;
        [SerializeField] private Damager _damager;

        private Ray _ray;
        private RaycastHit[] _hits;

        protected override void Awake()
        {
            base.Awake();
            _ray = new Ray(_barrelTransform.position, _barrelTransform.forward);
            _hits = new RaycastHit[4];
        }

        public override void Attack()
        {
            var hitsNumber = Physics.RaycastNonAlloc(_ray, _hits, _damager.DamagerAttributes.CollisionLayer);
            if (hitsNumber != 0)
            {
                for (int i = 0; i < hitsNumber; i++)
                {
                    var damageable = _hits[i].collider.GetComponent<IDamageable>();
                    if (damageable != null)
                    {
                        _damager.InflictDamage(new DamagerInfo(damageable, _hits[i].point, _ray.direction));
                    }
                }
            }
        }

        public override void Recharge()
        {

        }
    }
}
