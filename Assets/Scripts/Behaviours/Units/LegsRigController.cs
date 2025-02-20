using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace Behaviours
{
    sealed class LegsRigController
    {
        private RigBuilder _rigBuilder;
        private Rig _legsRig;

        public LegsRigController(RigBuilder rigBuilder)
        {
            _rigBuilder = rigBuilder;
            _legsRig = _rigBuilder.layers[1].rig;
        }

        public void SetLegsRig()
        {

        }
    }
}
