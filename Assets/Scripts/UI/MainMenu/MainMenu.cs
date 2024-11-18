using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button exitButton;

    [Header("Panels")]
    [SerializeField] private GameObject panelMainMenu;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    private void Awake() {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        controlsButton.onClick.AddListener(OnControlsButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnDestroy() {
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
        controlsButton.onClick.RemoveListener(OnControlsButtonClicked);
        settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
        creditsButton.onClick.RemoveListener(OnCreditsButtonClicked);
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

    private void OnPlayButtonClicked() {
        if (SceneManager.GetActiveScene().name != "GamePlayScene")
            SceneManager.LoadScene("GamePlayScene");
        else
            panelMainMenu.SetActive(false);

        Time.timeScale = 1;
    }

    private void OnControlsButtonClicked() {
        controlsPanel.SetActive(true);
    }

    private void OnSettingsButtonClicked() {
        settingsPanel.gameObject.SetActive(true);
    }

    private void OnCreditsButtonClicked() {
        creditsPanel.gameObject.SetActive(true);
    }

    public void OnExitButtonClicked() {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        Debug.Log("Exiting game");
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            Application.Quit();
#endif
    }
}
