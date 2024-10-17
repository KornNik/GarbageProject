using UnityEngine;
using Controllers;
using Helpers.Managers;
using Behaviours;
using Helpers;

namespace Behaviours.States
{
    class AimState : CharacterState
    {
        public AimState(CharacterStateController stateController) : base(stateController)
        {
        }

        protected override void InputHandle()
        {
            throw new System.NotImplementedException();
        }
    }
}
