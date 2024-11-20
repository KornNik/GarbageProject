using Behaviours.Items;
using System.Collections.Generic;

namespace Behaviours
{
    interface IInventory
    {
        bool AddItem(Item item);
        bool RemoveItem(Item selectedItem);
    }
    class Inventory : IInventory
    {
        private HashSet<Item> _items;

        public bool AddItem(Item item)
        {
            _items.Add(item);
            InventoryEvent.Trigger(InventoryEventType.InventoryChanged);
            return true;
        }
        public bool RemoveItem(Item selectedItem)
        {
            _items.Remove(selectedItem);
            InventoryEvent.Trigger(InventoryEventType.InventoryChanged);
            return true;
        }
    }
}
