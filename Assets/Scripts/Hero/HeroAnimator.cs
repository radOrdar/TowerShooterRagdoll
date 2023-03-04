using System;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    [RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
    public class HeroAnimator : MonoBehaviour
    {
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;
        
        private static readonly int speedId = Animator.StringToHash("Speed");
        private static readonly int shootBehaviourId = Animator.StringToHash("ShootBehaviour");
        private static readonly int shootOnceId = Animator.StringToHash("ShootOnce");
        private static readonly int shootLoopId = Animator.StringToHash("ShootLoop");
        private static readonly int walkId = Animator.StringToHash("Walk");
        private static readonly int attackId = Animator.StringToHash("Attack");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update() => 
            _animator.SetFloat(speedId, _navMeshAgent.velocity.magnitude);


        public void ToggleShootBehaviour(bool enable)
        {
            _animator.SetBool(shootBehaviourId, enable);
        }

        public void ShotOnce()
        {
            _animator.SetTrigger(shootOnceId);
        }

        public void ToggleShotLoop(bool enable)
        {
            _animator.SetBool(shootLoopId, enable);
        }
    }
}