using Data;

namespace Behaviours.Items
{
    interface IItem
    {
        ItemData ItemData { get; set; }
        void DropItem();
        void GrabItem();
    }
}
