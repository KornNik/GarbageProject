using System.Collections.Generic;
using UnityEngine;
using Kinemation.SightsAligner;
using MFPC;
using Data;
using Behaviours.States;

namespace Behaviours.Units
{
    abstract class UnitModel : MonoBehaviour
    {
        [SerializeField] private UnitData _unitData;
        [SerializeField] private UnitSounds _unitSounds;
        [SerializeField] private UnitAnimation _unitAnimation;
        [SerializeField] private Collider _collider;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _gunTransform;
        [SerializeField] private CoreAnimComponent _coreAnimComponent;
        [SerializeField] private PlayerData _playerData;

        protected Jump _jump;
        protected Combat _combat;
        protected Movement _movement;
        protected Rotation _rotation;
        protected UnitEvents _unitEvents;
        protected UnitAttributesContainer _unitAttributes;
        protected CharacterStateController _characterStateController;
        protected IInteracter _interacter;
        protected Crouch _crouch;
        protected Gravity _gravity;

        private Equipment _equipment;

        protected List<IEventSubscription> _subsciptions;

        public Jump Jump => _jump;
        public Crouch Crouch =>_crouch;
        public Gravity Gravity => _gravity;
        public Combat Combat => _combat;
        public Collider Collider => _collider;
        public UnitData UnitData => _unitData;
        public Rotation Rotation => _rotation;
        public Movement Movement => _movement;
        public PlayerData PlayerData => _playerData;
        public UnitEvents UnitEvents => _unitEvents;
        public UnitSounds UnitSounds => _unitSounds;
        public IInteracter Interacter => _interacter;
        public UnitAnimation UnitAnimation => _unitAnimation;
        public CoreAnimComponent CoreAnimComponent => _coreAnimComponent;
        public UnitAttributesContainer UnitAttributes => _unitAttributes;
        public CharacterStateController CharacterStateController => _characterStateController;

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
            _equipment = new Equipment();
            _gravity = new Gravity();
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
