namespace Behaviours
{
    interface IInteracter
    {
        float InteractionDistance { get;}
        void MakeInteraction(IInteractable interactable);
        bool CheckInteraction();
    }
}
