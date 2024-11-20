namespace Behaviours
{
    sealed class EquipmentSlot : ItemSlot
    {
        protected override void OnSelectButtonDown()
        {
            SlotEvent.Trigger(ItemData, SlotEventType.ItemMovedToInventory);
            ClearSlot();
        }
    }

}
