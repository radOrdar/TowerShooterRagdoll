using Logic;

namespace Services.Audio
{
    public interface IAudioService : IService
    {
        void PlayOneShot(AudioTypeId audioTypeId);
    }
}