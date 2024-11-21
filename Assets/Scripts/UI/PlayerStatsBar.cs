using TMPro;
using UnityEngine;

public class PlayerStatsBar : MonoBehaviour {
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text coinsText;

    private void Awake() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable() {
        GameManager.SharedInstance.onStatsChanged.AddListener(UpdateStatBar);
    }

    void Start() {
        UpdateStatBar();
    }

    private void UpdateStatBar() {
        scoreText.text = $"Score: {GameManager.SharedInstance.Score.ToString("0000")}";
        coinsText.text = $"Coins: {GameManager.SharedInstance.Coins.ToString("0000")}";
    }
}
