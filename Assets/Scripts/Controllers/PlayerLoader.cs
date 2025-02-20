using UnityEngine;
using Data;
using Helpers;
using Behaviours.Units;

namespace Controllers
{
    sealed class PlayerLoader
    {
        private UnitController _player;
        private UnitsPrafabsData _prefabsData;

        public PlayerLoader()
        {
            _prefabsData = Services.Instance.DatasBundle.ServicesObject.GetData<UnitsPrafabsData>();
        }

        public void LoadPlayerClean()
        {
            ClearPlayer();
            LoadPlayerPrefab();
        }
        public void DeletePlayer()
        {
            ClearPlayer();
        }


        private bool LoadPlayerPrefab()
        {
            var playerPrefab = _prefabsData.GetPlayer();
            _player = GameObject.Instantiate(playerPrefab);
            if (!ReferenceEquals(_player, null))
            {
                Services.Instance.PlayerGameObject.SetObject(_player.gameObject);
                return true;
            }
            return false;
        }
        private bool ClearPlayer()
        {
            if (!ReferenceEquals(_player, null))
            {
                GameObject.Destroy(_player.gameObject);
                _player = null;
                return true;
            }
            return false;
        }
    }
}
