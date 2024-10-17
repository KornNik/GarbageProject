using Controllers;
using Helpers;


namespace Behaviours.States
{
    abstract class CharacterState : BaseState<CharacterStateController>
    {
        protected InputController _inputController;
        protected CharacterState(CharacterStateController stateController) : base()
        {
            _stateController = stateController;
            _inputController = Services.Instance.InputController.ServicesObject;
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            MakeRotation();
            InputHandle();
        }
        public override void LogicLateUpdate()
        {
            base.LogicLateUpdate();
        }
        protected abstract void InputHandle();

        private void MakeRotation()
        {
            _stateController.StateObject.Rotation.RotateTowardCamera();
        }
    }
}