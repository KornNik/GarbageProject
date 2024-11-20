using Behaviours.States;
using Data;
using Helpers;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviours.Units
{
    abstract class UnitModel : MonoBehaviour
    {
        [SerializeField] private UnitData _unitData;
        [SerializeField] private UnitSounds _unitSounds;
        [SerializeField] private UnitAnimation _unitAnimation;
        [SerializeField] private Collider _collider;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _gunTransform;

        protected Jump _jump;
        protected Combat _combat;
        protected Movement _movement;
        protected Rotation _rotation;
        protected UnitEvents _unitEvents;
        protected UnitAttributesContainer _unitAttributes;
        protected CharacterStateController _characterStateController;
        protected IInteracter _interacter;
        protected Crouch _crouch;

        private Inventory _inventory;
        private Equipment _equipment;

        protected List<IEventSubscription> _subsciptions;

        public Jump Jump => _jump;
        public Crouch Crouch =>_crouch;
        public Combat Combat => _combat;
        public Collider Collider => _collider;
        public UnitData UnitData => _unitData;
        public Rotation Rotation => _rotation;
        public Movement Movement => _movement;
        public UnitEvents UnitEvents => _unitEvents;
        public UnitSounds UnitSounds => _unitSounds;
        public IInteracter Interacter => _interacter;
        public UnitAnimation UnitAnimation => _unitAnimation;
        public UnitAttributesContainer UnitAttributes => _unitAttributes;
        public CharacterStateController CharacterStateController => _characterStateController;

        public Inventory Inventory => _inventory;
        public Equipment Equipment => _equipment;

        protected virtual void Awake()
        {
            InitializeComponents();
        }
        protected virtual void InitializeComponents()
        {
            _subsciptions = new List<IEventSubscription>(5);
            _unitEvents = new UnitEvents();
            _unitAttributes = new UnitAttributesContainer(this);
            _characterStateController = new CharacterStateController(this);
            _inventory = new Inventory();
            _equipment = new Equipment();
            _interacter = new CharacterInteraction(this);

            FillSubscriptions();
        }
        private void OnEnable()
        {
            foreach (var item in _subsciptions)
            {
                item.Subscribe();
            }
        }
        private void OnDisable()
        {
            foreach (var item in _subsciptions)
            {
                item.Unsubscribe();
            }
        }
        private void FillSubscriptions()
        {

        }
    }
}
