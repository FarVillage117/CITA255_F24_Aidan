using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DoSomething
{
    public int Damage { get; set; }

    public void DoSomething()
    { 
        Damage = 2;
        Debug.Log(" Player Damage" + Damage);
    }

    /*
    int playerHp;
    public int playerHp
    {
        get { return playerHp; }
        set { playerHp = value; }
    }
    public string PlayerName { get; set; }
    */

}
