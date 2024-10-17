using UnityEngine;

namespace Controllers
{
    class SettingsController
    {
        private const int DEFAULT_VSYNC_COUNT = 1;
        private const int DEFAULT_FRAME_RATE = 60;
        private const bool DEFAULT_CURSOR_STATE = false;
        private const CursorLockMode DEFAULT_CURSOR_LOCK_MODE = CursorLockMode.Locked;

        public SettingsController()
        {
            UnLockedCursor();
            LockedFPS();
        }
        private void LockedFPS()
        {
            QualitySettings.vSyncCount = DEFAULT_VSYNC_COUNT;
            Application.targetFrameRate = DEFAULT_FRAME_RATE;
        }
        private void LockedCursor()
        {
            Cursor.lockState = DEFAULT_CURSOR_LOCK_MODE;
            Cursor.visible = DEFAULT_CURSOR_STATE;
        }
        private void UnLockedCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
