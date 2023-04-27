using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<string, float> playerItems = new Dictionary<string, float>();
    public int itemsLimit;
    bool isTriggered;
    bool onLimit;
    bool comprado;
    ObjetoTienda otherScript;

    // Start is called before the first frame update
    void Start()
    {
        //Prueba de dinero en inventario para comprar items
        playerItems.Add("Coins", 1000);
    }

    // Update is called once per frame
    void Update()
    {
        //Comprueba que este en el trigger y se pulse la tecla de comprar
        if (isTriggered && Input.GetKeyDown(KeyCode.B))
        {
            //Comprueba que haya inventario disponible antes de realizar una compra
            onLimit = InventarioLimite();
            if (onLimit)
            {
                foreach (KeyValuePair<string, float> item in playerItems)
                {
                    if (item.Key == "Coins")
                    {
                        //Llama a la funcion de compra, enviandole el parametro del player inventory y el dinero disponible
                        AudioSource audio = GetComponent<AudioSource>();
                        otherScript.Comprar(item.Value, playerItems, audio);
                        break;
                    }
                }
                //GetComponent<ObjetoTienda>();
            }
            else
            {
                Debug.Log("Fuera de Inventario");
            }
        }
    }

    public bool InventarioLimite()
    {
        int cont = 0;
        foreach (KeyValuePair<string, float> item in playerItems)
        {
            cont++;
        }
        if (cont < itemsLimit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //Comprueba si esta sobre un item que puede comprar
        if(other.tag == "Item")
        {
            isTriggered = true;
            //Conecta al script ObjetoTienda
            ObjetoTienda objetoTienda = other.gameObject.GetComponent<ObjetoTienda>();
            otherScript = objetoTienda;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Cuando se sale del trigger ya no esta en el trigger
        if (other.tag == "Item")
        {
            isTriggered = false;
        }
    }
}
