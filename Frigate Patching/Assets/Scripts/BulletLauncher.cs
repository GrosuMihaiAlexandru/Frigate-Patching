using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour
{
    public GameObject bulletPrefab;

    public void FireBullet(Vector2 spawnLocation)
    {
        Instantiate(bulletPrefab, spawnLocation, Quaternion.identity);
    }
}
