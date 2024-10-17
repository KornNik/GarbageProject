using Data;
using System;

namespace Behaviours.Units
{
    struct HealthStruct
    {
        public float HealthRate;
        public float CurrentHealth;
        public float MaxHealth;

        public HealthStruct(float healthRate, float currentHealth, float maxHealth)
        {
            HealthRate = healthRate;
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }
    }
    class Health
    {
        public const float MINIMUM_DAMAGE = 2;

        public event Action HealthIsEnd;
        public event Action<HealthStruct> HealthChanged;

        private HealthAttribute _healthAttributes;

        public Health(HealthAttribute healthAttributes)
        {
            _healthAttributes = healthAttributes;
        }

        public void TakeDamage(float damage)
        {
            if (_healthAttributes.Health > 0)
            {
                var damagedHealth = _healthAttributes.Health - DamageReductionCalculation(damage);
                float finalHealth = 0;

                if (IsHealthInLimits(damagedHealth))
                {
                    finalHealth = damagedHealth;
                }
                else
                {
                    finalHealth = 0;
                    HealthIsEnd?.Invoke();
                }

                ChangeHealth(finalHealth);
            }
        }
        public void TakeHeal(float heal)
        {
            if (_healthAttributes.Health < _healthAttributes.MaxHealth.CurrentValue)
            {
                var healedHealth = _healthAttributes.Health + heal;
                float finalHealth = 0;

                if (IsHealthInLimits(healedHealth))
                {
                    finalHealth = healedHealth;
                }
                else
                {
                    finalHealth = _healthAttributes.MaxHealth.CurrentValue;
                }

                ChangeHealth(finalHealth);
            }
        }
        public void ResetHealth()
        {
            ChangeHealth(_healthAttributes.MaxHealth.CurrentValue);
        }
        public float GetHealthRate()
        {
            var healthRate = _healthAttributes.Health / _healthAttributes.MaxHealth.CurrentValue;
            return healthRate;
        }
        public float GetMaxHealth()
        {
            var maxHealth = _healthAttributes.MaxHealth.CurrentValue;
            return maxHealth;
        }

        protected virtual float DamageReductionCalculation(float damage)
        {
            return damage;
        }

        private bool IsHealthInLimits(float healthExpectedValue)
        {
            if (healthExpectedValue < 0)
            {
                return false;
            }
            else if (healthExpectedValue > _healthAttributes.MaxHealth.CurrentValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void ChangeHealth(float value)
        {
            _healthAttributes.SetHealth(value);
            HealthChanged?.Invoke(new HealthStruct(GetHealthRate(), _healthAttributes.Health, _healthAttributes.MaxHealth.MaxValue));
        }
    }
}
