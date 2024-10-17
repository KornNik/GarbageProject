using UnityEngine;
using Helpers;

namespace Behaviours
{
    class InventoryUI : MonoBehaviour, IEventListener<InventorySlotEvent>
    {
        private const int INVENTORY_SLOTS_NUMBER = 20;

        [SerializeField] private ItemSlot _slotPrefab;
        [SerializeField] private Transform _slotsSpawnTransform;

        private BasePool<ItemSlot> _inventorySlots;

        private void Awake()
        {
            _inventorySlots = new BasePool<ItemSlot>(() => PreLoad(_slotPrefab), GetAction, ReturnAction, INVENTORY_SLOTS_NUMBER);
            GetAllSlots();
        }
        private void OnEnable()
        {
            this.EventStartListening<InventorySlotEvent>();
            UpdateInventoryOnEnable();
        }
        private void OnDisable()
        {
            this.EventStopListening<InventorySlotEvent>();
        }

        public ItemSlot PreLoad(ItemSlot prefab)
        {
            var slot = Instantiate(prefab);
            slot.transform.parent = _slotsSpawnTransform;
            return slot;
        }
        public void GetAction(ItemSlot itemSlot) => itemSlot.gameObject.SetActive(true);
        public void ReturnAction(ItemSlot itemSlot) => itemSlot.gameObject.SetActive(false);

        private void GetAllSlots()
        {
            for (int i = 0; i < INVENTORY_SLOTS_NUMBER; i++)
            {
                _inventorySlots.Get();
            }
        }
        private void UpdateInventoryOnEnable()
        {

        }

        public void OnEventTrigger(InventorySlotEvent eventType)
        {
            if(eventType.SlotEventType == SlotEventType.ItemDroped)
            {

            }
            else if(eventType.SlotEventType == SlotEventType.ItemMovedToEquipment)
            {

            }
            else if (eventType.SlotEventType == SlotEventType.ItemMovedToInventory)
            {

            }
        }
    }

}
