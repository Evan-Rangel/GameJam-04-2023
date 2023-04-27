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
            //canUse = false;
            collision.transform.position = otherDoor.transform.position;
            //StartCoroutine(Disable_Enable_Collider());
            ScenaryController.instance.NextRoom(doorType, otherDoor.transform.position);
        }
    }

    IEnumerator Disable_Enable_Collider()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Collider2D>().enabled = true;

    }
}
