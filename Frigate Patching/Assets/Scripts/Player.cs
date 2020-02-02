using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    public float baseHealth = 100;
    public float healthPerLevel = 20;

    public float damageDecreasePerLevel = 2;

    public float moveSpeed;

    public bool isPlayerInvincible;
    public bool isPlayerAlive;

    public int maxAmmo = 5;
    public int ammo;
    public float damage;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        GameEvents.OnAmmoPickup += AddAmmo;
        health = CalculateTotalHealth();
        isPlayerAlive = true;
        StartCoroutine(AutoDamage());
    }

    void OnDestroy()
    {
        GameEvents.OnAmmoPickup -= AddAmmo;
    }

    public void Heal(float amount)
    {
        health += amount;

        if (health > CalculateTotalHealth())
        {
            health = CalculateTotalHealth();
        }

        if (health >= CalculateTotalHealth() / 2)
        {
            animator.SetBool("Damaged", false);
        }
    }

    public void TakeDamage(float value)
    {
        if (!isPlayerInvincible)
        {
            if (health - CalculateDamageTaken(value) < 0)
            {
                health = 0;
                Die();
                GameEvents.PlayerUpdateHealth(this);
            }
            else
            {
                health -= CalculateDamageTaken(value);
                GameEvents.PlayerUpdateHealth(this);
            }
        }
        if (health < CalculateTotalHealth() / 2)
        {
            animator.SetBool("Damaged", true);
        }
    }

    public void Die()
    {
        isPlayerAlive = false;
        Destroy(gameObject);
        GameEvents.PlayerDied(this);
        Debug.Log("dead");
    }

    public void MakePlayerInvincible(float time)
    {
        if (!isPlayerInvincible)
        {
            moveSpeed /= 2.5f;
            isPlayerInvincible = true;
            StartCoroutine(Blinking());
            Invoke("MakePlayerVulnerable", time);
        }
    }

    private void MakePlayerVulnerable()
    {
        moveSpeed *= 2.5f;
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
            TakeDamage(damageDecreasePerLevel * PlayerStats.Instance.resistanceLevel + 1);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public float CalculateTotalHealth()
    {
        return baseHealth + healthPerLevel * PlayerStats.Instance.durabilityLevel;
    }

    public float CalculateDamageTaken(float value)
    {
        return value - damageDecreasePerLevel * PlayerStats.Instance.resistanceLevel;
    }

    private void AddAmmo()
    {
        if (ammo < maxAmmo)
            ammo++;
    }
}
