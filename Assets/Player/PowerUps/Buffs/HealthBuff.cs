using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealthBuff")]
public class HealthBuff : PowerUpsEffects
{
    //Cantidad que aumentara
    public int amount;
    public override void Apply(GameObject target)
    {
        //Buscamos el script de la variable que queremos modificar, tomamos la variable y sumamos o restamos dependiendo que queremos hacer (Esto para este tipo de items)
        if (target.GetComponent<PlayerMovementScript>().currentHealth > 0 && target.GetComponent<PlayerMovementScript>().currentHealth < target.GetComponent<PlayerMovementScript>().maxHealth)
        {
            if (target.GetComponent<PlayerMovementScript>().currentHealth > target.GetComponent<PlayerMovementScript>().maxHealth)
            {
                target.GetComponent<PlayerMovementScript>().currentHealth = target.GetComponent<PlayerMovementScript>().maxHealth;
            }
            else
            {
                target.GetComponent<PlayerMovementScript>().currentHealth += amount;
            }
        }       
    }
}
