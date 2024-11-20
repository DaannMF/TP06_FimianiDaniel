using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour {
    [SerializeField] private GameObject pauseMenu;
    private PlayerInput playerInput;

    private void Awake() {
        CharactersEvents.characterDamaged += CreateDamageText;
        CharactersEvents.characterHealed += CreateHealthText;
        CharactersEvents.characterInvincible += CreateInvincibleText;
        playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>();
    }

    private void Update() {
        CheckGamePause();
    }

    private void OnDestroy() {
        CharactersEvents.characterDamaged -= CreateDamageText;
        CharactersEvents.characterHealed -= CreateHealthText;
        CharactersEvents.characterInvincible -= CreateInvincibleText;
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

    private void CheckGamePause() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnPauseGame();
        }
    }

    public void OnPauseGame() {
        Time.timeScale = 0;
        if (playerInput) {
            playerInput.DeactivateInput();
        }
        pauseMenu.SetActive(true);
    }
}
