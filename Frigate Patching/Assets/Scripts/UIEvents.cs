using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIEvents : MonoBehaviour
{
    public static Action<Player> OnPlayerTakeDamage;

    public static void PlayerTakeDamage(Player player)
    {
        if (OnPlayerTakeDamage != null)
        {
            OnPlayerTakeDamage(player);
        }

    }
}
