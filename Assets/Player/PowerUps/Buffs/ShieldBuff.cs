using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/ShieldBuff")]

public class ShieldBuff : PowerUpsEffects
{
    //Cantidad que aumentara
    public bool activate;
    public override void Apply(GameObject target)
    {
        //Buscamos el script de la variable que queremos modificar, tomamos la variable y sumamos o restamos dependiendo que queremos hacer (Esto para este tipo de items)
        target.GetComponent<PlayerMovementScript>().shield = activate;
    }
}
