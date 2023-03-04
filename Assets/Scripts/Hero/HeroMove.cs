using System;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class HeroMove : MonoBehaviour
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
    }
}