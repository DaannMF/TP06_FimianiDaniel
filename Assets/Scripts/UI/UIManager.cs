using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject storePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private UIAudioController uIAudioController;

    private void Awake() {
        CharactersEvents.characterDamaged += CreateDamageText;
        CharactersEvents.characterHealed += CreateHealthText;
        CharactersEvents.characterInvincible += CreateInvincibleText;
        CharactersEvents.powerUpPicked += CreatePowerUpText;
        CharactersEvents.playerDied += OnGameOver;
        CharactersEvents.playerWon += OnGameWin;
    }

    private void Update() {
        if (!storePanel.activeSelf) {
            CheckGamePause();
        }
        if (SceneManager.GetActiveScene().name == "GamePlayScene" && !pauseMenu.activeSelf) {
            CheckSTore();
        }
    }

    private void OnDestroy() {
        CharactersEvents.characterDamaged -= CreateDamageText;
        CharactersEvents.characterHealed -= CreateHealthText;
        CharactersEvents.characterInvincible -= CreateInvincibleText;
        CharactersEvents.powerUpPicked -= CreatePowerUpText;
        CharactersEvents.playerDied -= OnGameOver;
        CharactersEvents.playerWon -= OnGameWin;
    }

    public void CreateDamageText(GameObject character, Int16 damage) {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        GameObject damageText = DamageTextPool.SharedInstance.GetPooledObject();
        if (damageText) {
            damageText.transform.position = spawnPosition;
            damageText.GetComponent<TextMeshProUGUI>().text = damage.ToString();
            damageText.SetActive(true);
        }
    }

    public void CreateHealthText(GameObject character, Int16 heal) {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        GameObject healText = HealTextPool.SharedInstance.GetPooledObject();
        if (healText) {
            healText.transform.position = spawnPosition;
            healText.GetComponent<TextMeshProUGUI>().text = heal.ToString();
            healText.SetActive(true);
        }
    }

    public void CreateInvincibleText(GameObject character) {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        GameObject invincibleText = InvincibleTextPool.SharedInstance.GetPooledObject();
        if (invincibleText) {
            invincibleText.transform.position = spawnPosition;
            invincibleText.SetActive(true);
        }
    }

    public void CreatePowerUpText(GameObject character, String message) {
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);
        GameObject invincibleText = PickUpTextPool.SharedInstance.GetPooledObject();
        if (invincibleText) {
            TMP_Text text = invincibleText.GetComponent<TMP_Text>();
            text.text = message;
            invincibleText.transform.position = spawnPosition;
            invincibleText.SetActive(true);
        }
    }

    private void CheckGamePause() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnPauseGame();
        }
    }

    public void OnPauseGame() {
        if (!pauseMenu.activeSelf) {
            GameManager.SharedInstance.PauseGame();
            pauseMenu.SetActive(true);
            uIAudioController.PlayPauseSound();
        }
    }

    public void CheckSTore() {
        if (Input.GetKeyDown(KeyCode.P)) {
            GameManager.SharedInstance.PauseGame();
            storePanel.SetActive(true);
            uIAudioController.PlayPauseSound();
        }
    }

    private void OnGameOver() {
        GameManager.SharedInstance.PauseGame();
        gameOverPanel.SetActive(true);
    }

    private void OnGameWin() {
        GameManager.SharedInstance.PauseGame();
        winPanel.SetActive(true);
    }
}
