using System;
using UnityEngine;
using UnityEngine.Events;

public class CharactersEvents {
    public static UnityAction<GameObject, Int16> characterDamaged;
    public static UnityAction<GameObject, Int16> characterHealed;
    public static UnityAction<GameObject> characterInvincible;
    public static UnityAction<GameObject, String> powerUpPicked;
    public static UnityAction<Int16, Int16> enemyDied;
    public static UnityAction playerDied;
    public static UnityAction playerWon;
    public static UnityAction<Int16> itemBuy;
}