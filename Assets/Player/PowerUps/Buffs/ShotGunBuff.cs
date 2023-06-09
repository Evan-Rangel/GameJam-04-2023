using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/ShotGunBuff")]
public class ShotGunBuff : PowerUpsEffects
{
    //Esta activo o no
    public bool activate;
    public override void Apply(GameObject target)
    {
        //Buscamos el script de la variable que queremos modificar, tomamos la variable y activamos o desactivamos dependiendo que queremos hacer 
        //
        target.GetComponentInChildren<ControladorDisparo>().armaDefault = false;
        target.GetComponentInChildren<ControladorDisparo>().armaBigCannon = false;
        target.GetComponentInChildren<ControladorDisparo>().armaEscopeta = activate;      
    }
}
