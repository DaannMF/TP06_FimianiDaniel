using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Slider healthSlider;
    Damageable damageable;

    private void Awake() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        damageable = player.GetComponent<Damageable>();
    }

    private void OnEnable() {
        damageable.onHealthChanged.AddListener(UpdateHealthBar);
    }

    void Start() {
        UpdateHealthBar(damageable.Health, damageable.MaxHealth);
    }

    private void OnDisable() {
        damageable.onHealthChanged.RemoveListener(UpdateHealthBar);
    }

    private void UpdateHealthBar(Single currentHealth, Single maxHealth) {
        Single value = Math.Max(currentHealth / maxHealth, 0);
        healthSlider.value = value;
        healthText.text = $"Health: {Math.Max(currentHealth, 0)}/{maxHealth}";
    }
}
