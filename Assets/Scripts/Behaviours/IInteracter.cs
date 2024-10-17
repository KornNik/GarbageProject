using UnityEngine;

namespace Behaviours
{
    interface IInteracter
    {
        void MakeInteraction(IInteractable<MonoBehaviour> interactable);
    }
}
