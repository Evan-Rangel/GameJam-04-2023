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
    [SerializeField] float time;
    [SerializeField] int currentMovDir = 0;

    [SerializeField, Range(1,30)] int projectilesPerWave;
    [SerializeField, Range(0,360)] int angleInit;
    [SerializeField, Range(0, 100)] int angleSum;
    [SerializeField, Range(0, 20)] int bulletSpeed;
    [SerializeField] GameObject bullet;
    [SerializeField, Range(0, 10)] float bulletCadence;  
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
    
    
    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        switch (movType)
        {
            case MovType.CUSTOM:
                break;
            case MovType.FOLLOW_PLAYER:
                break;
        }
        Movement();
        Attack();
    }
    void Movement()
    {
        Debug.Log(directions[(int)movDir[currentMovDir]]    );
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
        Attack();
    }

    IEnumerator NextMovement()
    {
        yield return new WaitForSeconds(time);
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
}
