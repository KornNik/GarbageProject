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
        [SerializeField,TextArea] private string _description;
        [SerializeField] private int _cost;
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private ItemUsingType _itemUsingType;
        [SerializeField] private int _quantityMaxStack;
        [SerializeField] private bool _isQuantity = false;

        public int Cost => _cost;
        public Sprite Icon => _icon;
        public string Name => _name;
        public GameObject Prefab => _prefab;
        public bool IsQuantity => _isQuantity;
        public string Description => _description;
        public int QuantityMaxStack => _quantityMaxStack;
        public ItemUsingType ItemUsingType  => _itemUsingType;
    }
}
