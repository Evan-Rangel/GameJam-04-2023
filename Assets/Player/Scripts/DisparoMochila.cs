using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoMochila : MonoBehaviour
{
    [SerializeField] private float velocidad;

    [SerializeField] private int damage;

    public int multy;

    private void Start()
    {
        //gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * velocidad;
    }

    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limites"))
        {
            Destroy(gameObject);
        }
    }

    public void setDamage(int _damage, int _multy)
    {
        damage = _damage;
        multy = _multy;
    }
}
