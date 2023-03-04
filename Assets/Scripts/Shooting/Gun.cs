using Logic;
using Services;
using Services.Audio;
using UnityEngine;

namespace Shooting
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private float shotSpeed;
        [SerializeField] private float shotDamage;
        [SerializeField] private ParticleSystem shotFx;
    
        [SerializeField] private Bullet bulletPf;
        [SerializeField] private Transform spawnPoint;

        private BulletPool bulletPool;
        private IAudioService _audioService;

        private void Awake()
        {
            _audioService = AllServices.Container.Single<IAudioService>();
            bulletPool = new BulletPool(bulletPf);
            SetActive(false);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    
        public void Shoot()
        {
            Bullet bullet = bulletPool.Get();
            bullet.Init(new ShotMessage
            {
                damage = shotDamage,
                speed = shotSpeed,
                direction = spawnPoint.forward,
                spawnPoint = spawnPoint.position
            });
            _audioService.PlayOneShot(AudioTypeId.BulletShot);
            shotFx.Play();
        }
    }
}
