using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void LoadGame()
    {
        SceneManager.LoadScene("Playground");
    }
    void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void Save(){

    }

    void Quit()
    {
        Application.Quit();
    }
}
