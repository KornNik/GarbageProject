using System.Collections.Generic;
using UnityEngine;
using Data;
using Helpers.Extensions;
using System.Linq;

namespace Behaviours.Items
{
    [DisallowMultipleComponent]
    sealed class PlayerGunSelector : MonoBehaviour
    {
        [SerializeField] private GunType _gunType;
        [SerializeField] private Transform _gunParent;
        [SerializeField] private HashSet<GunScriptable> _guns;

        [SerializeField, ReadOnly] private GunScriptable _currentGun;

        public GunScriptable CurrentGun => _currentGun;

        private void Awake()
        {
            GunScriptable gun = _guns.First(gun => gun.Type == _gunType);

            if(gun != null)
            {
                Debug.LogError($"gun is null:{gun}");
                return;
            }
            _currentGun = gun;
            _currentGun.Spawn(_gunParent, this);
        }
        public bool IsGunActive()
        {
            if(!ReferenceEquals(_currentGun, null)) return true;
            return false;
        }
    }
}