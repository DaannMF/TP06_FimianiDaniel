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

    [Header("Audio")]
    [SerializeField] private UIAudioController audioController;

    private void Awake() {
        backButton.onClick.AddListener(OnBackButtonClicked);
        LoadPlayerPrefs();
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
        PlayerPrefs.SetFloat(PlayerPrefsKeys.MasterVolume, masterSlider.value);
    }

    public void SetMusicVolume() {
        audioMixer.SetFloat("music", Mathf.Log10(musicSlider.value) * 20);
        PlayerPrefs.SetFloat(PlayerPrefsKeys.MusicVolume, musicSlider.value);
    }

    public void SetSFXVolume() {
        audioMixer.SetFloat("sfx", Mathf.Log10(sfxSlider.value) * 20);
        PlayerPrefs.SetFloat(PlayerPrefsKeys.SFXVolume, sfxSlider.value);
    }

    public void SetUIVolume() {
        audioMixer.SetFloat("ui", Mathf.Log10(uiSlider.value) * 20);
        PlayerPrefs.SetFloat(PlayerPrefsKeys.UiVolume, uiSlider.value);
    }

    private void LoadPlayerPrefs() {
        masterSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.MasterVolume, 1);
        musicSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.MusicVolume, 1);
        sfxSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.SFXVolume, 1);
        uiSlider.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.UiVolume, 1);
    }

    private void OnBackButtonClicked() {
        audioController.PlayButtonClickSound();
        mainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
