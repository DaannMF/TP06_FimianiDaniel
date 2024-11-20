using UnityEngine;

public class JumoPowerUp : MonoBehaviour {
    [SerializeField] private JumpBuff jumpBuff;
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 180, 0);

    private void OnTriggerEnter2D(Collider2D other) {
        jumpBuff.ApplyEffect(other.gameObject);
        CharactersEvents.powerUpPicked?.Invoke(other.gameObject, "+Jump");
        Destroy(gameObject);
    }

    private void Update() {
        transform.eulerAngles += rotationSpeed * Time.deltaTime;
    }
}
