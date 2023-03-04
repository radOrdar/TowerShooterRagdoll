using UnityEngine;

public class HeroIKControl : MonoBehaviour, IShootStateReader
{
    protected Animator animator;

    private bool _ikActive = false;
    public Transform leftHandTarget;
    public Transform rightHandTarget;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //a callback for calculating IK
    void OnAnimatorIK()
    {
        if (animator)
        {
            if (_ikActive)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
                animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
            } else
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            }
        }
    }

    public void EnteredState()
    {
        _ikActive = true;
    }

    public void ExitedState()
    {
        _ikActive = false;
    }
}