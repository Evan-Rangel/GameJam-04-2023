using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //Hacemos referencia al Script que aplica los power Ups
    public PowerUpsEffects powerupEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Si lo toca lo destruya
            Destroy(gameObject);
            //Aplica el efecto dependiendo que ScripObj se le ponga en el inspector
            powerupEffect.Apply(collision.gameObject);
        }       
    }
}
