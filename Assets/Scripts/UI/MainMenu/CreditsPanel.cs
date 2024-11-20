using UnityEngine;
using UnityEngine.UI;

public class CreditsPanel : MonoBehaviour {
    [Header("Buttons")]
    [SerializeField] private Button backButton;

    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;

    private void Awake() {
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void OnDestroy() {
        backButton.onClick.RemoveListener(OnBackButtonClicked);
    }

    private void OnBackButtonClicked() {
        mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
