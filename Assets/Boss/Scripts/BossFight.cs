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

    private void Start()
    {
        partes[0].GetComponent<CircleCollider2D>().enabled = false;
        partes[1].GetComponent<CircleCollider2D>().enabled = false;
        partes[2].GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(EsperarIntroduccion());
    }

    private void Update()
    {
        Fase1();

        Fase2();

        Morir();
    }

    private void Fase1()
    {
        if (ataquesBrazos == 1)
        {
            partes[0].GetComponent<Animator>().SetBool("Atk1", true);
            partes[1].GetComponent<Animator>().SetBool("Atk1", true);
        }
        else if (ataquesBrazos == 2)
        {
            partes[0].GetComponent<Animator>().SetBool("Atk2", true);
            //Corrutina
            StartCoroutine(primeroUnBrazoIzq());
        }
        else
        {
            partes[0].GetComponent<Animator>().SetBool("Atk1", false);
            partes[0].GetComponent<Animator>().SetBool("Atk2", false);
        }
    }

    private void Fase2()
    {
        /*
        if (partes[0].GetComponent<EnemyController>().Health <= 0 && partes[1].GetComponent<EnemyController>().Health <= 0)
        {
            
        }
        */

        if (ataquesCabeza == 1)
        {
            partes[2].GetComponent<Animator>().SetBool("AtaqueIzq", true);
        }
        else if (ataquesCabeza == 2)
        {
            partes[2].GetComponent<Animator>().SetBool("AtaqueDer", true);
        }
        else
        {
            partes[2].GetComponent<Animator>().SetBool("AtaqueIzq", false);
            partes[2].GetComponent<Animator>().SetBool("AtaqueDer", false);
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
        partes[1].GetComponent<CircleCollider2D>().enabled = true;
        partes[2].GetComponent<CircleCollider2D>().enabled = true;
    }

    IEnumerator morirBoss()
    {
        yield return new WaitForSeconds(4);
        partes[2].GetComponent<Animator>().SetBool("Morir", true);
    }
}
