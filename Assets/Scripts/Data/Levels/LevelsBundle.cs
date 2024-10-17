using UnityEngine;
using Helpers.Extensions;

namespace Data
{
    [CreateAssetMenu(fileName = "LevelsBundle", menuName = "Data/Level/LevelsBundle")]
    class LevelsBundle : ScriptableObject
    {
        [SerializeField] private LevelData[] _levelsDatas;
        [SerializeField, ReadOnly] private int _levelIndex;

        public LevelData GetLevelData(int levelNumber)
        {
            if (levelNumber < _levelsDatas.Length)
            {
                var neededData = _levelsDatas[levelNumber];
                _levelIndex = levelNumber;
                return neededData;
            }
            else
            {
                throw new System.Exception($"{this.name} try to access to element that dont exist");
            }
        }
        public LevelData GetRandomLevelData()
        {
            var random = Random.Range(0, _levelsDatas.Length);
            var level = _levelsDatas[random];
            if (level != null)
            {
                _levelIndex = random;
                return level;
            }
            else
            {
                throw new System.Exception("level is null");
            }
        }
        public LevelData GetCurrentLevelData()
        {
            if (_levelIndex < _levelsDatas.Length)
            {
                var neededData = _levelsDatas[_levelIndex];
                return neededData;
            }
            else
            {
                throw new System.Exception($"{this.name} try to access to element that dont exist");
            }
        }
    }
}
