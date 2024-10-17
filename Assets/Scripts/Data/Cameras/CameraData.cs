﻿using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CameraData", menuName = "Data/Camera/CameraData")]
    public class CameraData : ScriptableObject
    {
        [SerializeField] private float _cameraSpeed;
        [SerializeField] private float _cameraDistance;
        [SerializeField] private float _cameraRotationSpeed;

        public float CameraSpeed => _cameraSpeed;
        public float CameraDistance => _cameraDistance;
        public float CameraRotationSpeed => _cameraRotationSpeed;
    }
}