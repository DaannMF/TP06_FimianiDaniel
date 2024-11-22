using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTitle : MonoBehaviour {
    [SerializeField] private TMP_Text statsText;
    [SerializeField] private Button restartButton;

    private void Awake() {
        LoadStats();
        restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    private void OnDestroy() {
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
    }

    private void LoadStats() {
        statsText.text = "Score: " + GameManager.SharedInstance.Score + "\n" +
                         "Coins: " + GameManager.SharedInstance.Coins + "\n";
    }

    public void OnRestartButtonClicked() {
        GameManager.SharedInstance.RestartGame();
    }
}
