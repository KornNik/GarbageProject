using UnityEngine;

namespace Behaviours.Items
{
    [RequireComponent(typeof(Rigidbody))]
    class PhysicsProjectile : Projectile
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private PhysicsAttributes _physicsAttributes;
        public Rigidbody Rigidbody=> _rigidbody;

        protected override void ProjectileFly()
        {
            base.ProjectileFly();
            if (!_rigidbody) { throw new System.Exception($"{this.name} try to access _rigidbody but its empty"); }

            _rigidbody.AddForce(_poolTransform.forward * _physicsAttributes.BulletForce.CurrentValue, ForceMode.Impulse);
        }
        public override void ReturnToPool()
        {
            base.ReturnToPool();

        }
    }
}
