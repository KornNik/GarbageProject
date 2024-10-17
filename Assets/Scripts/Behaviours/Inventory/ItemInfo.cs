using Data;

namespace Behaviours
{
    struct ItemInfo
    {
        public ItemData ItemData;
        public int Quantity;

        public ItemInfo(ItemData itemData, int quantity)
        {
            ItemData = itemData;
            Quantity = quantity;
        }
    }
}
