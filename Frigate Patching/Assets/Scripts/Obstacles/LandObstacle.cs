using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandObstacle : MonoBehaviour
{
    public float Damage { get; set; } = 20f;

    public bool isLightning;

    bool played;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered");
        if (collision.tag == "Player" && !played)
        {
            played = true;
            StartCoroutine(Delay());
            if (isLightning)
                AudioPlayer.Instance.PlayLightning();
            else
                AudioPlayer.Instance.PlayCrash();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            DamagePlayer(player);
        }
    }

    public void DamagePlayer(Player player)
    {
        player.TakeDamage(Damage);
        player.MakePlayerInvincible(1f);
        
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        played = false;
    }

}
