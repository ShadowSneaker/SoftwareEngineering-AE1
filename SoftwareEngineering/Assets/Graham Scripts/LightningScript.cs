using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour {

    public GameObject Lightning;
    public Vector2 lightningTime;
    public float Timer;
    private float LightningFadeTime;
    public bool LightningFade;
    public bool LightningSecondFade;
    public bool countdown;
    private float SecondLightingFadeTime;

	// Use this for initialization
	void Start () {

        Timer = Random.Range(lightningTime.x, lightningTime.y);
        LightningFade = false;
        LightningSecondFade = false;
        countdown = true;
        LightningFadeTime = 0.1f;
    }
	
	// Update is called once per frame
	void Update () {

        if (countdown)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Lightning.SetActive(true);
                countdown = false;
                LightningFade = true;
                LightningFadeTime = 0.1f;
            }
        }
        if(LightningFade)
        {
            LightningFadeTime -= Time.deltaTime;
            if(LightningFadeTime <= 0)
            {
                LightningFade = false;               
                LightningFadeTime = 0.1f;
                if(Timer <= 0)
                {
                    LightningSecondFade = true;
                }
                Lightning.SetActive(false);
                
            }
        }
        if (LightningSecondFade && Timer <= 0)
        {
            LightningFadeTime -= Time.deltaTime;
            if (LightningFadeTime <= 0)
            {
                LightningFade = true;
                LightningSecondFade = false;
                LightningFadeTime = 0.1f;
                Lightning.SetActive(true);
                Timer = Random.Range(lightningTime.x, lightningTime.y);
                countdown = true;
            }
        }


    }
}
