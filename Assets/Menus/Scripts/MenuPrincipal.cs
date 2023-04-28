using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
