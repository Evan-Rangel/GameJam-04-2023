using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorDisparo : MonoBehaviour
{
    [SerializeField] private Transform[] controladorDisparo;

    [SerializeField] private GameObject[] bala;

    [SerializeField] private PlayerInput playerinput;

    //Armas
    public bool armaDefault;
    public bool armaEscopeta;
    public bool armaBigCannon;

    public bool shooting;
    public float carga;
    public int etapa;

    public int damage;
    public int multy;

    private void Start()
    {
        playerinput = GetComponent<PlayerInput>();
        shooting = false;
        armaDefault = true;
        armaEscopeta = false;
        armaBigCannon = false;
        damage = 1;
        multy = 1;
    }

    private void Update()
    {
        //Disparo
        Disparar();
        if (armaBigCannon == true)
        {
            armaDefault = false;
            armaEscopeta = false;
            CargarDisparo();
        }
        
    }

    private void CargarDisparo()
    {
        GameObject bullet;
        if (playerinput.actions["Fire"].IsPressed())
        {
            shooting = true;
            carga += 1 * Time.deltaTime;
        }
        
        if (!playerinput.actions["Fire"].IsPressed() && shooting)
        {
            if (carga >= 1 && carga < 2)
            {
                etapa = 1;
            }
            if (carga >= 2)
            {
                etapa = 2;
            }
            switch (etapa)
            {
                case 0:
                    bullet = Instantiate(bala[0], controladorDisparo[0].position, controladorDisparo[0].rotation);
                    bullet.GetComponent<DisparoMochila>().setDamage(damage, multy);
                    break;
                case 1:
                    bullet = Instantiate(bala[1], controladorDisparo[0].position, controladorDisparo[0].rotation);
                    bullet.GetComponent<DisparoMochila>().setDamage(damage, multy);
                    break;
                case 2:
                    bullet = Instantiate(bala[2], controladorDisparo[0].position, controladorDisparo[0].rotation);
                    bullet.GetComponent<DisparoMochila>().setDamage(damage, multy);
                    break;
            }
            carga = 0;
            etapa = 0;
            shooting = false;
        }
    }

    private void Disparar()
    {
        if (playerinput.actions["Fire"].WasPressedThisFrame())
        {
            GameObject bullet;
            if (armaDefault == true)
            {

                armaEscopeta = false;
                armaBigCannon = false;
                bullet = Instantiate(bala[0], controladorDisparo[0].position, controladorDisparo[0].rotation);
                bullet.GetComponent<DisparoMochila>().setDamage(damage, multy);
                if (!shooting)//If para animacione slo puedes cambiar
                {
                    shooting = true;
                }
            }
            if (armaEscopeta == true)
            {
                armaDefault = false;
                armaBigCannon = false;
                
                bullet = Instantiate(bala[0], controladorDisparo[0].position, controladorDisparo[0].rotation);
                bullet.GetComponent<DisparoMochila>().setDamage(damage, multy);
                bullet = Instantiate(bala[0], controladorDisparo[1].position, controladorDisparo[1].rotation);
                bullet.GetComponent<DisparoMochila>().setDamage(damage, multy);
                bullet = Instantiate(bala[0], controladorDisparo[2].position, controladorDisparo[2].rotation);
                bullet.GetComponent<DisparoMochila>().setDamage(damage, multy);
                if (!shooting)//If para animacione slo puedes cambiar
                {
                    shooting = true;
                }
            }
            
        }
        
        
        //GameObject disparo = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
        //disparo.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
    }

    public void bulletDamage(int _damage, int _multy)
    {
        damage = _damage;
        multy = _multy;

        damage = damage * multy;
    }
}
