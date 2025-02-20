using Behaviours.Items;
using Helpers;
using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    class ItemInfoDefault
    {
        public int Quantity;
        public ItemData ItemData;
        [Range(0, 100)] public float Condition;

        public ItemInfoDefault(float condition, ItemData itemData)
        {
            Condition = condition;
            ItemData = itemData;
        }
        public virtual void DropItem()
        {
            Transform charachterTransform = Services.Instance.PlayerGameObject.ServicesObject.transform;
            var frontCharacterPosition = charachterTransform.position + charachterTransform.forward + charachterTransform.up;
            var item = GetItem();
            item.transform.position = frontCharacterPosition;
            item.transform.rotation = charachterTransform.rotation;
            item.SetItemDataInfo(this);
            item.Move(Vector3.forward);
        }
        public virtual Item GetItem()
        {
            var item = GameObject.Instantiate(ItemData.Prefab).GetComponent<Item>();
            return item;
        }
        public void RaiseQuantityByValue(int value)
        {
            Quantity += value;
        }
        public void DecreaseQuantityByValue(int value)
        {
            Quantity -= value;
        }
        public virtual float GetCost()
        {
            var cost = ItemData.Cost * Condition / 100 * Quantity;
            return cost;
        }
    }
}
