using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SceneStore");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
