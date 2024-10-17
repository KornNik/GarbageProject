using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Data
{
    enum GunType
    {
        None,
        Pistol,
        Rifle,
        Shotgun
    }
    [CreateAssetMenu(fileName = "GunConfig", menuName = "Data/Weapon/GunConfig")]
    sealed class GunScriptable : ScriptableObject
    {
        [SerializeField] private GunType _type;
        [SerializeField] private string _name;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Vector3 _spawnPoint;
        [SerializeField] private Vector3 _spawnRotation;

        [SerializeField] private ShootConfiguration _shootConfiguration;
        [SerializeField] private TrailConfiguration _trailConfig;

        private MonoBehaviour _activeMonoBehaviour;
        private GameObject _model;
        private float _lastShootTime;
        private ParticleSystem _shotParticle;
        private ObjectPool<TrailRenderer> _trailPool;
        private WaitForSeconds _waitForTrail;

        internal GunType Type { get => _type; set => _type = value; }
        public string Name { get => _name; set => _name = value; }
        public GameObject Prefab { get => _prefab; set => _prefab = value; }
        public Vector3 SpawnPoint { get => _spawnPoint; set => _spawnPoint = value; }
        public Vector3 SpawnRotation { get => _spawnRotation; set => _spawnRotation = value; }

        public void Spawn(Transform parent, MonoBehaviour activeMonoBehaviour)
        {
            _activeMonoBehaviour = activeMonoBehaviour;
            _lastShootTime = 0f;
            _waitForTrail = new WaitForSeconds(_trailConfig.Duration);
            _trailPool = new ObjectPool<TrailRenderer>(CreateTrail);

            CreateModel(parent);

            _shotParticle = _model.GetComponentInChildren<ParticleSystem>();
        }
        public void Shoot()
        {
            if (Time.time > _shootConfiguration.FireRate + _lastShootTime)
            {
                _lastShootTime = Time.time;
                _shotParticle.Play();
                Vector3 shotDirection = _shotParticle.transform.forward + GetSpread();
                shotDirection.Normalize();

                if (Physics.Raycast(_shotParticle.transform.position, shotDirection,
                    out RaycastHit hit, float.MaxValue, _shootConfiguration.HitLayer))
                {
                    _activeMonoBehaviour.StartCoroutine(PlayTrail(_shotParticle.transform.position,
                        hit.point, hit));
                }
                else
                {
                    _activeMonoBehaviour.StartCoroutine(PlayTrail(_shotParticle.transform.position,
                        _shotParticle.transform.position + (shotDirection * _trailConfig.MissDistance),
                        new RaycastHit()));
                }
            }
        }

        private void CreateModel(Transform parent)
        {
            _model = Instantiate(_prefab);
            _model.transform.SetParent(parent, false);
            _model.transform.localPosition = _spawnPoint;
            _model.transform.localRotation = Quaternion.Euler(_spawnRotation);
        }
        private TrailRenderer CreateTrail()
        {
            GameObject newObject = new GameObject("BulletTrail");
            TrailRenderer trailRenderer = newObject.AddComponent<TrailRenderer>();
            trailRenderer.colorGradient = _trailConfig.Color;
            trailRenderer.material = _trailConfig.Material;
            trailRenderer.widthCurve = _trailConfig.WidthCurve;
            trailRenderer.time = _trailConfig.Duration;
            trailRenderer.minVertexDistance = _trailConfig.MinVertexDistancve;
            trailRenderer.emitting = false;
            trailRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            return trailRenderer;
        }
        private IEnumerator PlayTrail(Vector3 startPoint, Vector3 endPoint, RaycastHit hit)
        {
            TrailRenderer trailRenderer = _trailPool.Get();
            trailRenderer.gameObject.SetActive(true);
            trailRenderer.transform.position = startPoint;
            yield return null;

            trailRenderer.emitting = true;
            var distance = Vector3.Distance(startPoint, endPoint);
            float remainingDistance = distance;

            while (remainingDistance > 0)
            {
                trailRenderer.transform.position = Vector3.Lerp(startPoint, endPoint,
                    Mathf.Clamp01(1 - (remainingDistance / distance)));
                remainingDistance -= _trailConfig.SimulationSpeed * Time.deltaTime;

                yield return null;
            }

            trailRenderer.transform.position = endPoint;

            if(hit.collider != null)
            {
               ///Add impact on target
            }

            yield return _waitForTrail;
            yield return null;

            trailRenderer.emitting = false;
            trailRenderer.gameObject.SetActive(false);
            _trailPool.Release(trailRenderer);
        }
        private Vector3 GetSpread()
        {
            var xRange = UnityEngine.Random.Range(-_shootConfiguration.Spread.x, _shootConfiguration.Spread.x);
            var yRange = UnityEngine.Random.Range(-_shootConfiguration.Spread.y, _shootConfiguration.Spread.y);
            var zRange = UnityEngine.Random.Range(-_shootConfiguration.Spread.z, _shootConfiguration.Spread.z);

            var randomSpreadVector = new Vector3(xRange, yRange, zRange);

            return randomSpreadVector;
        }
    }
}
