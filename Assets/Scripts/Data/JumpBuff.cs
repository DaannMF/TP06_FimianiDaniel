
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "JumpBuff", menuName = "PowerUp/JumpBuff")]
public class JumpBuff : PowerUpEffect {
    [SerializeField] private float duration = 10;

    public override void ApplyEffect(GameObject target) {
        PlayerController playerController = target.GetComponent<PlayerController>();
        playerController.ApplyJumpBuff(duration);
    }
}
