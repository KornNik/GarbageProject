using Controllers;
using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    class GameStateControllerInitializer : IInitialization
    {
        public void Initialization()
        {
            var gameStateResources = Services.Instance.DatasBundle.ServicesObject.
                GetData<ResourcesPathData>().GetGameStatePath();
            var gameStateBeh = Object.Instantiate
                (gameStateResources, Vector3.zero, Quaternion.identity);
            Services.Instance.GameStateBehavior.SetObject(gameStateBeh);
        }
    }
}