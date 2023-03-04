using System.Collections.Generic;
using Data;
using Enemy;
using Infrastructure.Factory;
using Services.PersistentProgress;
using StaticData;
using UnityEngine;

namespace Logic.EnemySpawners
{
    public class SpawnPoint : MonoBehaviour, ISavedProgress
    {
        public MonsterTypeId MonsterTypeId;
        
        public string Id { get; set; }

        private IGameFactory _factory;

        private TriggerRagdollOnShot _ragdoll;
        private bool _slain;

        public void Construct(IGameFactory gameFactory) =>
            _factory = gameFactory;


        public void LoadProgress(PlayerProgress progress)
        {
            if (progress.ClearedSpawners.Contains(Id))
                _slain = true;
            else
                Spawn();
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            List<string> slainSpawnerList = progress.ClearedSpawners;

            if (_slain && !slainSpawnerList.Contains(Id))
            {
                slainSpawnerList.Add(Id);
            }
        }

        private void Spawn()
        {
            GameObject monster = _factory.CreateMonster(MonsterTypeId, transform);
            _ragdoll = monster.GetComponent<TriggerRagdollOnShot>();
            _ragdoll.Happened += Slay;
        }

        private void Slay()
        {
            _ragdoll.Happened -= Slay;
            _slain = true;
        }
    }
}