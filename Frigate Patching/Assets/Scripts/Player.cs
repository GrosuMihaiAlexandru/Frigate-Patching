using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100f;

    public float moveSpeed;
    public float fireSpeed;

    public bool isPlayerInvincible;
    public bool isPlayerAlive;

    void Start()
    {
        isPlayerAlive = true;
        StartCoroutine(AutoDamage());
    }

    public void Heal(float amount)
    {
        health += amount;

        if (health > 100)
        {
            health = 100;
        }
    }

    public void TakeDamage(float amount)
    {
        if (!isPlayerInvincible)
        {
            if (health - amount < 0)
            {
                health = 0;
                Die();
                GameEvents.PlayerUpdateHealth(this);
            }
            else
            {
                health -= amount;
                GameEvents.PlayerUpdateHealth(this);
            }
        }
    }

    public void Die()
    {
        isPlayerAlive = false;
        Debug.Log("dead");
    }

    public void MakePlayerInvincible(float time)
    {
        if (!isPlayerInvincible)
        {
            isPlayerInvincible = true;
            StartCoroutine(Blinking());
            Invoke("MakePlayerVulnerable", time);
        }
    }

    private void MakePlayerVulnerable()
    {
        isPlayerInvincible = false;
    }

    private IEnumerator Blinking()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        while (isPlayerInvincible)
        {
            renderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            renderer.enabled = true;
            yield return new WaitForSeconds(0.2f);  
        }
    }

    private IEnumerator AutoDamage()
    {
        while (isPlayerAlive)
        {
            TakeDamage(1);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
