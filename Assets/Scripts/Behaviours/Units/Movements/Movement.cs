using MFPC.Movement;
using UnityEngine;

namespace Behaviours
{
    abstract class Movement : IMovement
    {
        protected Vector3 _movementVector;

        public bool IsLockGravity { get; set; } = false;

        public abstract void MoveHorizontal(Vector3 direction, float speed = 1);

        public abstract void MoveUpdate();

        public abstract void MoveVertical(Vector3 direction, float speed = 1);
    }
}
