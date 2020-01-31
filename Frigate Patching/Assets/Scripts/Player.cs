using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;

    public float moveSpeed;
    public float fireSpeed;

    void Start()
    {
        
    }

    public void TakeDamage(float amount)
    {
        if (health - amount < 0)
        {
            Die();
        }
        else
        {
            health -= amount;
        }
    }

    public void Die()
    {

    }

}
