using UnityEngine;

[CreateAssetMenu(fileName = "UiAudio", menuName = "Audio/UiData")]
public class UiAudioData : ScriptableObject {
    [SerializeField] public AudioClip pause;
    [SerializeField] public AudioClip buttonClick;
    [SerializeField] public AudioClip buttonHover;
}
