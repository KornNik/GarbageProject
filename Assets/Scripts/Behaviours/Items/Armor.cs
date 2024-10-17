using Data;
using UnityEngine;

namespace Behaviours.Items
{
    class Armor : Item
    {
        [SerializeField] private ArmorType _armorType;

        public ArmorType ArmorType => _armorType;
    }
}