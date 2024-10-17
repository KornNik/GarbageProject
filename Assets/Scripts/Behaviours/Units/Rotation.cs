using Behaviours;
using DG.Tweening;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    class Rotation
    {
        private Camera _camera;
        private CharacterController _characterController;
        protected Transform _characterTransform;
        protected float _rotationSpeed = 20f;

        public Rotation(CharacterController characterController)
        {
            _characterController = characterController;
            _characterTransform = characterController.transform;
            _camera = Services.Instance.CameraService.ServicesObject;
        }

        public void RotateTowardCamera()
        {
            Quaternion rotation = _characterTransform.rotation;
            rotation.SetLookRotation(_camera.transform.forward);
            var rotationInEulers = rotation.eulerAngles;
            var finalObjectRotation = new Vector3(0f, rotationInEulers.y, 0f);
            _characterTransform.DOLocalRotate(finalObjectRotation, 0.2f);
            //_characterTransform.DOLookAt(_camera.transform.forward, 0.2f);
        }
    }
}
