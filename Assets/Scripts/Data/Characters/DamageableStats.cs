using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageableStats", menuName = "Character/DamageableStats")]
public class DamageableStats : ScriptableObject {
    [Header("Health")]
    public Int16 maxHealth = 100;
    public Int16 health = 100;
    public Boolean isAlive = true;
    public Boolean isInvencible = false;
    public Single invincibilityTime = 1.5f;

    [Header("Score")]
    public Int16 score = 100;
    public Int16 coins = 10;
}
