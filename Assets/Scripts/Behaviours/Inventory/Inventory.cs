using Data;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Behaviours
{
    class Inventory : IInventory, IEventListener<InventoryUIEvent>,
        IEventListener<SlotEvent>, IEventListener<EquipmentSlotEvent>, IDisposable
    {
        private InventoryData _inventoryData;
        private HashSet<ItemInfoDefault> _items;

        /// <summary>
        /// cached item list for UI
        /// </summary>
        private List<ItemInfoDefault> _itemsList;

        public Inventory()
        {
            _inventoryData = Services.Instance.DatasBundle.ServicesObject.GetData<InventoryData>();
            _items = new HashSet<ItemInfoDefault>(_inventoryData.ItemsLimit);
            _itemsList = new List<ItemInfoDefault>(_inventoryData.ItemsLimit);
            this.EventStartListening<InventoryUIEvent>();
            this.EventStartListening<SlotEvent>();
        }
        public void Dispose()
        {
            _items.Clear();
            _itemsList.Clear();
            _items = null;
            _itemsList = null;
            this.EventStopListening<InventoryUIEvent>();
            this.EventStopListening<SlotEvent>();
        }

        private void SendItemsToUI()
        {
            _itemsList.Clear();
            _itemsList.AddRange(_items);
            InventoryEvent.Trigger(_itemsList);
        }


        #region IInventory

        public void AddItem(ItemInfoDefault item)
        {

        }
        public void RemoveItem(ItemInfoDefault item)
        {

        }
        public bool TryAddItem(ItemInfoDefault item)
        {
            var itemInInventory = _items.FirstOrDefault
                (tempItem => tempItem.ItemData == item.ItemData);

            if (itemInInventory != null)
            {
                if (itemInInventory.ItemData.IsQuantity)
                {
                    itemInInventory.RaiseQuantityByValue(item.Quantity);
                    SendItemsToUI();
                    return true;
                }
                else
                {
                    _items.Add(item);
                    SendItemsToUI();
                    return true;
                }
            }
            else if (_items.Count != _inventoryData.ItemsLimit)
            {
                _items.Add(item);
                SendItemsToUI();
                return true;
            }

            return false;
        }
        public bool TryRemoveItem(ItemInfoDefault item)
        {
            if (_items.Contains(item))
            {
                var neededItem = _items.FirstOrDefault
                    (tempItem => tempItem.ItemData == item.ItemData);
                neededItem.DropItem();
                _items.Remove(neededItem);
                SendItemsToUI();
                return true;
            }
            return false;
        }

        #endregion


        #region EventTriggers

        public void OnEventTrigger(SlotEvent eventType)
        {
            if (eventType.SlotEventType == SlotEventType.ItemDroped)
            {
                TryRemoveItem(eventType.ItemData);
            }
            else if (eventType.SlotEventType == SlotEventType.ItemMovedToEquipment)
            {
                TryRemoveItem(eventType.ItemData);
            }
        }
        public void OnEventTrigger(EquipmentSlotEvent eventType)
        {
            if(eventType.SlotEventType == SlotEventType.ItemMovedToInventory)
            {
                if (!TryAddItem(eventType.ItemData))
                {
                    eventType.ItemData.DropItem();
                }
            }
        }
        public void OnEventTrigger(InventoryUIEvent eventType)
        {
            SendItemsToUI();
        }

        #endregion


    }
}
