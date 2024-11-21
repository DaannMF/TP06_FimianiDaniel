using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StoreData", menuName = "Store/StoreData")]
public class StoreData : ScriptableObject {
    [Header("Damage")]
    [SerializeField] public Int16 damagePrice;
    [SerializeField] public Single damageAddition;

    [Header("Health")]
    [SerializeField] public Int16 healthPrice;
    [SerializeField] public Int16 healthAddition;
}
