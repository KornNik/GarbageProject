using UnityEngine;

namespace Behaviours
{
    interface IInteracter
    {
        float InteractionDistance { get;}
        void MakeInteraction(IInteractable<MonoBehaviour> interactable);
        bool CheckInteraction();
    }
}
