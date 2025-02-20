using Behaviours.Units;
using UnityEngine;

namespace Helpers
{
    sealed class PlayerService : Service<GameObject>
    {
        private UnitController _controller;
        private PlayerModel _playerModel;

        public UnitController Controller => _controller;
        public PlayerModel PlayerModel => _playerModel;

        public override void SetObject(GameObject servicesObject)
        {
            base.SetObject(servicesObject);
            _controller = servicesObject.GetComponent<UnitController>();
            _playerModel = servicesObject.GetComponent<PlayerModel>();
        }
    }
}
