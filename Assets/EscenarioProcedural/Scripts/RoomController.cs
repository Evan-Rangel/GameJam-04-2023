using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomController : MonoBehaviour
{
    
    
    public Transform[] enemyGroundPoints;
    public Transform[] enemyAirPoints;


    [SerializeField] Transform chestPoint;

    [SerializeField] int level;


    public void SetLevel(int _level)
    {
        level = _level;
    }

}
