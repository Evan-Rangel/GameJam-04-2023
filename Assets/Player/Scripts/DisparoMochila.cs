using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoMochila : MonoBehaviour
{
    [SerializeField] private float velocidad;

    [SerializeField] private float da�o;

    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            //other.GetComponent<Enemigo>().TomarDa�o(da�o);
            Destroy(gameObject);
        }
    }
}
