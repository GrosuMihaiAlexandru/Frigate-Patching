﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    int Damage { get; set; }

    void DamagePlayer(Player player);

}
