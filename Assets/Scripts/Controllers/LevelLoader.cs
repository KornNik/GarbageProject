using UnityEngine;
using Data;
using Helpers;

namespace Controllers
{
    class LevelLoader
    {
        private GameObject _level;
        private LevelData _levelData;

        public LevelLoader()
        {
            _levelData = Services.Instance.DatasBundle.ServicesObject.GetData<LevelsBundle>().GetRandomLevelData();
        }
        public void LoadLevelGame(int index)
        {
            ClearLevelFull();
            LoadLevelVisuals(index);
        }
        public void ClearLevelFull()
        {
            if (!ReferenceEquals(_level, null))
            {
                GameObject.Destroy(_level.gameObject);
                _level = null;
            }
        }

        private void LoadLevelVisuals(int index)
        {
            _level = GameObject.Instantiate(_levelData.GetPrefab(), _levelData.GetLevelPosition(), Quaternion.identity);
            _level.transform.localPosition = Vector3.zero;
            _level.transform.localRotation = Quaternion.identity;
        }
    }
}
