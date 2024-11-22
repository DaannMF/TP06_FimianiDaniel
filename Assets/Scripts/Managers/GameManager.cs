using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [Header("Audio")]
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] public UnityEvent onStatsChanged;

    private Int16 coins;
    public Int16 Coins {
        get => coins;
        set {
            coins = value;
            onStatsChanged?.Invoke();
        }
    }

    private Int16 score;
    public Int16 Score {
        get => score;
        set {
            score = value;
            onStatsChanged?.Invoke();
        }
    }


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
        CharactersEvents.enemyDied += EnemyDefeated;
        CharactersEvents.itemBuy += BuyItem;
    }

    private void Start() {
        LoadPlayerPrefs();
    }

    private void OnDestroy() {
        onStatsChanged.RemoveAllListeners();
        CharactersEvents.enemyDied -= EnemyDefeated;
        CharactersEvents.itemBuy -= BuyItem;
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

    public void EnemyDefeated(Int16 score, Int16 coins) {
        Coins += coins;
        Score += score;
    }

    public void BuyItem(Int16 price) {
        Coins -= price;
    }

    public void CoinPicker() {
        Coins += 1;
    }

    public void RestartGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
