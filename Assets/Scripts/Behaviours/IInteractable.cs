using UnityEngine;

namespace Behaviours
{
    interface IInteractable<T>
    {
        void Interact(T interactObject);
    }
}
