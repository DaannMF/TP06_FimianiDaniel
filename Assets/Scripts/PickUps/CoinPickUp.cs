using UnityEngine;

public class CoinPickUp : MonoBehaviour {
    [SerializeField] private CoinPickUpData data;
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 180, 0);
    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameManager.SharedInstance.Coins += data.value;
        AudioSource.PlayClipAtPoint(data.audioClip, transform.position, audioSource.volume);
        Destroy(gameObject);
    }

    private void Update() {
        transform.eulerAngles += rotationSpeed * Time.deltaTime;
    }
}
