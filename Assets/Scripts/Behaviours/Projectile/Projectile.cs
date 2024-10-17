using UnityEngine;
using Attributes;
using Helpers;

namespace Behaviours.Items
{
    [RequireComponent(typeof(Collider))]
    abstract class Projectile : Damager, IPoolable
    {
        [SerializeField] private ProjectileAttributes _projectileAttributes;
        [SerializeField] private ProjectileCurve _projectileCurve;
        [SerializeField] private Collider _collider;

        protected Transform _transform;
        protected Transform _poolTransform;

        public Transform PoolTransform { get => _poolTransform; set => _poolTransform = value; }
        public GameObject PoolableObject { get => gameObject; set => PoolableObject.SetActive(value); }
        public Collider Collider => _collider;

        protected override void OnEnable()
        {
            base.OnEnable();
            _projectileCurve.OnEnable();
        }
        protected override void Awake()
        {
            base.Awake();
            _transform = transform;
            _projectileAttributes = new ProjectileAttributes();
            _projectileCurve = new ProjectileCurve(_projectileAttributes, _transform);
            _damageCalculator = new ProjectileDamageCalculator(DamagerAttributes, _projectileCurve);
        }
        protected virtual void FixedUpdate()
        {
            _projectileCurve.FixedUpdate();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.layer == DamagerAttributes.CollisionLayer)
            {
                var damageable = collision.gameObject.GetComponent<IDamageable>();
                if(damageable is IDamageable)
                {
                    InflictDamage(new DamagerInfo(damageable, collision.contacts[0].point,transform.forward));
                }
            }

            ReturnToPool();
        }

        public virtual void ReturnToPool()
        {
            transform.SetParent(PoolTransform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            PoolableObject.SetActive(false);
            CancelInvoke(nameof(ReturnToPool));

            if (!PoolTransform)
            {
                Destroy(gameObject);
            }
        }

        public virtual void ActiveObject()
        {
            gameObject.SetActive(true);
            Invoke(nameof(ReturnToPool), _projectileAttributes.TimeToDestruct);
            transform.SetParent(null);
            ProjectileFly();
        }

        protected virtual void ProjectileFly()
        {

        }
    }
}
