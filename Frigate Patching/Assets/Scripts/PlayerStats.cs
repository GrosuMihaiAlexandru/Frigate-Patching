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
        if (GameManager.Instance.coins > CalculateDurabilityPrice())
        {
            if (durabilityLevel < maxLevel)
            {
                GameManager.Instance.RemoveCoins((int)(CalculateDurabilityPrice()));
                durabilityLevel++;
            }
        }
    }

    public void UpgradeWeapon()
    {
        if (GameManager.Instance.coins > CalculateWeaponPrice())
        {
            if (weaponLevel < maxLevel)
            {
                GameManager.Instance.RemoveCoins((int)CalculateWeaponPrice());
                weaponLevel++;
            }
        }
    }

    public void UpgradeResistance()
    {
        if (GameManager.Instance.coins > CalculateResistancePrice())
        {
            if (resistanceLevel < maxLevel)
            {
                GameManager.Instance.RemoveCoins((int)(CalculateResistancePrice()));
                resistanceLevel++;
            }
        }
    }

    public float CalculateDurabilityPrice()
    {
        return basePrice * Mathf.Pow(priceMultiplier, durabilityLevel);
    }

    public float CalculateWeaponPrice()
    {
        return basePrice * Mathf.Pow(priceMultiplier, weaponLevel);
    }

    public float CalculateResistancePrice()
    {
        return basePrice * Mathf.Pow(priceMultiplier, resistanceLevel);
    }
}
