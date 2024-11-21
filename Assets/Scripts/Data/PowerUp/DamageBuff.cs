
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageBuff", menuName = "PowerUp/DamageBuff")]
public class DamageBuff : PowerUpEffect {
    [SerializeField] private Int16 damageBuff = 15;
    [SerializeField] private float duration = 10;
    [SerializeField] public AudioClip audioClip;

    public override void ApplyEffect(GameObject target) {
        Attack[] attack = target.GetComponentsInChildren<Attack>();
        foreach (Attack a in attack) {
            a.ApplyDamageBuff(damageBuff, duration);
        }
    }
}
