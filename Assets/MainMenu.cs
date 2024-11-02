using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeModeOrbit()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ChangeModeStatic()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("APP is exiting"); // This line is useful for testing in the Unity editor
    }
}

