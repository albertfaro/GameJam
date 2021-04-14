using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    //FindObjectOfType<SoundManager>().Play("NOMBRESONIDO"); Para reproducir un sonido desde otro script
    public Sound[] sounds;
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
        }
    }


    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
