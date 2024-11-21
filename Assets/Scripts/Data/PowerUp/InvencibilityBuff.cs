
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "InvincibilityBuff", menuName = "PowerUp/InvincibilityBuff")]
public class InvincibilityBuff : PowerUpEffect {
    [SerializeField] private Single duration = 10;
    [SerializeField] public AudioClip audioClip;

    public override void ApplyEffect(GameObject target) {
        Damageable damageable = target.GetComponent<Damageable>();
        damageable.ApplyInvincibilityBuff(duration);
    }
}
