using Helpers;
using Behaviours;
using UnityEngine;

namespace Controllers
{
    sealed class BootsTrap : PersistanceSingleton<BootsTrap>
    {
        private SystemsInitializer _systemsInitializer;
        private ComponentsInitializer _componentsInitializer;

        private void Start()
        {
            InitializationComponents();
            ClearResources();
        }
        private void InitializationComponents()
        {
            _systemsInitializer = new SystemsInitializer();
            _componentsInitializer = new ComponentsInitializer();

            _systemsInitializer.Initialization();
            _componentsInitializer.Initialization();
        }
        private void ClearResources()
        {
            Resources.UnloadUnusedAssets();
        }
    }
}
