using System.Collections.Generic;
using UnityEngine;
using Helpers;
using System;
using Data;

namespace Behaviours
{
    [Serializable]
    struct EquipmentArmor
    {
        public ArmorType ArmorType;
        public EquipmentSlot Slot;
    }
    class EquipmentUI : MonoBehaviour, IEventListener<EquipmentEvent>
    {
        [SerializeField] private EquipmentSlot _weaponSlot;
        [SerializeField] private EquipmentArmor[] _equipmentArmor;

        private Dictionary<ArmorType, EquipmentSlot> _armors;

        private void Awake()
        {
            FillDictionary();
            ActivateAllSlots();
        }
        private void OnEnable()
        {
            this.EventStartListening<EquipmentEvent>();
            EquipmentUIEvent.Trigger();
        }
        private void OnDisable()
        {
            this.EventStopListening<EquipmentEvent>();
        }

        private void FillDictionary()
        {
            _armors = new Dictionary<ArmorType, EquipmentSlot>(_equipmentArmor.Length);
            for (int i = 0; i < _equipmentArmor.Length; i++)
            {
                _armors.Add(_equipmentArmor[i].ArmorType, _equipmentArmor[i].Slot);
            }
        }
        private void ActivateAllSlots()
        {
            _weaponSlot.ActivateSlot();
            for (int i = 0; i < _armors.Count; i++)
            {
                _equipmentArmor[i].Slot.ActivateSlot();
            }
        }
        private void UpdateEquipment(ItemInfoDefault itemInfo, ItemUsingType itemType)
        {
            if (itemType == ItemUsingType.Weapon)
            {
                _weaponSlot.FillSlot(itemInfo);
            }
            else if (itemType == ItemUsingType.HeadArmor)
            {
                _armors[ArmorType.Helmet].FillSlot(itemInfo);
            }
            else if (itemType == ItemUsingType.BodyArmor)
            {
                _armors[ArmorType.Body].FillSlot(itemInfo);
            }
        }
        private void ClearSlot(ItemUsingType itemType)
        {
            if(itemType == ItemUsingType.Weapon)
            {
                _weaponSlot.ClearSlot();
            }
            else if(itemType == ItemUsingType.HeadArmor)
            {
                _armors[ArmorType.Helmet].ClearSlot();
            }
            else if (itemType == ItemUsingType.BodyArmor)
            {
                _armors[ArmorType.Body].ClearSlot();
            }
        }

        public void OnEventTrigger(EquipmentEvent eventType)
        {
            if(eventType.EventType== EquipmentEventType.Remove)
            {
                ClearSlot(eventType.ItemType);
            }
            else if(eventType.EventType == EquipmentEventType.Change)
            {
                UpdateEquipment(eventType.ChangedItem, eventType.ItemType);
            }
        }
    }

}
