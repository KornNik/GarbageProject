using Helpers;
using Helpers.Extensions;
using Controllers;
using UnityEngine;
using Data;

namespace Behaviours
{
    class AudioInitializer : IInitialization
    {
        public void Initialization()
        {
            var audioControllerResources = CustomResources.Load<AudioController>
                (Services.Instance.DatasBundle.ServicesObject.GetData<ResourcesPathData>().
                GetAudioPath(AudioTypes.AudioController));
            var audioController = GameObject.Instantiate(audioControllerResources, Vector3.zero, Quaternion.identity);

            Services.Instance.AudioController.SetObject(audioController);
        }
    }
}
