using UnityEngine;

namespace Behaviours
{
    sealed class LandingCheck
    {
        private Collider _objectCollider;
        private Transform _transform;
        private RaycastHit[] _hits;
        private LayerMask _layerMask;

        public LandingCheck(Collider objectCollider, Transform transform)
        {
            _objectCollider = objectCollider;
            _transform = transform;
            _hits = new RaycastHit[4];
        }
        public bool IsLandOnGround()
        { 
            var halfColliderSize = _objectCollider.bounds.size / 2;
            var ray = Physics.BoxCastNonAlloc(_transform.position, Vector3.one, Vector3.down, _hits, Quaternion.identity, halfColliderSize.x / 0.1f, _layerMask);
            if (ray > 0)
            {
                foreach (var hit in _hits)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
