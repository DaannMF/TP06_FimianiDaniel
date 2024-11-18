using System;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour {
    [SerializeField] private List<Collider2D> detectedColliders = new();
    public Boolean HasDetectedColliders => detectedColliders.Count > 0;

    private void OnTriggerEnter2D(Collider2D other) {
        detectedColliders.Add(other);
    }

    private void OnTriggerExit2D(Collider2D other) {
        detectedColliders.Remove(other);
    }
}
