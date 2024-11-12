using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player player = new Player();
        Health playerHealth = new Health(player);
        player.Damage();
    }
}
