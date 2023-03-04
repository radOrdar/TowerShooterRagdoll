using System.Collections.Generic;
using Infrastructure.AssetManagement;
using Logic.EnemySpawners;
using Services.PersistentProgress;
using Services.StaticData;
using StaticData;
using UnityEngine;
using UnityEngine.AI;

namespace Infrastructure.Factory
{
    class GameFactory : IGameFactory
    {
        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<ISavedProgress> ProgressWriters { get; } = new();

        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;
        private GameObject _heroGameObject;

        public GameFactory(IAssetProvider assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        public void CreateHero(GameObject at)
        {
            _heroGameObject = InstantiateRegistered(AssetPath.HeroPath, at.transform.position);
        }

        public void CreateSpawner(string spawnerId, Vector3 at, MonsterTypeId monsterTypeId)
        {
            SpawnPoint spawner = InstantiateRegistered(AssetPath.Spawner, at).GetComponent<SpawnPoint>();

            spawner.Construct(this);
            spawner.MonsterTypeId = monsterTypeId;
            spawner.Id = spawnerId;
        }

        public GameObject CreateMonster(MonsterTypeId monsterTypeId, Transform parent)
        {
            MonsterStaticData monsterData = _staticData.ForMonster(monsterTypeId);
            GameObject monster = Object.Instantiate(monsterData.Prefab, parent.position, Quaternion.identity, parent);
            monster.GetComponent<NavMeshAgent>().speed = monsterData.MoveSpeed;
            monster.GetComponent<Enemy.Enemy>().Construct(_heroGameObject.transform);
            
            return monster;
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);
            RegisterProgressWatchers(gameObject);

            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
            {
                if (progressReader is ISavedProgress progressWriter)
                {
                    ProgressWriters.Add(progressWriter);
                }

                ProgressReaders.Add(progressReader);
            }
        }
    }
}