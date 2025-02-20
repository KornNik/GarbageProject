using Data;
using Helpers;
using System.Collections.Generic;

namespace Behaviours
{
    enum InventoryEventType
    {
        None,
        InventoryChanged,
        SendInventoryList
    }
    struct InventoryEvent
    {
        private InventoryEventType _inventoryEventType;
        private List<ItemInfoDefault> _eventItems;
        private static InventoryEvent _inventoryEvent;

        public InventoryEventType InventoryEventType  => _inventoryEventType;
        public List<ItemInfoDefault> Items => _eventItems;

        public static void Trigger(List<ItemInfoDefault> eventItems)
        {
            _inventoryEvent._eventItems = eventItems;
            EventManager.TriggerEvent(_inventoryEvent);
        }
    }
    struct InventoryUIEvent
    {
        private static InventoryUIEvent _inventoryUIEvent;
        public static void Trigger()
        {
            EventManager.TriggerEvent(_inventoryUIEvent);
        }
    }
}