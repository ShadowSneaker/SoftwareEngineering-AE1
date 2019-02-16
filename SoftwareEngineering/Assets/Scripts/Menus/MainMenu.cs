using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator CameraAnim;
    public int waitTime;

    public string BeginingScene;

    //three functions for the menu



    // one to bring up the settings
    public void OpenSettings()
    {

    }

    //one to begin the game
    public void BeginGame()
    {
        //CameraAnim = FindObjectOfType<Animator>();
        CameraAnim.SetBool("BeginGame", true);

        //then the code to load the scene
        StartCoroutine(LoadScene(BeginingScene));
        
    }

    //one to load differnt floors of game
    public void LoadFloorGame()
    {

    }



    IEnumerator LoadScene(string SceneName)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneName);
    }

}
