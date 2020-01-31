using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;

    public float moveSpeed;
    public float fireSpeed;

    public bool isPlayerInvincible;

    void Start()
    {
        
    }

    public void TakeDamage(float amount)
    {
        if (!isPlayerInvincible)
        {
            if (health - amount < 0)
            {
                Die();
            }
            else
            {
                health -= amount;
                UIEvents.PlayerTakeDamage(this);
            }
        }
    }

    public void Die()
    {
        Debug.Log("dead");
    }

    public void MakePlayerInvincible(float time)
    {
        if (!isPlayerInvincible)
        {
            isPlayerInvincible = true;
            //StartCoroutine(Blink());
            Invoke("MakePlayerVulnerable", time);
        }
    }

    private void MakePlayerVulnerable()
    {
        isPlayerInvincible = false;
    }

}
