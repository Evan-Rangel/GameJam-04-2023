using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenaryController : MonoBehaviour
{
    [SerializeField]List <GameObject> rooms;
    [SerializeField] GameObject shopRoom;
    [SerializeField] GameObject boosRoom;
    [SerializeField] GameObject tutorialRoom;

    [SerializeField] GameObject currentCenterRoom;
    [SerializeField] GameObject currentRightRoom;
    [SerializeField] GameObject currentLeftRoom;

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
        currentCenterRoom= Instantiate(rooms[0], centerPoint, Quaternion.identity, transform);
        /*randomRoomArrPos = Random.Range(0, rooms.Count);
        currentRightRoom = Instantiate(rooms[1], rightPoint, Quaternion.identity, transform);
        randomRoomArrPos = Random.Range(0, rooms.Count);
        currentLeftRoom =  Instantiate(rooms[2], leftPoint, Quaternion.identity, transform);*/
    }

    private void Update()
    {
        if (lerpRight)
        {
            transform.position = Vector3.Lerp(transform.position, rightPoint, Time.deltaTime * moveSpeed);
            if (Vector2.Distance(transform.position, rightPoint) < 0.1f)
            {
                lerpRight = false;
                transform.position = centerPoint;

                currentRightRoom.transform.position = centerPoint;
                Destroy(currentCenterRoom);
                currentCenterRoom = currentRightRoom;
            }
        }
        if (lerpLeft)
        {
            transform.position = Vector3.Lerp(transform.position, leftPoint, Time.deltaTime * moveSpeed);
            if (Vector2.Distance(transform.position, leftPoint) < 0.1f)
            {
                lerpLeft = false;
                transform.position = centerPoint;

                currentLeftRoom.transform.position = centerPoint;
                Destroy(currentCenterRoom);
                currentCenterRoom = currentLeftRoom;
            }
        }
    }

    public void NextRoom(DoorController.DoorType _doorType, Vector2 _target)
    {
        switch (_doorType)
        {
            case DoorController.DoorType.LeftDoor:
                randomRoomArrPos = Random.Range(0, rooms.Count);

                currentLeftRoom = Instantiate(rooms[randomRoomArrPos], rightPoint, Quaternion.identity, transform);
                lerpLeft = true;
                //StartCoroutine(TeleportPlayer(_target));
                break;
            case DoorController.DoorType.RightDoor:
                randomRoomArrPos = Random.Range(0, rooms.Count);

                currentRightRoom = Instantiate(rooms[randomRoomArrPos], leftPoint, Quaternion.identity, transform);
                lerpRight = true;
                //StartCoroutine(TeleportPlayer(_target));
                break;
        }
    }
    IEnumerator TeleportPlayer(Vector2 _target)
    {
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("Player").transform.position = _target;
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
