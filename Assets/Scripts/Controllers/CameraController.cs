using Behaviours;
using UnityEngine;

namespace Controllers
{
    sealed class CameraController : MonoBehaviour
    {
        private CameraModel _cameraModel;
        private CameraMovement _cameraMovement;

        private void Awake()
        {
            _cameraModel = new CameraModel();
            _cameraModel.Initialization();
        }
    }
}
