using Logic;
using Services.Randomizer;
using Services.StaticData;
using UnityEngine;

namespace Services.Audio
{
    public class AudioService : MonoBehaviour, IAudioService
    {
        private IRandomService _randomService;
        private IStaticDataService _staticDataService;
    
        private AudioSource _audioSource;

        public void Construct(IRandomService randomService, IStaticDataService staticDataService)
        {
            _randomService = randomService;
            _staticDataService = staticDataService;
        }
    
        private void Awake()
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }

        public void PlayOneShot(AudioTypeId audioTypeId)
        {
            _audioSource.pitch = _randomService.Range(0.6f, 1f);
            _audioSource.PlayOneShot(_staticDataService.ForAudioClip(audioTypeId));
        }
    }
}