using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoTienda : MonoBehaviour
{
    //Referencia al script con los items
    public Items thisItem;

    private float price;
    public string nombre;
    private bool inicializado = false;

    public TextMeshPro priceTXT;
    public TextMeshPro nameTXT;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!inicializado)
        {
            //inicializa los datos para cada item
            ComprobarExistencia();
            inicializado = true;
        }
    }

    public void ComprobarExistencia()
    {
        //Recorre todo el diccionario
        foreach (KeyValuePair<string, float> item in thisItem.items)
        {
            Debug.Log("Nombre: " + item.Key + "\nPrecio: " + item.Value);
            //Si el nombre coincide con alguno del dicionario entonces...
            if (nombre == item.Key)
            {
                Debug.Log("Nombre: " + item.Key + "\nPrecio: " + item.Value);
                price = item.Value;
                //Despliega en pantalla sus atributos
                priceTXT.text = "Precio: " + price.ToString();
                nameTXT.text = "Nombre: " + nombre.ToString();
                break;
            }
        }
        Debug.Log("Inexistente");
    }

    public void Comprar(float monedas, Dictionary<string, float> playerItems)
    {
        //comprueba que el player tenga dinero suficiente
        if(monedas >= price)
        {
            //Resta el dinero que cuesta al player
            QuitarDinero(playerItems, monedas);
            DarItem(playerItems);
            //Se inhabilita el item a la venta
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Pombre");
        }
    }

    //Agrega el item al inventario del player
    public void DarItem(Dictionary<string, float> playerItems)
    {
        playerItems.Add(nombre, price);
        //Debug
        foreach (KeyValuePair<string, float> item in playerItems)
        {
            Debug.Log("Nombre: " + item.Key + "\nPrecio: " + item.Value);
        }
    }

    public void QuitarDinero(Dictionary<string, float> playerItems, float monedas) 
    {
        //Calculo del dinero restante del player
        float resultado = monedas - price;
        //Se modifica el numero de monedas del player
        playerItems["Coins"] = resultado;

        //Debug
        foreach (KeyValuePair<string, float> item in playerItems)
        {
            Debug.Log("Nombre: " + item.Key + "\nCantidad Disponible: " + item.Value);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Cuando el player este sobre el item
        if(collision.tag == "Player")
        {
            //Debug.Log(collision.tag);
            //se escala un poco mas el item
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //Regresa a su escala inicial cuando el jugador no esta sobre el item
        transform.localScale = new Vector3(1, 1, 1);
    }
}
