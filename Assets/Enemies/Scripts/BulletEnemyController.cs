using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyController : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Puerta")|| collision.CompareTag("Limites"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovementScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
