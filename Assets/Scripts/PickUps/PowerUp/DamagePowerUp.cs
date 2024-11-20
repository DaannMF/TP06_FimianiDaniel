using UnityEngine;

public class DamagePowerUp : MonoBehaviour {
    [SerializeField] private DamageBuff damageBuff;
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 180, 0);

    private void OnTriggerEnter2D(Collider2D other) {
        damageBuff.ApplyEffect(other.gameObject);
        CharactersEvents.powerUpPicked?.Invoke(other.gameObject, "+Damage");
        Destroy(gameObject);
    }

    private void Update() {
        transform.eulerAngles += rotationSpeed * Time.deltaTime;
    }
}
