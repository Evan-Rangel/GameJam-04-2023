using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryController : MonoBehaviour
{
    [SerializeField]List <GameObject> rooms;
    [SerializeField] GameObject shopRoom;
    [SerializeField] GameObject boosRoom;

    [SerializeField] GameObject currentCenterRoom;
    [SerializeField] GameObject currentRightRoom;
    [SerializeField] GameObject currentLefttRoom;

    [SerializeField] Vector2 centerPoint;
    [SerializeField] Vector2 rightPoint;
    [SerializeField] Vector2 leftPoint;

    [SerializeField] bool showGizmos=false;
    public static ScenaryController instance;
    bool lerpRight;
    bool lerpLeft;
    [SerializeField]float moveSpeed;
    int randomRoomArrPos;
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
        currentCenterRoom= Instantiate(rooms[randomRoomArrPos], centerPoint, Quaternion.identity, transform);
        randomRoomArrPos = Random.Range(0, rooms.Count);
        currentRightRoom = Instantiate(rooms[randomRoomArrPos], rightPoint, Quaternion.identity, transform);
        randomRoomArrPos = Random.Range(0, rooms.Count);
        currentLefttRoom =  Instantiate(rooms[randomRoomArrPos], leftPoint, Quaternion.identity, transform);
    }

    private void Update()
    {
        if (lerpRight)
        {
            transform.position = Vector3.Lerp(transform.position, rightPoint, Time.deltaTime * moveSpeed);
            if (Vector2.Distance(transform.position, rightPoint) < 0.1f)
            {
                transform.position = rightPoint;
                lerpRight = false;
                transform.position = centerPoint;

                currentRightRoom.transform.position = currentCenterRoom.transform.position;
                Destroy(currentCenterRoom);
                Destroy(currentLefttRoom);
                currentCenterRoom = currentRightRoom;

                randomRoomArrPos = Random.Range(0, rooms.Count);
                currentRightRoom = Instantiate(rooms[randomRoomArrPos], rightPoint, Quaternion.identity, transform);

                randomRoomArrPos = Random.Range(0, rooms.Count);
                currentLefttRoom = Instantiate(rooms[randomRoomArrPos], leftPoint, Quaternion.identity, transform);

            }
        }
        if (lerpLeft)
        {
            transform.position = Vector3.Lerp(transform.position, leftPoint, Time.deltaTime * moveSpeed);
            if (Vector2.Distance(transform.position, leftPoint) < 0.1f)
            {
                transform.position = leftPoint;
                lerpLeft = false;
                transform.position = centerPoint;

                currentLefttRoom.transform.position = currentCenterRoom.transform.position;
                Destroy(currentCenterRoom);
                Destroy(currentRightRoom);
                currentCenterRoom = currentLefttRoom;

                randomRoomArrPos = Random.Range(0, rooms.Count);
                currentRightRoom = Instantiate(rooms[randomRoomArrPos], rightPoint, Quaternion.identity, transform);

                randomRoomArrPos = Random.Range(0, rooms.Count);
                currentLefttRoom = Instantiate(rooms[randomRoomArrPos], leftPoint, Quaternion.identity, transform);
            }
        }
    }


    public void NextRoom(DoorController.DoorType _doorType)
    {
        switch (_doorType)
        {
            case DoorController.DoorType.LeftDoor:
                lerpLeft = true;
                break;
            case DoorController.DoorType.RightDoor:
                lerpRight = true;
                break;
        }
    }
    
    void SetRooms()
    {
        
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
