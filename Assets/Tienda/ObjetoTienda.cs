using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjetoTienda : MonoBehaviour
{
    //Referencia al script con los items
    public Items thisItem;

    private float price;

    public string nombre;
    public TextMeshPro priceTXT;
    public TextMeshPro nameTXT;

    void Start()
    {
        ComprobarExistencia();
    }

    public void ComprobarExistencia()
    {
        //Recorre todo el diccionario
        foreach (KeyValuePair<string, float> item in thisItem.items)
        {
            //Si el nombre coincide con alguno del dicionario entonces...
            if(nombre == item.Key)
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Cuando el player este sobre el item
        if(collision.tag == "Player")
        {
            Debug.Log(collision.tag);
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
