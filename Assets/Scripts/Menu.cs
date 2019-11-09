using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
