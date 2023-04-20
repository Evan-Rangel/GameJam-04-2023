using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] PlayerInput input;

    Vector2 movDir;
    Rigidbody2D rb;
    bool isJumping;
    float xDir;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        xDir = input.actions["Move"].ReadValue<Vector2>().x;
        rb.velocity = new Vector2(xDir, 0);
        if (input.actions["Jump"].WasPressedThisFrame())
        {
            Debug.Log("Salto");
            rb.AddForce(Vector2.up*5);
        }
        
        RaycastHit2D hit= Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity);
        if (hit.collider!=null)
        {
            //Debug.Log("RayLog");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            Debug.Log("Piso");
        }
    }
}
