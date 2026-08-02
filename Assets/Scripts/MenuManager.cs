using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {   
        AudioManager.Instance.PlayButton();
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {   
        AudioManager.Instance.PlayButton();
        SceneManager.LoadScene("Start Menu");
    }

    public void QuitGame()
    {   
        AudioManager.Instance.PlayButton();

        Application.Quit();
    }
}