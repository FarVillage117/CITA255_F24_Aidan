using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    Vector3 GetMouseWprldPosition()
    {
        Vector3 result = Input.mousePosition;
        result.z = Camera.main.WorldToScreenPoint(transform.position).z;
        result = Camera.main.ScreenToWorldPoint(result);
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = GetMouseWprldPosition();
            Collider2D collider = Physics2D.OverlapPoint(mousePos);
            if (collider != null)
            {
                if (Collider2D.TryGetComponent(out IInteract interact))
                {
                    interact.Interact();
                }
            }
        }
    }
}
