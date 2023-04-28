using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/MaxHealthBuff")]
public class HealthMaxBuff : PowerUpsEffects
{
    //Cantidad que aumentara
    public int amount;
    private int maxH;
    private int currMaxH;
    public override void Apply(GameObject target)
    {
        //Buscamos el script de la variable que queremos modificar, tomamos la variable y sumamos o restamos dependiendo que queremos hacer (Esto para este tipo de items)
        maxH = target.GetComponent<PlayerMovementScript>().maxHealth;
        currMaxH = target.GetComponent<PlayerMovementScript>().currentMaxHealth;

        while (currMaxH+amount > maxH)
        {
            amount--;
        }

        target.GetComponent<PlayerMovementScript>().currentMaxHealth += amount;
    }
}
