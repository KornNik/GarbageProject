using Behaviours.Units;
using UnityEngine;
using Attributes;

namespace Data
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Data/Attributes/UnitData")]
    sealed class UnitData : ScriptableObject
    {
        [SerializeField] private float _armor;
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _attackPower;
        [SerializeField] private float _attackRecharge;
        [SerializeField] private float _reloadSpeed;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private UnitSounds _unitSounds;

        public HealthAttribute GetHealthAttributes()
        {
            var newAttributes = new HealthAttribute
                (new AttributeDataFloat(_maxHealth, 0, _maxHealth));
            return newAttributes;
        }
        public AttributeDataFloat GetArmorAttributes()
        {
            var newAttributes = new AttributeDataFloat(_armor, 0, _armor);
            return newAttributes;
        }
        public AttributeDataFloat GetMovementAttributes()
        {
            var newAttributes = new AttributeDataFloat(_movementSpeed, 0, _movementSpeed);
            return newAttributes;
        }
    }
}
