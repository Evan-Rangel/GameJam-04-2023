using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/SpeedBuff")]
public class SpeedBuff : PowerUpsEffects
{
    //Cantidad que aumentara
    public float amount;
    public override void Apply(GameObject target)
    {
        //Buscamos el script de la variable que queremos modificar, tomamos la variable y sumamos o restamos dependiendo que queremos hacer (Esto para este tipo de items)
        target.GetComponent<PlayerMovementScript>().movementVelocity += amount;
    }
}
