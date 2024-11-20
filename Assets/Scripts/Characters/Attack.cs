using System;
using UnityEngine;

public class Attack : MonoBehaviour {
    [SerializeField] private AttackStats attackStats;
    private Int16 buff = 0;

    private Int16 Damage {
        get { return attackStats.damage; }
        set { attackStats.damage = value; }
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
        this.buff = buff;
        Damage += this.buff;
        Invoke(nameof(RemoveDamageBuff), duration);
    }

    private void RemoveDamageBuff() {
        Damage -= this.buff;
        this.buff = 0;
    }
}
