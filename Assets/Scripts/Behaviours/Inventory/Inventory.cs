using Behaviours.Items;
using System.Collections.Generic;

namespace Behaviours
{
    interface IInventory
    {
        void AddItem(Item item);
        void RemoveItem(Item selectedItem);
    }
    class Inventory : IInventory
    {
        private HashSet<Item> _items;

        public void AddItem(Item item)
        {
            _items.Add(item);
            InventoryEvent.Trigger();
        }
        public void RemoveItem(Item selectedItem)
        {
            _items.Remove(selectedItem);
            InventoryEvent.Trigger();
        }
    }
}
