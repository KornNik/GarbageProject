using Helpers.Extensions;

namespace Behaviours.Items
{
    class CriticalModifier : DamageModifier
    {
        private const float DEFAULT_CRIT_VALUE = 1f;
        private const float DEFAULT_CHANCE_VALUE = 20f;

        protected float _chanceToTrigger;

        public CriticalModifier(float damageValue, float chanceToTrigger) : base(damageValue)
        {
            if (chanceToTrigger < 0 || chanceToTrigger > 100)
            {
                _chanceToTrigger = DEFAULT_CHANCE_VALUE;
            }
            else
            {
                _chanceToTrigger = chanceToTrigger;
            }
        }

        public override float ReturnCalculationValue()
        {
            if (MathExtender.CalculateChances(_chanceToTrigger))
            {
                return InflictValue();
            }
            else { return DefaultValue(); }
        }
        protected override float InflictValue()
        {
            return _modifierValue;
        }
        protected override float DefaultValue()
        {
            return DEFAULT_CRIT_VALUE;
        }
    }
}
