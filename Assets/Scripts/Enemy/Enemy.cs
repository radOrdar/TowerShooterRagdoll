using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float checkTargetPeriod = 0.2f;

    public HeroController target;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    
    private float lastCheckTargetTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (Time.time - lastCheckTargetTime > checkTargetPeriod)
        {
            if (target == null)
            {
                return;
            }

            lastCheckTargetTime = Time.time;
            if (navMeshAgent.enabled == false) return;

            Vector3 toTarget = target.transform.position - transform.position;
            if (toTarget.sqrMagnitude < navMeshAgent.radius * navMeshAgent.radius)
            {
                toTarget.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(toTarget), Time.deltaTime * 20);
                navMeshAgent.isStopped = true;
            } else
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(target.transform.position);
            }
        }
    }
}