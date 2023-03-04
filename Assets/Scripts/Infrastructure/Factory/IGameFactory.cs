using System.Collections.Generic;
using Services;
using Services.PersistentProgress;
using StaticData;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
        void CreateHero(GameObject at);
        void CreateSpawner(string spawnerId, Vector3 at, MonsterTypeId monsterTypeId);
        GameObject CreateMonster(MonsterTypeId monsterTypeId, Transform parent);
    }
}