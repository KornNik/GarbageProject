using Behaviours.Units;
using UnityEngine;

namespace Helpers
{
    sealed class PlayerService : Service<GameObject>
    {
        private UnitController _controller;

        public UnitController Controller => _controller;

        public override void SetObject(GameObject servicesObject)
        {
            base.SetObject(servicesObject);
            _controller = servicesObject.GetComponent<UnitController>();
        }
    }
}
