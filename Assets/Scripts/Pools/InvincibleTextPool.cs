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
        canvas = GameObject.FindGameObjectsWithTag("GameCanvas")[0].GetComponent<Canvas>();
    }

    private void Start() {
        LoadPool();
    }

    private void LoadPool() {
        invincibleTextPool = new List<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++) {
            GameObject obstacle = Instantiate(invincibleTextPrefabs, canvas.transform);
            obstacle.SetActive(false);
            invincibleTextPool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < poolSize; i++) {
            if (!invincibleTextPool[i].activeInHierarchy) {
                return invincibleTextPool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (invincibleTextPool is not null) {
            for (int i = 0; i < poolSize; i++) {
                invincibleTextPool[i].SetActive(false);
            }
        }
    }
}
