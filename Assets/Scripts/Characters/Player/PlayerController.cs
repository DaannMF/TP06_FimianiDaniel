using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour {
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    private Rigidbody2D rb;
    private Animator animator;
    private TouchingDirections touchingDirections;
    private Vector2 moveInput;
    private Boolean _isMoving = false;
    public Boolean IsMoving {
        get {
            return _isMoving;
        }
        private set {
            _isMoving = value;
            animator.SetBool(Animations.IsMoving, value);
        }
    }

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    private void FixedUpdate() {
        Move();
    }

    public void OnInputMove(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection();
    }

    public void OnJump(InputAction.CallbackContext context) {
        if (context.started) {
            Jump();
        }
    }

    private void SetFacingDirection() {
        if (moveInput.x != 0)
            transform.localScale = new Vector3(
                    Mathf.Sign(moveInput.x),
                    transform.localScale.y,
                    transform.localScale.z
            );
    }

    private void Move() {
        if (!touchingDirections.IsOnWAll)
            rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
        animator.SetFloat(Animations.YVelocity, rb.velocity.y);
    }

    private void Jump() {
        if (touchingDirections.IsGround) {
            animator.SetTrigger(Animations.Jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
