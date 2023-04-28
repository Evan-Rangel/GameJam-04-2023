using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    [SerializeField] private GameObject[] partes;

    public bool fase1;
    public bool fase2;

    public int ataquesBrazos;
    public int ataquesCabeza;

    public int random;

    private void Start()
    {
        partes[0].GetComponent<CircleCollider2D>().enabled = false;
        partes[1].GetComponent<CircleCollider2D>().enabled = false;
        partes[2].GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(EsperarIntroduccion());
        ataquesBrazos = 3;
    }

    private void Update()
    {
        Fase1();

        Fase2();

        Morir();
    }

    private void Fase1()
    {
        ataquesBrazos = random;
        if (ataquesBrazos == 1)
        {
            //Aqui no dispara
            partes[0].GetComponent<Animator>().SetBool("Atk1", true);
            partes[1].GetComponent<Animator>().SetBool("Atk1", true);
            StartCoroutine(Fase1ATK1());
        }
        else if (ataquesBrazos == 2)
        {
            //Aqui no dispara
            partes[0].GetComponent<Animator>().SetBool("Atk2", true);
            //Corrutina
            StartCoroutine(primeroUnBrazoIzq());
            StartCoroutine(Fase1ATK2());
        }
        else if (ataquesBrazos == 3)
        {
            //Las dos manos diparen en escoptea osea tres direcciones hacia abajo
            partes[0].GetComponent<Animator>().SetBool("Atk1", false);
            partes[0].GetComponent<Animator>().SetBool("Atk2", false);
            StartCoroutine(Fase1ATK3());
        }
    }

    private void Fase2()
    {
        ataquesCabeza = random;

        /*
        if (partes[0].GetComponent<EnemyController>().Health <= 0 && partes[1].GetComponent<EnemyController>().Health <= 0)
        {
            
        }
        */
        partes[2].GetComponent<CircleCollider2D>().enabled = true;
        if (ataquesCabeza == 1)
        {
            //Dispara en 4 o 5 direcciones hacia abajo cadencia lo suficiente para que esquive
            partes[2].GetComponent<Animator>().SetBool("AtaqueIzqDer", true);
            StartCoroutine(Fase2ATK1());
        }
        else if (ataquesCabeza == 2)
        {
            //Dispara en 4 direciones en X, mucha cadencia
            partes[2].GetComponent<Animator>().SetBool("AtaqueAbajo", true);
            StartCoroutine(Fase2ATK2());
        }
        else
        {
            //Dispare como quieras
            partes[2].GetComponent<Animator>().SetBool("AtaqueIzq", false);
            partes[2].GetComponent<Animator>().SetBool("AtaqueDer", false);
            StartCoroutine(Fase2ATK3());
        }
    }

    private void Morir()
    {
        /*
        if (partes[0].GetComponent<EnemyController>().Health <= 0)
        {
            partes[0].GetComponent<CircleCollider2D>().enabled = false;
            partes[0].GetComponent<Animator>().SetBool("Morir", true);
        
        }
        */
        /*
        if (partes[1].GetComponent<EnemyController>().Health <= 0)
        {
            partes[1].GetComponent<CircleCollider2D>().enabled = false;
            partes[1].GetComponent<Animator>().SetBool("Morir", true);
        }
        */
        /*
        if (partes[2].GetComponent<EnemyController>().Health <= 0)
        {
            partes[2].GetComponent<CircleCollider2D>().enabled = false;
            partes[2].GetComponent<Animator>().SetBool("Morir", true);
        }
        */
    }

    IEnumerator primeroUnBrazoIzq()
    {
        yield return new WaitForSeconds(3);
        partes[1].GetComponent<Animator>().SetBool("Atk2", true);
    }

    IEnumerator EsperarIntroduccion()
    {
        yield return new WaitForSeconds(10);
        partes[0].GetComponent<CircleCollider2D>().enabled = true;
        partes[1].GetComponent<CircleCollider2D>().enabled = true;
    }

    IEnumerator morirBoss()
    {
        yield return new WaitForSeconds(4);
        partes[2].GetComponent<Animator>().SetBool("Morir", true);
    }

    IEnumerator Fase1ATK1()
    {
        yield return new WaitForSeconds(7);
        random = Random.Range(1, 4);
    }
    IEnumerator Fase1ATK2()
    {
        yield return new WaitForSeconds(5);
        random = Random.Range(1, 4);
    }
    IEnumerator Fase1ATK3()
    {       
        yield return new WaitForSeconds(10);
        random = Random.Range(1, 4);
    }

    IEnumerator Fase2ATK1()
    {
        yield return new WaitForSeconds(7);
        random = Random.Range(1, 4);
    }
    IEnumerator Fase2ATK2()
    {
        yield return new WaitForSeconds(30);
        random = Random.Range(1, 4);
    }
    IEnumerator Fase2ATK3()
    {
        yield return new WaitForSeconds(11);
        random = Random.Range(1, 4);
    }
}
