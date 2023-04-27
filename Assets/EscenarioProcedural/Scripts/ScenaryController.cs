using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryController : MonoBehaviour
{
    [SerializeField]List <GameObject> rooms;
    [SerializeField] GameObject shopRoom;
    [SerializeField] GameObject boosRoom;

    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;

    [SerializeField] Vector2 centerPoint;
    [SerializeField] Vector2 rightPoint;
    [SerializeField] Vector2 leftPoint;


    private void Start()
    {
         
    }



    void NextRoom()
    {
        int randomRoomArrPos= Random.Range(0, rooms.Count);
        GameObject room = Instantiate(rooms[randomRoomArrPos], centerPoint, Quaternion.identity);
        randomRoomArrPos = Random.Range(0, rooms.Count);
        GameObject rightRoom = Instantiate(rooms[randomRoomArrPos], rightPoint, Quaternion.identity);
        randomRoomArrPos = Random.Range(0, rooms.Count);
        GameObject leftRoom = Instantiate(rooms[randomRoomArrPos], leftPoint, Quaternion.identity);


        //activar funcion de room para los enemigos.

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(centerPoint, new Vector2(18,10));
        Gizmos.DrawCube(rightPoint, new Vector2(18, 10));
        Gizmos.DrawCube(leftPoint, new Vector2(18, 10));
    }
}
