using Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Behaviours
{
    class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image _itemIcon;
        [SerializeField] private Sprite _emptySlotSprite;
        [SerializeField] private Button _removeItemButton;
        [SerializeField] private Button _selectItemButton;

        [SerializeField] private TMP_Text _itemName;
        [SerializeField] private TMP_Text _itemQuantity;

        private ItemData _itemData;

        public ItemData ItemData => _itemData;

        private void OnEnable()
        {
            _removeItemButton.onClick.AddListener(OnRemoveButtonDown);
            _selectItemButton.onClick.AddListener(OnSelectButtonDown);
        }
        private void OnDisable()
        {
            _removeItemButton.onClick.RemoveListener(OnRemoveButtonDown);
            _selectItemButton.onClick.RemoveListener(OnSelectButtonDown);
        }

        public void FillSlot(ItemInfo itemInfo)
        {
            _itemData = itemInfo.ItemData;
            _itemIcon.sprite = itemInfo.ItemData.Icon;
            _itemName.text = itemInfo.ItemData.Name;
            _itemQuantity.text = itemInfo.Quantity.ToString();
            _removeItemButton.gameObject.SetActive(true);
        }
        public void ClearSlot()
        {
            _itemData = null;
            _itemIcon.sprite = _emptySlotSprite;
            _itemName.text = "Empty";
            _itemQuantity.text = "0";
            _removeItemButton.gameObject.SetActive(false);
        }

        private void OnRemoveButtonDown()
        {
            InventorySlotEvent.Trigger(_itemData,SlotEventType.ItemDroped);
            ClearSlot();
        }
        private void OnSelectButtonDown()
        {
            InventorySlotEvent.Trigger(_itemData, SlotEventType.ItemMovedToEquipment);
            ClearSlot();
        }
    }

}
