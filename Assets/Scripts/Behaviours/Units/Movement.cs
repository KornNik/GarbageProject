using UnityEngine;

namespace Behaviours
{
    abstract class Movement : IMovable
    {
        public abstract void Move(Vector3 movement);

        public abstract void StopMovement();
    }
}
