﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    //FindObjectOfType<SoundManager>().Play("NOMBRESONIDO"); Para reproducir un sonido desde otro script
    public Sound[] sounds;

    private void Awake()
    {
        DontDestroyOnLoad(this);


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
