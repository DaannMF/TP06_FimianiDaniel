using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageable))]
public class GroundEnemyController : MonoBehaviour {
    [SerializeField] private EnemyMovementStats stats;
    private Rigidbody2D rb;
    private Animator animator;
    private DetectionZone detectionZone;
    private DetectionZone groundDetectionZone;
    private TouchingDirections touchingDirections;
    private Damageable damageable;
    private Vector2 lookDirection = Vector2.right;
    private WalkableDirection _walkDirection;
    private Single speed = 3f;

    public Single Speed {
        get { return speed; }
        private set { speed = value; }
    }

    public WalkableDirection WalkDirection {
        get { return _walkDirection; }
        private set {
            if (_walkDirection != value) {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                lookDirection = value == WalkableDirection.Right ? Vector2.right : Vector2.left;
            }

            _walkDirection = value;
        }
    }
    private Boolean _hasTarget;
    public Boolean HasTarget {
        get { return _hasTarget; }
        private set {
            _hasTarget = value;
            animator.SetBool(Animations.HasTarget, value);
        }
    }

    private Boolean CanMove {
        get { return animator.GetBool(Animations.CanMove); }
    }

    public Single AttackCoolDown {
        get { return animator.GetFloat(Animations.AttackCoolDown); }
        private set { animator.SetFloat(Animations.AttackCoolDown, Mathf.Max(value, 0)); }
    }

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        DetectionZone[] detectionZones = GetComponentsInChildren<DetectionZone>();
        detectionZone = detectionZones[0];
        groundDetectionZone = detectionZones[1];
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();
        Speed = stats.speed;
    }

    private void Update() {
        DetectTarget();
        CoolDownAttack();
    }

    private void FixedUpdate() {
        Move();
    }

    public void OnHit(Int16 damage, Vector2 knockBack) {
        rb.velocity = new Vector2(knockBack.x, rb.velocity.y + knockBack.y);
    }

    private void Move() {
        if (touchingDirections.IsGround &&
        (touchingDirections.IsOnWAll || !groundDetectionZone.HasDetectedColliders)) {
            FlipDirection();
        }
        if (!damageable.LockVelocity) {
            if (CanMove)
                rb.velocity = new Vector2(Speed * lookDirection.x, rb.velocity.y);
            else
                rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void FlipDirection() {
        WalkDirection = WalkDirection == WalkableDirection.Right ? WalkableDirection.Left : WalkableDirection.Right;
    }

    private void DetectTarget() {
        HasTarget = detectionZone.HasDetectedColliders;
    }

    private void CoolDownAttack() {
        if (AttackCoolDown > 0)
            AttackCoolDown -= Time.deltaTime;
    }
}
