using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    } 
    public void LoadMaintScene()
    {
        SceneManager.LoadScene(1);
    }
}
