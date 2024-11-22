
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HealPickUpData", menuName = "PickUp/HealPickUp")]
public class HealPickUpData : ScriptableObject {
    [SerializeField] public Int16 healAmount = 15;
    [SerializeField] public AudioClip audioClip;
}
