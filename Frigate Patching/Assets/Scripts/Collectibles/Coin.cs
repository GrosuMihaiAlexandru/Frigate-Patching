using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{

    public int value = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Collect();
        }
    }

    public void Collect()
    {
        Destroy(gameObject);
        GameManager.Instance.CollectCoins(value);
        GameEvents.ItemCollected(this);
    }
}
