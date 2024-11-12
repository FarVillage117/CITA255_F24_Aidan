using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public event Action OnPlayerDamaged;
    public void Damage()
    {
        OnPlayerDamaged?.Invoke();
    }
}
