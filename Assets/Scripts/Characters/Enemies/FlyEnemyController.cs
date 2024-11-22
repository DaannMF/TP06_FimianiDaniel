using System;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyController : MonoBehaviour {
    [SerializeField] private EnemyMovementStats stats;
    [SerializeField] private List<Transform> waypoints = new();
    private Rigidbody2D rb;
    private DetectionZone detectionZone;
    private Animator animator;
    private Damageable damageable;
    private Transform nextWaypoint;
    private Int16 currentWaypointIndex = 0;
    private Boolean _hasTarget;
    private Single speed = 3f;
    public Single Speed {
        get { return speed; }
        private set { speed = value; }
    }

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
        detectionZone = GetComponentInChildren<DetectionZone>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        damageable = GetComponent<Damageable>();
        Speed = stats.speed;
    }

    private void Start() {
        nextWaypoint = waypoints[currentWaypointIndex];
    }

    // Update is called once per frame
    void Update() {
        DetectTarget();
    }

    private void FixedUpdate() {
        Fly();
    }

    private void DetectTarget() {
        HasTarget = detectionZone.HasDetectedColliders;
    }

    private void Fly() {
        if (damageable.IsAlive) {
            if (CanMove) {
                Vector2 direction = (nextWaypoint.position - transform.position).normalized;
                rb.velocity = direction * speed;
                UpdateDirection();

                if (Vector2.Distance(transform.position, nextWaypoint.position) < 0.1f) {
                    currentWaypointIndex = (Int16)((currentWaypointIndex + 1) % waypoints.Count);
                    nextWaypoint = waypoints[currentWaypointIndex];
                }
            }
            else {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void UpdateDirection() {
        transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x) * -1, 1);
    }
}
