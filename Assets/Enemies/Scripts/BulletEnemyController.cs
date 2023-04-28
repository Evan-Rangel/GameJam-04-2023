using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")|| collision.CompareTag("Puerta")|| collision.CompareTag("Limites"))
        {
            Destroy(gameObject);
        }
    }
}
