using Behaviours;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class ButtonExtender : MonoBehaviour
    {
        [SerializeField] private AudioClip _clickClip;
        [SerializeField] private Button _extendedButton;

        private void OnEnable()
        {
            _extendedButton.onClick.AddListener(CustomButtonClick);
        }
        private void OnDisable()
        {
            _extendedButton.onClick.RemoveListener(CustomButtonClick);
        }

        private void CustomButtonClick()
        {
            MakeSoundEvent.Trigger(new SoundEventInfo(_clickClip, Vector3.zero));
        }
    }
}
