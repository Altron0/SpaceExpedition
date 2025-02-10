using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    [SerializeField] GameObject preFanNewGame;

    void GameReset(){
        SceneManager.LoadScene("");
    }
}
