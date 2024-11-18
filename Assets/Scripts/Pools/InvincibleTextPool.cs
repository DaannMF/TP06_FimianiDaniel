using System;
using UnityEngine;
using System.Collections.Generic;

public class InvincibleTextPool : MonoBehaviour {
    [SerializeField] private GameObject invincibleTextPrefabs;
    [SerializeField] private Int16 poolSize;

    private Canvas canvas;
    private List<GameObject> invincibleTextPool;
    private static InvincibleTextPool instance;

    public static InvincibleTextPool SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<InvincibleTextPool>();
            }
            return instance;
        }
    }

    private void Awake() {
        canvas = FindObjectOfType<Canvas>();
    }

    private void Start() {
        LoadPool();
    }

    private void LoadPool() {
        this.invincibleTextPool = new List<GameObject>(this.poolSize);
        for (int i = 0; i < this.poolSize; i++) {
            GameObject obstacle = Instantiate(invincibleTextPrefabs, canvas.transform);
            obstacle.SetActive(false);
            this.invincibleTextPool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < this.poolSize; i++) {
            if (!this.invincibleTextPool[i].activeInHierarchy) {
                return this.invincibleTextPool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (this.invincibleTextPool is not null) {
            for (int i = 0; i < this.poolSize; i++) {
                this.invincibleTextPool[i].SetActive(false);
            }
        }
    }
}
