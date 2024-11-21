using UnityEngine;

public class UIAudioController : MonoBehaviour {
    [SerializeField] private UiAudioData uiAudioData;

    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPauseSound() {
        audioSource.PlayOneShot(uiAudioData.pause);
    }
    public void PlayButtonHoverSound() {
        audioSource.PlayOneShot(uiAudioData.buttonHover);
    }

    public void PlayButtonClickSound() {
        audioSource.PlayOneShot(uiAudioData.buttonClick);
    }
}
