using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{

    public string name;


    public AudioClip clip;

   
    [Range(0f,1f)] //Para que salga el slider
    public float volume;

    [HideInInspector] //Para que aunque sea público no se vea en el inspector
    public AudioSource source;


}
