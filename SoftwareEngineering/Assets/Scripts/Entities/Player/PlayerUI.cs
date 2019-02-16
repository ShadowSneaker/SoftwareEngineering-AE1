using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image GameOverImage;
    Animation GameOverAnim;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void DisplayGameOver()
    {
        if (GameOverImage)
        {
            if (!GameOverAnim)
                GameOverAnim = GameOverImage.GetComponent<Animation>();

            GameOverAnim.Play(GameOverAnim.clip.name);
        }
    }
}
