using Data;

namespace Services.PersistentProgress
{
    public interface ISavedProgress : IPersistentProgressService
    {
        void UpdateProgress(PlayerProgress progress);
    }
}