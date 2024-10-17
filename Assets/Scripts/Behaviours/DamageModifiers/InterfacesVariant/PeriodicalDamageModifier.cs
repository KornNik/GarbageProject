namespace Behaviours.Items
{
    class PeriodicalDamageModifier : InterfaceDamageModifier
    {
        private readonly float _poisonDamage;
        private readonly float _poisonDuration;

        public PeriodicalDamageModifier(IDamager modifiedDamage, float poisonDamage, float poisonDuration) : base(modifiedDamage)
        {
            _poisonDamage = poisonDamage;
            _poisonDuration = poisonDuration;
        }

        protected override void Modify()
        {
            //_modifiedDamage.InflictDamageOverTime(_damagerCollision, _poisonDamage, _poisonDuration);
        }
    }
}
