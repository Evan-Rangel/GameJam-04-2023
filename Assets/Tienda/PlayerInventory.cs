using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Dictionary<string, float> playerItems = new Dictionary<string, float>();
    // Start is called before the first frame update
    void Start()
    {
        playerItems.Add("Coins", 23);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            //Comprobar que el jugador tenga dinero para comprar el item
            Debug.Log("compra compra");
        }
    }
}
