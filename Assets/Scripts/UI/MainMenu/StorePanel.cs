using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StorePanel : MonoBehaviour {

    [SerializeField] private StoreData storeData;

    [Header("Text")]
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private TMP_Text damagePriceText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text healthPriceText;

    [Header("Buttons")]
    [SerializeField] private Button damageButton;
    [SerializeField] private Button healthButton;
    [SerializeField] private Button backButton;

    [Header("Audio")]
    [SerializeField] private UIAudioController audioController;

    private PlayerInput playerInput;

    private void Awake() {
        LoadStoreData();
        backButton.onClick.AddListener(OnBackButtonClicked);
        damageButton.onClick.AddListener(OnDamageButtonClicked);
        healthButton.onClick.AddListener(OnHealthButtonClicked);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player) playerInput = player.GetComponent<PlayerInput>();
    }

    private void OnDestroy() {
        backButton.onClick.RemoveListener(OnBackButtonClicked);
        damageButton.onClick.RemoveListener(OnDamageButtonClicked);
        healthButton.onClick.RemoveListener(OnHealthButtonClicked);
    }

    private void OnBackButtonClicked() {
        audioController.PlayButtonClickSound();
        gameObject.SetActive(false);
        GameManager.SharedInstance.ResumeGame();
    }

    private void OnDamageButtonClicked() {
        audioController.PlayButtonClickSound();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player) {
            Attack[] attacks = player.GetComponentsInChildren<Attack>();
            foreach (Attack attack in attacks) {
                attack.ApplyBuyDamageBuff(3);
            }
        }
    }

    private void OnHealthButtonClicked() {
        audioController.PlayButtonClickSound();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player) {
            Damageable damageable = player.GetComponent<Damageable>();
            if (damageable) {
                damageable.ApplyBuyMaxHealth(10);
            }
        }
    }

    private void LoadStoreData() {
        damageText.text = $"+ {storeData.damageAddition.ToString()} Damage";
        damagePriceText.text = storeData.damagePrice.ToString();
        healthText.text = $"+ {storeData.healthAddition.ToString()} Damage";
        healthPriceText.text = storeData.healthPrice.ToString();
    }
}
