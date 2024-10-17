using System;
using System.Collections;
using UnityEngine;
using Helpers;
using Attributes;

namespace Behaviours.Items
{
    class WeaponClip
    {
        public event Action ClipIsEmpty;
        public event Action ClipsIsEnd;
        public event Action ReloadIsStarted;
        public event Action ReloadIsCompleted;

        private ProjectileWeapon _weapon;
        private Projectile _projectilePrefab;
        private CertainPool<Projectile> _projectilesPool;
        private ObjectAttributeInt _clipsAmountAttribute;
        private ObjectAttributeInt _bulletsInClipAttribute;
        private WaitForSeconds _waitForReloadEnd;
        private Coroutine _reloadCoroutine;

        private int _poolCapacity;
        private int _clipsAmount;
        private int _bulletsInClip;

        public WeaponClip(Transform barrelTransform, Projectile projectilePrefab, ProjectileWeapon weapon)
        {
            _weapon = weapon;
            _projectilePrefab = projectilePrefab;
            _clipsAmountAttribute = weapon.WeaponAttributes.ClipsAmount;
            _bulletsInClipAttribute = weapon.WeaponAttributes.BulletsInClip;
            _clipsAmount = _clipsAmountAttribute.CurrentValue;
            _bulletsInClip = _bulletsInClipAttribute.CurrentValue;
            _poolCapacity = _bulletsInClip;
            _waitForReloadEnd = new WaitForSeconds(weapon.WeaponAttributes.ReloadTime.CurrentValue);
            _projectilesPool = new CertainPool<Projectile>(_poolCapacity, barrelTransform, _projectilePrefab);
        }

        public int ClipsAmount => _clipsAmount;
        public int BulletsInClip => _bulletsInClip;

        public Projectile GetProjectile()
        {
            var projectile = _projectilesPool.GetObject() as Projectile;
            if (projectile is Projectile)
            {
                RemoveBullets(1);
                return projectile;
            }
            else
            {
                throw new Exception($"{this.GetType()} is trying to get projectile from pool but somthing went wrong ");
            }
        }
        public bool TryGetBulletFromClip(out Projectile projectile)
        {
            if (IsCanTakeBullet())
            {
                projectile = GetProjectile();
                return true;
            }
            else 
            {
                projectile = null;
                return false; 
            }
        }
        public void Reload()
        {
            if (ReferenceEquals(_reloadCoroutine, null))
            {
                _reloadCoroutine = _weapon.StartCoroutine(Reloading());
            }
        }
        public bool AddClips(int clipsAdd)
        {
            if (_clipsAmount >= _clipsAmountAttribute.CurrentValue)
            {
                return false;
            }
            else
            {
                var expectedClips = _clipsAmount + clipsAdd;
                if (expectedClips > _clipsAmountAttribute.CurrentValue)
                {
                    _clipsAmount = _clipsAmountAttribute.CurrentValue;
                }
                else
                {
                    _clipsAmount = expectedClips;
                }
            }
            return true;
        }
        public bool IsCanTakeBullet()
        {
            if (_bulletsInClip > 0)
            {
                return true;
            }
            else { return false; }
        }
        private void AddBullets(int value)
        {
            _bulletsInClip += value;
            ChangeBulletsInClip();
        }
        private void RemoveBullets(int value)
        {
            _bulletsInClip -= value;
            ChangeBulletsInClip();
        }
        private void ChangeBulletsInClip()
        {
            _weapon.ProjectileWeaponSubjects.BulletsChanged(_bulletsInClip);
        }
        private IEnumerator Reloading()
        {
            StartReload();
            yield return _waitForReloadEnd;
            _reloadCoroutine = null;
            ReloadClip();
            ReloadIsCompleted?.Invoke();
        }
        private void StartReload()
        {
            ReloadIsStarted?.Invoke();
        }
        private void ReloadClip()
        {
            if (_clipsAmount > 0)
            {
                _clipsAmount--;
                _bulletsInClip = 0;
                AddBullets(_bulletsInClipAttribute.CurrentValue);
            }
            else
            {
                ClipsIsEnd?.Invoke();
                return;
            }
        }
    }
}
