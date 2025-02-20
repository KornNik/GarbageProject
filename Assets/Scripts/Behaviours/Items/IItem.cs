using Data;

namespace Behaviours.Items
{
    interface IItem
    {
        ItemData ItemData { get; }
        void DropItem();
        void GrabItem();
    }
}
