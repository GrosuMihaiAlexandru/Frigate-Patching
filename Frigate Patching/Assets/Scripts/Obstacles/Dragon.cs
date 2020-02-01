using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour, IEnemy
{
    public float Health = 100f;

    private BulletLauncher launcher;
    private Animator animator;

    public float damage = 50f;
    public float flySpeed = 2;
    public float screenLimitY;

    public float fireballWaitTime = 5f;

    private bool flyingUp;

    public Transform fireballSpawnPos;


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
        StartCoroutine(ShootFireball());
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

    public void DamagePlayer(Player player)
    {
        player.TakeDamage(damage);
        player.MakePlayerInvincible(1f);
    }

    private IEnumerator ShootFireball()
    {
        while(true)
        {
            yield return new WaitForSeconds(fireballWaitTime);
            animator.SetBool("ShootFireball", true);
            yield return new WaitForSeconds(0.5f);
            launcher.FireBullet(fireballSpawnPos.position);
            animator.SetBool("ShootFireball", false);
        }
        
    }
}
