using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDisparo : MonoBehaviour
{
    [SerializeField] private Transform[] controladorDisparo;

    [SerializeField] private GameObject bala;

    //Armas
    public bool armaDefault;
    public bool armaEscopeta;
    public bool armaBigCannon;

    private void Start()
    {
        armaDefault = true;
        armaEscopeta = false;
        armaBigCannon = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Disparo
            Disparar();
        }
    }

    private void Disparar()
    {
        if (armaDefault == true)
        {
            armaEscopeta = false;
            armaBigCannon = false;
            Instantiate(bala, controladorDisparo[0].position, controladorDisparo[0].rotation);
        }
        if (armaEscopeta == true)
        {
            armaDefault = false;
            armaBigCannon = false;
            Instantiate(bala, controladorDisparo[0].position, controladorDisparo[0].rotation);
            Instantiate(bala, controladorDisparo[1].position, controladorDisparo[1].rotation);
            Instantiate(bala, controladorDisparo[2].position, controladorDisparo[2].rotation);
        }
        
        //GameObject disparo = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
        //disparo.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
    }
}
