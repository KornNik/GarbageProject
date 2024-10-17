using UnityEngine.InputSystem;
using Helpers;
using Assets.Scripts.Helpers.Extensions;
using Data;

namespace Controllers
{
    internal class InputController
    {
        private InputActionAsset _playerActionsAsset;
        private InputActionMap _playerActionMap;
        private InputActions _inputActions;

        public InputActions InputActions => _inputActions;

        public InputController()
        {
            _playerActionsAsset = Services.Instance.DatasBundle.ServicesObject.GetData<InputData>().InputActionAsset;
            if (!ReferenceEquals(_playerActionsAsset, null))
            {
                _playerActionMap = _playerActionsAsset.FindActionMap(InputActionManagerPlayer.PLAYER_ACTIONS_MAP);
                if (!ReferenceEquals(_playerActionMap, null))
                {
                    UnityEngine.Debug.Log("InputsLoaded");
                    _inputActions = new InputActions(_playerActionMap);
                }
                else { throw new System.Exception($"{this.GetType()} try to use _playerActionMap but reference is null"); }
            }
            else { throw new System.Exception($"{this.GetType()} try to use player action asset but reference is null"); }
        }
    }
}
