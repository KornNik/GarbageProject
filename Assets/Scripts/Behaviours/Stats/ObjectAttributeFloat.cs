using System;

namespace Attributes
{
    [Serializable]
    struct AttributeDataFloat
    {
        public float MaxValue;
        public float MinValue;
        public float CurrentValue;

        public AttributeDataFloat(float maxValue, float minValue, float currentValue)
        {
            MaxValue = maxValue;
            MinValue = minValue;
            CurrentValue = currentValue;
        }
    }
    class ObjectAttributeFloat : ObjectAttribute<float>
    {
        public ObjectAttributeFloat() : base()
        {
            _stat = new Stat<ObjectAttribute<float>>(_currentValue, this);
        }
        public ObjectAttributeFloat(AttributeDataFloat attributesData) : this()
        {
            _maxValue = attributesData.MaxValue;
            _minValue = attributesData.MinValue;
            _currentValue = attributesData.CurrentValue;
        }
        public ObjectAttributeFloat(float maxValue, float minValue, float currentValue):base (maxValue, minValue, currentValue) { }

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
                _currentValue = _stat.CurrentValue;
                return true;
            }
        }
    }
}
