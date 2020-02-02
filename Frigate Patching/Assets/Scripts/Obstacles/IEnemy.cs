using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void DamagePlayer(Player player);

    void TakeDamage(Cannonball cannonball);

}
