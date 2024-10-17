namespace Attributes
{
    abstract class ObjectAttribute<T> : IBaseAttribute where T : struct
    {
        protected T _maxValue;
        protected T _minValue;
        protected T _currentValue;

        protected Stat<ObjectAttribute<T>> _stat;

        public T MaxValue => _maxValue;
        public T MinValue => _minValue;
        public T CurrentValue => _currentValue;

        public ObjectAttribute()
        {

        }
        public ObjectAttribute(T maxValue, T minValue, T currentValue) : this()
        {
            _maxValue = maxValue;
            _minValue = minValue;
            _currentValue = currentValue;
        }

        public bool AddModifier(StatModifier newModifier)
        {
            if (newModifier != null)
            {
                _stat.AddModifier(newModifier);
                CheckValueBounds();
                return true;
            }
            else { return false; }
        }
        public bool RemoveModifier(StatModifier newModifier)
        {
            if (newModifier != null)
            {
                _stat.RemoveModifier(newModifier);
                CheckValueBounds();
                return true;
            }
            else { return false; }
        }
        public abstract bool CheckValueBounds();
    }
}
