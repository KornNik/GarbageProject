using Helpers;
using Controllers;

namespace Behaviours
{
    sealed class PlayerLoaderInitializer : IInitialization
    {
        public void Initialization()
        {
            var playerLoader = new PlayerLoader();
            Services.Instance.PlayerLoader.SetObject(playerLoader);
        }
    }
}
