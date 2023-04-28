using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomController : MonoBehaviour
{
    [SerializeField] Transform[] enemyPoints;

    [SerializeField] Transform chestPoint;

    [SerializeField] int level;


    public void SetLevel(int _level)
    {
        level = _level;
    }



}
