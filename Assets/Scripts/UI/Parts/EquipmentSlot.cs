namespace Behaviours
{
    sealed class EquipmentSlot : ItemSlot
    {
        protected override void OnSelectButtonDown()
        {
            EquipmentSlotEvent.Trigger(ItemData, SlotEventType.ItemMovedToInventory);
        }
        protected override void OnRemoveButtonDown()
        {
            EquipmentSlotEvent.Trigger(ItemData, SlotEventType.ItemDroped);
        }
    }

}
