using System;
using UnityEngine;

public class Attack : MonoBehaviour {
    [SerializeField] private AttackStats attackStats;
    private Int16 currentBuff = 0;

    private Int16 damage;
    private Vector2 knockBack;

    private Int16 Damage {
        get { return damage; }
        set { damage = value; }
    }

    private void Awake() {
        Damage = attackStats.damage;
        knockBack = attackStats.knockBack;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Damageable damageable = other.GetComponent<Damageable>();
        Vector2 knockBackDirection = new Vector2(
            attackStats.knockBack.x * Mathf.Sign(transform.parent.localScale.x),
            attackStats.knockBack.y
        );
        damageable?.TakeDamage(Damage, knockBackDirection);
    }

    public void ApplyDamageBuff(Int16 buff, Single duration) {
        currentBuff = buff;
        Damage += buff;
        Invoke(nameof(RemoveDamageBuff), duration);
    }

    private void RemoveDamageBuff() {
        Damage -= currentBuff;
        currentBuff = 0;
    }
}
