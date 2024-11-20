using Helpers;
using Controllers;
using UnityEngine;
using Data;

namespace Behaviours
{
    class AudioInitializer : IInitialization
    {
        public void Initialization()
        {
            var audioControllerResources = Services.Instance.DatasBundle.ServicesObject.
                GetData<ResourcesPathData>().GetAudioPath(AudioTypes.AudioController);
            var audioController = GameObject.Instantiate
                (audioControllerResources, Vector3.zero, Quaternion.identity).
                GetComponent<AudioController>();

            Services.Instance.AudioController.SetObject(audioController);
        }
    }
}
