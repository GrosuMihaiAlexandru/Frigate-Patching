﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static Action<Player> OnPlayerHealthChanged;

    public static Action<ICollectible> OnItemCollected;

    public static Action<Dragon> OnDragonSpawn;
    public static Action<Dragon> OnDragonHealthChanged;
    public static Action<Dragon> OnDragonDefeat;

    public static Action<Player> OnPlayerDeath;

    public static Action OnAmmoPickup;

    public static Action OnFireAction;

    public static void FireAction()
    {
        if (OnFireAction != null)
        {
            OnFireAction();
        }
    }

    public static void AmmoPickup()
    {
        if (OnAmmoPickup != null)
        {
            OnAmmoPickup();
        }
    }

    public static void PlayerUpdateHealth(Player player)
    {
        if (OnPlayerHealthChanged != null)
        {
            OnPlayerHealthChanged(player);
        }

    }

    public static void PlayerDied(Player player)
    {
        if (OnPlayerDeath != null)
        {
            OnPlayerDeath(player);
        }
    }

    public static void ItemCollected(ICollectible collectible)
    {
        if (OnItemCollected != null)
        {
            OnItemCollected(collectible);
        }
    }

    public static void DragonSpawn(Dragon dragon)
    {
        if (OnItemCollected != null)
        {
            OnDragonSpawn(dragon);
        }
    }

    public static void DragonUpdateHealth(Dragon dragon)
    {
        if (OnDragonHealthChanged != null)
        {
            OnDragonHealthChanged(dragon);
        }
    }

    public static void DragonDefeated(Dragon dragon)
    {
        if (OnDragonDefeat != null)
        {
            OnDragonDefeat(dragon);
        }
    }
}
