using Behaviours;
using Data;

namespace Helpers.Extensions
{
    static class ArmorTypeConverter
    {
        public static ArmorType GetArmorType(ItemUsingType usingType)
        {
            if(usingType == ItemUsingType.HeadArmor)
            {
                return ArmorType.Helmet;
            }
            else if(usingType == ItemUsingType.BodyArmor)
            {
                return ArmorType.Body;
            }
            return ArmorType.None; // Default to None if no armor type found.
        }
        public static ItemUsingType GetItemType(ArmorType armorType)
        {
            if (armorType == ArmorType.Helmet)
            {
                return ItemUsingType.HeadArmor;
            }
            else if (armorType == ArmorType.Body)
            {
                return ItemUsingType.BodyArmor;
            }
            return ItemUsingType.None; // Default to None if no armor type found.
        }
    }
}
