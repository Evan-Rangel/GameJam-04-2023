using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    [SerializeField] float jumpForce;
    [SerializeField] float movementVelocity;
    [SerializeField] float gravityScale = 5;
    [SerializeField] float fallGravityScale = 15;

    float jumpF;
    Vector2 movDir;
    Rigidbody2D rb;
    bool isJumping=false;
    bool canJump =true;
    float xDir;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
    }
    private void Update()
    {
        xDir = input.actions["Move"].ReadValue<Vector2>().x;
        rb.velocity = new Vector2(xDir*movementVelocity, rb.velocity.y);
        //jumpForce=input.actions["Jump"].butt
        if (input.actions["Jump"].IsPressed() && !isJumping && jumpF>0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpF);

            jumpF -= Time.deltaTime*jumpForce;
            canJump = true;
            //isJumping = true;
            // rb.AddForce(Vector2.up * jumpF, ForceMode2D.Impulse);
            Debug.Log("Salto");
        }
        else if(jumpF!=jumpForce)
        {
            jumpF = jumpForce;
            isJumping = true;
        }
        if (rb.velocity.y>0)
        {
            rb.gravityScale = gravityScale;
        }
        else
        {
            rb.gravityScale = fallGravityScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isJumping = false;
            Debug.Log("Piso");
        }
    }
}
