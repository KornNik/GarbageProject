using Behaviours.Items;
using System;
using System.Collections.Generic;

namespace Behaviours
{
    class Equipment : IInventory
    {
        public event Action<bool> WeaponEquiped;
        private Weapon _weapon;
        private Dictionary<ArmorType, Item> _armors = new Dictionary<ArmorType, Item>(2);

        public Weapon Weapon => _weapon;

        public Equipment()
        {
            CreateArmorSlots();
        }

        private void CreateArmorSlots()
        {
            _armors.Add(ArmorType.Body, null);
            _armors.Add(ArmorType.Helmet, null);
        }

        public bool IsWeaponEquiped()
        {
            if(ReferenceEquals(null, _weapon))return false;
            else return true;
        }

        public bool AddItem(Item item)
        {
            if (item is Weapon)
            {
                _weapon = item as Weapon;
                WeaponEquiped?.Invoke(true);
                return true;
            }
            else if (item is Armor)
            {
                var armor = item as Armor;
                _armors[armor.ArmorType] = armor;
                return true;
            }
            return false;
        }
        public bool RemoveItem(Item item)
        {
            if(item is Weapon)
            {
                if(ReferenceEquals(_weapon, null))
                {
                    _weapon = null;
                    WeaponEquiped?.Invoke(false);
                    return true;
                }
                return false;
            }
            else if(item is Armor)
            {
                var armor = item as Armor;
                if (_armors.ContainsKey(armor.ArmorType))
                {
                    _armors[armor.ArmorType] = null;
                    return true;
                }
                return false;
            }
            return false;
        }
    }

}
