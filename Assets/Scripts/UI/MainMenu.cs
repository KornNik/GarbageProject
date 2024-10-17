using UnityEngine;
using UnityEngine.UI;
using Behaviours;

namespace UI
{
    class MainMenu : BaseUI
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _quitGameButton;
        [SerializeField] private LayoutGroup _buttonsGroup;

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(OnStartButtonDown);
            _quitGameButton.onClick.AddListener(OnQuitGameButtonDown);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(OnStartButtonDown);
            _quitGameButton.onClick.RemoveListener(OnQuitGameButtonDown);
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

        private void OnStartButtonDown()
        {
            ChangeGameStateEvent.Trigger(GameStateType.GameState);
        }
        private void OnQuitGameButtonDown()
        {
            Application.Quit();
        }
    }
}