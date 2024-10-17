namespace Behaviours.Items
{
    class BonusDamageModifier : InterfaceDamageModifier
    {
        private readonly float _bonusDamage;

        public BonusDamageModifier(IDamager modifiedDamage, float bonusDamage) : base(modifiedDamage)
        {
            _bonusDamage = bonusDamage;
        }

        protected override void Modify()
        {
            //_modifiedDamage.AdditionalDamage(_bonusDamage);
        }
    }
}
