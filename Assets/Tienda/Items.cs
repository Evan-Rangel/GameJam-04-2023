using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Progress;

public class Items : MonoBehaviour
{
    public Dictionary<string, int> items = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        //Agregar items al diccionario
        items.Add("Big Cannon", 75);
        items.Add("Damage Buff", 20);
        items.Add("Health Buff", 20);
        items.Add("Max Health Buff", 30);
        items.Add("ShotGun", 50);
        items.Add("Speed Buff", 30);
        items.Add("Star", 50);


    }

}
