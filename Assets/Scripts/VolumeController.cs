using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer mixer;
    public void setVolume (float value)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20); //Hay un bug de Unity donde el slider de volumen no funciona correctamente, haciéndolo de este modo el slider funciona de forma lineal
    }
}
