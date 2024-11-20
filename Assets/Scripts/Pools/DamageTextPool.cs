using System;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextPool : MonoBehaviour {
    [SerializeField] private GameObject damageTextPrefabs;
    [SerializeField] private Int16 poolSize;

    private Canvas canvas;
    private List<GameObject> damageTextPool;
    private static DamageTextPool instance;

    public static DamageTextPool SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<DamageTextPool>();
            }
            return instance;
        }
    }

    private void Awake() {
        canvas = GameObject.FindGameObjectsWithTag("GameCanvas")[0].GetComponent<Canvas>();
    }

    private void Start() {
        LoadPool();
    }

    private void LoadPool() {
        damageTextPool = new List<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++) {
            GameObject obstacle = Instantiate(damageTextPrefabs, canvas.transform);
            obstacle.SetActive(false);
            damageTextPool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < poolSize; i++) {
            if (!damageTextPool[i].activeInHierarchy) {
                return damageTextPool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (damageTextPool is not null) {
            for (int i = 0; i < poolSize; i++) {
                damageTextPool[i].SetActive(false);
            }
        }
    }
}
