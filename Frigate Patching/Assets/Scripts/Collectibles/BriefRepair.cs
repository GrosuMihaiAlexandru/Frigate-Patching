using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefRepair : MonoBehaviour, ICollectible
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
        player.Heal(value);
        GameEvents.PlayerUpdateHealth(player);
    }
}
