using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpsEffects : ScriptableObject
{
    //Forma distinta de hacer el ScriptableObect haciendo abstracta la clase para que no se mueva y pueda aplicar al objetivo que se desea
    public abstract void Apply(GameObject target);
}
