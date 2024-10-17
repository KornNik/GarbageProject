using System;
using UnityEngine;
using Attributes;

namespace Behaviours.Items
{
    [Serializable]
    class ProjectileCurve
    {
        [SerializeField] private AnimationCurve DamageReductionGraph;

        private float _startTime;
        private Vector3 _previousStep;
        private Transform _projectileTransform;

        private ProjectileAttributes _projectileAttributes;

        private ProjectileCurve()
        {

        }
        public ProjectileCurve(ProjectileAttributes projectileAttributes,Transform projectileTransform)
        {
            _projectileTransform = projectileTransform;
            _projectileAttributes = projectileAttributes;

            Keyframe[] ks;
            ks = new Keyframe[3];

            ks[0] = new Keyframe(0, 1);
            ks[1] = new Keyframe(_projectileAttributes.StartPointOfDamageReduction.CurrentValue / 100, 1);
            ks[2] = new Keyframe(1, _projectileAttributes.FinalDamageInPercent.CurrentValue / 100);

            DamageReductionGraph = new AnimationCurve(ks);
        }
        public void OnEnable()
        {
            _startTime = Time.time;
            _previousStep = _projectileTransform.position;
        }
        public void FixedUpdate()
        {
            Quaternion CurrentStep = _projectileTransform.rotation;

            _projectileTransform.LookAt(_previousStep, _projectileTransform.up);
            float Distance = Vector3.Distance(_previousStep, _projectileTransform.position);
            if (Distance == 0.0f)
                Distance = 1e-05f;
            Debug.Log(Distance);

            _projectileTransform.rotation = CurrentStep;

            _previousStep = _projectileTransform.position;
        }

        public float GetDamageCoefficient()
        {
            float Value = 1.0f;
            float CurrentTime = Time.time - _startTime;
            Value = DamageReductionGraph.Evaluate(CurrentTime / _projectileAttributes.TimeToDestruct);

            return Value;
        }
    }
}
