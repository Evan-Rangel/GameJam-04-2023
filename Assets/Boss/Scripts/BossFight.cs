using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    [SerializeField] private GameObject[] partes;
    [SerializeField] GameObject projectile;
    public bool fase1;
    public bool fase2;

    public int ataquesBrazos;
    public int ataquesCabeza;
    [SerializeField] float bulletSpeed;
    [SerializeField] MenuPausa menuPausa;
    public int random;
    public int health=50;
    [SerializeField]float temp;
    float tempTot;
    private void Start()
    {
        tempTot = temp;
        partes[0].GetComponent<CircleCollider2D>().enabled = false;
        partes[1].GetComponent<CircleCollider2D>().enabled = false;
        partes[2].GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(EsperarIntroduccion());
        menuPausa = GameObject.FindGameObjectWithTag("CanvasControlador").GetComponent<MenuPausa>();
        ataquesBrazos = 3;
    }

    private void Update()
    {
        Fase1();

        Fase2();

       // Morir();
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


            tempTot -= Time.deltaTime;
            if (tempTot<=0)
            {
                BulletAttack(partes[1].transform);
                BulletAttack(partes[2].transform);
                tempTot = temp;
            }
            
            
        }
    }

    void BulletAttack(Transform _pos)
    {
        float angle = 140;
        float angleStep = 360 / 18;
        Vector2 startPos = _pos.position;


        for (int i = 0; i < 4; i++)
        {
            float DirXPos = startPos.x + Mathf.Sin((angle * Mathf.PI) / 180);
            float DirYPos = startPos.y + Mathf.Cos((angle * Mathf.PI) / 180);
            Vector2 dir = new Vector2(DirXPos, DirYPos);
            Vector2 movDir = (dir - startPos).normalized * bulletSpeed;
            GameObject bulletTemp = Instantiate(projectile, startPos, Quaternion.identity);
            bulletTemp.GetComponent<Rigidbody2D>().velocity = movDir * bulletSpeed;
            angle += angleStep;
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

    public void Morir()
    {
        
        gameObject.SetActive(false);

        menuPausa.Ganaste();

        /*if (partes[0].GetComponent<EnemyController>().Health <= 0)
        {
            partes[0].GetComponent<CircleCollider2D>().enabled = false;
            partes[0].GetComponent<Animator>().SetBool("Morir", true);
        
        }
        
        
        if (partes[1].GetComponent<EnemyController>().Health <= 0)
        {
            partes[1].GetComponent<CircleCollider2D>().enabled = false;
            partes[1].GetComponent<Animator>().SetBool("Morir", true);
        }
        
        
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            health -= collision.GetComponent<DisparoMochila>().GetDamage;
        }
    }
}
