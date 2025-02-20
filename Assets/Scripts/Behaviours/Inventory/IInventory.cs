using Data;

namespace Behaviours
{
    interface IInventory
    {
        bool TryAddItem(ItemInfoDefault item);
        bool TryRemoveItem(ItemInfoDefault item);
        void AddItem(ItemInfoDefault item);
        void RemoveItem(ItemInfoDefault item);
    }

}
