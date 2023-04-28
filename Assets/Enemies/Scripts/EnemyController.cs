using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum MovType
    {
        CUSTOM,
        FOLLOW_PLAYER
    }

    public enum MovDirection
    {
        NORTH,
        SOUTH,
        WEST,
        EAST,
        NORTHEAST,
        NORTHWEST,
        SOUTHEAST,
        SOUTHWEST
    }


    [SerializeField] MovType movType;

    [SerializeField] List<MovDirection> movDir;
    [SerializeField] float vel;
    [SerializeField] float movTime;

    [SerializeField] int currentMovDir = 0;

    [SerializeField, Range(1, 30)] int projectilesPerWave;
    [SerializeField, Range(0, 360)] int angleInit;
    [SerializeField, Range(-100, 100)] int angleSum;
    [SerializeField, Range(0, 20)] float bulletSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField, Range(0, 2)] float bulletCadence;
    [SerializeField] int bulletDamage;
    [SerializeField] int health;
    Rigidbody2D rb;
    Vector2[] directions= 
    { 
    Vector2.up,
    Vector2.down,
    Vector2.right,
    Vector2.left,
    new Vector2(-1,1).normalized,
    new Vector2(1,1).normalized,
    new Vector2(-1,-1).normalized,
    new Vector2(1,-1).normalized
    };


    GameObject player;
    
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        switch (movType)
        {
            case MovType.CUSTOM:
                Movement();
                Attack();
                break;
            case MovType.FOLLOW_PLAYER:
                AttackPlayer(); 
                MovementToPlayer();
                break;
        }
    }

    private void Update()
    {
        if (movType== MovType.FOLLOW_PLAYER)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left*5);

            Debug.DrawRay(transform.position, Vector2.left*2, Color.white);
            if (hit.transform.CompareTag("Puerta") && hit.distance < 2)
            {
                Debug.Log("puerta izquierda");
                rb.velocity = directions[2] * vel;
            }

            RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.right*5);

            if (hit2.transform.CompareTag("Puerta") && hit2.distance < 2)
            {
                Debug.Log("puerta derecha");

                rb.velocity = directions[3] * vel;
            }
        }
    }

    void AttackPlayer()
    {
        Vector2 dirToPlayer = (player.transform.position - transform.position).normalized;
        GameObject bulletTemp = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletTemp.GetComponent<Rigidbody2D>().velocity = dirToPlayer * bulletSpeed;
        StartCoroutine(NextAttackToPlayer());

    }

    void MovementToPlayer()
    {
        if (Vector2.Distance(player.transform.position , transform.position)>3)
        {
            if (player.transform.position.x < transform.position.x)
            {
                rb.velocity = directions[3] * vel;
            }
            else
            {
                rb.velocity = directions[2] * vel;
            }
        }
        
        StartCoroutine (NextMovToPlayer());
    }

    IEnumerator NextMovToPlayer()
    {
        yield return new WaitForSeconds(movTime);
        MovementToPlayer();
    }


    void Movement()
    {
        rb.velocity = directions[(int)movDir[currentMovDir]]*vel;
        StartCoroutine(NextMovement());
    }

    void Attack()
    {
        float angle = angleInit;
        float angleStep= 360/projectilesPerWave;
        Vector2 startPos = transform.position;
        
        
        for (int i = 0; i < projectilesPerWave; i++)
        {
            float DirXPos = startPos.x + Mathf.Sin((angle * Mathf.PI) / 180);
            float DirYPos = startPos.y + Mathf.Cos((angle * Mathf.PI) / 180);
            Vector2 dir = new Vector2(DirXPos, DirYPos);
            Vector2 movDir = (dir - startPos).normalized * bulletSpeed;
            GameObject bulletTemp = Instantiate(bullet, startPos, Quaternion.identity);
            bulletTemp.GetComponent<Rigidbody2D>().velocity = movDir*bulletSpeed;
            angle += angleStep;
        }
        StartCoroutine(NextShoot()) ;
    }
    IEnumerator NextShoot()
    {

        yield return new WaitForSeconds(bulletCadence);
        
        angleInit += angleSum;
        Attack();
    }

    IEnumerator NextMovement()
    {
        yield return new WaitForSeconds(movTime);
        if (currentMovDir < movDir.Count-1)
        {
            currentMovDir++;
        }
        else
        {
            currentMovDir = 0;
        }
        Movement();
    }
    IEnumerator NextAttackToPlayer()
    {
        yield return new WaitForSeconds(bulletCadence);
        AttackPlayer();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerBullet"))
        {
            health -= collision.gameObject.GetComponent<DisparoMochila>().GetDamage;
            if (health<=0)
            {
                Destroy(gameObject);
            }
        }
    }


}
