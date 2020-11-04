using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct SoundBase
{
    public string soundName;
    public AudioClip audioClip;
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;

    private AudioSource audioSource;

    public SoundBase[] soundBases;

    private Dictionary<string, AudioClip> soundPool = new Dictionary<string, AudioClip>();



    private void Awake()
    {
        audioManager = this;
        for (int i = 0; i < soundBases.Length; i++)
        {
            if(!soundPool.ContainsKey(soundBases[i].soundName))
            {
                soundPool.Add(soundBases[i].soundName, soundBases[i].audioClip);
            }
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundOneShot(string name)
    {
        audioSource.PlayOneShot(soundPool[name]);
    }


}
