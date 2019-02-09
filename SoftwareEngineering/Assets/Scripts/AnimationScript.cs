using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animation Anim;

	// Use this for initialization
	void Start ()
    {
        Anim = GetComponent<Animation>();
	}
	

    public void PlayAnimation()
    {
        if (Anim && Anim.clip)
        {
            Anim.Play(Anim.clip.name);
        }
    }
}
