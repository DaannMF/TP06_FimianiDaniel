using System;
using UnityEngine;

public class Attack : MonoBehaviour {
    [SerializeField] private Int16 damage = 10;
    [SerializeField] private Vector2 knockBack = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D other) {
        Damageable damageable = other.GetComponent<Damageable>();
        Vector2 knockBackDirection = new Vector2(
            knockBack.x * Mathf.Sign(transform.parent.localScale.x),
            knockBack.y
        );
        damageable?.TakeDamage(damage, knockBackDirection);
    }
}
