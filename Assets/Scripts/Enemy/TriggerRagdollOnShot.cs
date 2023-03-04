using System;
using Shooting;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class TriggerRagdollOnShot : MonoBehaviour
    {
        private Rigidbody[] rbs;
        private Animator animator;
        private NavMeshAgent navMeshAgent;
        private LayerMask layerRagdoll;
        
        private bool isRagdollActive = false;

        public event Action Happened;

        private void Awake()
        {
            rbs = GetComponentsInChildren<Rigidbody>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            foreach (var rb in rbs)
            {
                ShotTarget st = rb.gameObject.AddComponent<ShotTarget>();
                st.OnShot = ShotRagdoll;
            }
            
            TurnRagdoll(false);
            layerRagdoll = LayerMask.GetMask("Ragdoll");
        }

        public void ShotRagdoll(ShotMessage shotMessage)
        {
            TurnRagdoll(true);
          
            shotMessage.shotTarget.GetComponent<Rigidbody>().AddForce(100 * shotMessage.direction, ForceMode.Impulse);
            Happened?.Invoke();
        }

        private void TurnRagdoll(bool isActive)
        {
            if (isRagdollActive && isActive) return;
            isRagdollActive = isActive;

            if (animator) animator.enabled = !isActive;
            if (navMeshAgent) navMeshAgent.enabled = !isActive;
            foreach (var rb in rbs)
            {
                rb.isKinematic = !isActive;
            }
        }
    }
}