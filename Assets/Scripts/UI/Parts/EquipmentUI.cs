using Data;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
using System;

namespace Behaviours
{
    [Serializable]
    struct EquipmentArmor
    {
        public ArmorType ArmorType;
        public EquipmentSlot Slot;
    }
    class EquipmentUI : MonoBehaviour, IEventListener<SlotEvent>
    {
        [SerializeField] private EquipmentSlot _weaponSlot;
        [SerializeField] private EquipmentArmor[] _equipmentArmor;

        private Dictionary<ArmorType, EquipmentSlot> _armors;

        private void Awake()
        {
            FillDictionary();
        }
        private void OnEnable()
        {
            this.EventStartListening<SlotEvent>();
            UpdateEquipmentOnEnable();
        }
        private void OnDisable()
        {
            this.EventStopListening<SlotEvent>();
        }

        private void FillDictionary()
        {
            _armors = new Dictionary<ArmorType, EquipmentSlot>(_equipmentArmor.Length);
            for (int i = 0; i < _equipmentArmor.Length; i++)
            {
                _armors.Add(_equipmentArmor[i].ArmorType, _equipmentArmor[i].Slot);
            }
        }
        private void FillEquipmentSlot(ItemData itemData)
        {
            if (itemData.ItemUsingType == ItemUsingType.HeadArmor)
            {
                _armors[ArmorType.Helmet].FillSlot(new ItemInfo(itemData, 0));
            }
            else if (itemData.ItemUsingType == ItemUsingType.BodyArmor)
            {
                _armors[ArmorType.Body].FillSlot(new ItemInfo(itemData, 0));
            }
            else if(itemData.ItemUsingType == ItemUsingType.Weapon)
            {
                Debug.Log("EquipWeapon");
                _weaponSlot.FillSlot(new ItemInfo(itemData, 0));
            }
            else
            {
                SlotEvent.Trigger(itemData, SlotEventType.ItemMovedToInventory);
            }
        }
        private void UpdateEquipmentOnEnable()
        {
            _weaponSlot.ActivateSlot();
            for (int i = 0; i < _armors.Count; i++)
            {
                _equipmentArmor[i].Slot.ActivateSlot();
            }
        }

        public void OnEventTrigger(SlotEvent eventType)
        {
            if (eventType.SlotEventType == SlotEventType.ItemMovedToEquipment)
            {
                FillEquipmentSlot(eventType.ItemData);
                EquipmentEvent.Trigger(EquipmentEventType.EquipmentChanged);
            }
        }
    }

}
