using System;
using UnityEngine;

public enum WalkableDirection {
    Right,
    Left
}

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(TouchingDirections))]
public class Skeleton : MonoBehaviour {
    [SerializeField] private Single walkSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private DetectionZone detectionZone;
    private TouchingDirections touchingDirections;
    private Vector2 lookDirection = Vector2.right;
    private WalkableDirection _walkDirection;
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

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        detectionZone = GetComponentInChildren<DetectionZone>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        DetectTarget();
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move() {
        if (touchingDirections.IsGround && touchingDirections.IsOnWAll) {
            FlipDirection();
        }
        if (CanMove)
            rb.velocity = new Vector2(walkSpeed * lookDirection.x, rb.velocity.y);
        else
            rb.velocity = new Vector2(0, rb.velocity.y);
    }

    private void FlipDirection() {
        WalkDirection = WalkDirection == WalkableDirection.Right ? WalkableDirection.Left : WalkableDirection.Right;
    }

    private void DetectTarget() {
        HasTarget = detectionZone.HasDetectedColliders;
    }
}
