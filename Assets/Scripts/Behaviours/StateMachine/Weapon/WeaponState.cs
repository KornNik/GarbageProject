using Controllers;
using Helpers;

namespace Behaviours.States
{
    abstract class WeaponState : BaseState<WeaponStateController>
    {
        protected InputController _inputController;
        protected WeaponState(WeaponStateController stateController) : base()
        {
            _stateController = stateController;
            _inputController = Services.Instance.InputController.ServicesObject;
        }
    }
}
