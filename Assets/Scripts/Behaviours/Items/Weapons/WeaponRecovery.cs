using System;
using System.Collections;
using UnityEngine;

namespace Behaviours
{
    sealed class WeaponRecovery
    {
        public event Action RecoveryEnd;

        private Timer _timer;
        private WaitForEndOfFrame _waitForEndOfFrame;

        private bool _isWeaponRecovering;
        public WeaponRecovery(float recoverTime)
        {
            _timer = new Timer(recoverTime);
            _waitForEndOfFrame = new WaitForEndOfFrame();

            _timer.TimerIsEnd += OnTimerIsEnd;
        }
        ~WeaponRecovery()
        {
            _timer.TimerIsEnd -= OnTimerIsEnd;
        }

        public void StartWeaponRecovery()
        {
            _timer.StartTimer();
        }
        public bool IsWeaponRecovering()
        {
            return _isWeaponRecovering;
        }

        private IEnumerator TimerUpdate()
        {
            while (IsWeaponRecovering())
            {
                _timer.TimerProccesedUpdate();
                yield return _waitForEndOfFrame;
            }
        }
        private void OnTimerIsEnd()
        {
            _isWeaponRecovering = false;
            RecoveryEnd?.Invoke();
        }
    }
}
