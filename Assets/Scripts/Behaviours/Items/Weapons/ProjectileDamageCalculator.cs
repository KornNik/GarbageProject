using UnityEngine;

namespace Behaviours.Items
{
    class ProjectileDamageCalculator : IDamageCalculator
    {
        private ProjectileCurve _projectileCurve;
        private DamagerAttributes _damagerAttributes;

        public ProjectileDamageCalculator(DamagerAttributes damagerAttributes, ProjectileCurve projectileCurve)
        {
            _damagerAttributes = damagerAttributes;
            _projectileCurve = projectileCurve;
        }
        public float CalculateDamage()
        {
            var damage = _damagerAttributes.Damage.CurrentValue;
            if (_damagerAttributes.IsDamageRandom)
            {
                var randomDamageValue = Random.Range
                    (-_damagerAttributes.RandomDamageRange.CurrentValue,
                    _damagerAttributes.RandomDamageRange.CurrentValue);

                damage += randomDamageValue;

                if (damage <= 0)
                {
                    damage = 1f;
                }
            }

            if (_damagerAttributes.IsDamageReduction)
            {
                damage = damage * _projectileCurve.GetDamageCoefficient();
            }

            return damage;
        }
    }
}
