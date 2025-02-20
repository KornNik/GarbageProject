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

        private ItemInfoDefault _itemData;
        private bool _isEmpty;

        public ItemInfoDefault ItemData => _itemData;
        public bool IsEmpty => _isEmpty;

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

        public void FillSlot(ItemInfoDefault itemInfo)
        {
            _itemData = itemInfo;
            _itemIcon.sprite = itemInfo.ItemData.Icon;
            _itemName.text = itemInfo.ItemData.Name;
            _removeItemButton.gameObject.SetActive(true);
            _isEmpty = false;
            if (itemInfo.ItemData.IsQuantity)
            {
                _itemQuantity.text = NumericalFormatter.FormatNumberString(ItemData.Quantity.ToString());
            }
        }
        public void ClearSlot()
        {
            _itemData = null;
            _itemIcon.sprite = _emptySlotSprite;
            _itemName.text = null;
            _itemQuantity.text = null;
            _removeItemButton.gameObject.SetActive(false);
            _isEmpty = true;
        }
        public void ActivateSlot()
        {
            gameObject.SetActive(true);
            ClearSlot();
        }
        public void DeactivateSlot()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnRemoveButtonDown()
        {
            SlotEvent.Trigger(_itemData,SlotEventType.ItemDroped);
        }
        protected virtual void OnSelectButtonDown()
        {
            SlotEvent.Trigger(_itemData, SlotEventType.ItemMovedToEquipment);
        }
    }

}
