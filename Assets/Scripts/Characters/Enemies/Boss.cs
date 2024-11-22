using UnityEngine;

public class Boss : MonoBehaviour {
    private Damageable damageable;

    private void Awake() {
        damageable = GetComponent<Damageable>();
    }

    private void Update() {
        CheckDefeated();
    }

    private void CheckDefeated() {
        if (!damageable.IsAlive) {
            CharactersEvents.playerWon?.Invoke();
        }
    }
}