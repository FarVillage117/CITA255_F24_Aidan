using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Polymorphism
        //DoSomething player = new Player();
        //player.DoSomething();
        //IAttack player = new Player();
        //player.Attack();
        AttackObject(new Player());
        AttackObjectIAttack(new Enemy());

    }
    void AttackObjectIAttack iAttack)
    {
        iAttack.Attack();
    }
}
