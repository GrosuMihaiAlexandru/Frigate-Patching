using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAmmo : MonoBehaviour
{
    public GameObject ammoDisplayPrefab;

    private List<GameObject> cannonBalls = new List<GameObject>();

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        GameEvents.OnAmmoPickup += AddAmmo;
        GameEvents.OnFireAction += RemoveAmmo;

        for (int i = 0; i < player.ammo; i++)
        {
            GameObject cannonBall = Instantiate(ammoDisplayPrefab);
            cannonBall.transform.SetParent(transform);
            cannonBalls.Add(cannonBall);
            cannonBall.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("Created sammo");
        }
    }

    private void OnDestroy()
    {
        GameEvents.OnAmmoPickup -= AddAmmo;
        GameEvents.OnFireAction -= RemoveAmmo;
    }

    private void AddAmmo()
    {
        if (player.ammo < player.maxAmmo)
        {
            GameObject cannonBall = Instantiate(ammoDisplayPrefab);
            cannonBall.transform.SetParent(transform);
            cannonBalls.Add(cannonBall);
            cannonBall.transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("Created ammo");
        }
    }

    private void RemoveAmmo()
    {
        if (player.ammo > 0)
        {
            GameObject cannonBall = cannonBalls[0];
            cannonBalls.Remove(cannonBall);
            Destroy(cannonBall);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
