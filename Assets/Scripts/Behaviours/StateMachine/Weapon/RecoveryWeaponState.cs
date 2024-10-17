using Behaviours;

namespace Behaviours.States
{
    class RecoveryWeaponState : WeaponState
    {
        private WeaponRecovery _weaponRecovery;

        public RecoveryWeaponState( WeaponStateController weaponStateController) : base(weaponStateController)
        {
            _weaponRecovery = new WeaponRecovery(2f);
        }

        public override void EnterState()
        {

        }

        public override void ExitState()
        {

        }

        public override void LogicFixedUpdate()
        {
        }
        public override void LogicUpdate()
        {
        }
        public override void LogicLateUpdate()
        {
        }
    }
}
