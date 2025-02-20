using UnityEngine;
using Helpers;
using Data;
using System.Collections.Generic;
using Behaviours;

namespace UI
{
    class InventoryUI : MonoBehaviour, IEventListener<InventoryEvent>
    {
        [SerializeField] private Transform _slotsSpawnTransform;

        private List<ItemSlot> _slots;
        private InventoryData _inventoryData;
        private BasePool<ItemSlot> _inventorySlots;

        private void Awake()
        {
            _inventoryData = Services.Instance.DatasBundle.ServicesObject.GetData<InventoryData>();
            _slots = new List<ItemSlot>(_inventoryData.ItemsLimit);
            _inventorySlots = new BasePool<ItemSlot>(() => PreLoad(_inventoryData.SlotPrefab), GetAction, ReturnAction, _inventoryData.ItemsLimit);
            GetAllSlots();
        }
        private void OnEnable()
        {
            this.EventStartListening<InventoryEvent>();
            InventoryUIEvent.Trigger();
        }
        private void OnDisable()
        {
            this.EventStopListening<InventoryEvent>();
        }

        private void GetAllSlots()
        {
            for (int i = 0; i < _inventoryData.ItemsLimit; i++)
            {
                var slot = _inventorySlots.Get();
                _slots.Add(slot);
            }
        }
        private void UpdateInventory(List<ItemInfoDefault> itemsData)
        {
            ClearAllSlots();
            for (int i = 0;i < itemsData.Count; i++)
            {
                _slots[i].FillSlot(itemsData[i]);
            }
        }
        private void ClearSlot(ItemInfoDefault itemData)
        {
            for(int i = 0;i < _slots.Count; i++)
            {
                if(_slots[i].ItemData.ItemData == itemData.ItemData)
                {
                    _slots[i].ClearSlot();
                }
            }
        }
        private void ClearAllSlots()
        {
            for (int i = 0; i < _slots.Count; i++)
            {
                _slots[i].ClearSlot();
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


        #region PoolMethods

        public ItemSlot PreLoad(ItemSlot prefab)
        {
            var slot = Instantiate(prefab);
            slot.transform.parent = _slotsSpawnTransform;
            return slot;
        }
        public void GetAction(ItemSlot itemSlot) => itemSlot.ActivateSlot();
        public void ReturnAction(ItemSlot itemSlot) => itemSlot.DeactivateSlot();

        #endregion


        #region EventTriggers

        public void OnEventTrigger(InventoryEvent eventType)
        {
            UpdateInventory(eventType.Items);
        }

        #endregion


    }

}
