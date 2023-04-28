using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatMenu : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("SceneStore");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
