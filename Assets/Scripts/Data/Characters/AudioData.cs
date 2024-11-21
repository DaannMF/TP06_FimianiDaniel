using System;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioData", menuName = "Character/AudioData")]
public class AudioData : ScriptableObject {
    public AudioMixerGroup output;
    public SoundList[] sounds = new SoundList[] {
        new SoundList { name = nameof(AudioAction.Attack) },
        new SoundList { name = nameof(AudioAction.Hit) },
        new SoundList { name = nameof(AudioAction.Jump)},
        new SoundList { name = nameof(AudioAction.Death) },
        new SoundList { name = nameof(AudioAction.Land) },
    };
}

[Serializable]
public struct SoundList {
    [SerializeField] public String name;
    [SerializeField] public AudioClip audioClip;
}
