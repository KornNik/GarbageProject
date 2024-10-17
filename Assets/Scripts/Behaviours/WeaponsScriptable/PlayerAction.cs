using UnityEngine;
using Behaviours.Items;
using Helpers;

namespace Behaviours
{
    sealed class PlayerAction : MonoBehaviour
    {
        [SerializeField] private PlayerGunSelector _gunSelector;

        private void Update()
        {
            if (Services.Instance.InputController.ServicesObject.InputActions.Fire.IsPressed()&&_gunSelector.IsGunActive())
            {
                _gunSelector.CurrentGun.Shoot();
            }
        }
    }
}