using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour, IEnemy
{
    public float damage = 30f;
    public float speed = 8;
    public float autoDestroyTime = 3f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        Invoke("AutoDestroy", autoDestroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            DamagePlayer(player);
        }
    }

    void AutoDestroy()
    {
        Destroy(gameObject);
    }

    public void DamagePlayer(Player player)
    {
        Destroy(gameObject);
        player.TakeDamage(damage);
        player.MakePlayerInvincible(1f);
    }
}
