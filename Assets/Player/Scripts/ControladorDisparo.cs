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

    private void Start()
    {
        playerinput = GetComponent<PlayerInput>();
        shooting = false;
        armaDefault = true;
        armaEscopeta = false;
        armaBigCannon = false;
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
        if (playerinput.actions["Fire"].IsPressed())
        {
            shooting = true;
            carga += 1 * Time.deltaTime;
        }
        if (carga >= 1)
        {
            carga = 0;
            if (etapa <= 1)
            {
                etapa += 1;
            }
        }
        if (!playerinput.actions["Fire"].IsPressed() && shooting)
        {
            switch (etapa)
            {
                case 1:
                    Instantiate(bala[1], controladorDisparo[0].position, controladorDisparo[0].rotation);

                    break;
                case 2:
                    Instantiate(bala[2], controladorDisparo[0].position, controladorDisparo[0].rotation);

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
            if (armaDefault == true)
            {
                armaEscopeta = false;
                armaBigCannon = false;
                Instantiate(bala[0], controladorDisparo[0].position, controladorDisparo[0].rotation);
                if (!shooting)//If para animacione slo puedes cambiar
                {
                    shooting = true;
                }
            }
            if (armaEscopeta == true)
            {
                armaDefault = false;
                armaBigCannon = false;
                Instantiate(bala[0], controladorDisparo[0].position, controladorDisparo[0].rotation);
                Instantiate(bala[0], controladorDisparo[1].position, controladorDisparo[1].rotation);
                Instantiate(bala[0], controladorDisparo[2].position, controladorDisparo[2].rotation);
                if (!shooting)//If para animacione slo puedes cambiar
                {
                    shooting = true;
                }
            }
            
        }
        if (shooting)
        {
            //aqui se activa el animator
        }
        
        
        //GameObject disparo = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
        //disparo.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
    }
}
