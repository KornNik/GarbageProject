using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "TrailConfig", menuName = "Data/Weapon/TrailConfig")]
    sealed class TrailConfiguration : ScriptableObject
    {
        [SerializeField] private Material _material;
        [SerializeField] private AnimationCurve _widthCurve;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private float _minVertexDistancve = 0.1f;
        [SerializeField] private Gradient _color;

        [SerializeField] private float _missDistance = 100f;
        [SerializeField] private float _simulationSpeed = 25f;

        public Material Material { get => _material; set => _material = value; }
        public AnimationCurve WidthCurve { get => _widthCurve; set => _widthCurve = value; }
        public float Duration { get => _duration; set => _duration = value; }
        public float MinVertexDistancve { get => _minVertexDistancve; set => _minVertexDistancve = value; }
        public Gradient Color { get => _color; set => _color = value; }
        public float MissDistance { get => _missDistance; set => _missDistance = value; }
        public float SimulationSpeed { get => _simulationSpeed; set => _simulationSpeed = value; }
    }
}
