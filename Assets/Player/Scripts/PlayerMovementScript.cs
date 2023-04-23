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
    [SerializeField] float jumpTime;
    float jumpF;
    Vector2 movDir;
    Rigidbody2D rb;
    bool isJumping=false;
    bool canJump =true;
    float xDir;
    float jumpT;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        jumpT = jumpTime;
        jumpF = jumpForce;
    }
    private void Update()
    {
        xDir = input.actions["Move"].ReadValue<Vector2>().x;
        rb.velocity = new Vector2(xDir*movementVelocity, rb.velocity.y);


        if (input.actions["Jump"].IsPressed() && !isJumping && jumpT > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpF);
            if (jumpT< jumpTime/2)
            {
                jumpF -= Time.deltaTime * 2; 
            }
            jumpT -= Time.deltaTime;
            canJump = true;

            Debug.Log("Salto");
        }
        else if (jumpT != jumpTime)
        {
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
            jumpF = jumpForce;
            jumpT = jumpTime;
            isJumping = false;
            Debug.Log("Piso");
        }
    }
}