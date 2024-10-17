using System.Collections;
using UnityEngine;

namespace Behaviours.Items
{
    abstract class Damager : MonoBehaviour, IDamager
    {
        [SerializeField] private DamagerAttributes _damagerAttributes;

        protected DamageModifiers _damageModifiers;
        protected IDamageCalculator _damageCalculator;
        protected WaitForSeconds _waitForNextDamageTick;
        protected InterfacesDamageModifiers _iDamageModifiers;

        protected float _additianalDamage;

        public DamagerAttributes DamagerAttributes => _damagerAttributes;

        protected virtual void Awake()
        {
            _damagerAttributes = new DamagerAttributes();
            _waitForNextDamageTick = new WaitForSeconds(1f);
            _damageModifiers = new DamageModifiers();
            _iDamageModifiers = new InterfacesDamageModifiers();
        }
        protected virtual void OnEnable()
        {

        }
        protected virtual void OnDisable()
        {

        }


        #region IDamager

        public void InflictDamage(DamagerInfo damageableInfo)
        {
            _additianalDamage = default;
            var finalDamage = _damagerAttributes.Damage.CurrentValue;
            _iDamageModifiers.InflictDamage(damageableInfo);

            finalDamage += _additianalDamage;
            if (!ReferenceEquals(_damageModifiers, null))
            {
                finalDamage += _damageModifiers.CalculateModifiersDamage();
            }
            if (!ReferenceEquals(_damageCalculator, null))
            {
                finalDamage += _damageCalculator.CalculateDamage();
            }

            var currentDamageInfoCollision = new DamageableInfo
                (finalDamage, transform.position, transform.forward);
            damageableInfo.Damageable.TakeDamage(currentDamageInfoCollision);
        }

        public float AdditionalDamage(float extraDamage)
        {
            _additianalDamage += extraDamage;
            return _additianalDamage;
        }

        public void InflictDamageOverTime(DamagerInfo damagerCollision, float damage, float duration)
        {
            StartCoroutine(DamageOverTime(damagerCollision, damage, duration));
        }

        #endregion


        #region Coroutine

        private IEnumerator DamageOverTime(DamagerInfo damagerInfo, float damage, float duration)
        {
            var damageable = damagerInfo.Damageable;

            if ((damageable is IDamageable))
            {
                var infoCollision = new DamageableInfo(damage, transform.position, transform.forward);

                for (int tick = 0; tick < duration; tick++)
                {
                    yield return _waitForNextDamageTick;
                    damageable.TakeDamage(infoCollision);
                }
            }
            else
            {
                StopCoroutine(nameof(DamageOverTime));
            }
        }

        #endregion
    }
}
