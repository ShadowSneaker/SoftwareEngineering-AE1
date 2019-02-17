using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator CameraAnim;
    public int waitTime;

    public string BeginingScene;

    public Image Settings;
    public Image FloorSelect;

    //three functions for the menu



    // one to bring up the settings
    public void OpenSettings()
    {
        // makes the settings panel appear
        Settings.gameObject.SetActive(true);
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
        // this will have the pannel appear
        FloorSelect.gameObject.SetActive(true);
    }

    public void CloseLoadFloorPanel()
    {
        // makes the load floor panel disapear
        FloorSelect.gameObject.SetActive(false);
    }

    public void CloseSettingsPanel()
    {
        // makes the settings pannel disapear
        Settings.gameObject.SetActive(false);
    }

    IEnumerator LoadScene(string SceneName)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneName);
    }

}
