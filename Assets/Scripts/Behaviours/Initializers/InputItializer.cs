using Controllers;
using Helpers;

namespace Behaviours
{
    sealed class InputItializer : IInitialization
    {
        public void Initialization()
        {
            var inputController = new InputController();
            Services.Instance.InputController.SetObject(inputController);
        }
    }
}
