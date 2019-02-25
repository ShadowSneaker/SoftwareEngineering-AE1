using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    // name of the clip
    public string name;
    // the actual audio clip used
    public AudioClip clip;

    // volume of the cound clip
    [Range(0.0f, 1f)]
    public float volume;

    // pitch of the sound clip
    [Range(0.1f, 3f)]
    public float pitch;

    public bool Loop;

    [HideInInspector]
    public AudioSource source;

}
