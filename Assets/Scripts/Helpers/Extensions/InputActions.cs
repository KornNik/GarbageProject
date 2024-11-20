using System.Collections.Generic;
using UnityEngine.InputSystem;
using Helpers;

namespace Assets.Scripts.Helpers.Extensions
{
    internal class InputActions
    {
        private InputAction _fire;
        private InputAction _move;
        private InputAction _aim;
        private InputAction _jump;
        private InputAction _look;
        private InputAction _inspect;
        private InputAction _reload;
        private InputAction _holster;
        private InputAction _run;
        private InputAction _inventory;
        private Dictionary<string, InputAction> _playerActionList = new Dictionary<string, InputAction>();

        public InputAction Fire => _fire;
        public InputAction Move => _move;
        public InputAction Aim => _aim;
        public InputAction Jump => _jump;
        public InputAction Look => _look;
        public InputAction Inspect => _inspect;
        public InputAction Reload => _reload;
        public InputAction Holster => _holster;
        public InputAction Run => _run;
        public InputAction Inventory => _inventory;

        public Dictionary<string, InputAction> PlayerActionList => _playerActionList;


        public InputActions(InputActionMap playerActionMap)
        {
            InitializeActions(playerActionMap);
        }

        private void InitializeActions(InputActionMap playerActionMap)
        {
            _playerActionList.Add(InputActionManagerPlayer.FIRE, playerActionMap.FindAction(InputActionManagerPlayer.FIRE));
            _playerActionList.Add(InputActionManagerPlayer.MOVEMENT, playerActionMap.FindAction(InputActionManagerPlayer.MOVEMENT));
            _playerActionList.Add(InputActionManagerPlayer.AIM, playerActionMap.FindAction(InputActionManagerPlayer.AIM));
            _playerActionList.Add(InputActionManagerPlayer.JUMP, playerActionMap.FindAction(InputActionManagerPlayer.JUMP));
            _playerActionList.Add(InputActionManagerPlayer.LOOK, playerActionMap.FindAction(InputActionManagerPlayer.LOOK));
            _playerActionList.Add(InputActionManagerPlayer.INTERACT, playerActionMap.FindAction(InputActionManagerPlayer.INTERACT));
            _playerActionList.Add(InputActionManagerPlayer.RELOAD, playerActionMap.FindAction(InputActionManagerPlayer.RELOAD));
            _playerActionList.Add(InputActionManagerPlayer.HOLSTER, playerActionMap.FindAction(InputActionManagerPlayer.HOLSTER));
            _playerActionList.Add(InputActionManagerPlayer.RUN, playerActionMap.FindAction(InputActionManagerPlayer.RUN));
            _playerActionList.Add(InputActionManagerPlayer.INVENTORY, playerActionMap.FindAction(InputActionManagerPlayer.INVENTORY));
            _playerActionList.Add(InputActionManagerPlayer.CROUCH, playerActionMap.FindAction(InputActionManagerPlayer.CROUCH));

            _fire = playerActionMap.FindAction(InputActionManagerPlayer.FIRE);
            _move = playerActionMap.FindAction(InputActionManagerPlayer.MOVEMENT);
            _aim = playerActionMap.FindAction(InputActionManagerPlayer.AIM);
            _jump = playerActionMap.FindAction(InputActionManagerPlayer.JUMP);
            _look = playerActionMap.FindAction(InputActionManagerPlayer.LOOK);
            _inspect = playerActionMap.FindAction(InputActionManagerPlayer.INTERACT);
            _reload = playerActionMap.FindAction(InputActionManagerPlayer.RELOAD);
            _holster = playerActionMap.FindAction(InputActionManagerPlayer.HOLSTER);
            _run = playerActionMap.FindAction(InputActionManagerPlayer.RUN);
            _inventory = playerActionMap.FindAction(InputActionManagerPlayer.INVENTORY);
        }
    }
}
