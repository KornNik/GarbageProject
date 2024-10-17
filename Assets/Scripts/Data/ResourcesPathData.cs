using Helpers;
using Helpers.Extensions;
using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    struct ResourcePathStruct<TType> where TType : struct
    {
        public TType Type;
        public string ResourcePath;
    }
    [CreateAssetMenu(fileName ="ResourcesPath",menuName ="Data/ResourcesPath")]
    sealed class ResourcesPathData : ScriptableObject
    {
        [SerializeField] private string _prefabsFolder;
        [SerializeField] private string _playerFolder;
        [SerializeField] private string _unitsFolder;
        [SerializeField] private string _audioFolder;
        [SerializeField] private string _uiScreenFolder;
        [SerializeField] private string _uiPartFolder;
        [SerializeField] private string _camerasFolder;
        [SerializeField] private string _gameStatePath;

        [SerializeField] private ResourcePathStruct<ScreenTypes>[] _screensPath;
        [SerializeField] private ResourcePathStruct<AudioTypes>[] _audiosPath;

        public string GetScreenPath(ScreenTypes screenType)
        {
            string screenName = default;
            for (int i = 0; i < _screensPath.Length; i++)
            {
                if (_screensPath[i].Type == screenType) screenName = _screensPath[i].ResourcePath;
            }
            var fullPath = StringBuilderExtender.CreateString(_prefabsFolder, _uiScreenFolder, screenName);
            return fullPath;
        }
        public string GetAudioPath(AudioTypes audioType)
        {
            string audioName = default;
            for (int i = 0; i < _audiosPath.Length; i++)
            {
                if (_audiosPath[i].Type == audioType) audioName = _audiosPath[i].ResourcePath;
            }
            var fullPath = StringBuilderExtender.CreateString(_prefabsFolder, _audioFolder, audioName);
            return fullPath;
        }
        public string GetCamerPath()
        {
            var fullPath = StringBuilderExtender.CreateString(_prefabsFolder, _camerasFolder);
            return fullPath;
        }
        public string GetGameStatePath()
        {
            var fullPath = StringBuilderExtender.CreateString(_prefabsFolder, _gameStatePath);
            return fullPath;
        }

    }
}
