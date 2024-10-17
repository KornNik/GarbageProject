using UnityEngine;

namespace Behaviours.Units
{
    class UnitAnimation : MonoBehaviour
    {
        public const string ATTACK = "Attack";
        public const string SPEED_MULTY = "Attack";
        public const string IS_MOVING = "IsMoving";
        public const string HORIZONTAL = "Horizontal";
        public const string VERTICAL = "Vertical";

        [SerializeField]private Animator _animator;
        [SerializeField]private UnitController _controller;

        private UnitEvents _events;

        protected readonly int _attack = Animator.StringToHash(ATTACK);
        protected readonly int _speedMulty = Animator.StringToHash(SPEED_MULTY);
        protected readonly int _isMoving = Animator.StringToHash(IS_MOVING);
        protected readonly int _horizontal = Animator.StringToHash(HORIZONTAL);
        protected readonly int _vertical = Animator.StringToHash(VERTICAL);

        public void Awake()
        {
            _events = _controller.Model.UnitEvents;
        }

        private void OnEnable()
        {
            _events.IsMoving += OnStartMoving;
            _events.HorizontalMoving += OnHorizontalMove;
            _events.VerticalMoving += OnVerticalMove;
        }
        private void OnDisable()
        {
            _events.IsMoving -= OnStartMoving;
            _events.HorizontalMoving -= OnHorizontalMove;
            _events.VerticalMoving -= OnVerticalMove;
        }

        public void SetSpeed(float speed)
        {
            _animator.speed = speed;
        }
        private void OnHorizontalMove(float value)
        {
            _animator.SetFloat(_horizontal, value);
        }
        private void OnVerticalMove(float value)
        {
            _animator.SetFloat(_vertical, value);
        }
        private void OnStartMoving(bool value)
        {
            _animator.SetBool(_isMoving, value);
        }
        private void OnAttack()
        {

        }
    }
}
