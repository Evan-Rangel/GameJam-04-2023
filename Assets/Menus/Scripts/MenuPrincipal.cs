using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public Animator transition;
    public void Jugar()
    {
        StartCoroutine(Fade());
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
