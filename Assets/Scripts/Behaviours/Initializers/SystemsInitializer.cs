using Controllers;
using System.Collections.Generic;

namespace Behaviours
{
    class SystemsInitializer : IInitialization
    {
        private List<IInitialization> _systems = new List<IInitialization>();

        public void Initialization()
        {
            _systems.Add(new DataInitializer());
            _systems.Add(new SettingsInitializer());
            _systems.Add(new TimeInitializer());
            _systems.Add(new AudioInitializer());
            _systems.Add(new InputItializer());

            foreach (var system in _systems)
            {
                system.Initialization();
            }
        }
    }
}
