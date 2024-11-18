using System;
using UnityEngine;
using UnityEngine.Events;

public class CharactersEvents {
    public static UnityAction<GameObject, Int16> characterDamaged;
    public static UnityAction<GameObject, Int16> characterHealed;
    public static UnityAction<GameObject> characterInvincible;
}