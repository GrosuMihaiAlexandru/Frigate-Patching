using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour, ICollectible
{
    public float value = 25;
    private Player player;
    private Animator animator;


    void Awake()
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
        animator.SetBool("Used", true);
        player.Heal(value);
        GameEvents.PlayerUpdateHealth(player);
    }
}
