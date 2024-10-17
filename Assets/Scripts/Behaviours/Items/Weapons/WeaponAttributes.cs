using UnityEngine;

namespace Attributes
{
    [System.Serializable]
    struct WeaponAttributes
    {
        [SerializeField] private ObjectAttributeFloat _recoil;
        [SerializeField] private ObjectAttributeFloat _fireRate;
        [SerializeField] private ObjectAttributeFloat _distance;
        [SerializeField] private ObjectAttributeFloat _reloadTime;
        [SerializeField] private ObjectAttributeInt _bulletsInClip;
        [SerializeField] private ObjectAttributeInt _clipsAmount;
        [SerializeField] private ObjectAttributeInt _modificationsAmount;

        public ObjectAttributeFloat Recoil => _recoil;
        public ObjectAttributeFloat FireRate => _fireRate;
        public ObjectAttributeFloat Distance => _distance;
        public ObjectAttributeFloat ReloadTime => _reloadTime;
        public ObjectAttributeInt BulletsInClip => _bulletsInClip;
        public ObjectAttributeInt ClipsAmount => _clipsAmount;
        public ObjectAttributeInt ModificationsAmount => _modificationsAmount;
    }
}
