using UnityEngine;
using Data;
using Controllers;
using Helpers;
using Helpers.Extensions;

namespace Behaviours
{
   sealed class CamerasInitializer : IInitialization
    {
        private CamerasInitilaizationData _camerasData;
        public void Initialization()
        {
            CamerasDataInitialization();
            MainCameraInitialization();
        }

        private void CamerasDataInitialization()
        {
            var dataResources = Services.Instance.DatasBundle.ServicesObject.
                GetData<CamerasInitilaizationData>();
            _camerasData = dataResources;
        }
        private void MainCameraInitialization()
        {
            var mainCameraResource = CustomResources.Load<Camera>
                (Services.Instance.DatasBundle.ServicesObject.GetData<ResourcesPathData>().GetCamerPath());
            var mainCameraObject = Object.Instantiate(mainCameraResource,
                _camerasData.GetMainCameraPosition(), Quaternion.identity);

            Services.Instance.CameraService.SetObject(mainCameraObject);
        }
    }
}
