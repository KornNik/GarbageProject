using Behaviours.Units;
using UnityEngine;

namespace Behaviours
{
    sealed class Target : MonoBehaviour, IDamageable
    {
        public Collider Collider;

        private Health _health;

        private void Awake()
        {
            _health = new Health(new Data.HealthAttribute(new Attributes.AttributeDataFloat(100, 0, 100)));
        }
        private void OnEnable()
        {
            _health.HealthIsEnd += OnHealthEnd;
        }
        private void OnDisable()
        {
            _health.HealthIsEnd -= OnHealthEnd;
        }
        public void TakeDamage(DamageableInfo damageInfo)
        {
            _health.TakeDamage(damageInfo.Damage);
        }
        private void OnHealthEnd()
        {
            this.gameObject.SetActive(false);
        }
    }
}
