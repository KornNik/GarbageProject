using Helpers.Managers;
using Controllers;
using Helpers;


namespace Behaviours.States
{
    class NeutralWeaponState : WeaponState
    {
        public NeutralWeaponState(WeaponStateController weaponStateController) : base(weaponStateController)
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
            if (_inputController.InputActions.PlayerActionList[InputActionManagerPlayer.FIRE].IsPressed())
            {
                _stateController.ChangeState(_stateController.RecoveryState);
            }
            if (_inputController.InputActions.PlayerActionList[InputActionManagerPlayer.RELOAD].IsPressed())
            {
                _stateController.ChangeState(_stateController.ReloadState);
            }
        }
    }
    class AttackWeaponState : WeaponState
    {
        public AttackWeaponState(WeaponStateController weaponStateController) : base(weaponStateController)
        {

        }
        public override void EnterState()
        {
            _stateController.StateObject.Attack();
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
    }
}
