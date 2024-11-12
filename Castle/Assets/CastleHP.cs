using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleHP : MonoBehaviour
{
    void UseBasicShield()
    {
        if (gameObject.GetComponent<BasicShield>() != null && DividerShield != GetComponent<DividerShield>())
        {
            return;
        }

        Destroy(gameObject.AddComponent<BasicShield>());
        shield = gameObject.AddComponent<DividerShield>();
    }
    void UseDividerShield()
    {
        if (gameObject.GetComponent<DividerShield>() != null) ;
        {
            return;
        }
        Destroy(GetComponent<BasicShield>());
        shield =  gameObject.AddComponent<DividerShield>();
    }
}
