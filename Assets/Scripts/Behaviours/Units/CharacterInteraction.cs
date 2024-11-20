using Behaviours.Items;
using Helpers;
using UnityEngine;

namespace Behaviours.Units
{
    sealed class CharacterInteraction : IInteracter
    {
        private UnitModel _unitModel;
        private Camera _camera;
        private float _interactionDistance = 20f;

        public CharacterInteraction(UnitModel unitModel)
        {
            _unitModel = unitModel;
            _camera = Services.Instance.CameraService.ServicesObject;
        }

        public float InteractionDistance { get => _interactionDistance; private set => InteractionDistance = value; }

        public bool CheckInteraction()
        {
            RaycastHit[] results = new RaycastHit[5];
            var hits = Physics.SphereCastNonAlloc(_camera.transform.position, 2f, _camera.transform.forward, results, _interactionDistance);
            if (hits > 0)
            {
                for (int i = 0; i < hits; i++)
                {
                    var item = results[i].collider.gameObject.GetComponent<Item>();
                    if (item != null)
                    {
                        item.Interact(_unitModel.Equipment);
                        return true;
                    }
                }
            }
            return false;
        }

        public void MakeInteraction(IInteractable<MonoBehaviour> interactable)
        {
            interactable.Interact(_unitModel);
        }
    }
}
