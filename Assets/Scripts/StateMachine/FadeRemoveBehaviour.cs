using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class FadeRemoveBehaviour : StateMachineBehaviour {
    [SerializeField] private Single fadeTime = 0.5f;
    private SpriteRenderer spriteRenderer;
    private ParticleSystem particleSystem;
    private Single fadeTimer = 0f;
    private Color startColor;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        fadeTimer = 0f;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();
        startColor = spriteRenderer.color;
        particleSystem = animator.GetComponent<ParticleSystem>();
        particleSystem.Play();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        fadeTimer += Time.deltaTime;

        Single newAlpha = startColor.a * (1 - fadeTimer / fadeTime);
        spriteRenderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);

        if (fadeTimer >= fadeTime) {
            Destroy(animator.gameObject);
        }
    }
}
