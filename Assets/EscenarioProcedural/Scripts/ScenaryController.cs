using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryController : MonoBehaviour
{
    [SerializeField]List <GameObject> rooms;
    [SerializeField] List<GameObject> roomDoors;
    [SerializeField] GameObject shopRoom;
    [SerializeField] GameObject bossRoom;
    [SerializeField] GameObject tutorialRoom;

    [SerializeField] GameObject currentCenterRoom;
    [SerializeField] GameObject currentRightRoom;
    [SerializeField] GameObject currentLeftRoom;

    [SerializeField] Vector2 centerPoint;
    [SerializeField] Vector2 rightPoint;
    [SerializeField] Vector2 leftPoint;


    [SerializeField] GameObject[] enemigoSuelo;
    [SerializeField] GameObject[] enemigoAire;

    [SerializeField] int enemiesAlive;



    [SerializeField] bool showGizmos=false;
    bool lerpRight;
    bool lerpLeft;
    [SerializeField]float moveSpeed;
    int randomRoomArrPos;
    int nivel=0;
    [SerializeField]bool activateBossRoom = false;

    public void setActivateBossRoom(bool _activateBossRoom)
    {
        activateBossRoom = _activateBossRoom;
    }

    public static ScenaryController instance;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        randomRoomArrPos = Random.Range(0, rooms.Count);
        currentCenterRoom= Instantiate(rooms[0], centerPoint, Quaternion.identity, transform);
        currentCenterRoom.GetComponent<RoomController>().SetLevel(nivel);
    }

    private void Update()
    {
        if (lerpLeft)
        {
            transform.position = Vector3.Lerp(transform.position, leftPoint, Time.deltaTime * moveSpeed);
            if (Vector2.Distance(transform.position, leftPoint) < 0.05f)
            {
                lerpLeft = false;
                transform.position = centerPoint;

                currentLeftRoom.transform.position = centerPoint;
                Destroy(currentCenterRoom);
                currentCenterRoom = currentLeftRoom;
                currentCenterRoom.GetComponent<RoomController>().SetLevel(nivel);

            }
        }
        if (lerpRight)
        {
            transform.position = Vector3.Lerp(transform.position, rightPoint, Time.deltaTime * moveSpeed);
            if (Vector2.Distance(transform.position, rightPoint) < 0.05f)
            {
                lerpRight = false;
                transform.position = centerPoint;

                currentRightRoom.transform.position = centerPoint;
                Destroy(currentCenterRoom);
                currentCenterRoom = currentRightRoom;
                currentCenterRoom.GetComponent<RoomController>().SetLevel(nivel);

            }
        }
    }
    void GenerateEnemies()
    {
        for (int i = 0; i < currentCenterRoom.GetComponent<RoomController>().enemyGroundPoints.Length; i++)
        {
            Instantiate(enemigoSuelo[Random.Range(0,enemigoSuelo.Length)], currentCenterRoom.GetComponent<RoomController>().enemyGroundPoints[i].position, Quaternion.identity);
        }
        for (int i = 0; i < currentCenterRoom.GetComponent<RoomController>().enemyAirPoints.Length; i++)
        {

            Instantiate(enemigoSuelo[Random.Range(0, enemigoAire.Length)], currentCenterRoom.GetComponent<RoomController>().enemyAirPoints[i].position, Quaternion.identity);
        }
    }

    public void NextRoom(DoorController.DoorType _doorType, Vector2 _target)
    {
        nivel++;
        
        switch (_doorType)
        {
            case DoorController.DoorType.LeftDoor:
                if (activateBossRoom)
                {
                    currentLeftRoom = Instantiate(bossRoom, rightPoint, Quaternion.identity, transform);

                }
                else
                {
                    if (nivel % 5 != 0)
                    {
                        randomRoomArrPos = Random.Range(0, rooms.Count);
                        currentLeftRoom = Instantiate(rooms[randomRoomArrPos], rightPoint, Quaternion.identity, transform);
                    }
                    else
                    {
                        randomRoomArrPos = Random.Range(0, roomDoors.Count);
                        currentLeftRoom = Instantiate(roomDoors[randomRoomArrPos], rightPoint, Quaternion.identity, transform);
                    }
                }
                lerpLeft = true;
                break;
            case DoorController.DoorType.RightDoor:
                if (activateBossRoom)
                {
                    currentRightRoom = Instantiate(bossRoom, leftPoint, Quaternion.identity, transform);
                }
                else
                {
                    if (nivel % 5 != 0)
                    {
                        randomRoomArrPos = Random.Range(0, rooms.Count);
                        currentRightRoom = Instantiate(rooms[randomRoomArrPos], leftPoint, Quaternion.identity, transform);
                    }
                    else
                    {
                        randomRoomArrPos = Random.Range(0, roomDoors.Count);
                        currentRightRoom = Instantiate(roomDoors[randomRoomArrPos], leftPoint, Quaternion.identity, transform);
                    }
                }

                lerpRight = true;
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (showGizmos)
        {
            Gizmos.DrawCube(centerPoint, new Vector2(18,10));
            Gizmos.DrawCube(rightPoint, new Vector2(18, 10));
            Gizmos.DrawCube(leftPoint, new Vector2(18, 10));
        }
    }
}
