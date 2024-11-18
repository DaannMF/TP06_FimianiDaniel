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
        this.healTextPool = new List<GameObject>(this.poolSize);
        for (int i = 0; i < this.poolSize; i++) {
            GameObject obstacle = Instantiate(healTextPrefabs, canvas.transform);
            obstacle.SetActive(false);
            this.healTextPool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < this.poolSize; i++) {
            if (!this.healTextPool[i].activeInHierarchy) {
                return this.healTextPool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (this.healTextPool is not null) {
            for (int i = 0; i < this.poolSize; i++) {
                this.healTextPool[i].SetActive(false);
            }
        }
    }
}
