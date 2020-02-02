using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShip : MonoBehaviour, IEnemy
{
    public float damage = 35f;
    public float flySpeed = 12;
    public float autoDestroyTime = 3f;

    void Start()
    {
        Invoke("AutoDestroy", autoDestroyTime);
    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * flySpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            DamagePlayer(player);
        }
    }

    public void DamagePlayer(Player player)
    {
        player.TakeDamage(damage);
        player.MakePlayerInvincible(1f);
    }

    void AutoDestroy()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(Cannonball cannonball)
    {
        Destroy(gameObject);
    }
}
