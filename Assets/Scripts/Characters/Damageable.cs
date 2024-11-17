using System;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour {
    [SerializeField] private Int16 maxHealth = 100;
    [SerializeField] private Int16 health = 100;
    [SerializeField] private Boolean isAlive = true;
    [SerializeField] private Boolean isInvencible = false;
    [SerializeField] private Single invincibilityTime = 1.5f;
    [SerializeField] private UnityEvent<Int16, Vector2> onDamageTaken;

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

    public Boolean LockVelocity {
        get { return animator.GetBool(Animations.LockVelocity); }
        set { animator.SetBool(Animations.LockVelocity, value); }
    }

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        CheckInvincibility();
    }

    public Boolean TakeDamage(Int16 damage, Vector2 knockBack) {
        if (IsAlive && !isInvencible) {
            Health -= damage;

            NotifyDamaKnockBack(damage, knockBack);

            isInvencible = true;
            return true;
        }

        return false;
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

    private void NotifyDamaKnockBack(Int16 damage, Vector2 knockBack) {
        LockVelocity = true;
        animator.SetTrigger(Animations.HitTrigger);
        onDamageTaken.Invoke(damage, knockBack);
    }
}
