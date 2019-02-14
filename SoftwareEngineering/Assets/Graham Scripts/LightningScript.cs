using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScript : MonoBehaviour {

    public GameObject Lightning;
    public Vector2 lightningTime;
    private float Timer;
    private float LightningFadeTime;
    private bool LightningFade;
    private bool LightningSecondFade;
    private bool countdown;
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
            }
        }
        if(LightningFade)
        {
            LightningFadeTime -= Time.deltaTime;
            if(LightningFadeTime <= 0)
            {
                LightningFade = false;
                LightningSecondFade = true;
                LightningFadeTime = 0.1f;
                Lightning.SetActive(false);
                Timer = -0.1f;
            }
        }
        if (LightningSecondFade && Timer < 0)
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
