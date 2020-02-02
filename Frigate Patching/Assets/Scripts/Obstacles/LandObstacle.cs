using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandObstacle : MonoBehaviour
{
    public float Damage { get; set; } = 10f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            DamagePlayer(player);
        }
    }

    public void DamagePlayer(Player player)
    {
        player.TakeDamage(Damage);
        player.MakePlayerInvincible(1f);
    }

}
