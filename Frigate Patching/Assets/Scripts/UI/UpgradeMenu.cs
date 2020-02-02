using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public Button upgradeDurability;
    public Button upgradeWeapon;
    public Button upgradeResistance;

    public Text durabilityLevel;
    public Text weaponLevel;
    public Text resistanceLevel;

    public Text durabilityUpgradePrice;
    public Text weaponUpgradePrice;
    public Text resistanceUpgradePrice;

    public Text coins;

    void Start()
    {
        UpdateLevelDisplay();
    }

    public void UpgradeDurability()
    {
        PlayerStats.Instance.UpgradeDurability();
        UpdateLevelDisplay();
    }

    public void UpgradeWeapon()
    {
        PlayerStats.Instance.UpgradeWeapon();
        UpdateLevelDisplay();
    }

    public void UpgradeResistance()
    {
        PlayerStats.Instance.UpgradeResistance();
        UpdateLevelDisplay();
    }

    public void UpdateLevelDisplay()
    {
        coins.text = GameManager.Instance.coins.ToString();

        if (PlayerStats.Instance.durabilityLevel == PlayerStats.Instance.maxLevel)
        {
            durabilityLevel.text = "Max";
            durabilityUpgradePrice.text = "Upgrade Durability\nCost:";
        }
        else
        {
            durabilityLevel.text = PlayerStats.Instance.durabilityLevel.ToString();
            durabilityUpgradePrice.text = "Upgrade Durability\nCost: " + PlayerStats.Instance.CalculateDurabilityPrice().ToString();
        }

        if (PlayerStats.Instance.weaponLevel == PlayerStats.Instance.maxLevel)
        {
            weaponLevel.text = "Max";
            weaponUpgradePrice.text = "Upgrade Weapon\nCost:";

        }
        else
        {
            weaponLevel.text = PlayerStats.Instance.weaponLevel.ToString();
            weaponUpgradePrice.text = "Upgrade Weapon\nCost: " + PlayerStats.Instance.CalculateWeaponPrice().ToString();
        }

        if (PlayerStats.Instance.resistanceLevel == PlayerStats.Instance.maxLevel)
        {
            resistanceLevel.text = "Max";
            resistanceUpgradePrice.text = "Upgrade Durability\nCost:";

        }
        else
        {
            resistanceLevel.text = PlayerStats.Instance.resistanceLevel.ToString();
            resistanceUpgradePrice.text = "Upgrade Resistance\nCost: " + PlayerStats.Instance.CalculateResistancePrice().ToString();
        }

    }
}
