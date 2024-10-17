using Attributes;
using System.Collections.Generic;

namespace Data
{
    struct UnitAttributeFloat
    {
        private ObjectAttributeFloat _attribute;
        private List<StatModifier> __attributeStatModifiers;

        public UnitAttributeFloat(AttributeDataFloat attributeData)
        {
            _attribute = new ObjectAttributeFloat(attributeData);
            __attributeStatModifiers = new List<StatModifier>();
        }

        public ObjectAttributeFloat Attribute => _attribute;
    }
}
