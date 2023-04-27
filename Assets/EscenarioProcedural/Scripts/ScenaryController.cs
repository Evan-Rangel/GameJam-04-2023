using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryController : MonoBehaviour
{
    [SerializeField]List <GameObject> rooms;
    [SerializeField] GameObject shopRoom;
    [SerializeField] GameObject boosRoom;

    [SerializeField] Transform centerPoint;
    [SerializeField] Transform rightPoint;
    [SerializeField] Transform leftPoint;


    private void Start()
    {
        
    }



    void NextRoom()
    {
        int randomRoomArrPos= Random.Range(0, rooms.Count);

        GameObject room = Instantiate(rooms[randomRoomArrPos], centerPoint.transform.position, Quaternion.identity);

        //activar funcion de room para los enemigos.


    }








}
