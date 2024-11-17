using System;
using UnityEngine;

public class Damageable : MonoBehaviour {
    [SerializeField] private Int16 maxHealth = 100;
    [SerializeField] private Int16 health = 100;
    [SerializeField] private Boolean isAlive = true;
    [SerializeField] private Boolean isInvencible = false;
    [SerializeField] private Single invincibilityTime = 1.5f;

    private Animator animator;

    private Single timeSinceHit = 0f;

    public Int16 MaxHealth {
        get { return maxHealth; }
        private set { maxHealth = value; }
    }

    public Int16 Health {
        get { return health; }
        private set {
            health = value;
            if (health <= 0) {
                IsAlive = false;
            }
        }
    }

    public Boolean IsAlive {
        get { return isAlive; }
        private set {
            isAlive = value;
            animator.SetBool(Animations.IsAlive, value);
        }
    }

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        CheckInvincibility();
    }

    public void TakeDamage(Int16 damage) {
        if (IsAlive && !isInvencible) {
            Health -= damage;
            isInvencible = true;
        }
    }

    private void CheckInvincibility() {
        if (isInvencible) {
            if (timeSinceHit > invincibilityTime) {
                timeSinceHit = 0f;
                isInvencible = false;
            }

            timeSinceHit += Time.deltaTime;
        }
    }
}
