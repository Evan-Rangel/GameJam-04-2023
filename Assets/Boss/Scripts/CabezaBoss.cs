using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabezaBoss : MonoBehaviour
{
    public int health=60;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            health -= collision.GetComponent<DisparoMochila>().GetDamage;
            if (health<=0)
            {
                GetComponentInParent<BossFight>().Morir();
            }
        }
    }
}
