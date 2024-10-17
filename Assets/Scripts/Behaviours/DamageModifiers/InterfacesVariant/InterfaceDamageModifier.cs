using Helpers.Extensions;

namespace Behaviours.Items
{
    abstract class InterfaceDamageModifier : IDamager
    {
        protected IDamager _modifiedDamage;
        protected IDamageable _bulletVictim;
        protected DamagerInfo _damagerInfo;

        public InterfaceDamageModifier(IDamager modifiedDamage)
        {
            _modifiedDamage = modifiedDamage;
        }

        protected abstract void Modify();

        public void InflictDamage(DamagerInfo damagerInfo)
        {
            if (!_modifiedDamage.Equals(null))
            {
                _damagerInfo = damagerInfo;
                _bulletVictim = damagerInfo.Damageable;
                Modify();
            }
        }
        public float AdditionalDamage(float extraDamage) { return default; }

        public void InflictDamageOverTime(DamagerInfo damagerInfo, float damage, float duration) { }
    }
}
