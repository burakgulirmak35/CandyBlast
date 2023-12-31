using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("----------------------------")]
    [SerializeField] private Sound PopSound;
    [SerializeField] private Sound ShakeSound;
    [Header("----------------------------")]
    [SerializeField] private float SoundVolume;
    [SerializeField] private float MusicVolume;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(SoundName sound)
    {
        switch (sound)
        {
            case SoundName.PopSound:
                Play(PopSound);
                break;
            case SoundName.ShakeSound:
                Play(ShakeSound);
                break;
            default:
                break;
        }
    }

    private void Play(Sound audio)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audio.audioClip[Random.Range(0, audio.audioClip.Length)];
        audioSource.loop = false;
        audioSource.dopplerLevel = 0;
        audioSource.reverbZoneMix = 0;
        audioSource.volume = Random.Range(audio.minVolume, audio.maxVolume) * SoundVolume;
        audioSource.pitch = Random.Range(audio.minPitch, audio.maxPitch);
        audioSource.Play();
        Destroy(audioSource, 1f);
    }

    public void SetSoundVolume(float value)
    {
        SoundVolume = value;
    }

    public void SetMusicVolume(float value)
    {
        MusicVolume = value;
    }

}

public enum SoundName
{
    PopSound, ShakeSound
}

[System.Serializable]
public class Sound
{
    public AudioClip[] audioClip;
    [Range(0, 2)]
    public float minVolume = 1;
    [Range(0, 2)]
    public float maxVolume = 1;
    [Range(0, 2)]
    public float minPitch = 1;
    [Range(0, 2)]
    public float maxPitch = 1;
}
