using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour {

    [Header("Controls")]
    [SerializeField] private Button backButton;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider uiSlider;

    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;

    private void Awake() {
        backButton.onClick.AddListener(OnBackButtonClicked);
    }

    private void Start() {
        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
        SetUIVolume();
    }

    private void OnDestroy() {
        backButton.onClick.RemoveListener(OnBackButtonClicked);
    }

    public void SetMasterVolume() {
        audioMixer.SetFloat("master", Mathf.Log10(masterSlider.value) * 20);
    }

    public void SetMusicVolume() {
        audioMixer.SetFloat("music", Mathf.Log10(musicSlider.value) * 20);
    }

    public void SetSFXVolume() {
        audioMixer.SetFloat("sfx", Mathf.Log10(sfxSlider.value) * 20);
    }

    public void SetUIVolume() {
        audioMixer.SetFloat("ui", Mathf.Log10(uiSlider.value) * 20);
    }

    private void OnBackButtonClicked() {
        mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
