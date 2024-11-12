using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public Health()
    {

    }
    public Health(Player player)
    {
        player.OnPlayerDamaged += Player_OnPlayerDamaged;
    }
    private void Player_OnPlayerDamaged()
    {
        
    }
    public void Unsubscribe(Player player)
    {
        player.OnPlayerDamaged -= Player_OnPlayerDamaged;
    }

}
