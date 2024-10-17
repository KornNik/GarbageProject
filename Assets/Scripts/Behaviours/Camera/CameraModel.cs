using UnityEngine;
using Data;
using Controllers;
using Helpers;

namespace Behaviours
{
    sealed class CameraModel : IInitialization
    {
        private Camera _camera;
        private CameraData _cameraData;
        private CameraMovement _movement;

        public void Initialization()
        {
            _camera = Camera.main;
            _cameraData = Services.Instance.DatasBundle.ServicesObject.GetData<CameraData>();
            _movement = new CameraMovement();
        }
    }
}