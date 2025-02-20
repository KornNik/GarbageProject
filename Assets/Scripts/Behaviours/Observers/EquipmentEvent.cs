using Data;
using Helpers;

namespace Behaviours
{
    struct EquipmentItems
    {
        public ItemInfoDefault Weapon;
        public ItemInfoDefault Helmet;
        public ItemInfoDefault BodyArmor;

        public EquipmentItems(ItemInfoDefault weapon, ItemInfoDefault helmet, ItemInfoDefault bodyArmor)
        {
            Weapon = weapon;
            Helmet = helmet;
            BodyArmor = bodyArmor;
        }
    }
    enum EquipmentEventType
    {
        None,
        Change,
        Remove
    }
    struct EquipmentEvent
    {
        private EquipmentEventType _eventType;
        private ItemInfoDefault _changedItem;
        private ItemUsingType _itemType;
        private static EquipmentEvent _equipmentEvent;

        public EquipmentEventType EventType => _eventType;
        public ItemInfoDefault ChangedItem => _changedItem;
        public ItemUsingType ItemType => _itemType;

        public static void Trigger(EquipmentEventType eventType, ItemUsingType itemType, ItemInfoDefault changedItem)
        {
            _equipmentEvent._itemType = itemType;
            _equipmentEvent._eventType = eventType;
            _equipmentEvent._changedItem = changedItem;
            EventManager.TriggerEvent(_equipmentEvent);
        }
    }
    struct EquipmentUIEvent
    {
        private static EquipmentEventType _eventType;

        public static void Trigger()
        {
            EventManager.TriggerEvent(_eventType);
        }
    }
}