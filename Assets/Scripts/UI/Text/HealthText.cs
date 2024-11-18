using System;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour {
    [SerializeField] private Vector3 moveSpeed = new Vector3(0, 75f, 0);
    [SerializeField] private Single timeToFade = 1.5f;

    private RectTransform rectTransform;
    private TextMeshProUGUI text;

    private Single timeElapsed = 0f;
    private Color originalColor;
    private Color currentColor;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable() {
        timeElapsed = 0f;
        originalColor = text.color;
        currentColor = text.color;
    }

    // Update is called once per frame
    void Update() {
        FloatUp();
    }

    private void FloatUp() {
        rectTransform.position += moveSpeed * Time.deltaTime;
        timeElapsed += Time.deltaTime;
        if (timeElapsed < timeToFade) {
            Single alpha = currentColor.a * (1 - (timeElapsed / timeToFade));
            text.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
        }
        else {
            gameObject.SetActive(false);
            text.color = originalColor;
        }
    }
}
