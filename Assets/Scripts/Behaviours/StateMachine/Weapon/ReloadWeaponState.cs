using Behaviours.Items;

namespace Behaviours.States
{
    class ReloadWeaponState : WeaponState
    {
        private WeaponClip _weaponClip;
        public ReloadWeaponState(WeaponStateController weaponStateController) : base(weaponStateController)
        {
            //_weaponClip = (_stateController.StateObject as ProjectileWeapon).WeaponClip;
        }

        public override void EnterState()
        {
            _weaponClip.ReloadIsCompleted += ReloadComplete;
            _weaponClip.Reload();
        }
        public override void ExitState()
        {
            _weaponClip.ReloadIsCompleted -= ReloadComplete;
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

        private void ReloadComplete()
        {
            //_stateController.ChangeState(_stateController.NeutralState);
        }
    }
}
