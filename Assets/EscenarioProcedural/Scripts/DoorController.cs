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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && canUse)
        {
            //canUse = false;
            collision.transform.position = otherDoor.transform.position;
            StartCoroutine(MovePlayer(collision.gameObject));
            ScenaryController.instance.NextRoom(doorType, otherDoor.transform.position);
        }
    }

    IEnumerator MovePlayer(GameObject _player)
    {
        _player.GetComponent<PlayerMovementScript>().SetCanMove(false);
        _player.SetActive(false);
        yield return new WaitForSeconds(0.5F);
        _player.SetActive(true);

        _player.GetComponent<PlayerMovementScript>().SetCanMove(true);

    }
}
