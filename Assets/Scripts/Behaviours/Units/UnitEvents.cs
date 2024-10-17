using System;

namespace Behaviours.Units
{
    sealed class UnitEvents
    {
        public Action Die;
        public Action Revived;
        public Action WeaponSwap;
        public Action HealthIsEnd;
        public Action AttackFinished;
        public Action<HealthStruct> HealthChanged;
        public Action<bool> IsMoving;
        public Action<float> HorizontalMoving;
        public Action<float> VerticalMoving;
    }
}
