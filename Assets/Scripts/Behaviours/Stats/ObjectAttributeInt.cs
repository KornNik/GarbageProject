using System;
using UnityEngine;

namespace Attributes
{
    [Serializable]
    struct AttributeDataInt
    {
        public int MaxValue;
        public int MinValue;
        public int CurrentValue;
    }
    sealed class ObjectAttributeInt : ObjectAttribute<int>
    {
        public ObjectAttributeInt() : base()
        {
            _stat = new Stat<ObjectAttribute<int>>(_currentValue, this);
        }
        public ObjectAttributeInt(AttributeDataInt attributeData) : this()
        {
            _maxValue = attributeData.MaxValue;
            _minValue = attributeData.MinValue;
            _currentValue = attributeData.CurrentValue;
        }
        public ObjectAttributeInt(int maxValue, int minValue, int currentValue) : base(maxValue, minValue, currentValue) { }

        public override bool CheckValueBounds()
        {
            var calculatedValue = _stat.CurrentValue;
            if (calculatedValue > MaxValue)
            {
                _currentValue = MaxValue;
                return false;
            }
            else if (calculatedValue < MinValue)
            {
                _currentValue = MinValue;
                return false;
            }
            else
            {
                _currentValue = Mathf.FloorToInt(_stat.CurrentValue);
                return true;
            }
        }
    }
}
