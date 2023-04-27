using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDisparo : MonoBehaviour
{
    [SerializeField] private Transform controladorDisparo;

    [SerializeField] private GameObject bala;

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
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
        //GameObject disparo = Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
        //disparo.GetComponent<Rigidbody2D>().AddForce(Vector2.up);
    }
}
