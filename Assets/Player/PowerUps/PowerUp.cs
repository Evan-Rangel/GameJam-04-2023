using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //Hacemos referencia al Script que aplica los power Ups
    public PowerUpsEffects powerupEffect;

    public void ApllyBuffEffect( GameObject _player)
    {
        powerupEffect.Apply(_player.gameObject);
        Destroy(gameObject);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Aplica el efecto dependiendo que ScripObj se le ponga en el inspector
            powerupEffect.Apply(collision.gameObject);
            //Si lo toca lo destruya
            Destroy(gameObject);           
        }       
    }*/
}
