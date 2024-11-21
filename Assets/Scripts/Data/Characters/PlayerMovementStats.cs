using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementStats", menuName = "Player/PlayerMovementStats")]
public class PlayerMovementStats : ScriptableObject {
    public Single walkSpeed = 5f;
    public Single jumpForce = 10f;
    public Int16 maxJumps = 2;
}
