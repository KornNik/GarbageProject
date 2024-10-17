using Controllers;
using Data;
using Helpers.Extensions;
using Helpers;
using UnityEngine;
using Zenject;

namespace Behaviours
{
    sealed class AudioInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            var audioControllerResources = CustomResources.Load<AudioController>
                (Services.Instance.DatasBundle.ServicesObject.GetData<ResourcesPathData>().
                GetAudioPath(AudioTypes.AudioController));

            //var audioController = GameObject.Instantiate
            //    (audioControllerResources, Vector3.zero, Quaternion.identity);

            var audioController = Container.InstantiatePrefabForComponent<AudioController>
                (audioControllerResources, Vector3.zero, Quaternion.identity, null);

            Container.Bind<AudioController>().FromInstance(audioController).AsSingle().NonLazy();

            Services.Instance.AudioController.SetObject(audioController);
        }
    }
}
