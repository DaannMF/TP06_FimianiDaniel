using System;
using UnityEngine;

public class SetFloatBehaviour : StateMachineBehaviour {
    [SerializeField] private String floatName;
    [SerializeField] private Boolean updateOnState;
    [SerializeField] private Single valueOnEnter, valueOnExit;
    [SerializeField] private Single valueOnMachineEnter, valueOnMachineExit;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (updateOnState)
            animator.SetFloat(floatName, valueOnEnter);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (updateOnState)
            animator.SetFloat(floatName, valueOnExit);
    }

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash) {
        if (!updateOnState)
            animator.SetFloat(floatName, valueOnMachineEnter);
    }

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash) {
        if (!updateOnState)
            animator.SetFloat(floatName, valueOnMachineExit);
    }
}
