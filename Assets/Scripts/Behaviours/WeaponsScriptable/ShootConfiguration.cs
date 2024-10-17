using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "ShootConfig", menuName = "Data/Weapon/ShootConfig")]
    sealed class ShootConfiguration : ScriptableObject
    {
        [SerializeField] private LayerMask _hitLayer;
        [SerializeField] private Vector3 _spread = new Vector3(0.1f, 0.1f, 0.1f);
        [SerializeField] private float _fireRate = 0.25f;

        public LayerMask HitLayer { get => _hitLayer; set => _hitLayer = value; }
        public Vector3 Spread { get => _spread; set => _spread = value; }
        public float FireRate { get => _fireRate; set => _fireRate = value; }
    }
}
