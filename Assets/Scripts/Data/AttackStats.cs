using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackStats", menuName = "Attack/AttackStats")]
public class AttackStats : ScriptableObject {
    public Int16 damage = 10;
    public Vector2 knockBack = Vector2.zero;
}
