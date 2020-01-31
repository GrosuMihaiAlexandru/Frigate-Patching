using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour
{
    public Image health;

    void Start()
    {
        UIEvents.OnPlayerTakeDamage += UpdateHealthBar;
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
