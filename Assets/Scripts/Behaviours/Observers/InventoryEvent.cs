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
        private static InventoryEvent _inventoryEvent;

        public static void Trigger()
        {
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
    struct InventorySlotEvent
    {
        private ItemData _itemData;
        private SlotEventType _slotEventType;
        private static InventorySlotEvent _inventorySlotEvent;

        public ItemData ItemData => _itemData;
        public SlotEventType SlotEventType => _slotEventType;

        public static void Trigger(ItemData ItemData, SlotEventType SlotEventType)
        {
            EventManager.TriggerEvent(_inventorySlotEvent);
        }
    }
}