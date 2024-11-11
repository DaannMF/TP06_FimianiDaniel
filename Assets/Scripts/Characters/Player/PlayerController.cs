using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.A)) {
            transform.position += new Vector3(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.D)) {
            transform.position -= new Vector3(-1, 0, 0);
        }
    }
}
