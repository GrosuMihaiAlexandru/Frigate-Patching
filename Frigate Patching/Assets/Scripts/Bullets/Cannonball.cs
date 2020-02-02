using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float damage = 20f;
    public float speed = 8;
    public float autoDestroyTime = 3f;

    public float damagePerLevel = 2;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Invoke("AutoDestroy", autoDestroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            IEnemy enemy = collision.gameObject.GetComponent<IEnemy>();
            DamageEnemy(enemy);
        }
    }

    void AutoDestroy()
    {
        Destroy(gameObject);
    }

    public void DamageEnemy(IEnemy enemy)
    {
        Destroy(gameObject);
        enemy.TakeDamage(this);
    }

    public float CalculateDamage()
    {
        return damage + damagePerLevel * PlayerStats.Instance.weaponLevel;
    }
}
