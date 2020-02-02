using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadItem : MonoBehaviour, ICollectible
{
    public float value = 25;
    Player player;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = collision.gameObject.GetComponent<Player>();
            Collect();
        }
    }

    public void Collect()
    {
        animator.SetBool("Explode", true);
        Invoke("DestroyObject", 1f);
        player.TakeDamage(value);
        player.MakePlayerInvincible(1f);
        GameEvents.PlayerUpdateHealth(player);
        AudioPlayer.Instance.PlayExplosion();
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
