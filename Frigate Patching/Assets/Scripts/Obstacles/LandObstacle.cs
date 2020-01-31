using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandObstacle : MonoBehaviour, IEnemy
{
    public float Damage { get; set; } = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

        }
    }

    public void DamagePlayer(Player player)
    {
        
    }

}
