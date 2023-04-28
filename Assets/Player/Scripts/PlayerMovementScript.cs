using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] PlayerInput input;
    //Vida
    public int maxHealth = 10;
    public int currentHealth = 3;
    //Escudo
    public bool shield;
    [SerializeField] float jumpForce;
    public float movementVelocity; //Movi esto Evan a public
    [SerializeField] float gravityScale = 5;
    [SerializeField] float fallGravityScale = 15;
    [SerializeField] float jumpTime;
    public int stars;
    float jumpF;
    Vector2 movDir;
    Rigidbody2D rb;
    bool isJumping=false;
    bool canJump =true;
    float xDir;
    float jumpT;

    bool canMove=true;
    bool frstCheck = false;

    public AudioSource Ruidos;
    public AudioSource Pasos;
    public AudioClip Jump_Start;
    public AudioClip Hits_Ground;
    public AudioClip Damage_Big;
    public AudioClip Damage_Med;
    public AudioClip Damage_Sm;


    public void SetCanMove(bool _canMove)
    {
        canMove = _canMove;
    }

    public bool GetCanMove { get { return canMove; } }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        //currentHealth = maxHealth;
        shield = false;
        jumpT = jumpTime;
        jumpF = jumpForce;
    }
    private void Update()
    {

        if (canMove)
        {

            xDir = input.actions["Move"].ReadValue<Vector2>().x;
            rb.velocity = new Vector2(xDir*movementVelocity, rb.velocity.y);
            if (!Pasos.isPlaying && rb.velocity.x!=0 && !isJumping)
            {
                Pasos.Play();
            }

            if (input.actions["Jump"].IsPressed() && !isJumping && jumpT > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpF);
                if (jumpT< jumpTime/2)
                {
                    jumpF -= Time.deltaTime * 2; 
                }
                jumpT -= Time.deltaTime;
                canJump = true;
            }
            else if (jumpT != jumpTime)
            {
                if (!isJumping)
                {
                    Ruidos.PlayOneShot(Jump_Start);
                }
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            jumpF = jumpForce;
            jumpT = jumpTime;
            isJumping = false;

            if(frstCheck)
            {
                Ruidos.PlayOneShot(Hits_Ground);
            }
            else
            {
                frstCheck = true;
            }
            
        }
    }
    //Funcion pa recibir daño llamala y ponle cuanto quieres que se baje
    void TakeDamage(int amount)
    {
        //random para el sonido
        int num = Random.Range(1, 4);
        switch (num)
        {
            case 1:
                Ruidos.PlayOneShot(Damage_Sm);
                break;
            case 2:
                Ruidos.PlayOneShot(Damage_Med);
                break;
            case 3:
                Ruidos.PlayOneShot(Damage_Big);
                break;
        }

        //Si el escudo esta activo no recibe daño y se apaga
        if (shield == true)
        {
            shield = false;
        }
        else
        {
            currentHealth -= amount;
        }
        if (currentHealth <= 0)
        {
            //Moriste proo
            //Play Death animation
            //Show GameOver Screen
        }
    }
}