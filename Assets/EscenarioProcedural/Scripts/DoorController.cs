using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public enum DoorType

    {
        LeftDoor,
        RightDoor
    }

    [SerializeField] bool canUse = false;
    [SerializeField] GameObject otherDoor;
    [SerializeField] DoorType doorType;


    public void SetCanUse(bool _canUse)
    {
        canUse = _canUse;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && canUse)
        {
            collision.transform.position = otherDoor.transform.position;
            ScenaryController.instance.NextRoom(doorType);
        }
    }
}
