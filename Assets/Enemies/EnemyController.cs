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
    Rigidbody2D rb;
    [SerializeField] int currentMovDir = 0;
    

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

    private void OnEnable()
    {
        //Movement();
    }
    private void Start()
    {
        Movement();

    }
    void Movement()
    {
        Debug.Log(directions[(int)movDir[currentMovDir]]    );
        rb.velocity = directions[(int)movDir[currentMovDir]]*vel;
        StartCoroutine(NextMovement());
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
