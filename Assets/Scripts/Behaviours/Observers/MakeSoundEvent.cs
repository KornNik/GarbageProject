using UnityEngine;
using Helpers;

namespace Behaviours
{
    struct SoundEventInfo
    {
        public bool IsOneShot;
        public float SoundVolume;
        public AudioClip AudioClip;
        public Vector3 PlayPosition;

        public SoundEventInfo(AudioClip audioClip, Vector3 playPosition, float soundVolume = 1f, bool isOneShot = default)
        {
            AudioClip = audioClip;
            IsOneShot = isOneShot;
            SoundVolume = soundVolume;
            PlayPosition = playPosition;
        }
    }

    struct MakeSoundEvent
    {
        private static MakeSoundEvent _soundEvent;

        private SoundEventInfo _soundData;

        public SoundEventInfo SoundData => _soundData;

        public static void Trigger(SoundEventInfo soundData)
        {
            _soundEvent._soundData.AudioClip = soundData.AudioClip;
            _soundEvent._soundData.SoundVolume = soundData.SoundVolume;
            _soundEvent._soundData.IsOneShot = soundData.IsOneShot;
            _soundEvent._soundData.PlayPosition = soundData.PlayPosition;
            EventManager.TriggerEvent(_soundEvent);
        }
    }
}
