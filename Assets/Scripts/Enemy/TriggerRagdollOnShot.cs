using Shooting;
using UnityEngine;
using UnityEngine.AI;

public class TriggerRagdollOnShot : MonoBehaviour
{
    private Rigidbody[] rbs;
    // private Collider[] triggerColliders;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private LayerMask layerRagdoll;

    // public bool isKinematicOnStart;
    private bool isRagdollActive = false;

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

        // triggerColliders = GetComponents<Collider>();
        TurnRagdoll(false);
        layerRagdoll = LayerMask.GetMask("Ragdoll");
    }

    public void ShotRagdoll(ShotMessage shotMessage)
    {
        TurnRagdoll(true);
        // Collider[] candidatesToImpact = Physics.OverlapSphere(shotMessage.impactPoint, 0.5f, layerRagdoll);
        // foreach (Collider col in candidatesToImpact)
        // {
        shotMessage.shotTarget.GetComponent<Rigidbody>().AddForce(100 * shotMessage.direction, ForceMode.Impulse);
        // }
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