using Data;
using Helpers;

namespace Behaviours
{
    enum InventoryEventType
    {
        None,
        InventoryChanged,
    }
    struct InventoryEvent
    {
        private InventoryEventType _inventoryEventType;
        private static InventoryEvent _inventoryEvent;

        public InventoryEventType InventoryEventType  => _inventoryEventType;

        public static void Trigger(InventoryEventType inventoryEventType)
        {
            _inventoryEvent._inventoryEventType = inventoryEventType;
            EventManager.TriggerEvent(_inventoryEvent);
        }
    }
    enum EquipmentEventType
    {
        None,
        EquipmentChanged
    }
    struct EquipmentEvent
    {
        private EquipmentEventType _eventType;
        private static EquipmentEvent _equipmentEvent;

        public EquipmentEventType EventType => _eventType;

        public static void Trigger(EquipmentEventType eventType)
        {
            _equipmentEvent._eventType = eventType;
            EventManager.TriggerEvent(_equipmentEvent);
        }
    }
    enum SlotEventType
    {
        None,
        ItemDroped,
        ItemMovedToInventory,
        ItemMovedToEquipment
    }
    struct SlotEvent
    {
        private ItemData _itemData;
        private SlotEventType _slotEventType;

        private static SlotEvent _slotEvent;

        public ItemData ItemData => _itemData;
        public SlotEventType SlotEventType => _slotEventType;

        public static void Trigger(ItemData ItemData, SlotEventType slotEventType)
        {
            _slotEvent._itemData = ItemData;
            _slotEvent._slotEventType = slotEventType;
            EventManager.TriggerEvent(_slotEvent);
        }
    }
}