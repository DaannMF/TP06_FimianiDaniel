using TMPro;
using UnityEngine;

public class HoverButton : MonoBehaviour {
    private TMP_Text text;

    private void Awake() {
        text = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable() {
        text.color = Color.white;
    }

    public void OnPointerEnter() {
        text.color = Color.black;
    }

    public void OnPointerExit() {
        text.color = Color.white;
    }
}
