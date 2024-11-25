using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadOrbitScene()
    {
        SceneManager.LoadScene("OrbitScene");
    }

    public void LoadStaticScene()
    {
        SceneManager.LoadScene("StaticScene"); 
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene"); 
    }
    public void LoadInstructScene()
    {
        SceneManager.LoadScene("InstructScene");
    }
    public void QuitApplication()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
