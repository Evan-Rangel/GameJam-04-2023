using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganaste : MonoBehaviour
{
    public void Salir()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
