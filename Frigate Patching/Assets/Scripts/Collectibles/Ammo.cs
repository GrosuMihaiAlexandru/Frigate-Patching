using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            Collect();
        }
    }

    private void Collect()
    {
        Destroy(gameObject);
        GameEvents.AmmoPickup();
    }
}
