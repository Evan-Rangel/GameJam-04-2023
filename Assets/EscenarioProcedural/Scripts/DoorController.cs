using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public enum DoorType

    {
        LeftDoor,
        RightDoor,
        CenterDor
    }

    [SerializeField] bool canUse = false;
    [SerializeField] GameObject otherDoor;
    [SerializeField] GameObject shoopDoor;
    [SerializeField] DoorType doorType;

    [SerializeField] bool isShopDoor;
    bool appear=false;
    public void SetCanUse(bool _canUse)
    {
        canUse = _canUse;
    }

    private void Start()
    {
        if (isShopDoor)
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void Update()
    {
        if (ScenaryController.instance.roomToShop && isShopDoor)
        {
            GetComponent<Collider2D>().enabled = true;
            //appear = true;
            ScenaryController.instance.roomToShop = false;
        }
        else if(appear)
        {
            GetComponent<Collider2D>().enabled = false;
            appear = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && canUse)
        {
            collision.transform.position = shoopDoor.transform.position;
            StartCoroutine(MovePlayer(collision.gameObject));
            GetComponent<Collider2D>().enabled = false;
            ScenaryController.instance.ShopRoom(doorType,shoopDoor.transform.position);
            appear = true;

        }
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
