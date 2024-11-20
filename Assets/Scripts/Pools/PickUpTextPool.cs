using System;
using UnityEngine;
using System.Collections.Generic;

public class PickUpTextPool : MonoBehaviour {
    [SerializeField] private GameObject pickUpTextPrefabs;
    [SerializeField] private Int16 poolSize;

    private Canvas canvas;
    private List<GameObject> pickUpTextPool;
    private static PickUpTextPool instance;

    public static PickUpTextPool SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<PickUpTextPool>();
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
        pickUpTextPool = new List<GameObject>(poolSize);
        for (int i = 0; i < poolSize; i++) {
            GameObject obstacle = Instantiate(pickUpTextPrefabs, canvas.transform);
            obstacle.SetActive(false);
            pickUpTextPool.Add(obstacle);
        }
    }

    public GameObject GetPooledObject() {
        for (int i = 0; i < poolSize; i++) {
            if (!pickUpTextPool[i].activeInHierarchy) {
                return pickUpTextPool[i];
            }
        }
        return null;
    }

    public void DeactivateInstances() {
        if (pickUpTextPool is not null) {
            for (int i = 0; i < poolSize; i++) {
                pickUpTextPool[i].SetActive(false);
            }
        }
    }
}
