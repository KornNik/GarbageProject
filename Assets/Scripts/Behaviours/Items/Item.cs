using Data;
using Helpers;
using UnityEngine;

namespace Behaviours.Items
{
    abstract class Item : MonoBehaviour, IItem, IMovable, IInteractable
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _interactionCollider;
        [SerializeField] private ItemInfoDefault _itemDataInfo;

        private bool _isAllowInteract = false;

        public ItemData ItemData => ItemDataInfo.ItemData;
        public ItemInfoDefault ItemDataInfo => _itemDataInfo;

        protected virtual void Awake()
        {
            
        }
        protected virtual void OnEnable()
        {

        }
        protected virtual void OnDisable()
        {
            
        }

        public void SetItemDataInfo(ItemInfoDefault itemDataInfo)
        {
            _itemDataInfo.Quantity = itemDataInfo.Quantity;
            _itemDataInfo.Condition = itemDataInfo.Condition;
        }
        public void DropItem()
        {
            _isAllowInteract = true;
            _rigidbody.isKinematic = false;
            _interactionCollider.enabled = true;
            Move(gameObject.transform.forward);
        }
        public void GrabItem()
        {
            _isAllowInteract = false;
            _rigidbody.isKinematic = true;
            _interactionCollider.enabled = false;
            Destroy(gameObject);
        }
        public void Interact(IInteracter interacter)
        {
            if (Services.Instance.PlayerGameObject.PlayerModel.Inventory.TryAddItem(_itemDataInfo))
            {
                GrabItem();
            }
        }
        public void Move(Vector3 movement)
        {
            _rigidbody.AddForce(transform.forward);
        }
        public void StopMovement()
        {

        }
    }
}
