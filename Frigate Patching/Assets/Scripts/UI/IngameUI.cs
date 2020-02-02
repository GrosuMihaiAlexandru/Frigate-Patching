using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    public Image health;
    public Image bossHealth;
    public Text collectedCoins;

    public GameObject bossHealthObject;

    public GameObject gameOverScreen;

    void Awake()
    {
        GameEvents.OnPlayerHealthChanged += UpdateHealthBar;
        GameEvents.OnItemCollected += CollectCoins;
        GameEvents.OnDragonSpawn += DisplayDragonHealth;
        GameEvents.OnDragonHealthChanged += UpdateDragonHealth;
        GameEvents.OnDragonDefeat += HideDragonHealth;
        GameEvents.OnPlayerDeath += DisplayGameOver;
    }

    public void OnDestroy()
    {
        GameEvents.OnPlayerHealthChanged -= UpdateHealthBar;
        GameEvents.OnItemCollected -= CollectCoins;
        GameEvents.OnDragonSpawn -= DisplayDragonHealth;
        GameEvents.OnDragonHealthChanged -= UpdateDragonHealth;
        GameEvents.OnDragonDefeat -= HideDragonHealth;
        GameEvents.OnPlayerDeath -= DisplayGameOver;

    }

    public void DisplayGameOver(Player player)
    {
        gameOverScreen.SetActive(true);
    }

    public void DisplayDragonHealth(Dragon dragon)
    {
        bossHealthObject.SetActive(true);
        bossHealth.fillAmount = ReMap(dragon.health, 0, 100, 0, 1);
    }

    public void UpdateDragonHealth(Dragon dragon)
    {
        bossHealth.fillAmount = ReMap(dragon.health, 0, 100, 0, 1);
    }

    public void HideDragonHealth(Dragon dragon)
    {
        bossHealthObject.SetActive(false);
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
        health.fillAmount = ReMap(player.health, 0, player.CalculateTotalHealth(), 0, 1);
    }

    private float ReMap(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
