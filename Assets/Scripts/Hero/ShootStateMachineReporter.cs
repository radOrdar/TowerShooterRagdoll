using UnityEngine;

namespace Hero
{
    public class ShootStateMachineReporter : StateMachineBehaviour
    {
        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
            base.OnStateMachineEnter(animator, stateMachinePathHash);
            foreach (IShootStateReader shootStateReader in animator.GetComponents<IShootStateReader>()) 
                shootStateReader.EnteredState();
        }

        public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
        {
            base.OnStateMachineExit(animator, stateMachinePathHash);
            foreach (IShootStateReader shootStateReader in animator.GetComponents<IShootStateReader>()) 
                shootStateReader.ExitedState();
        }
    }
}
