using Behaviours;
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
    [Serializable]
    struct ResorcePrefabStruct<TType> where TType : struct
    {
        public TType Type;
        public GameObject Gameobject;
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
        [SerializeField] private GameObject _cameraPrefab;
        [SerializeField] private GameStateBehaviour _gameStatePrefab;

        [SerializeField] private ResorcePrefabStruct<ScreenTypes>[] _screensPrefabs;
        [SerializeField] private SerializableDictionary<AudioTypes, GameObject> _audioPrefabs;

        public GameObject GetScreenPrefab(ScreenTypes screenType)
        {
            GameObject screenPrefab = default;
            for (int i = 0; i < _screensPrefabs.Length; i++)
            {
                if (_screensPrefabs[i].Type == screenType) screenPrefab = _screensPrefabs[i].Gameobject;
            }

            return screenPrefab;
        }
        public GameObject GetAudioPath(AudioTypes audioType)
        {
            GameObject audioPrefab = default;
            if (_audioPrefabs.TryGetValue(audioType,out audioPrefab))
            {
                return audioPrefab;
            }
            throw new NullReferenceException();
        }
        public GameObject GetCamerPath()
        {
            return _cameraPrefab;
        }
        public GameStateBehaviour GetGameStatePath()
        {
            return _gameStatePrefab;
        }

    }
}
