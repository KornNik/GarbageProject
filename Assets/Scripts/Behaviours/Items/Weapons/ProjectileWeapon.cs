using UnityEngine;

namespace Behaviours.Items
{
    class ProjectileWeapon : Weapon
    {
        [SerializeField] private Transform _barrelTransform;
        [SerializeField] private Projectile _projectilePrefab;

        private WeaponClip _weaponClip;
        private ProjectileWeaponEvents _prWeaponSubjects;

        public WeaponClip WeaponClip => _weaponClip;
        public ProjectileWeaponEvents ProjectileWeaponSubjects => _prWeaponSubjects;

        protected override void Awake()
        {
            base.Awake();
            _prWeaponSubjects = new ProjectileWeaponEvents();
            _weaponClip = new WeaponClip(_barrelTransform, _projectilePrefab, this);

        }
        protected override void OnEnable()
        {
            base.OnEnable();
            _weaponClip.ClipIsEmpty += OnClipIsEmpty;
            _weaponClip.ClipsIsEnd += OnClipsIsEnd;
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            _weaponClip.ClipIsEmpty -= OnClipIsEmpty;
            _weaponClip.ClipsIsEnd -= OnClipsIsEnd;
        }
        private void OnClipIsEmpty()
        {

        }
        private void OnClipsIsEnd()
        {

        }

        public override void Attack()
        {
            Projectile projectile;
            if (_weaponClip.TryGetBulletFromClip(out projectile)) 
            {
                projectile.ActiveObject();
            }
        }

        public override void Recharge()
        {

        }
    }
}
