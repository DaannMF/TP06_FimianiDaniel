using UnityEngine;

public class Boss : MonoBehaviour {
    private void OnDestroy() {
        CharactersEvents.playerWon?.Invoke();
    }
}