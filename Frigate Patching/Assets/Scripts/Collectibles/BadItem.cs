using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadItem : MonoBehaviour, ICollectible
{
    public float value = 25;
    Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();
            Collect();
        }
    }

    public void Collect()
    {
        Destroy(gameObject);
        player.TakeDamage(value);
        player.MakePlayerInvincible(1f);
        GameEvents.PlayerUpdateHealth(player);
    }
}
