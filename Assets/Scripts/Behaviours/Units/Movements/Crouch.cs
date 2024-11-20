using Behaviours.Units;
using UnityEngine;

namespace Behaviours
{
    sealed class Crouch : ICroucher
    {
        private float _crouchHeight;
        private float _defaultHeight;
        private Vector3 _defaultOffset;
        private CharacterController _controller;

        public Crouch(CharacterController controller)
        {
            _controller = controller;
            _defaultHeight = _controller.height;
            _defaultOffset = _controller.center;
            _crouchHeight = _controller.height * 0.6f;
        }

        public void StandUp()
        {
            _controller.height = _defaultHeight;
        }

        public void GetDown()
        {
            _controller.height = _crouchHeight;
        }
    }
}
interface ICroucher
{
    public void GetDown();
    public void StandUp();
}
