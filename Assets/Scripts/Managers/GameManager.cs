using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
    [Header("Audio")]
    [SerializeField] private AudioMixer audioMixer;
    private PlayerInput playerInput;

    private static GameManager instance;
    public static GameManager SharedInstance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Awake() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player) playerInput = player.GetComponent<PlayerInput>();
    }

    private void Start() {
        LoadPlayerPrefs();
    }

    public void PauseGame() {
        Time.timeScale = 0;
        if (playerInput) playerInput.DeactivateInput();
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        if (playerInput) playerInput.ActivateInput();
    }

    private void LoadPlayerPrefs() {
        Single master_volume = PlayerPrefs.GetFloat(PlayerPrefsKeys.MasterVolume, .3f);
        Single music_volume = PlayerPrefs.GetFloat(PlayerPrefsKeys.MusicVolume, .3f);
        Single sfx_volume = PlayerPrefs.GetFloat(PlayerPrefsKeys.SFXVolume, .3f);
        Single ui_volume = PlayerPrefs.GetFloat(PlayerPrefsKeys.UiVolume, .3f);

        audioMixer.SetFloat("master", Mathf.Log10(master_volume) * 20);
        audioMixer.SetFloat("music", Mathf.Log10(music_volume) * 20);
        audioMixer.SetFloat("sfx", Mathf.Log10(sfx_volume) * 20);
        audioMixer.SetFloat("ui", Mathf.Log10(ui_volume) * 20);
    }
}
