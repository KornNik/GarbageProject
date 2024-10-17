using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Attributes
{
    [Serializable]
    class Stat<T> where T : IBaseAttribute
    {
        public Action OnStatChanged;

        public readonly T Source;
        public readonly float BaseValue;
        public readonly ReadOnlyCollection<StatModifier> Modifiers;

        protected readonly List<StatModifier> _modifiers;
        protected readonly StatsCalculator _statsCalculator;

        protected float _currentValue;

        public virtual float CurrentValue => _currentValue;

        public Stat()
        {
            _modifiers = new List<StatModifier>();
            Modifiers = _modifiers.AsReadOnly();
        }
        public Stat(float baseValue, T source) : this()
        {
            Source = source;
            BaseValue = baseValue;
            _currentValue = baseValue;
            _statsCalculator = new StatsCalculator(_modifiers, BaseValue);
        }
        public virtual void AddModifier(StatModifier modifier)
        {
            if (modifier.Value != 0)
            {
                _modifiers.Add(modifier);
                _modifiers.Sort(delegate (StatModifier a, StatModifier b)
                {
                    return a.Order.CompareTo(b.Order);
                });
                _currentValue = CalculateFinalValue();
            }
            OnStatChanged?.Invoke();
        }
        public virtual void RemoveModifier(StatModifier modifier)
        {
            if (modifier.Value != 0)
            {
                _modifiers.Remove(modifier);
                _currentValue = CalculateFinalValue();
            }
            OnStatChanged?.Invoke();
        }
        protected virtual float CalculateFinalValue()
        {
            float calculatedValue = BaseValue;
            calculatedValue = _statsCalculator.CalculateStat();
            return calculatedValue;
        }
    }
}
