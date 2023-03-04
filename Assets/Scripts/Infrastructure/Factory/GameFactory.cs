using System.Collections.Generic;
using Services.PersistentProgress;

namespace Infrastructure.Factory
{
    class GameFactory : IGameFactory
    {
        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<ISavedProgress> ProgressWriters { get; } = new();
        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }
    }
}