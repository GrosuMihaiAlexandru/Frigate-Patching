using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour, IEnemy
{
    public float health = 100f;

    private BulletLauncher launcher;
    private Animator animator;

    public float damage = 50f;
    public float flySpeed = 2;
    public float screenLimitY;

    public float fireballWaitTime = 5f;

    private bool flyingUp;
    private bool isAlive;

    public Transform fireballSpawnPos;

    public static float nextDragonSpeed;
    public static float nextDragonFireBall;
    public static float nextDragonHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            DamagePlayer(player);
        }
    }

    void Awake()
    {
        launcher = GetComponent<BulletLauncher>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        isAlive = true;
        StartCoroutine(ShootFireball());
        StartCoroutine(AutoDamage());
        GameEvents.DragonSpawn(this);
        flySpeed = nextDragonSpeed;
        fireballWaitTime = nextDragonFireBall;
        health = nextDragonHealth;
    }

    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * GameManager.Instance.gameSpeed;
        if (flyingUp)
        {
            transform.position += Vector3.up * Time.deltaTime * flySpeed;
            if (transform.position.y - screenLimitY > 0)
                flyingUp = false;
        }
        else
        {
            transform.position += Vector3.down* Time.deltaTime* flySpeed;
            if (transform.position.y + screenLimitY < 0)
                flyingUp = true;
        }
    }

    public void TakeDamage(Cannonball cannonball)
    {
        health -= cannonball.CalculateDamage();
    }

    public void DamagePlayer(Player player)
    {
        player.TakeDamage(damage);
        player.MakePlayerInvincible(1f);
    }

    private IEnumerator AutoDamage()
    {
        while (isAlive)
        {
            TakeDamage(1);
            yield return new WaitForSeconds(0.3f);
        }
    }

    private IEnumerator ShootFireball()
    {
        while(isAlive)
        {
            yield return new WaitForSeconds(fireballWaitTime);
            animator.SetBool("ShootFireball", true);
            yield return new WaitForSeconds(0.5f);
            launcher.FireBullet(fireballSpawnPos.position);
            animator.SetBool("ShootFireball", false);
        }
        
    }

    public void TakeDamage(float amount)
    {
        if (health - amount < 0)
        {
            health = 0;
            isAlive = false;
            GameEvents.DragonDefeated(this);
            screenLimitY = 10f;
            Invoke("AutoDestroy", 2.5f);
            flySpeed = 5f;
            if (nextDragonSpeed < 8)
                nextDragonSpeed += 1f;
            if (nextDragonFireBall > 0.5)
                nextDragonFireBall -= 0.25f;
            if (nextDragonHealth < 200)
                nextDragonHealth += 20;
        }
        else
        {
            health -= amount;
            GameEvents.DragonUpdateHealth(this);
        }
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }
}
