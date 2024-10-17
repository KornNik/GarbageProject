namespace Behaviours
{
    sealed class EquipmentSlot : ItemSlot
    {
        private void OnSelectButtonDown()
        {
            InventorySlotEvent.Trigger(ItemData, SlotEventType.ItemMovedToInventory);
            ClearSlot();
        }
    }

}
