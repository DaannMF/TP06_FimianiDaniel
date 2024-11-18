using System;
using UnityEngine;

public class TouchingDirections : MonoBehaviour {
    [Header("Cast Filter")]
    [SerializeField] private ContactFilter2D castFilter;
    [SerializeField] private CapsuleCollider2D touchCollider;

    [Header("Ground Check")]
    [SerializeField] private readonly RaycastHit2D[] groundHits = new RaycastHit2D[5];
    [SerializeField] private readonly Single groundDistance = 0.5f;

    [Header("Wall Check")]
    [SerializeField] private readonly RaycastHit2D[] wallHits = new RaycastHit2D[5];
    [SerializeField] private readonly Single wallDistance = 0.2f;

    [Header("Ceiling Check")]
    [SerializeField] private readonly RaycastHit2D[] ceilingHits = new RaycastHit2D[5];
    [SerializeField] private readonly Single ceilingDistance = 0.5f;

    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;
    private Animator animator;
    private Boolean _isGround;
    public Boolean IsGround {
        get { return _isGround; }
        private set {
            _isGround = value;
            animator.SetBool(Animations.IsGround, value);
        }
    }

    private Boolean _isOnWAll;
    public Boolean IsOnWAll {
        get { return _isOnWAll; }
        private set {
            _isOnWAll = value;
            animator.SetBool(Animations.IsOnWAll, value);
        }
    }

    private Boolean _isOnCeiling;
    public Boolean IsOnCeiling {
        get { return _isOnCeiling; }
        private set {
            _isOnCeiling = value;
            animator.SetBool(Animations.IsOnCeiling, value);
        }
    }


    private void Awake() {
        touchCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        IsGround = touchCollider.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;
        IsOnWAll = touchCollider.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchCollider.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;
    }
}
