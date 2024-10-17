using System;
using UnityEngine;

namespace Behaviours
{
    class Timer
    {
        public event Action TimerIsEnd;

        private float _currentTime;
        private float _neededTime;
        private bool _isProccesed;
        private bool _isTimerEnd;

        public Timer(float neededTime)
        {
            _neededTime = neededTime;
        }

        public void StartTimer()
        {
            _isProccesed = true;
            _currentTime = 0f;
        }
        public void EndTimer()
        {
            _isProccesed = false;
        }
        public void TimerProccesedUpdate()
        {
            if (_currentTime < _neededTime)
            {
                _currentTime += Time.deltaTime;
            }
            else
            {
                TimerIsDone();
            }
        }
        private void TimerIsDone()
        {
            if (!IsTimerProccesed()) { return; }

            EndTimer();
            TimerIsEnd?.Invoke();
        }

        public bool IsTimerEnd()
        {
            return _isTimerEnd;
        }
        public bool IsTimerProccesed()
        {
            return _isProccesed;
        }

    }
}
