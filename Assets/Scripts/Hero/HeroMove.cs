using System;
using Data;
using Services.PersistentProgress;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Hero
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class HeroMove : MonoBehaviour, ISavedProgress
    {
        private NavMeshAgent _navmeshAgent;

        private void Awake()
        {
            _navmeshAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 to)
        {
            _navmeshAgent.SetDestination(to);
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (CurrentLevel() != progress.WorldData.PositionOnLevel.Level)
                return;

            Vector3Data savedPosition = progress.WorldData.PositionOnLevel.Position;
            if (savedPosition != null) 
                Warp(savedPosition);
        }

        private void Warp(Vector3Data savedPosition)
        {
            _navmeshAgent.Warp(savedPosition.AsUnityVector());
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.PositionOnLevel = progress.WorldData.PositionOnLevel =
                new PositionOnLevel(CurrentLevel(), transform.position.AsVectorData());
        }

        private string CurrentLevel() => 
            SceneManager.GetActiveScene().name;
    }
}