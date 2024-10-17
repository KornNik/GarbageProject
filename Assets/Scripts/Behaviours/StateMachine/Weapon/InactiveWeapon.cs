using Behaviours.Items;

namespace Behaviours.States
{
    class InactiveWeaponState : WeaponState
    {
        public InactiveWeaponState(WeaponStateController stateController) : base(stateController)
        {

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

        private void ReloadComplete()
        {

        }
    }
}
