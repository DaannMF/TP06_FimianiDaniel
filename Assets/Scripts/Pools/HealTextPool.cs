using System;
using UnityEngine;
using System.Collections.Generic;

public class HealTextPool : MonoBehaviour {
    [SerializeField] private GameObject healTextPrefabs;
    [SerializeField] private Int16 poolSize;

    private Canvas canvas;
    private List<GameObject> healTextPool;
    private static HealTextPool instance;

    public static HealTextPool SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<HealTextPool>();
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
        healTextPool = new List<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++) {
            GameObject obstacle = Instantiate(healTextPrefabs, canvas.transform);
            obstacle.SetActive(false);
            healTextPool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < poolSize; i++) {
            if (!healTextPool[i].activeInHierarchy) {
                return healTextPool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (healTextPool is not null) {
            for (int i = 0; i < poolSize; i++) {
                healTextPool[i].SetActive(false);
            }
        }
    }
}
