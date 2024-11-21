using TMPro;
using UnityEngine;

public class HoverButton : MonoBehaviour {
    [SerializeField] private UIAudioController uiAudioController;

    private TMP_Text text;

    private void Awake() {
        text = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable() {
        text.color = Color.white;
    }

    public void OnPointerEnter() {
        text.color = Color.black;
        uiAudioController.PlayButtonHoverSound();
    }

    public void OnPointerExit() {
        text.color = Color.white;
    }
}
