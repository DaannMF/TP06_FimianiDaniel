using System;
using UnityEngine;

public class Attack : MonoBehaviour {
    [SerializeField] private Int16 damage = 10;

    private void OnTriggerEnter2D(Collider2D other) {
        Damageable damageable = other.GetComponent<Damageable>();
        damageable?.TakeDamage(damage);
    }
}
