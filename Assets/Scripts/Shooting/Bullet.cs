using Logic;
using Services;
using Services.Audio;
using UnityEngine;

namespace Shooting
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float lifeTime;
        [SerializeField] private ParticleSystem impactFx;
    
        
        private IAudioService _audioService;
        public BulletPool OriginFactory { get; set; }
        private ShotMessage _message;
        private Vector3 _velocity;
        private Rigidbody _rb;
        private float _aliveTime;

        private void Awake()
        {
            _audioService = AllServices.Container.Single<IAudioService>();
            GetComponent<Collider>().isTrigger = true;
            _rb = GetComponent<Rigidbody>();
            _rb.isKinematic = true;
        }

        private void FixedUpdate()
        {
            _rb.MovePosition(transform.position + _velocity * Time.fixedDeltaTime);
            _aliveTime += Time.fixedDeltaTime;
            if (_aliveTime > lifeTime)
            {
                OriginFactory.Reclaim(this);
            }
        }

        public void Init(ShotMessage message)
        {
            this._message = message;
            _velocity = message.direction * message.speed;
            transform.rotation = Quaternion.LookRotation(message.direction);
            transform.position = message.spawnPoint;
            _aliveTime = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ShotTarget shotTarget))
            {
                _message.impactPoint = transform.position;
                shotTarget.TakeShot(_message);
                Instantiate(impactFx, transform.position, Quaternion.LookRotation(-transform.forward));
                _audioService.PlayOneShot(AudioTypeId.BulletHit);
                OriginFactory.Reclaim(this);
            }
        }
    }
}