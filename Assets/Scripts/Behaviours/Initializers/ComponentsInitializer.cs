using Controllers;
using System.Collections.Generic;

namespace Behaviours
{
    class ComponentsInitializer : IInitialization
    {
        private List<IInitialization> _components = new List<IInitialization>();
        public void Initialization()
        {
            _components.Add(new CamerasInitializer());
            _components.Add(new LevelLoaderInitializer());
            _components.Add(new PlayerLoaderInitializer());
            _components.Add(new GameStateControllerInitializer());
            
            foreach (var component in _components)
            {
                component.Initialization();
            }
        }
    }
}
