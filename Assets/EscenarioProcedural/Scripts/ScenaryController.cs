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
    [SerializeField] GameObject shopRoomIns;
    [SerializeField] GameObject currentCenterRoom;
    [SerializeField] GameObject currentRightRoom;
    [SerializeField] GameObject currentLeftRoom;

    [SerializeField] Vector2 centerPoint;
    [SerializeField] Vector2 rightPoint;
    [SerializeField] Vector2 leftPoint;
    [SerializeField] Vector2 shopPoint;

    [SerializeField] GameObject[] enemigoSuelo;
    [SerializeField] GameObject[] enemigoAire;
    [SerializeField] GameObject chestPrefab;

    [SerializeField] int enemiesAlive;

    [SerializeField] Transform[] enemiesSueloPositions;
    [SerializeField] Transform[] enemiesAirePositions;


    [SerializeField] Transform chestPosition;

    [SerializeField] bool showGizmos=false;
    [SerializeField] int enemyGroundCount;
    [SerializeField] int enemyAirCount;

    [SerializeField] GameObject leftDoor;
    [SerializeField] GameObject rightDoor;
    [SerializeField] GameObject[] items;
    [SerializeField] Transform[] itemPos;
    [SerializeField] List<GameObject> itemPrefabs;

    int itemCount = 3;
    bool lerpRight =false;
    bool lerpLeft=false;
    bool lerpShoop=false;
    [SerializeField]float moveSpeed;
    int randomRoomArrPos;
    int nivel=0;
    [SerializeField]bool activateBossRoom = false;
    public bool roomToShop=false;
    public bool nextRoom = false;
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
        enemyGroundCount = 1;
        enemyAirCount = -1;
        randomRoomArrPos = Random.Range(0, rooms.Count);
       // currentCenterRoom= Instantiate(rooms[0], centerPoint, Quaternion.identity, transform);
        currentCenterRoom= Instantiate(bossRoom, centerPoint, Quaternion.identity, transform);

        currentCenterRoom.GetComponent<RoomController>().SetLevel(nivel);
        nextRoom = true;
        rightDoor.GetComponent<DoorController>().canUse = true;
        leftDoor.GetComponent<DoorController>().canUse = true;
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
                GenerateEnemies();
                rightDoor.GetComponent<DoorController>().canUse = false;
                leftDoor.GetComponent<DoorController>().canUse = false;
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
                GenerateEnemies();
                rightDoor.GetComponent<DoorController>().canUse = false;
                leftDoor.GetComponent<DoorController>().canUse = false;
            }
        }
        if (lerpShoop)
        {
            transform.position = Vector2.Lerp(transform.position, shopPoint, Time.deltaTime*moveSpeed);
            if (Vector2.Distance(transform.position, shopPoint)<0.05f)
            {
                lerpShoop = false;
                transform.position = shopPoint;

                shopRoomIns.transform.position = centerPoint;
                Destroy(currentCenterRoom);
                currentCenterRoom = shopRoomIns;
                currentCenterRoom.GetComponent<RoomController>().SetLevel(nivel);
                nextRoom = true;
                GenerateShop();
            }
        }
    }

    void GenerateShop()
    {
        for (int i = 0; i < itemPos.Length; i++)
        {
            if (itemPrefabs.Count>0)
            {
                int rand= Random.Range(0, itemPrefabs.Count);
                Instantiate(itemPrefabs[rand], itemPos[i]);
                itemPrefabs.Remove(itemPrefabs[rand]);
            }

        }
    }
    void GenerateEnemies()
    {
        for (int i = 0; i < enemyGroundCount; i++)
        {
            Instantiate(enemigoSuelo[Random.Range(0,enemigoSuelo.Length)], enemiesSueloPositions[i].position, Quaternion.identity);
            enemiesAlive++;
        }
        for (int i = 0; i < enemyAirCount; i++)
        {
            enemiesAlive++;
            Instantiate(enemigoAire[Random.Range(0, enemigoAire.Length)], enemiesAirePositions[i].position, Quaternion.identity);
        }
    }
    public void EnemyDeath()
    {
        enemiesAlive--;
        if (enemiesAlive==0)
        {
            nextRoom = true;
            rightDoor.GetComponent<DoorController>().canUse = true;
            leftDoor.GetComponent<DoorController>().canUse = true;

            int rand = Random.Range(0,3);
            if (rand==2)
            {
                Instantiate(chestPrefab, chestPosition);
            }

        }
    }
    public void ShopRoom(DoorController.DoorType _doorType, Vector2 _target)
    {
        if (_doorType== DoorController.DoorType.CenterDor)
        {
            shopRoomIns = Instantiate(shopRoom, shopPoint, Quaternion.identity,transform);
            lerpShoop = true;
            if (enemyGroundCount < enemiesSueloPositions.Length - 1)
            {
                enemyGroundCount++;
            }
            if (enemyAirCount < enemiesAirePositions.Length - 1)
            {
                enemyAirCount++;
            }
        }
    }
    public void NextRoom(DoorController.DoorType _doorType, Vector2 _target)
    {
        nivel++;
        if (nivel % 15 != 0)
        {
            activateBossRoom = true;
        }
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
                        roomToShop = false;
                        rightDoor.GetComponent<DoorController>().canUse = true;
                        leftDoor.GetComponent<DoorController>().canUse = true;
                    }
                    else
                    {
                        randomRoomArrPos = Random.Range(0, roomDoors.Count);
                        currentLeftRoom = Instantiate(roomDoors[randomRoomArrPos], rightPoint, Quaternion.identity, transform);
                        roomToShop = true;
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
                        roomToShop = false;
                        rightDoor.GetComponent<DoorController>().canUse = true;
                        leftDoor.GetComponent<DoorController>().canUse = true;
                    }
                    else
                    {
                        
                        randomRoomArrPos = Random.Range(0, roomDoors.Count);
                        currentRightRoom = Instantiate(roomDoors[randomRoomArrPos], leftPoint, Quaternion.identity, transform);
                        roomToShop = true;
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
