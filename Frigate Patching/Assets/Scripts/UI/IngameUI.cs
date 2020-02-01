using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    public Image health;
    public Image bossHealth;
    public Text collectedCoins;

    void Start()
    {
        GameEvents.OnPlayerHealthChanged += UpdateHealthBar;
        GameEvents.OnItemCollected += CollectCoins;
        GameEvents.OnDragonSpawn += DisplayDragonHealth;
    }

    public void DisplayDragonHealth(Dragon dragon)
    {
        bossHealth.enabled = true;
        bossHealth.fillAmount = ReMap(dragon.Health, 0, 100, 0, 1);
    }

    public void CollectCoins(ICollectible collectible)
    {
        if (collectible is Coin)
        {
            collectedCoins.text = "Coins: " + GameManager.Instance.collectedCoins;
        }
    }

    public void UpdateHealthBar(Player player)
    {
        health.fillAmount = ReMap(player.health, 0, 100, 0, 1);
    }

    private float ReMap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
