using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageable))]
public class PlayerController : MonoBehaviour {

    [SerializeField] private PlayerMovementStats stats;
    private Rigidbody2D rb;
    private Animator animator;
    private TouchingDirections touchingDirections;

    private Single walkSpeed;
    private Single jumpForce;
    private Int16 maxJumps;

    private Damageable damageable;
    private Vector2 moveInput;
    private Int16 jumpCount = 0;
    private Boolean _isMoving = false;

    public Single WalkSpeed {
        get { return walkSpeed; }
        private set { walkSpeed = value; }
    }

    public Single JumpForce {
        get { return jumpForce; }
        private set { jumpForce = value; }
    }

    public Int16 MaxJumps {
        get { return maxJumps; }
        private set { maxJumps = value; }
    }

    public Boolean IsMoving {
        get { return _isMoving; }
        private set {
            _isMoving = value;
            animator.SetBool(Animations.IsMoving, value);
        }
    }

    public Boolean CanMove {
        get { return animator.GetBool(Animations.CanMove); }
    }

    public Boolean IsAlive {
        get { return animator.GetBool(Animations.IsAlive); }
    }

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<Damageable>();
        WalkSpeed = stats.walkSpeed;
        JumpForce = stats.jumpForce;
        MaxJumps = stats.maxJumps;
    }

    private void Update() {
        ResetJumpCount();
    }

    private void FixedUpdate() {
        Move();
    }

    public void OnInputMove(InputAction.CallbackContext context) {
        moveInput = context.ReadValue<Vector2>();
        if (IsAlive) {
            IsMoving = moveInput != Vector2.zero;
            SetFacingDirection();
        }
    }

    public void OnJump(InputAction.CallbackContext context) {
        if (context.started && CanMove) {
            Jump();
        }
    }

    public void OnAttack(InputAction.CallbackContext context) {
        if (context.started) {
            animator.SetTrigger(Animations.AttackTrigger);
        }
    }

    public void OnHit(Int16 damage, Vector2 knockBack) {
        if (IsAlive)
            rb.velocity = new Vector2(knockBack.x, rb.velocity.y + knockBack.y);
    }

    private void SetFacingDirection() {
        if (moveInput.x != 0) {
            transform.localScale = new Vector2(Mathf.Sign(moveInput.x), 1);
        }
    }

    private void Move() {
        if (!damageable.LockVelocity) {
            if (CanMove && !touchingDirections.IsOnWAll) {
                rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
                animator.SetFloat(Animations.YVelocity, rb.velocity.y);
            }
            else {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    private void Jump() {
        if (touchingDirections.IsGround || jumpCount < maxJumps - 1) {
            if (jumpCount == 0)
                animator.SetTrigger(Animations.JumpTrigger);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
    }

    private void ResetJumpCount() {
        if (IsAlive && touchingDirections.IsGround) {
            jumpCount = 0;
        }
    }

    public void ApplyJumpBuff(Single duration) {
        maxJumps += 1;
        Invoke(nameof(RemoveJumpBuff), duration);
    }

    private void RemoveJumpBuff() {
        maxJumps -= 1;
    }
}
