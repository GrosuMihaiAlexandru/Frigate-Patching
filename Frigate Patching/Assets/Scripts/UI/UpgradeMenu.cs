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

    void Start()
    {
        durabilityLevel.text = PlayerStats.Instance.durabilityLevel.ToString();
        weaponLevel.text = PlayerStats.Instance.weaponLevel.ToString();
        resistanceLevel.text = PlayerStats.Instance.resistanceLevel.ToString();
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
        durabilityLevel.text = PlayerStats.Instance.durabilityLevel.ToString();
        weaponLevel.text = PlayerStats.Instance.weaponLevel.ToString();
        resistanceLevel.text = PlayerStats.Instance.resistanceLevel.ToString();
    }
}
