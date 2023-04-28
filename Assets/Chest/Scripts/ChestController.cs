using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{

    int stars;
    [SerializeField] int maxAmount;
    [SerializeField] int minAmount;
    bool isTriggered=false;
    [SerializeField] Sprite openSprite;
    public int GetStars { get { return stars; } }
    private void Start()
    {
        stars = Random.Range(minAmount, maxAmount);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTriggered)
        {
            //quiero que las estrellas de este objeto, se sumen a las estrellas del player
            collision.GetComponent<PlayerInventory>().playerItems["Coins"]+=stars;
            isTriggered = true;
            StartCoroutine(ChestOpen());
        }
    }

    IEnumerator ChestOpen()
    {
        GetComponent<SpriteRenderer>().sprite = openSprite;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
