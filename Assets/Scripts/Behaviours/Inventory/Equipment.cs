using Behaviours.Items;
using Data;
using Helpers;
using Helpers.Extensions;
using System;
using System.Collections.Generic;

namespace Behaviours
{
    class Equipment : IInventory, IEventListener<SlotEvent>, IEventListener<EquipmentUIEvent>, IDisposable
    {
        public event Action<bool> WeaponEquiped;
        public event Action<bool> ArmorEquipped;

        private Weapon _weapon;
        private Dictionary<ArmorType, Item> _armors = new Dictionary<ArmorType, Item>(2);

        public Weapon Weapon => _weapon;

        public Equipment()
        {
            CreateArmorSlots();
            this.EventStartListening<SlotEvent>();
            this.EventStartListening<EquipmentUIEvent>();
        }

        public void Dispose()
        {
            this.EventStopListening<SlotEvent>();
            this.EventStopListening<EquipmentUIEvent>();
        }

        private void CreateArmorSlots()
        {
            _armors.Add(ArmorType.Body, null);
            _armors.Add(ArmorType.Helmet, null);
        }

        public bool IsWeaponEquiped()
        {
            if (ReferenceEquals(_weapon, null)) { return false; }
            return true;
        }
        public bool IsArmorSlotEquiped(ArmorType armorToCheck)
        {
            if (ReferenceEquals(_armors[armorToCheck], null)) { return false; }
            return true;
        }
        public bool TryAddItem(ItemInfoDefault itemInfo)
        {
            var armorType = ArmorTypeConverter.GetArmorType(itemInfo.ItemData.ItemUsingType);

            if (itemInfo.ItemData.ItemUsingType == ItemUsingType.Weapon)
            {
                if (IsWeaponEquiped())
                {
                    //Send weapon to inventory
                }
                _weapon = itemInfo.GetItem() as Weapon;
                WeaponEquiped?.Invoke(true);
                EquipmentEvent.Trigger(EquipmentEventType.Change, itemInfo.ItemData.ItemUsingType, itemInfo);
                return true;
            }
            else if (armorType != ArmorType.None)
            {
                if (IsArmorSlotEquiped(armorType))
                {
                    //Send armor to inventory
                }
                _armors[armorType] = itemInfo.GetItem();
                ArmorEquipped?.Invoke(true);
                EquipmentEvent.Trigger(EquipmentEventType.Change, itemInfo.ItemData.ItemUsingType, itemInfo);
                return true;
            }
            return false;
        }

        public bool TryRemoveItem(ItemInfoDefault itemInfo)
        {
            if (itemInfo.ItemData.ItemUsingType == ItemUsingType.Weapon)
            {
                if (!ReferenceEquals(_weapon, null))
                {
                    WeaponEquiped?.Invoke(false);
                    EquipmentEvent.Trigger(EquipmentEventType.Remove, itemInfo.ItemData.ItemUsingType, itemInfo);
                    return true;
                }
                return false;
            }
            else if (itemInfo.ItemData.ItemUsingType == ItemUsingType.HeadArmor ||
                itemInfo.ItemData.ItemUsingType == ItemUsingType.BodyArmor)
            {
                if (!ReferenceEquals(_weapon, null))
                {

                }
                EquipmentEvent.Trigger(EquipmentEventType.Remove, itemInfo.ItemData.ItemUsingType, itemInfo);
                return true;
            }
            return false;
        }

        public void AddItem(ItemInfoDefault item)
        {

        }

        public void RemoveItem(ItemInfoDefault item)
        {

        }

        public void OnEventTrigger(SlotEvent eventType)
        {
            if (eventType.SlotEventType == SlotEventType.ItemMovedToEquipment)
            {
                if (!TryAddItem(eventType.ItemData))
                {
                    SlotEvent.Trigger(eventType.ItemData, SlotEventType.ItemMovedToInventory);
                }
            }
        }

        public void OnEventTrigger(EquipmentUIEvent eventType)
        {

        }
    }
}
