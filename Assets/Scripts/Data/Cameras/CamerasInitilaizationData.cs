using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CamerasInitilaizationData", menuName = "Data/Camera/CamerasInitilaizationData")]
    class CamerasInitilaizationData : ScriptableObject
    {
        [SerializeField] private Vector3 _mainCameraPosition;
        [SerializeField] private Vector3 _uiCameraPosition;

        public Vector3 GetMainCameraPosition()
        {
            return _mainCameraPosition;
        }
        public Vector3 GetUICameraPosition()
        {
            return _uiCameraPosition;
        }
    }
}
