using UnityEngine;

public class JumoPowerUp : MonoBehaviour {
    [SerializeField] private JumpBuff jumpBuffData;
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 180, 0);
    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        jumpBuffData.ApplyEffect(other.gameObject);
        CharactersEvents.powerUpPicked?.Invoke(other.gameObject, "+Jump");
        AudioSource.PlayClipAtPoint(jumpBuffData.audioClip, transform.position, audioSource.volume);
        Destroy(gameObject);
    }

    private void Update() {
        transform.eulerAngles += rotationSpeed * Time.deltaTime;
    }


}
