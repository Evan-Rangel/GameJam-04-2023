using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Items : MonoBehaviour
{
    public Dictionary<string, int> items = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        //Agregar items al diccionario
        items.Add("Torpe2", 40);
        items.Add("Manzana", 5);
        items.Add("Lanza Webos", 30);
        items.Add("Estrella", 500);
        items.Add("Prochevo", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
