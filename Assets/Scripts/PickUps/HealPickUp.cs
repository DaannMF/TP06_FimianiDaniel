using System;
using UnityEngine;

public class HealPickUp : MonoBehaviour {
    [SerializeField] private Int16 healAmount = 15;
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 180, 0);

    private void OnTriggerEnter2D(Collider2D other) {
        Damageable damageable = other.GetComponent<Damageable>();
        if (damageable) {
            if (damageable.Heal(healAmount))
                Destroy(gameObject);
        }
    }

    private void Update() {
        transform.eulerAngles += rotationSpeed * Time.deltaTime;
    }
}
