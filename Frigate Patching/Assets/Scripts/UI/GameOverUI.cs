using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{

    public Text text;

    void Start()
    {
        GameEvents.OnPlayerDeath += UpdateText;
    }

    private void OnDestroy()
    {
        GameEvents.OnPlayerDeath -= UpdateText;
    }

    public void UpdateText(Player player)
    {
        text.text = "Collected coins: " + GameManager.Instance.collectedCoins.ToString();
    }
}
