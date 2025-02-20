using Data;
using Helpers;

namespace Behaviours
{
    enum SlotEventType
    {
        None,
        ItemDroped,
        ItemMovedToInventory,
        ItemMovedToEquipment
    }
    struct SlotEvent
    {
        private ItemInfoDefault _itemData;
        private SlotEventType _slotEventType;

        private static SlotEvent _slotEvent;

        public ItemInfoDefault ItemData => _itemData;
        public SlotEventType SlotEventType => _slotEventType;

        public static void Trigger(ItemInfoDefault ItemData, SlotEventType slotEventType)
        {
            _slotEvent._itemData = ItemData;
            _slotEvent._slotEventType = slotEventType;
            EventManager.TriggerEvent(_slotEvent);
        }
    }
    struct EquipmentSlotEvent 
    {
        private ItemInfoDefault _itemData;
        private SlotEventType _slotEventType;

        private static EquipmentSlotEvent _equipmentSlotEvent;

        public ItemInfoDefault ItemData => _itemData;
        public SlotEventType SlotEventType => _slotEventType;

        public static void Trigger(ItemInfoDefault ItemData, SlotEventType slotEventType)
        {
            _equipmentSlotEvent._itemData = ItemData;
            _equipmentSlotEvent._slotEventType = slotEventType;
            EventManager.TriggerEvent(_equipmentSlotEvent);
        }
    }

}