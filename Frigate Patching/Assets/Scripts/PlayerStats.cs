using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public enum Type { durability, weapon, resistance}

    public int durabilityLevel = 1;
    public int weaponLevel = 1;
    public int resistanceLevel = 1;

    public int basePrice;

    public int maxLevel = 5;
    public float priceMultiplier = 1.5f;

    public void UpgradeDurability()
    {
        if (GameManager.Instance.coins > basePrice * Mathf.Pow(priceMultiplier, durabilityLevel))
        {
            GameManager.Instance.RemoveCoins((int)(basePrice * Mathf.Pow(priceMultiplier, durabilityLevel)));
            durabilityLevel++;
        }
    }

    public void UpgradeWeapon()
    {
        if (GameManager.Instance.coins > basePrice * Mathf.Pow(priceMultiplier, weaponLevel))
        {
            GameManager.Instance.RemoveCoins((int)(basePrice * Mathf.Pow(priceMultiplier, weaponLevel)));
            weaponLevel++;
        }
    }

    public void UpgradeResistance()
    {
        if (GameManager.Instance.coins > basePrice * Mathf.Pow(priceMultiplier, resistanceLevel))
        {
            GameManager.Instance.RemoveCoins((int)(basePrice * Mathf.Pow(priceMultiplier, resistanceLevel)));
            resistanceLevel++;
        }
    }
}
