using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5, 5]; //Cantidad de Items
    public float price;
    public Text priceTXT;

    void Start()
    {
        priceTXT.text = "Precio:" + price.ToString();

        //Declaracion de ID's de cada Item
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 1;
        shopItems[1, 3] = 1;
        shopItems[1, 4] = 1;

        //Precio de cada Item
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 15;
        shopItems[2, 3] = 11;
        shopItems[2, 4] = 13;
    }

    public void Buy()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("On trigger");
    }
}
