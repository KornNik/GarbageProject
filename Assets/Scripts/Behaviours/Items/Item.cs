using Data;
using UnityEngine;

namespace Behaviours.Items
{
    abstract class Item : MonoBehaviour, IItem, IMovable, IInteractable<Equipment>
    {
        [SerializeField] private ItemData _data;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Collider _interactionCollider;
        [SerializeField, Range(0, 999)] private int _quantity = 1;
        [SerializeField, Range(0, 100)] private int _condition = 100;

        private bool _isAllowInteract = false;

        public ItemData ItemData { get => _data; set => ItemData = value; }

        protected virtual void Awake()
        {
            
        }
        protected virtual void OnEnable()
        {

        }
        protected virtual void OnDisable()
        {
            
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

        public void Interact(Equipment interactObject)
        {
            if (interactObject.AddItem(this))
            {
                Debug.Log($"Interacting{this}");
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
