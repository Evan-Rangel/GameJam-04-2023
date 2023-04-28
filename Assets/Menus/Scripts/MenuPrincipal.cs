using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Animator transition;
    public GameObject creditos;
    public GameObject creditosButton;
    public void Jugar()
    {
        StartCoroutine(Fade());
    }

    public void Creditos()
    {
        creditos.SetActive(true);
        creditosButton.SetActive(true);
    }

    public void Volver()
    {
        creditos.SetActive(false);
        creditosButton.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }

    IEnumerator Fade()
    {
        transition.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameScene");
    }
}
