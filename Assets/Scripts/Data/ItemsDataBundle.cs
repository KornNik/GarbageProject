using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ItemsBundle", menuName = "Data/Items/Bundle")]
    sealed class ItemsDataBundle : ScriptableObject
    {
        [SerializeField] private List<ItemData> _items;

        public ItemData GetRandomItem()
        {
            var random = Random.Range(0, _items.Count);
            var randomItem = _items[random];
            if (randomItem != null)
            {
                return randomItem;
            }
            else { return null; }
        }
    }
}
