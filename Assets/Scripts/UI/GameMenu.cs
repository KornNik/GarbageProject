using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace UI
{
    sealed class GameMenu : BaseUI
    {
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