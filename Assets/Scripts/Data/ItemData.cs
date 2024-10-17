using UnityEngine;

namespace Data
{
    enum ItemUsingType
    {
        None,
        HeadArmor  = 10,
        BodyArmor  = 20,
        Weapon     = 30,
        Consumable = 50
    }
    [CreateAssetMenu(fileName = "Item", menuName = "Data/item")]
    sealed class ItemData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private ItemUsingType _itemUsingType;

        public string Name => _name;
        public string Description => _description;
        public Sprite Icon => _icon;
        public GameObject Prefab => _prefab;
        public ItemUsingType ItemUsingType  => _itemUsingType;
    }
}
