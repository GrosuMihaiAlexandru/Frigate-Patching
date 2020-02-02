using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighthouse : MonoBehaviour, ICollectible
{
    private Player player;
    private Animator animator;

    public bool used;
    void Awake()
    {
        animator = GetComponent<Animator>();
        used = false;
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
        if (!used)
        {
            used = true;
            animator.SetBool("Used", true);
            player.Heal(player.CalculateTotalHealth());
            GameEvents.PlayerUpdateHealth(player);
            AudioPlayer.Instance.PlayRepair();
        }
    }
}
