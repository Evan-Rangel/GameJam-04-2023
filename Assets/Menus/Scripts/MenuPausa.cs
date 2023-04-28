using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private GameObject menuMorir;
    public void Pausar()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Morir()
    {
        botonPausa.SetActive(false);
        menuPausa.SetActive(false);
        menuMorir.SetActive(true);
    }

    public void Ganaste()
    {
        SceneManager.LoadScene("Ganaste");
    }

    public void Salir()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
