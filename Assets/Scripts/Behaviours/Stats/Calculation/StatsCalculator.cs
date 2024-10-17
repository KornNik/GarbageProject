using System;
using System.Collections.Generic;

namespace Attributes
{
    sealed class StatsCalculator
    {
        private readonly List<StatModifier> _modifiers;
        private float _baseValue;
        public StatsCalculator(List<StatModifier> modifiers, float baseValue)
        {
            _modifiers = modifiers;
            _baseValue = baseValue;
        }

        public float CalculateStat()
        {
            float finalValue = _baseValue;
            float statPercentAdd = 0f;
            for (int index = 0; index < _modifiers.Count; index++)
            {
                StatModifier modifier = _modifiers[index];

                switch (modifier.Type)
                {
                    case StatModType.None:
                        throw new Exception($"{modifier} type is none its need to be signed");
                    case StatModType.PercentAdd:
                        finalValue = CalculatePercentAdd(modifier, _modifiers, finalValue, index, ref statPercentAdd);
                        break;
                    case StatModType.Flat:
                        finalValue = CalculateFlat(modifier, finalValue);
                        break;
                    case StatModType.PercentMult:
                        finalValue = CalculatePercentMultiplier(modifier, finalValue);
                        break;
                }
            }
            if (_modifiers.Count == 0)
            {
                finalValue = _baseValue;
            }

            return finalValue;
        }
        private float CalculateFlat(StatModifier currentModifier, float value)
        {
            value += currentModifier.Value;
            return value;
        }
        private float CalculatePercentMultiplier(StatModifier currentModifier, float value)
        {
            value += value / 100 * currentModifier.Value;
            return value;
        }
        private float CalculatePercentAdd(StatModifier currentModifier, List<StatModifier> modifiers, float value, int modifierIndex,ref float statPercentAdd)
        {
            statPercentAdd += currentModifier.Value;

            if (modifierIndex + 1 >= modifiers.Count || modifiers[modifierIndex + 1].Type != StatModType.PercentAdd)
            {
                value += value / 100 * currentModifier.Value;
            }

            return value;
        }
    }
}
