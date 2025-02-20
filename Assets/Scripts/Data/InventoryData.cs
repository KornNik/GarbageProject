using Behaviours;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Data/InventoryData")]
    sealed class InventoryData : ScriptableObject
    {
        [SerializeField] private int _itemsLimit;
        [SerializeField] private ItemSlot _slotPrefab;

        public int ItemsLimit => _itemsLimit;
        public ItemSlot SlotPrefab => _slotPrefab;
    }
}
