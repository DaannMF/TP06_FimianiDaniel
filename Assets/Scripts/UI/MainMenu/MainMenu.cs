using UnityEngine;
using UnityEngine.InputSystem;
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
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject titleText;
    [SerializeField] private GameObject panelMainMenu;
    [SerializeField] private GameObject controlsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Audio")]
    [SerializeField] private UIAudioController audioController;

    private PlayerInput playerInput;

    private void Awake() {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        controlsButton.onClick.AddListener(OnControlsButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player) playerInput = player.GetComponent<PlayerInput>();
    }

    private void OnEnable() {
        titleText.SetActive(true);
    }

    private void OnDisable() {
        titleText.SetActive(false);
    }

    private void OnDestroy() {
        playButton.onClick.RemoveListener(OnPlayButtonClicked);
        controlsButton.onClick.RemoveListener(OnControlsButtonClicked);
        settingsButton.onClick.RemoveListener(OnSettingsButtonClicked);
        creditsButton.onClick.RemoveListener(OnCreditsButtonClicked);
        exitButton.onClick.RemoveListener(OnExitButtonClicked);
    }

    private void OnPlayButtonClicked() {
        audioController.PlayButtonClickSound();
        if (SceneManager.GetActiveScene().name != "GamePlayScene")
            SceneManager.LoadScene("GamePlayScene");
        else {
            panelPause.SetActive(false);
        }

        GameManager.SharedInstance.ResumeGame();
    }

    private void OnControlsButtonClicked() {
        audioController.PlayButtonClickSound();
        controlsPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnSettingsButtonClicked() {
        audioController.PlayButtonClickSound();
        settingsPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnCreditsButtonClicked() {
        audioController.PlayButtonClickSound();
        creditsPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
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
