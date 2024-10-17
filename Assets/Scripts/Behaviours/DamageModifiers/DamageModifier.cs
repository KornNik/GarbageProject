namespace Behaviours.Items
{
    abstract class DamageModifier
    {
        protected float _modifierValue;

        public float ModifierValue => _modifierValue;

        public DamageModifier(float damageValue)
        {
            _modifierValue = damageValue;
        }

        public abstract float ReturnCalculationValue();
        protected abstract float DefaultValue();
        protected abstract float InflictValue();

    }
}
