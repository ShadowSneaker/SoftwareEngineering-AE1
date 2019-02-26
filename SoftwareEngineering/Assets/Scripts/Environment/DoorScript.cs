using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : ActivatableObject
{
    public AudioClip DoorOpenSound;
    public AudioClip DoorCloseSound;
    public AudioClip LockedSound;

    public bool Locked;


    private AudioSource Audio;


    private void Start()
    {
        Audio = GetComponent<AudioSource>();

        if (!Audio)
        {
            Debug.LogError(gameObject.name + " doesn't have a AudioSource component added!");
        }
    }


    public override void Activate()
    {
        if (Activated)
        {
            if (DoorCloseSound)
            {
                Audio.clip = DoorCloseSound;
                Audio.Play();
            }
            else
            {
                Debug.LogWarning(gameObject.name + "'s close sound is not set!");
            }

            base.Activate();
        }
        else
        {
            if (!Locked)
            {
                if (DoorOpenSound)
                {
                    Audio.clip = DoorOpenSound;
                    Audio.Play();
                }
                else
                {
                    Debug.LogWarning(gameObject.name + "'s open sound is not set!");
                }

                base.Activate();
            }
            else
            {
                // Play locked sound

                if (LockedSound)
                {
                    Audio.clip = LockedSound;
                    Audio.Play();
                }
                else
                {
                    Debug.LogWarning(gameObject.name + "'s locked sound is not set!");
                }
            }
        }
    }


    public void SetLock(bool Lock)
    {
        Locked = Lock;
    }
}
