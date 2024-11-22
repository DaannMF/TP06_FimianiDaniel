
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinPickUpData", menuName = "PickUp/CoinPickUp")]
public class CoinPickUpData : ScriptableObject {
    public Int16 value = 11;
    public AudioClip audioClip;
}
