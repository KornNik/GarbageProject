using UnityEngine;
using Helpers;
using Data;
using System.Collections.Generic;

namespace Behaviours
{
    class InventoryUI : MonoBehaviour, IEventListener<SlotEvent>
    {
        private const int INVENTORY_SLOTS_NUMBER = 20;

        [SerializeField] private ItemSlot _slotPrefab;
        [SerializeField] private Transform _slotsSpawnTransform;

        private BasePool<ItemSlot> _inventorySlots;
        private List<ItemSlot> _slots;

        private void Awake()
        {
            _slots = new List<ItemSlot>(INVENTORY_SLOTS_NUMBER);
            _inventorySlots = new BasePool<ItemSlot>(() => PreLoad(_slotPrefab), GetAction, ReturnAction, INVENTORY_SLOTS_NUMBER);
            GetAllSlots();
        }
        private void OnEnable()
        {
            this.EventStartListening<SlotEvent>();
            UpdateInventoryOnEnable();
        }
        private void OnDisable()
        {
            this.EventStopListening<SlotEvent>();
        }

        public ItemSlot PreLoad(ItemSlot prefab)
        {
            var slot = Instantiate(prefab);
            slot.transform.parent = _slotsSpawnTransform;
            return slot;
        }
        public void GetAction(ItemSlot itemSlot) => itemSlot.ActivateSlot();
        public void ReturnAction(ItemSlot itemSlot) => itemSlot.DeactivateSlot();

        private void GetAllSlots()
        {
            for (int i = 0; i < INVENTORY_SLOTS_NUMBER; i++)
            {
                var slot = _inventorySlots.Get();
                _slots.Add(slot);
            }
        }
        private void UpdateInventoryOnEnable()
        {

        }
        private void FillSlot(ItemData itemData)
        {
            var emptySlot = GetEmptySlot();
            try
            {
                emptySlot.FillSlot(new ItemInfo(itemData,1));
            }
            catch (System.Exception exception)
            {
                Debug.Log($" exception description{exception}, slot status{emptySlot}, item status{itemData}");
                return;
            }
        }
        private void ClearSlot(ItemData itemData)
        {
            for(int i = 0;i < _slots.Count; i++)
            {
                if(_slots[i].ItemData == itemData)
                {
                    _slots[i].ClearSlot();
                }
            }
        }
        private ItemSlot GetEmptySlot()
        {
            for (int i = 0; i < _slots.Count; i++)
            {
                if (_slots[i].IsEmpty)
                {
                    return _slots[i];
                }
            }
            return null;
        }

        public void OnEventTrigger(SlotEvent eventType)
        {
            if (eventType.SlotEventType == SlotEventType.ItemMovedToInventory)
            {
                FillSlot(eventType.ItemData);
                InventoryEvent.Trigger(InventoryEventType.InventoryChanged);
            }
        }

        #region Test
        [ContextMenu("AddRandomItem")]
        public void TestAddItem()
        {
            for (int i = 0; i < _slots.Capacity; i++)
            { 
                FillSlot(Services.Instance.DatasBundle.ServicesObject.GetData<ItemsDataBundle>().GetRandomItem());
            }
        }
        #endregion
    }

}
