using System;
using UnityEngine;

public class PlayOneShootBehaviour : StateMachineBehaviour {
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private Boolean playOnEnter = true, playOnExit = false, playAfterDelay = false;
    [SerializeField] private Single delay = 0.25f;
    private AudioSource audioSource;
    private Single timeSinceEnter = 0;
    private Boolean hasDelayedSoundPlayed = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (playOnEnter) {
            audioSource = animator.gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClip);
        }

        timeSinceEnter = 0;
        hasDelayedSoundPlayed = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (playAfterDelay && !hasDelayedSoundPlayed) {
            timeSinceEnter += Time.deltaTime;
            if (timeSinceEnter >= delay) {
                audioSource = animator.gameObject.GetComponent<AudioSource>();
                audioSource.PlayOneShot(audioClip);
                hasDelayedSoundPlayed = true;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (playOnExit) {
            audioSource = animator.gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClip);
        }
    }
}
