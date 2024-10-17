using UnityEngine;
using UnityEngine.UI;
using Controllers;
using Behaviours;

namespace UI
{
    class PauseMenu : BaseUI
    {
        [SerializeField] Button _resumeButton;
        [SerializeField] Button _quitButton;
        [SerializeField] private LayoutGroup _buttonsGroup;


        private void OnEnable()
        {
            _resumeButton.onClick.AddListener(OnResumeButtonDown);
            _quitButton.onClick.AddListener(OnQuitButtonDown);
        }
        private void OnDisable()
        {
            _resumeButton.onClick.RemoveListener(OnResumeButtonDown);
            _quitButton.onClick.RemoveListener(OnQuitButtonDown);

        }

        private void OnResumeButtonDown()
        {
            ChangeGameStateEvent.Trigger(GameStateType.GameState);
        }

        private void OnQuitButtonDown()
        {
            ChangeGameStateEvent.Trigger(GameStateType.ManuState);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();

        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }
    }
}
