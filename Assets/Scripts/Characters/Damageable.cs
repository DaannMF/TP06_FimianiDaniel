using System;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour {
    [SerializeField] private DamageableStats stats;
    [SerializeField] private UnityEvent<Int16, Vector2> onDamageTaken;
    [SerializeField] public UnityEvent<Single, Single> onHealthChanged;

    private Int16 maxHealth;
    private Int16 health;
    private Boolean isAlive = true;
    private Boolean isInvencible = false;
    private Single invincibilityTime = 0.5f;

    private EnemyFloatingHealthBar enemyFloatingHealthBar;

    private Animator animator;

    private Single timeSinceHit = 0f;

    public Int16 MaxHealth {
        get { return maxHealth; }
        private set {
            maxHealth = value;
            onHealthChanged?.Invoke(health, maxHealth);
        }
    }

    public Int16 Health {
        get { return health; }
        private set {
            health = value;
            onHealthChanged?.Invoke(health, maxHealth);
            if (health <= 0) {
                IsAlive = false;
                if (gameObject.tag != "Player")
                    CharactersEvents.enemyDied.Invoke(stats.score, stats.coins);
                else
                    CharactersEvents.playerDied.Invoke();
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
        enemyFloatingHealthBar = GetComponentInChildren<EnemyFloatingHealthBar>();
        MaxHealth = stats.maxHealth;
        Health = stats.health;
        isInvencible = stats.isInvencible;
        invincibilityTime = stats.invincibilityTime;
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

        if (isInvencible) {
            CharactersEvents.characterInvincible.Invoke(gameObject);
        }

        return false;
    }

    public Boolean Heal(Int16 healAmount) {
        if (IsAlive && Health < MaxHealth) {
            Int16 maxHealth = (Int16)Math.Max(MaxHealth - Health, 0);
            Int16 actualHealAmount = (Int16)Math.Min(healAmount, maxHealth);
            Health += actualHealAmount;
            CharactersEvents.characterHealed.Invoke(gameObject, actualHealAmount);
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
        if (enemyFloatingHealthBar) enemyFloatingHealthBar.UpdateHealthBar(Health, MaxHealth);
        CharactersEvents.characterDamaged.Invoke(gameObject, damage);
    }

    public void ApplyInvincibilityBuff(Single duration) {
        isInvencible = true;
        invincibilityTime += duration;
        Invoke(nameof(RemoveInvincibilityBuff), duration);
    }

    public void ApplyBuyMaxHealth(Int16 healthBuy) {
        MaxHealth += healthBuy;
        if (enemyFloatingHealthBar) enemyFloatingHealthBar.UpdateHealthBar(Health, MaxHealth);
    }

    public void RemoveInvincibilityBuff() {
        isInvencible = false;
        invincibilityTime = stats.invincibilityTime;
    }
}
