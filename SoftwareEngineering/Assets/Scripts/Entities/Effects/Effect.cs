using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EEffectType
{
    Negative,
    Positive
}


public class Effect : MonoBehaviour
{

    public EEffectType Type;

    public float Duration = 10.0f;

    public bool RemoveOnEnd = true;


    private bool StartTimer;
    private float Timer;

	
    protected virtual void Start()
    {
        Timer = Duration;
        StartTimer = true;
    }

	
	void FixedUpdate ()
    {
        // Timer for the duration of this effect.
        if (StartTimer)
        {
            if (Timer > 0.0f)
            {
                Timer -= Time.deltaTime;
            }
            else
            {
                if (RemoveOnEnd)
                {
                    Destroy(this);
                }
            }
        }
	}


    public void ResetEffect()
    {
        Timer = Duration;
    }



    public float TimeRemaining
    {
        get
        {
            return Timer;
        }
    }
}
