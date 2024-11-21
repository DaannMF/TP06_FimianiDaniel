using UnityEngine;

public class InvincibilityPowerUp : MonoBehaviour {
    [SerializeField] private InvincibilityBuff invincibilityBuff;
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 180, 0);
    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        invincibilityBuff.ApplyEffect(other.gameObject);
        CharactersEvents.powerUpPicked?.Invoke(other.gameObject, "+Invincibility");
        AudioSource.PlayClipAtPoint(invincibilityBuff.audioClip, transform.position, audioSource.volume);
        Destroy(gameObject);
    }

    private void Update() {
        transform.eulerAngles += rotationSpeed * Time.deltaTime;
    }
}
