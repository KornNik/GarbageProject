using Controllers;
using Data;
using Helpers;
using Helpers.Extensions;
using UnityEngine;

namespace Behaviours
{
    class GameStateControllerInitializer : IInitialization
    {
        public void Initialization()
        {
            var gameStateResources = CustomResources.Load<GameStateBehaviour>
                (Services.Instance.DatasBundle.ServicesObject.GetData<ResourcesPathData>().GetGameStatePath());
            var gameStateBeh = GameObject.Instantiate
                (gameStateResources, Vector3.zero, Quaternion.identity);
            Services.Instance.GameStateBehavior.SetObject(gameStateBeh);
        }
    }
}