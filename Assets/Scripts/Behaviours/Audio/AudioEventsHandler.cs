using Helpers;

namespace Behaviours
{
    class AudioEventsHandler : IEventListener<MakeSoundEvent>, IEventListener<MuteSoundEvent>
    {
        public AudioEventsHandler()
        {
            StartListening();
        }

        ~AudioEventsHandler()
        {
            StopListening();
        }

        public void StartListening()
        {
            this.EventStartListening<MakeSoundEvent>();
            this.EventStartListening<MuteSoundEvent>();
        }

        public void StopListening()
        {
            this.EventStopListening<MakeSoundEvent>();
            this.EventStopListening<MuteSoundEvent>();
        }

        public void OnEventTrigger(MakeSoundEvent eventType)
        {
            Services.Instance.AudioController.ServicesObject.PlaySound(eventType.SoundData);
        }

        public void OnEventTrigger(MuteSoundEvent eventType)
        {
            Services.Instance.AudioController.ServicesObject.SetSoundStatus(eventType.MutedInfo.IsMuted);
        }
    }
}