using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageableStats", menuName = "Character/DamageableStats")]
public class DamageableStats : ScriptableObject {
    public Int16 maxHealth = 100;
    public Int16 health = 100;
    public Boolean isAlive = true;
    public Boolean isInvencible = false;
    public Single invincibilityTime = 1.5f;
}
