using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static Action<Player> OnPlayerHealthChanged;

    public static Action<ICollectible> OnItemCollected;

    public static void PlayerUpdateHealth(Player player)
    {
        if (OnPlayerHealthChanged != null)
        {
            OnPlayerHealthChanged(player);
        }

    }

    public static void ItemCollected(ICollectible collectible)
    {
        if (OnItemCollected != null)
        {
            OnItemCollected(collectible);
        }
    }
}
