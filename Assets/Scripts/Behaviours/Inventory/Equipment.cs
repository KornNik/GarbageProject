using Behaviours.Items;
using System;
using System.Collections.Generic;

namespace Behaviours
{
    class Equipment : IInventory
    {
        public event Action WeaponEquiped;
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

        public void AddItem(Item item)
        {
            if (item is Weapon)
            {
                _weapon = item as Weapon;
                WeaponEquiped?.Invoke();
            }
            else if (item is Armor)
            {
                var armor = item as Armor;
                _armors[armor.ArmorType] = armor;
            }
        }
        public void RemoveItem(Item item)
        {
            if(item is Weapon)
            {
                if(ReferenceEquals(_weapon, null))
                {
                    _weapon = null;
                }
            }
            else if(item is Armor)
            {
                var armor = item as Armor;
                if (_armors.ContainsKey(armor.ArmorType))
                {
                    _armors[armor.ArmorType] = null;
                }
            }
        }
    }

}
